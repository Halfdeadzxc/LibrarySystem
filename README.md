Для запуска бд необходимо выполнить следующее:
Запустить контейнер в терминале:
  cd Library.API
  docker compose up -d
Для использования миграции:
 cd Library.API
 dotnet ef database update
