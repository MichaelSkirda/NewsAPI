# NewsAPI | Михаил Скирда для МИРТЕК

Front-end: Swagger

Back-end: ASP.NET Core REST API, EntityFramework Core, [SyndicationFeed](https://learn.microsoft.com/ru-ru/dotnet/api/system.servicemodel.syndication.syndicationfeed?view=dotnet-plat-ext-7.0)

Database: MS SQL Server

## Классы

Post.cs - класс новости. Содержит заголовок новости, текст новости, ссылку на оригинал и дату публикации.

NewsSource.cs - новостной сайт, с которого берутся новости. Содержит имя сайта и ссылку на RSS. Через ``` /NewsSource/Post ``` пользователь может добавить свой сайт и приложение будет парсить с него новости.

ParseNewsSourcesTimer.cs - содержит единственный метод Parse, который раз в минуту через RSS добавляет новости в базу данных. Для чтения RSS используется библиотека '[SyndicationFeed](https://learn.microsoft.com/ru-ru/dotnet/api/system.servicemodel.syndication.syndicationfeed?view=dotnet-plat-ext-7.0)'. Сохраняются только новости, которых еще нет в базе данных.

UI доступен по адресу:

``` 
https://localhost:7181/swagger/index.html
```

## Послесловие

Задание интересное, познакомился с новой библиотекой. Для ежеминутного вызова парсинга использовал обычный System.Threading.Timer, но в реальном ASP.NET (Core) MVC проекте его использование нежелательно (подробнее тут [https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx/](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx/)). Наверное лучше было бы сделать парсинг отдельным микросервисом или процессом, но в тестовом проекте это смотрелось бы излишне. Надеюсь задание выполнено хорошо, буду рад прийти к вам на собеседование - Михаил Скирда.