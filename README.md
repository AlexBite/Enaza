# Enaza

## Задание 1
Выполнено полностью, кроме опциональных требований

SWAGGER: http://localhost:5000/swagger

Как запустить:
1. Установить MS SQL localDb
2. Перед запуском приложения в консоли из папки проекта прописать `dotnet dotnet-ef database update` для создания БД

## Задание 2

Запрос не учитывает, что pg_temp_* может быть другим. * - цифра для директории `pg_temp_*`, в которую PosgteSQL может решить определить временные таблицы.

```sql
SELECT *
FROM pg_temp_5.tmp_a WHERE pg_temp_5.tmp_a.value is not null
UNION SELECT * FROM pg_temp_5.tmp_b WHERE pg_temp_5.tmp_b.value is not null;
```
