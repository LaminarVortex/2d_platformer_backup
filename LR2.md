# Лабораторная работа № 2

**Тема:** Настройка репозиториев на GitHub и базовая автоматическая проверка проекта (Sanity Check)

**Основной репозиторий:** https://github.com/LaminarVortex/ARPO_Lab1

**Резервный репозиторий:** https://github.com/LaminarVortex/2d_platformer_backup

---

## Шаг 1. Создание резервного репозитория

На GitHub создан новый публичный репозиторий `2d_platformer_backup`. В него будет автоматически зеркалироваться основной проект.

![Создание нового репозитория](Docs/LR2_01_create_repo.png)

## Шаг 2. Сохранение токена в секреты проекта

В основном репозитории открыт раздел `Settings → Secrets and variables → Actions`. Создан секрет `BACKUP_TOKEN` с токеном доступа для записи в резервный репозиторий. Токен хранится в зашифрованном виде и не попадает в код.

![Сохранение токена в секреты проекта](Docs/LR2_02_secret_token.png)

## Шаг 3. Создание YAML-файла пайплайна

В проекте создан файл `.github/workflows/main.yml` с описанием workflow **CI and Mirroring**. Он запускается при событии `push` и состоит из двух задач (jobs):

1. `sanity_check` — базовая автоматическая проверка проекта;
2. `mirror_repo` — зеркалирование репозитория в резервный. Запускается только после успешного завершения `sanity_check`, а для доступа к резервному репозиторию использует секрет `BACKUP_TOKEN`.

![Создание YAML файла](Docs/LR2_03_yaml_file.png)

## Шаг 4. Отправка пайплайна на GitHub

Изменения выполнены в отдельной ветке `LR2`:

```
git checkout main
git pull origin main
git checkout -b LR2
git add .github/workflows/main.yml
git commit -m "feat: added CI and mirroring workflow"
git push origin LR2
```

![Отправка пайплайна на GitHub](Docs/LR2_04_git_push.png)

## Шаг 5. Проверка работы пайплайна

После слияния pull request в `main` запустился workflow. Обе задачи — `sanity_check` и `mirror_repo` — завершились успешно (общее время около 17 секунд). В процессе отладки в workflow было исправлено выполнение `git push` (отправка в `HEAD:main`).

![Успешное прохождение sanity_check и mirror_repo](Docs/LR2_05_actions_success.png)

## Шаг 6. Проверка резервного репозитория

В репозитории `2d_platformer_backup` появилась полная копия проекта, включая папку `.github/workflows`, `Assets`, `Packages`, `ProjectSettings` и историю коммитов. Это подтверждает, что зеркалирование работает.

![Резервный репозиторий](Docs/LR2_06_backup_repo.png)
