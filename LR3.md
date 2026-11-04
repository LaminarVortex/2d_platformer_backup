# Лабораторная работа № 3

**Тема:** Контейнеризация веб-сервера в Docker и раздача сжатых файлов со стороны Nginx

**Репозиторий:** https://github.com/LaminarVortex/ARPO_Lab1

---

## Шаг 1. Настройка сборки со сжатием

В `Project Settings → Player → Publishing Settings` параметр **Compression Format** установлен в значение **Gzip** (в ЛР № 1 сжатие было отключено).

![Настройка сборки](Docs/LR3_01_compression_gzip.png)

## Шаг 2. Получение сжатых файлов

После пересборки WebGL-проекта в папке `Builds/WebGL/Build` получены сжатые файлы: `Build.data.gz`, `Build.framework.js.gz`, `Build.wasm.gz`, а также `Build.loader.js`, который не сжимается.

![Полученные файлы](Docs/LR3_02_build_files.png)

## Шаг 3. Создание файла nginx.conf

Стандартный Nginx не знает, что файлы `.gz` нужно отдавать с заголовком `Content-Encoding: gzip`, поэтому браузер не сможет их распаковать. Для этого создан собственный конфиг с правилами для `.js.gz`, `.wasm.gz` и `.data.gz`: для каждого добавляется заголовок `Content-Encoding: gzip` и задаётся корректный `Content-Type`.

```nginx
server {
    listen 80;
    server_name localhost;
    location / {
        root /usr/share/nginx/html;
        index index.html;
        try_files $uri $uri/ /index.html;

        # Правила для перехвата JavaScript-архивов Unity
        location ~* \.js\.gz$ {
            add_header Content-Encoding gzip;
            default_type application/javascript;
        }

        # Правила для перехвата бинарного кода WebAssembly
        location ~* \.wasm\.gz$ {
            add_header Content-Encoding gzip;
            default_type application/wasm;
        }

        # Правила для перехвата текстур и ресурсов игры
        location ~* \.data\.gz$ {
            add_header Content-Encoding gzip;
            default_type application/octet-stream;
        }
    }
}
```

![Создание файла nginx.conf](Docs/LR3_03_nginx_conf.png)

## Шаг 4. Создание файла Dockerfile

Dockerfile описывает образ на основе лёгкого Nginx (Alpine Linux):

```dockerfile
# Шаг 1: Берем официальный ультра-легкий веб-сервер Nginx на базе Alpine Linux
FROM nginx:alpine
# Шаг 2: Удаляем дефолтный файл настроек Nginx, блокирующий работу архивов
RUN rm /etc/nginx/conf.d/default.conf
# Шаг 3: Копирование кастомного nginx.conf внутрь системных папок сервера
COPY nginx.conf /etc/nginx/conf.d/
# Шаг 4: Очищаем стандартную веб-папку и копируем туда файлы сжатой игры из ЛР №1
RUN rm -rf /usr/share/nginx/html/*
COPY Builds/WebGL/ /usr/share/nginx/html/
# Шаг 5: Объявляем рабочий порт контейнера
EXPOSE 80
# Шаг 6: Запускаем Nginx в режиме постоянного процесса (демона)
CMD ["nginx", "-g", "daemon off;"]
```

![Создание файла Dockerfile](Docs/LR3_04_dockerfile.png)

## Шаг 5. Сборка образа игры

Образ собран командой:

```
docker build -t platformer-compressed:v1 .
```

С первой попытки сборка завершилась ошибкой тайм-аута при загрузке базового образа `nginx:alpine` с Docker Hub (проблема сети). Повторный запуск прошёл успешно, образ создан.

![Сборка образа игры](Docs/LR3_05_docker_build.png)

## Шаг 6. Запуск контейнера в фоновом режиме

```
docker run -d -p 8080:80 --name unity_compressed_container platformer-compressed:v1
```

Порт 8080 хоста проброшен на порт 80 контейнера.

![Запуск контейнера в фоновом режиме](Docs/LR3_06_docker_run.png)

## Шаг 7. Проверка загрузки игры

По адресу `http://localhost:8080` игра успешно загрузилась и запустилась в браузере.

![Успешная загрузка игры](Docs/LR3_07_game_loaded.png)

## Шаг 8. Проверка через инструменты разработчика

На вкладке **Network** в DevTools выбран файл `Build.wasm.gz`. Статус ответа — `200 OK`, в заголовках ответа присутствует `Content-Encoding: gzip`. Размер переданных данных за сессию — около 12,4 МБ. Это подтверждает, что Nginx корректно раздаёт сжатые файлы.

![Проверка через инструменты разработчика](Docs/LR3_08_devtools.png)

## Шаг 9. Остановка тестового контейнера

```
docker stop unity_compressed_container && docker rm unity_compressed_container
```

![Остановка тестового контейнера](Docs/LR3_09_docker_stop.png)

## Шаг 10. Добавление третьего этапа пайплайна

В `.github/workflows/main.yml` добавлена задача `build_docker_image`. Она:

1. запускается после `sanity_check` (`needs: sanity_check`);
2. получает разрешения `contents: read` и `packages: write` для публикации пакетов;
3. выполняет checkout кода;
4. создаёт временные пустые `.gz`-файлы и `index.html`, если папка `Builds/WebGL/Build` пуста (в репозиторий билд не попадает, а без него шаг `COPY` в Dockerfile упал бы);
5. входит в GitHub Container Registry (`ghcr.io`) через `docker/login-action` с автоматическим токеном `GITHUB_TOKEN`;
6. собирает образ и публикует его через `docker/build-push-action` (`push: true`).

![Добавление третьего этапа пайплайна с поддержкой GitHub Packages](Docs/LR3_10_workflow_docker_job.png)

## Шаг 11. Добавление новых файлов и изменение main.yml на GitHub

В репозиторий добавлены файлы `Dockerfile` и `nginx.conf`, а также обновлён `main.yml`.

![Добавление новых файлов и изменение main.yml на github](Docs/LR3_11_repo_files.png)

## Шаг 12. Успешное прохождение проверок

В pull request все три проверки завершились успешно: `sanity_check` (5 с), `mirror_repo` (11 с) и `build_docker_image` (24 с). Конфликтов с основной веткой нет.

![Успешное прохождение проверок](Docs/LR3_12_checks_passed.png)

## Шаг 13. Готовый пакет игры

В разделе Packages репозитория появился пакет `arpo_lab1` (публикация через GitHub Container Registry). Образ можно скачать командой, которую показывает GitHub:

```
docker pull ghcr.io/laminarvortex/arpo_lab1:<tag>
```

![Готовый пакет игры](Docs/LR3_13_package.png)

## Шаг 14. Заголовок Content-Encoding

В DevTools на вкладке Sources выполнен поиск по `Content-Encoding`. Найдено, что `Build.framework.js.gz` и `Build.loader.js` проверяют этот заголовок в ответе сервера. Если он отсутствует, загрузчик Unity выдаёт ошибку о неверной настройке сервера. Благодаря правилам в `nginx.conf` заголовок отдаётся, и игра загружается без ошибок.

![Заголовок Content-Encoding](Docs/LR3_14_content_encoding.png)
