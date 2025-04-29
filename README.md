# Проект за управление на потребители написан на ASP.NET CORE MVC ,Dapper и SQL Server

Структура на проекта

- 'Controllers/UserController.cs' - контролерът, който обработва заявки за потребителите.
- 'Models/' - съдържа ViewModel и моделите за потребители и адреси.
- 'Repositories/UserRepository.cs' – запазва всички потребители в базата данни чрез ADO.NET/Dapper.
- 'Service/UserService' - е отговорен за извършването на основните операции по извличане на информация за потребителите чрез външно API.
- 'Views/User/Index.cshtml' - основната страница с таблица за зареждане и запазване на потребители. 
- 'InovasysTask.Data/Data/ApplicationDbContext.cs' - използва се само за създаване и миграции на базата данни.
- 'InovasysTask.Data/Models/' - модели на базата данни.
- 'InovasysTask.Commons/SqlQueries' - Клас, съдържащ SQL заявки, които се използват в процесите на работа с базата данни.
- 'InovasysTask.Commons/EntityValidationConstants' - Клас, който съдържа константи, свързани с валидация на полета за потребителите и адресите.

Инструкции отностно стартиране на проекта.

1.Клонирайте репото:

git clone https://github.com/VaNkOSl/InovasysTask.git

2.Отворете проекта в Visual Studio 2022 

3.Настройте файла appsettings.json с правилния connection string към вашата SQL Server база.

4.Стартирайте миграциите с EF Core
-dotnet ef database update

5.Стартирайте проекта

-dotnet run
