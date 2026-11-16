| № | Название лабораторной работы | Отчёт |
|---|------------------------------|-------|
| 1 | Автоматизация сборки 2D игры через командную строку (CLI) | [LR1.md](LR1.md) |
| 2 | Настройка репозиториев на GitHub и базовая автоматическая проверка проекта (Sanity Check) | [LR2.md](LR2.md) |
| 3 | Контейнеризация веб-сервера в Docker и раздача сжатых файлов со стороны Nginx | [LR3.md](LR3.md) |
| 4 | Автоматизация тестирования (Unity Test Runner) в CI/CD | [LR4.md](LR4.md) |

### 1.1. Запуск проекта 
![Создание проекта](Docs/Start_Project.png)

### 1.2. Создание скрипта сборщика 
![Создание скрипта сборщика](Docs/Creating_Collector_Script.png)

### 1.3. Отключение сжатия для WebGL
Compression Format = Disabled.
![Отключение сжатия для WebGL](Docs/Disabling_Compression.png)

### 1.4. Успешная сборка проекта 
![Успешная сборка проекта](Docs/Successful_Build.png)

### 1.5. Файлы билда 
![Файлы билда ](Docs/Build_Files.png)

### 1.6. Успешный запуск игры в браузере
![Успешный запуск игры в браузере](Docs/Successful_Startup_In_Browser.png)

### 1.7. Созданный .gitignore
![Созданный .gitignore](Docs/Created_Gitignore.png)

### 1.8. Инициализация репозитория
![Инициализация репозитория](Docs/Initializing_Repository.png)

### 1.9. Создание главной ветки и добавление файлов 
![Создание главной ветки и добавление файлов](Docs/Creating_Main_Branch_And_Adding_Files.png)

### 1.10. Создание коммита 
![Создание коммита](Docs/Creating_First_Commit.png)

### 1.11. Привязка к удаленному репозиторию 
![Привязка к удаленному репозиторию ](Docs/Link_To_Remote_Repository.png)

### 1.12. Отправление ветки 
![Отправление ветки](Docs/Push_Main_Branch.png)

### 1.13. Переключение на новую ветку и добавление BuildManager 
![Переключение на новую ветку и добавление BuildManager](Docs/Swap_Branch_To_LR1_And_Adding_BuildManager.png)

### 1.14. Добавление README.md  
![Добавление README.md](Docs/Adding_README.png)

### 1.15. Получение аппрувов от ревьюверов 
![Получение аппрувов от ревьюверов](Docs/Collecting_Approve.png)

### 1.16. Успешное объединение кода 
![Успешное объединение кода](Docs/Successfull_Merge.png)

### 2.1 Создание нового репозитория
![Создание нового репозитория](Docs/Creating_New_Repository.png)

### 2.2 Сохранение токена в секреты проекта 
![Сохранение токена в секреты проекта](Docs/Save_Token.png)

### 2.3 Создание YAML файла 
![Создание YAML файла](Docs/Creating_YAML.png)

### 2.4 Отправка пайплайна на GitHub 
![Отправка пайплайна на GitHub](Docs/Push_Pipeline.png)

### 2.5 Успешное прохождение sanity_check и mirror_repo 
![Успешное прохождение sanity_check и mirror_repo](Docs/Successfull_Checks_Complete.png)

### 2.6 Резервный репозиторий 
![Резервный репозиторий](Docs/Backup_Repository.png)

### 3.1 Настройка сборки со сжатием

![Настройка сборки](Docs/LR3_01_compression_gzip.png)

### 3.2 Получение сжатых файлов

![Полученные файлы](Docs/LR3_02_build_files.png)

### 3.3 Создание файла nginx.conf

![Создание файла nginx.conf](Docs/LR3_03_nginx_conf.png)

### 3.4 Создание файла Dockerfile

![Создание файла Dockerfile](Docs/LR3_04_dockerfile.png)

### 3.5 Сборка образа игры

![Сборка образа игры](Docs/LR3_05_docker_build.png)

### 3.6 Запуск контейнера в фоновом режиме

![Запуск контейнера в фоновом режиме](Docs/LR3_06_docker_run.png)

### 3.7 Проверка загрузки игры

![Успешная загрузка игры](Docs/LR3_07_game_loaded.png)

### 3.8 Проверка через инструменты разработчика

![Проверка через инструменты разработчика](Docs/LR3_08_devtools.png)

### 3.9 Остановка тестового контейнера

![Остановка тестового контейнера](Docs/LR3_09_docker_stop.png)

### 3.10 Добавление третьего этапа пайплайна

![Добавление третьего этапа пайплайна с поддержкой GitHub Packages](Docs/LR3_10_workflow_docker_job.png)

### 3.11 Добавление новых файлов и изменение main.yml на GitHub

![Добавление новых файлов и изменение main.yml на github](Docs/LR3_11_repo_files.png)

### 3.12 Успешное прохождение проверок

![Успешное прохождение проверок](Docs/LR3_12_checks_passed.png)

### 3.13 Готовый пакет игры

![Готовый пакет игры](Docs/LR3_13_package.png)

### 3.14 Заголовок Content-Encoding

![Заголовок Content-Encoding](Docs/LR3_14_content_encoding.png)

### 4.1 Создание файла GameAssembly.asmdef

![Создание файла GameAssembly.asmdef](Docs/LR4_Creating_GameAssembly.asmdef.png)

### 4.2 Создание файла Tests.asmdef в папке Tests/EditMode

![Создание файла Tests.asmdef в папке Tests/EditMode](Docs/LR4_Creating_Tests.asmdef.png)

### 4.3 Создание файла PlayModeTests.asmdef в папке Tests/PlayMode

![Создание файла PlayModeTests.asmdef в папке Tests/PlayMode](Docs/LR4_Creating_PlayModeTests.asmdef.png)

### 4.4 Успешное прохождение тестов Tests

![Успешное прохождение тестов Tests](Docs/LR4_Successfull_Completing_Tests.png)

### 4.5 Успешное прохождение тестов PlayModeTests

![Успешное прохождение тестов PlayModeTests](Docs/LR4_Successfull_Completing_PlayModeTests.png)

### 4.6 Добавление автозапуска тестов

![Добавление автозапуска тестов](Docs/LR4_Adding_Autorun.png)

### 4.7 Добавление секретов

![Добавление секретов](Docs/LR4_Adding_Secrets.png)

### 4.8 Успешное прохождение проверок

![Успешное прохождение проверок](Docs/LR4_Successfull_Completing_Checks.png)

### 4.9 Файлы логов результатов тестов

![Файлы логов результатов тестов](Docs/LR4_Test_Results_Log_Files.png)

### 4.10 Папки с файлами тестов

![Папки с файлами тестов](Docs/LR4_Folders_With_Tests_Files.png)

### 4.11 Файл GameAssembly.asmdef

![Файл GameAssembly.asmdef](Docs/LR4_File_GameAssembly.asmdef.png)

### 4.12 Демонстрация защиты пайплайна при непрохождении теста

![Демонстрация защиты пайплайна при непрохождении теста](Docs/LR4_Pipeline_Protection_Demonstration.png)