# Candidates Test Project

## Установка и настройка

### 1. Настройка User Secrets

Настройте User Secrets:

```bash
cd CandidatesTestProject
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:Password" "your_postgres_password"
dotnet user-secrets set "Telegram:BotToken" "YOUR_TELEGRAM_BOT_TOKEN"
```

### 2. Настройка PostgreSQL

Создайте базу данных PostgreSQL:

```sql
-- Подключиться к PostgreSQL
psql -U postgres

-- Создать базу данных
CREATE DATABASE candidatesdb
TEMPLATE template0
ENCODING 'UTF8'
LC_COLLATE 'ru_RU.UTF-8'
LC_CTYPE 'ru_RU.UTF-8';

-- Выход
\q
```

Убедитесь, что настройки подключения в `appsettings.json` корректны:
- Host: localhost
- Port: 5432
- Database: CandidatesDb
- Username: postgres
- Password: (хранится в User Secrets)

### 3. Применение миграций

```bash
cd CandidatesTestProject
dotnet ef database update
```

Это создаст все необходимые таблицы и заполнит базу тестовыми данными.

### 5. Настройка Telegram

Обновите `appsettings.json` с ID вашей Telegram группы:

```json
"Telegram": {
  "BotToken": "PLACEHOLDER_USE_SECRETS", 
  "ChatId": "YOUR_TELEGRAM_CHAT_ID"
}
```

Токен хранится в User Secrets.

## Тестовые данные

После применения миграций в базе будут доступны следующие пользователи:

| Login  | Password  | Role  |
|--------|-----------|-------|
| admin1 | qwerty123 | Admin |
| admin2 | qwerty123 | Admin |
| admin3 | qwerty123 | Admin |

