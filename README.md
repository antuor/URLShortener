# URLShortener
Небольшое приложение для сокращения ссылок на **ASP.NET core web api** и **razor pages**.
Для создания сокращённых ссылок была использована библиотека [Hashids.net](https://hashids.org/net/).

## Сборка проекта
### Требования
Для сборки проекта необходимы:
* **Visual Studio 2019** последней версии (16.11.3 на момент написания);
* установленный пакет **ASP.NET and web development**;
* возможно, пакет **.NET desktop development**.

### Возможные проблемы
Пакеты NuGet должны восстанавливаться автоматически, если у вас включена такая возможность. 
Для её включения перейдите **Tools > Options > NuGet Package Manager** и выберите **Automatically check for missing packages during build in Visual Studio under Package Restore**.

Также при возникновении ошибок, может помомочь перезапуск Visual Studio.
Если пакеты по какой-то причине не востановились, можно скачать их вручную, для этого нужно открыть **Tools > NuGet Package Manager > Package Manager Console** 
и ввести следующие команды для отсутствующих пакетов или для всех сразу:
1. Install-Package Hashids.net -Version 1.4.1
2. Install-Package Microsoft.EntityFrameworkCore -Version 5.0.10
3. Install-Package Microsoft.EntityFrameworkCore.Design -Version 5.0.10
4. Install-Package Microsoft.EntityFrameworkCore.Sqlite -Version 5.0.10
6. Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 5.0.2

## Некоторые мысли по доработке
1. Фронтенд: в настоящее время пользовательский интерфейс очень скудный. Возможно следует его немного переработать.
2. Бекенд: в настоящее время минификация ссылок происходит в razor page вместо ApiController, который просто сохраняет объект в базе данных. Такой подход показался мне более правильным, но возможно стоит перенести основную логику в контроллер.
3. Бекенд: можно попытаться доработать алгоритм работы приложения для снижения количества обращений к базе данных. А также рассмотреть другие способы для генерации коротких ссылок.
4. Общее: добавить возможность сбора статистики по ссылкам и отображения этой статистики пользователю. Поправить комментарии.
