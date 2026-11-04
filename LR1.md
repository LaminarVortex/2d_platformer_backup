# Лабораторная работа № 1

**Тема:** Автоматизация сборки 2D игры через командную строку (CLI)

**Репозиторий:** https://github.com/LaminarVortex/ARPO_Lab1/

---

## Шаг 1. Запуск проекта

Открыт проект 2D Platformer Microgame в Unity 6.3 LTS (6000.3.2f1). Проверено, что сцена `SampleScene` открывается и проект работает в редакторе.

![Запуск проекта](Docs/LR1_01_project_run.png)

## Шаг 2. Создание скрипта сборщика

В папке `Assets/Editor` создан статический класс `BuildManager` с методом `BuildWebGL()`. Метод:

1. получает список сцен, включённых в Build Settings;
2. запускает сборку под платформу WebGL в папку `Builds/WebGL`;
3. выводит в лог результат сборки (`[CI/CD] УСПЕХ!`), время сборки и размер билда;
4. завершает работу редактора с кодом `0` при успехе и ненулевым кодом при ошибке, чтобы результат можно было использовать в CI/CD.

![Создание скрипта сборщика](Docs/LR1_02_build_manager.png)

## Шаг 3. Отключение сжатия для WebGL

В `Project Settings → Player → Publishing Settings` параметр **Compression Format** установлен в значение **Disabled**, чтобы билд можно было раздавать любым простым веб-сервером.

![Отключение сжатия для WebGL](Docs/LR1_03_compression_disabled.png)

## Шаг 4. Запуск сборки из командной строки

Сборка запускается в режиме `batchmode` с вызовом статического метода и записью лога в файл `build_webgl.txt`:

```
"<путь к Unity.exe>" -batchmode -quit -projectPath "<путь к проекту>" -executeMethod BuildManager.BuildWebGL -logFile build_webgl.txt
```

В логе присутствует сообщение об успешной сборке. Время сборки составило 861,84 сек., размер — 64 761 582 байт.

![Успешная сборка проекта](Docs/LR1_04_build_log.png)

## Шаг 5. Проверка файлов билда

В папке `Builds/WebGL` появились файлы билда: `Build`, `TemplateData`, `index.html` и служебные файлы.

![Файлы билда](Docs/LR1_05_build_files.png)

## Шаг 6. Запуск игры в браузере

Билд запущен через локальный веб-сервер (`localhost:3000`). Игра загрузилась и работает в браузере.

![Успешный запуск игры в браузере](Docs/LR1_06_browser_run.png)

## Шаг 7. Создание .gitignore

Создан файл `.gitignore` для проекта Unity, чтобы в репозиторий не попадали временные и генерируемые папки (`Library`, `Temp`, `Logs`, `obj`, `UserSettings`, `Builds` и т.д.).

![Созданный .gitignore](Docs/LR1_07_gitignore.png)

## Шаг 8. Инициализация репозитория

В папке проекта выполнена команда:

```
git init
```

![Инициализация репозитория](Docs/LR1_08_git_init.png)

## Шаг 9. Создание главной ветки и добавление файлов

Основная ветка переименована в `main`, все файлы проекта добавлены в индекс:

```
git branch -M main
git add .
```

Предупреждения о замене LF на CRLF не являются ошибками и связаны с особенностями Windows.

![Создание главной ветки и добавление файлов](Docs/LR1_09_git_add.png)

## Шаг 10. Создание коммита

```
git commit -m "chore: initializing a 2D Platformer Microgame project"
```

![Создание коммита](Docs/LR1_10_git_commit.png)

## Шаг 11. Привязка к удалённому репозиторию

```
git remote add origin https://github.com/LaminarVortex/ARPO_Lab1.git
```

![Привязка к удалённому репозиторию](Docs/LR1_11_git_remote.png)

## Шаг 12. Отправка ветки main

```
git push -u origin main
```

![Отправка ветки](Docs/LR1_12_git_push_main.png)

## Шаг 13. Новая ветка LR1 и добавление BuildManager

Для работы создана отдельная ветка `LR1`, в неё добавлен скрипт сборщика:

```
git checkout -b LR1
git add Assets/Editor/
git commit -m "feat: added BuildManager script for build automation"
git push -u origin LR1
```

![Переключение на новую ветку и добавление BuildManager](Docs/LR1_13_branch_lr1.png)

## Шаг 14. Добавление README.md

```
git add README.md
git commit -m "docs: Lab report #1 added"
git push origin LR1
```

![Добавление README.md](Docs/LR1_14_readme.png)

## Шаг 15. Pull request и получение аппрувов

Создан pull request из ветки `LR1` в `main`. Запрошено ревью у двух проверяющих, оба одобрили изменения (Approved) и оставили комментарии.

![Получение аппрувов от ревьюверов](Docs/LR1_15_pr_approves.png)

## Шаг 16. Объединение кода

После аппрувов pull request влит в ветку `main` (merge).

![Успешное объединение кода](Docs/LR1_16_pr_merged.png)

