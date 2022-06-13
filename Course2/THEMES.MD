# Вопросы по информатике

## Введение в ASP.NET Core

### Понятие фреймворка

Фреймворк - карскас, определяющий структуру ПО. Облегчает разработку и объединение различных программных компонентов.
Диктует правила построения архитектуры приложения

### Особенности фреймворков

Библиотека, в отличие от фреймворка, предоставляет функциональность и не влияет на архитектуру.

### ASP.NET Core

ASP.NET Core - свободно-распространяемый кроссплатформенный фреймворк для создания веб-приложений на платформе .NET с открытым исходным кодом.
Построен на новом веб-стеке, но при этом обладает высокой степенью совместимости с ASP.NET.
Совмещает несколько моделей разработки: базовый (минимальные необходимые требования - middleware, routing, configuration), MVC, Razor Pages (надстройка над MVC), WebAPI, Blazor

### Свойство кросс-платформенности. Преимущества

Кросс-платформенность позволяет создавать WORA приложения (write once run anywhere). Мы можем написать общий код, описывающий общую функциональность, а затем запускать его на разных машинах, на разных ОС и т.д. Преимущества:

- Уменьшение времени разработки
- Сокращение расходов
- Единая кодовая база
- Покрытие более широкой аудитории
- Одинаковый UI/UX

### Запуск и настройка приложения

Приложение запускается из Main. Через метод статического класса WebApplicationBuilder.CreateBuilder() мы получаем объект WebApplicationBuilder, в котором определяем настройки нашего приложения: конфигурация, логирование, окружение, зависимости и т.д.

Когда настройка завершена, создаем само приложение, вызывая метод Build(). Полученный объект - наше приложение, которое и нужно запустить.

### Запуск

WebApplicationBuilder builder = WebApplication.CreateBuilder();
WebApplication app = builder.Build();

### Паттерн Builder

Builder - один из порождающих паттернов GoF. Позволяет создавать крупные составные объекты. Хорошо работает с FluentAPI.

Пример, когда есть значения по умолчанию, а нам нужно создать объект, в котором изменяется только 1 аргумент в конструкторе.

### Program и StartUp, как с этим в .NET 6

В .NET 6 убрали необходимость в отдельном классе StartUp. Его 2 основных метода теперь можно реализовать прямо в методе Main (начиная с C# 10 (вроде), метод Main не нужно явно реализовывать). Теперь все можно сделать в 1 методе - сначала ConfigureServices, затем Configure.

### HostBuilder. WebApplicationBuilder

HostBulider - **общий** класс для построения хостов.

WebApplicationBuilder - класс для постоения хостов преимущественно **HTTP(S)**.

В кратце, HostBuilder создает IHost (для любых подключений), WepHostBuilder создает IWebHost (для веб серверов). IHost может быть каким-нибудь клиентом Postgres (он http не принимает), IWebHost - наш веб-сервер. По умолчанию, в шаблоне Web используем IWebHost с WebHostBuilder.CreateBuilder(args)

### Content & Web root path

ContentRootPath - путь до файлов самого приложения (dll, exe)

WebRootPath - путь до файлов, обрабатываемых запросами (wwwroot по умолчанию)

Оба: абсолютные (с корня), задаются в IWebHostEnvironment, для каждого свой FileProvider

### Окружения

Нужны для корректной работы, передачи важных переменных (строки подключения, пароли, кол-во подключений в пуле и т.д.). Источники задаются в ConfigurationManager объекта IWebHostBuilder. 

Значения окружения могут быть получены из:

- файлов (launchSettings.json, web.config)
- переменных окружения (ASPNETCORE_URLS)
- задаваться вручную (AddInMemoryCollection(IEnumarable\<KeyValuePair\>))

### launchSettings.json

Настройки приложения могут быть получены из файла. По умолчанию в папке проекта ищется файл launchSettings.json, в котором в формате json определены настройки для проекта. 

Также в зависимости от типа кружения (Production, Developement ...) могут быть загружены специфичные настройки. Спец. настройки указываются в файле launchSettings.{Environment}.json (launchSettings.Development.json). Указанные в них значения перетирают launchSettings.json (если присутствуют)

### Класс Startup (.NET Core 3.x/5)

До .NET 6 для настройки сервисов и пайплайна обрабоки использовался класс специальный класс (StartUp по умолчанию), в котором должны быть опеределны 2 метода - ConfigureServices, Configure. В первом методе добавлялись сервисы необходимые для функционирования, во втором настраивался порядок обработки запроса (Pipeline).

### Настройка приложения в .NET 6

Начиная с .NET 6 необходимость в этом классе ушла и все необходимые манипуляции можно произвести в основном методе Main. Сначала создаем Builder, его настраиваем. Затем вызываем Build(), получаем  объект WepApplication. В нем настраиваем конвеер обработки (UseRouting, UseAuthorization...). В конце вызываем Run().

### Dependency Inversion Principle

Идея такая - вам нужен не сам класс, а его функциональность. Нам нужен не человек, а что-то, что может перетаскать коробки, а это могут быть робот, человек, магия и т.д. В таком случае, мы определяем ЧТО нам нужно, выделяем это ЧТО-ТО в отдельный интерфейс, и на основе этого делаем реализацию.

> Мы должны зависеть от абстракции, а не от реализации

### Сервисы

Сервис (англ. Service - обслуживать) - это что-то, что выполняет какую-то функциональность. Например, шлет email, логирует и т.д. 

Хорошо согласуется с [Dependency Inversion Principle](#dependency-inversion-principle) - в конструктор передаем выделенные интерфейсы.

### Инъекция зависимостей (зачем)

Инъекция зависимостей - паттерн, при котором мы передаем не сами классы с реализацией, а их интерфейсы (см. [Depency Inversion](#dependency-inversion-principle)). 

Зачем:

- динамчески заменять реализацию (в зависимости в от состояния подключения либо в памяти, либо в файл, либо в бд сохранять изменения)
- для тестов (заменяем на моки, стабы, фейки)

### IoC контейнеры

IoC container (IoC - Inversion of Control) - контейнер (объект) содержащий в себе все необходимые сущности. Сам выстраивает граф зависимостей для создания, определяет что нужно и т.д. В ASP.NET Core из коробки есть свой, но можно заменить на другие (Autofac ...)

### Инъекция в Startup (.NET Core 3.x/5)

В .NET Core 3.x/5 должен быть метод StartUp, котором есть методы ConfigureServices, Configure (см. [Класс StartUp (.NET Core 3.x/5)](#класс-startup-net-core-3x5)). Иногда нам нужно определить в каком окружении мы исполняемся - тест или прод. В таком случае мы можем пробросить зависимости в конструктор (или сам метод (уточнить!)). 
Например, IWebHostEnvironment.

### Замена контейнера. Замена на autofac

Замена контейнера производится как обычная замена сервиса - только заменить дескриптор. 

Пример для Autofac:

```cs
var host = new WebHostBuilder()
        .UseKestrel()
        .ConfigureServices(services => services.AddAutofac()) // Здесь заменяем
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

    host.Run();
```

Замена работает и для общего хоста IHost:

```cs
var host = Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureWebHostDefaults(webHostBuilder => {
          webHostBuilder
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>();
        })
        .Build();

    host.Run();
```

### Доступ к сервисам

Доступ к сервисам происходит:

- Автоматически с помощью DI контейнера через внедрение зависимосетей(конструктор, свойства(не рекомендуется), аргументы методов(new!!!!))
- Внедрить DI контейнер напрямую и разрешать самому

```cs
var service = _container.GetRequiredService<ISomeService>();
```

### Middleware

Middleware - ПО промежуточного слоя. Выстраивается в виде обработчика на конвеере запроса. Алгоритм такой:

1. Получаю запрос
2. Что-то с ним делаю
3. Решаю пускать ли его дальше или нет
4. Пускаю или возвращаю
5. Если пускаю, то могу обработать его еще раз на обратном пути

Настраивается после метода Build()/в методе Configure класса StartUp.
Для настройки используются методы Map, Use, Run

[Docs](https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0)

### Методы Use и Run

Use:

- Метод расширения
- Создание цепочки обработки
- Принимает Func\<HttpContext, RequestDelegate, Task\>: (context, next) -> Task

Run:

- Конечная точка обработки
- Принимает RequestDelegate: (context) -> Task
- Если ничего не передавать - запускает приложение

### Методы Map и MapWhen

[Даже название не изменил](https://metanit.com/sharp/aspnet5/2.22.php)

Map:

- Сопоставляет путь с текущим и если совпал то переходит по требуемому пути исполнения
- Получает строку для сопоставления и builder (т.е. для каждого совпадения отдельный конвеер обработки)

MapWhen:

- Как Map, но с условием

### Создание компонент middleware

Создание:

- Middleware - класс с методом InvokeAsync(HttpContext context, RequestDelegate next)
- Есть интерфейс IMiddleware (не обязательно)
- Добавление в пайплайн - UseMiddleware\<TMiddleware\>()
- Можно создать свои кастомные UseXXX

### Статические файлы

Для обработки статических файлов есть middleware UseStaticFiles. Файлы ищутся по пути WebRootPath из объекта WebHostEnvironment.

### Конвейер обработки запроса

Последовательно добавляем свои Middleware в конвеер. При старте конвеер собирается, а при получении запроса передается в конвеер. Каждый middleware при получении решает что с ним делать: добавляет в ответ какие-то данные, проверяет заголовки, логирует и т.д. Дальше запрос может не передать (UseAuthentication, UseStaticFiles). Последний в конвеере из Use - Run. Он дальше не передает - конечная точка. 
Также для MVC есть свой отдельный пайплайн из фильтров: ResourceFilter, ExceptionFilter, AuthrizationFilter и другие.

### Время жизни middleware

Middleware живет все время существования приложения - singleton.
Поэтому, для внедрения зависимостей transient, scoped лучше использовать внедрение через метод.

### Ведение журнала

Поддержка логирования - встроенная. Для этого есть даже отдельное свойство - Logging.
Логирование может осуществляться во множество путей: файл, консоль, даже сеть.
Есть поддержка уровней логирования:

- None - не логировать
- Debug - для дебага (например, занчения переменных)
- Trace - для трассировки выполнения (например, отслеживать какой метод вызвался)
- Information - главная логика приложения (например, что заказ выполнен, пользователь зарегистрировался)
- Warning - ошибки, не влияющие на выполнение приложения (например, отправка email не работает)
- Error - ошибки, которые влияют на корректное исполнение приложения и должны быть обработаны (например, бд недоступна)
- Critical - пиздец (например, переполнение бд, недостаток памяти)

Для логирования есть метод Log() и его расширения LogInformation и т.д.

Интерполяцию лучше не делать, а передавать аргументы позже (т.к. интерполяция стоит время, а если просто передавать аргументы, то она отложенная)

### Обработка ошибок

Ошибки есть 2 типов - сервера и логики (Exceptions и те, что должны вернуть HTTP 4xx статус).
Если это 2 - то, все ок возвращаем статус (+ страница если нужно).

Если это 1 - то, все плохо. Разработчик, должен понять, что произошло (UseDeveloperExceptionPage), а пользователь не должен такое увидеть (UseExceptionHandler)

В обоих случаях нужно логировать.

### Публикация в Azure

На Azure публикация проста - в Visual Studio кликаем на Publish, выбираем Azure, вводим свои данные, план, место и т.д. и публикуем. (Он вроде сам там скомпилирует(проверить!!))

## ASP.NET Core. Publish & Deploy

### Модель хостинга ASP.NET Core

ASP.NET Core - консольное приложение.

Всего есть 3 встроенных веб-сервера:
1. IIS - Windows only
2. HttpSys - Windows only
3. Kestrel - Cross-platform

По умолчанию используется кросс-платформенный веб-сервер Kestrel, построенный на libuv -
кросс-платформенной библиотеке асинихронного ввода/вывода (аналогия с async/await методов)

Модель хостинга такая:
1. Запрос приходит на веб-сервер (Nginx)
2. Он определяет, что запрос на наш процесс
3. Запрос проксируется на наш сервер (Kestrel)
4. Kestrel отдает запрос нашей логике
5. Kestrel получает результат и возвращает обработанный результат nginx

Причем логика и Kestrel - в одном процессе (большая производительность).
Самого Kestrel недостаточно и ему нужен главный веб-сервер (SSL termination, load balancing...)

На Windows доступен отдельный веб-сервер HttpSys

### Reverse proxy

Proxy открыт в интернет. Его работа - перенаправлять запросы в нужные точки.
Он может поддерживать несколько приложений одновременно.
Например, когда запрос идет на "http://server.com" отдавать запрос внутреннему процессу на порте 5500, 
а когда на "http://another.com/file" отдавать файл index.html.

Также у него могут быть другие рутинные задачи:
- Файрвол
- SSL termination
- Load balancing
- Кэширование

### Run ASP.NET Core app

1. Скомпилировать исходники
```shell
dotnet publish -c Release -o out
```
3. Запустить из папки

### Публикация

1. Установить .NET на сервере
2. Скопировать полученные файлы на сервер

### Запуск опубликованного приложения
```shell
dotnet Assembly.dll
```

### dotnet command

- Для запуска  (.NET Runtime required)
```shell
dotnet run 
```
- Для компиляции
```shell
dotnet build
```

### Независимый деплой

Выходная программа может быть:
- Self-Contained: 
  - есть варианты для всех систем (Windows, Linux, MacOS)
  - \+ сам Runtime
- Framework-Dependent: 
  - компилируем сразу под определенную систему (Windows, Linux, MacOS)
  - Runtime уже должен быть предустановлен

### Как деплоить
- Скопировать файлы на сервер вручную (ssh, ftp, ftps)
- CI/CD
  
### CI/CD

Устанавливаем конфигурацию: на какие действия триггерить систему (например, пуш в main)
При выполнении этого действия запускается система:
1. Собрать исходники вместе
2. Скомпилировать
3. Запустить тесты
4. Выпустить на прод.

Если где-то ошибка - узнаем сразу.

### Развёртывание в IIS

1. Установить .NET Core Windows Server Hosting Bundle
2. Настроить пул приложений для IIS
   1. No Managed Code
   2. Внутри - ASP.NET Core Module
3. Сами приложения - в отдельных процессах (Core module шлет им запросы)
4. Настроить IIS и пула
5. Открыть доступ к пулу

### Пул приложений

IIS работает как Reverse Proxy - перебрасывает запросы на сервер.
В отличие от Kestrel, на каждый запрос не отдельный поток, а целый процесс.
Большая изоляция и безопасность, но скорость меньше.

### Поддержка в коде. Middleware

При конфигурации указать, что используем IIS
```csharp
builder.WebHost.UseIIS();
builder.WebHost.UseIISIntegration();
```

- URL для переброса запросов
- Конфигурация переброса заголовков
- Включение Windows аутентификации (если нужно)

### web.config

Web.config - файл конфигурации, необходимый для запуска IIS (при каждом запуске он должен присутствовать).
Лежит где и само приложение.

### Хостинг приложений под Linux

Linux - top:
- Удобная настройка
- Меньше требований к железу
- Дешевле стоимость сервера

### Run ASP.NET Core app on Linux

1. Скомпилировать приложение
2. Установить .NET Runtime на сервер
3. Отправить приложение на сервер
4. Настроить reverse proxy (nginx)
5. Настроить process management (systemd)

### ASP.NET Core in Docker

Сейчас все в основном запускают в контейнерах. 
Обычно это Docker.
Для .NET есть уже готовые образы для разных типов Runtime.

### Docker

Docker - движок ОС виртуализации.
Ты запускаешь на Windows контейнер с образом Linux и твое приложение думает, что он работает в Linux.
(Вообще идея построена на cgroups - фича Linux, в Windows через жопу).

Концепции:
- Образ - единица развертывания, шаблон
- Контейнер - запущенный образ
- Dockerfile - файл конфигурации для создания образа
- Docker compose - утилита для создания группы взаимосвязных контейнеров
с легкой конфигурацией прочих вещей (сеть, аргументы ...)

### Потенциальные проблемы при деплое

- Изменения IP при пробрасывании запроса
- Пришедший запрос по http, не https


### Разница между Linux и Windows

- LF vs CRLF:
в Linux конец строки = '\n', в Windows = '\r\n'
- '\' vs '/':
в Linux разделитель - '/', в Windows = '\'
- Запрещенные символы в переменных окружения:
Regex для Linux ~ [a-zA-Z_]{1,}[a-zA-Z0-9_]{0,}

### Конфигурирование

Лучше иметь возможность выставлять конфигурацию приложения не в compiletime, а в runtime.
Для этого нужна конфигурация. 
В ASP.NET Core есть интерфейс IConfiguration откуда можно получить конифгурацию.
Источники: переменные окружения, аргументы командной строки, файлы, внешние конфигурации (запросы).
Например, строки подключения получать из переменных окружения, а кол-во попыток переподключения - из файла.

### Бандлинг/минификация

Цели:
1. Уменьшить трафик между клиентом и сервером
2. Уменьшить время рендеринга/отклика приложения

Для этого:
1. Посылаемые файлы нужно упаковать как можно плотнее - минификация.
Пример, `script.min.js` или `style.min.css` из React
2. Отправить все необходимое одним файлом, объединить все вместе - бандлинг
Пример, после сборки файлов в React, у нас есть только 1 файл со стилем, хотя в процессе было несколько `App.css`, `Header.css`...

## ASP.NET Core. Middleware

### Обработка запроса

1. Запрос принимается
2. Выстраивается конвеер обработки запроса
3. Запрос последовательно проходит по Middleware
   1. Каждый из них обрабатывает запрос
   2. Решает передавать ли дальше
4. По достижении конца, проходит обратный путь

### HttpContext

HttpContext - абстрактный класс, представляющий контекст запроса:
- Request - запрос
- Response - ответ
- User - информация о пользователе
- Connection - соединение (порт, адрес...)
- RequestServices - контейнер сервисов
- Items - дополнительные объекты

### HttpRequest

Представляет собой контекст запроса:
- Метод
- Схема
- Путь
- Хост
- Запрос
- Протокол

### HttpResponse

Контекст ответа:
- Статус код
- Заголовки
- Тело ответа
- Writer - для записи ответа
- Длина ответа
- Тип ответа

### Middleware

Промежуточный слой обработки запроса.
1. Обрабатывает запрос до и после передачи дальше
2. Решает передавать ли дальше

### Примеры

```csharp
app.Use(async (context, next) =>
{
    if (context.User.HasClaim(c => c.Type == "SlavesCount" && int.TryParse(c.Value, out var count) && count > 0))
    {
        await next();
    }
    else
    {
        await context.Response.WriteAsync("Not enough slaves count to perform action");
    }
});
```

### Middleware Pipeline

- Двусвязный список middleware
- Либо терминальный, либо содержит ссылку на следующий

### Выстраивание конвейера

С .NET 6:
- Добавление в WebApplication перед `app.Run();`
До:
- В методе `Configure()`;

### Методы Use, Map, Run, MapWhen

Run:
- Конечная точка обработки запроса (дальше не передает)

Use:
- Добавляет middleware в пайплайн

Map:
- Сопоставляет Path с требуемым, и если совпадает, то передает запрос
на выполнение уже другому пути выполнения

MapWhen:
- Как `When`, но есть условие для выполнения

### Проблема с формированием ответа

После записи ответа в Response его менять нельзя:
изменится Content-Length, Content-Type и т.д.

### Кастомные компоненты Middleware

Есть метод расширения `UseMiddleware<TMiddleware>();`. 
Принимает класс, в котором:
- Есть публичный метод `void Invoke(HttpContext context)` + Конструктор принимает `RequestDelegate`
- Если публичный метод `Task InvokeAsync(RequestDelegate next, HttpContext context);`
  
Хорошая практика - для своих типов Middleware отдельные методы расширения 

### Дополнительные параметры

В конструтор класса Middleware можно делать инъекции зависимостей.

### Порядок вызова

Порядок вызовов такой же как и на этапе построения WepApplication.

### Middleware обработки ошибок

Перадает запрос дальше. На обратном пути проверяет на ошибки Response.

### Middleware vs Services

Middleware - ответственен за логику обработки запроса

Services - ответственны за бизнес логику приложения

### Маршрутизация в ASP.NET Core

Включается с помощью `app.UseRouting()`;

Для навигации используется концепция конечных точек.

### Конечные точки

Конечная точка, Endpoint - логическая конечная точка обработки запроса.
Определяет делегат для обработки + метаданные (информацию из строки запроса...)

### Шаблоны маршрутов

Шаблоны представленны как Regex (не Regex). Общий вид такой
`must-be-here/{lanuguage:regex(^\w\w-\w\w$)}/{parameter=default-value}/{date:date}/{**other}`
- {...} - параметр для сопоставления
- :regex(), :date - сопоставление со значением и его типом в адресе
- =default-value - значение по умолчанию (если нет)
- **other - все остальное

### Маршрутизация - Концепции

Запуск middleware:
- До UseRouting:
  - Изменение данных для работы с маршрутизацией: переписывание пути, изменение метода, изменение базового пути
- После UseRouting:
  - Добавление метаданных
  - Проверка безопасности

### Совпадение маршрутов

Из всех путей выбирается наиболее конкретный.

Более конктретные:
1. Большее число сегментов (api/images - api/images/total)
2. Сегмент с литеральным (вшитым) текстом (api/{version} - {method}/{version}) 
3. Сегмент с ограничением ({date:date})
   
Менее конкретные:
1. Всеобъемлющие параметры ({**args})

### Генерация URL-адресов

LinkGenerator - синглтон объект, для генерации ссылок.
Используется в HTML helper, URL helper, Tag helper, ActionResult.
Устанавливает связь между различными действиями/точками в MVC.

### Обработка ошибок

Можно создать специальную страницу, которая будет выдаваться при ошибке.
`app.UseExceptionHandler('/Error')`

В шаблонах MVC, RazorPages - уже встроена.

### Обработка ошибок HTTP: UseStatusCodePagesWithRedirects vs UseStatusCodePagesWithReExecute

Для статус кодов 400-599 есть специальные обработчики для каждого случая.

Каждый из них может принимать строку, в которой можно указать параметр '{0}'. В него будет всталяться статус код.

```csharp
app.UseStatusCodePages();
app.UseStatusCodePagesWithRedirect();
app.UseStatusCodePagesWithReExecute();
```

### Использование Cookie

Для кук есть свои свойства в Request и Response:

```csharp
context.Response.Cookies
context.Request.Cookies
```

Причем в Response - только модифицировать, а в Request - только читать.

### Сессии

1. Добавляем сессии в Services
```csharp
builder.Services.AddSession();
```
2. Добавляем сессию в пайплайн
```csharp
app.UseSession();
```
3. Получаем доступ к сессии из объекта Session
```csharp
app.Run(async (context) => 
    await context.Response.WriteAsync(context.Session.GetString("UserName")));
```

## ASP.NET Core. Services & DI

Сервисы - зависимости
Пример зависимости
Проблемы прямых зависимостей
S.O.L.I.D
ServiceLocator
DI анти-паттерны
IoC (Inversion of Control)
Свой тривиальный контейнер
IServiceProvider
Регистрация сервисов
IServiceCollection Extension methods
Время жизни
Варианты регистрации
Общая схема работы
Типичные ошибки с Lifetime
Резолв из transient сервиса scoped или singleton зависимостей
GetService<TService>()
Несколько сервисов или интерфейсов
Рекомендации по созданию сервисов
Disposal of services
Рекомендации по использованию сервисов

5. Архитектура приложений ASP.NET Core MVC

Монолитное приложение
All-in-one приложения
Слои приложения
Правильные зависимости
Чистая архитектура
Распределение по слоям
Ядро приложения - Бизнес-логика
Типы данных ядра приложения
Инфраструктура - Доступ к данным
Типы данных слоя инфраструктуры
Repository pattern
Generic Repository
Инъекция Repository
Unit of Work
Repository и UoW в .NET
Уровень пользовательского интерфейса
Типы данных UI
UI ASP.NET Core
ASP.NET Core MVC / Razor Pages
Model / ViewModel
Контроллеры
Действия (action)
IActionResult
IActionResult: redirect
Валидация модели
Представления
Razor
Передача данных в представления
Вспомогательные функции тегов
Скаффолдинг
Маршрутизация
Атрибуты маршрутизации
ControllerContext
Передача параметров в запросе
model binding, массивы/объекты
Загрузка файлов
Работа с файлами - Безопасность
Инъекции зависимостей

## ASP.NET Core Auth*

### Фильтры MVC

Фильтр - объект, позволяющий выполнять определенный код до и/или после выполнения основного метода.

### Виды фильтров

1. Авторизации
2. Ресурсов
3. Действий
4. Исключений
5. Результатов действий

Образуют свой конвеер фильтров. На обратном пути работают только фильтр ресурсов и результатов.

Также есть отдельный фильтр RazorPages

### Создание фильтров

Фильтр должен реализовать свой интерфейс:
- Авторизации - IAuthorizationFilter
- Ресурсов - IResourceFilter
- Действий - IActionFilter
- RazorPages - IPageFilter
- Исключений - IExceptionFilter
- Результатов - IResultFilter

Это синхронные фильтры. Асинхронные имеют префикс Async после I (IAsyncActionFilter).

### Добавление фильтров

Фильтры могут быть добавлены:
- Глобально, в опциях MVC
```cs
builder.Services.AddMvc(options =>
        {
            options.Filters.Add(new SomeFiler());
        });
```
- Через атрибуты. Для этого нужно не только реализовать интерфейс, но и наследоваться от Attribute.
Добавлять - как атрибуты методов

### Identification / Authentication / Authorization

Identification - кто ты: назвать имя, username (PK - в общем случае)

Authentication - подтвердить что это ты: назвать пароль, passphrase, секретное слово

Authorization - есть ли у тебя права для этого: в какой ты роли, сколько тебе лет, из какой страны

Без вышележащего не может быть выполнено нижележащее: без аутентификации нельзя авторизовать (логично)

### Способы аутентификации
- По сертификатам: подписанный каким-нибудь авторитетом сертификат. 
Применяется в сертификатах SSL.
- По одноразовым паролям: SMS/EMAIL verification code (2FA)
- По ключам доступа: API key, Access token
- Аутентификации по паролю: username/password
  - HTTP authentication: 
Заголовок `Authorization: <type> <data>` 

type: Basic, Bearer, HOBA, Mutual, OAuth, Digest
data: данные закодированные base64.
Например, Basic = base64encode({username}:{password})
  - Forms authentication: в HTML форме логин, пароль.
Они с запросом передаются на сервер.
  - URL query: логин/пароль передаются в параметрах URL - небезопасно
  - Request body (POST, PUT, PATCH) - передача данных в теле запроса, в специальном виде, например, json или xml. 

### Аутентификация по паролю - Уязвимости

1. Простые пароли
2. Брут-форс атаки
3. Передача в незашифрованном виде
4. Нет возможности смены пароля
5. Уязвимость восстановления/смены пароля
6. При смене нет требований повторного ввода пароля
7. Эксплуатация сохраненной сессии

### Аутентификация по токенам

Есть Identity Provider - владеет аккаунтами. 
Другие - клиенты, ими пользуются, путем создания для себя токенов доступа описывающих пользователей (действующих от имени пользователя).
SSO - один раз зарегистрировался, в остальных местах используешь аккаунт.

Стандартов несколько:
- OAuth
- OpenID Connect
- SAML
- WS-Federation

### Форматы токенов

- SWT (Simple Web Token) - ключ-значение в формате HTTP формы
- JWT (JavaScript Web Token) - 3 поля:
  - header: метаданные
  - payload: информация о токене (время действия, кому, от кого)
  - sign: подпись
- SAML (Security Assertion Markup Language) - токены в XML формате

### Аутентификация в ASP.NET Core

Встроена из коробки

### HttpContext.User

Свойство, представляющее данные о пользователе в формате ключ-значение (Claims).

### ClaimsPrincipal

Набор утверждений (claims) о пользователе: username, email, date... 
в формате ключ-значение. 

### Claims vs Roles approach

Roles - устаревший, в HttpContext.User есть метод IsInRole только для совместимости.
Claims дает больше информации о пользователе.

### Процесс аутентификации

1. Клиент вводит логин/пароль и отправляет запрос на сервер
2. HttpContext.User выставляется в Anonymous
3. При успешной аутентификации - пользователь аутентифицируется (HttpContext.SignInAsync, SignInManager.SignIn)
4. Выставляются специальные зашифрованные куки представляющие пользователя
5. При дальнейших входах, куки парсятся и выставляется HttpContext.User

### Middleware. Добавление в обработку

Для рутинной проверки авторизованности - UseAuthentication/UseAuthorization - из коробки.
Поддержка нескольких источников: куки, Authorization header и другие.

### Задачи аутентификации

1. Определить, что пользователь не подделка
2. Проверка уровня доступа к ресурсам.

### Схема аутентификации

Схема аутентификации - название обработчика + его настройки (Cookies, Google, OAuth, Bearer...).
Следует указывать схему по умолчанию.

### Создание аутентификационной куки

```csharp
var claims = newList<Claim> {     
        newClaim(ClaimTypes.Name, user.Email),     
        newClaim("FullName", user.FullName),     
        newClaim(ClaimTypes.Role, "Administrator"), 
        }; 
var claimsIdentity = newClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // Здесь можно задать доп.параметры, например, RedirectUri, ExpiresUtcи т.д.
var authProperties= newAuthenticationProperties();  
await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,      
                              newClaimsPrincipal(claimsIdentity),      
                              authProperties);
```

### Удадение и обновление куки

```csharp
await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // обновление
var claims = newList<Claim> {     
         newClaim(ClaimTypes.Name, user.Email),     
         newClaim("LastChanged", {Database Value}) 
         };  
var claimsIdentity= new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);  
await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
```

### ASP.Net Core Identity

Фреймворк для работы с пользователями. 
Имеет поддержку многих стандартных случаев:

- Смена пароля
- Обновление почты
- Подтверждение почты

Нужно устанавливать отдельно, как NuGet пакет.


### Возможности Identity

- Готовая схема БД
- Валидация пароля
- Блокировка пользователей
- 2FA
- Токены для смены почты/пароля/username
- Отслеживание изменений свойств пользователя
- Возможность интеграции со сторонними провайдерами

### Кастомизация Identity

- Почти всё - шаблоны (нужно наследоваться от них и делать свое)
- Свои сервисы хеширования/генерации токенов
- Внешние провайдеры
- Свои Claims

### Сервисы Identity

```csharp
builder.Services.AddDefaultIdentity<DefaultUser>(options => 
                options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DefaultDbContext>();
```

### Настройка Cookie для Identity

Куки настраиваются так же - через 

```csharp
builder.Services.ConfigureApplicationCookie(options => {
    options.Cookie.Name = "SomeName";
    options.LoginPath = "/Identiy/Account/Login"; // Можно поменять на свои
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});
```

### Identity’s database schema

Есть шаблон для баз данных. В ней определены таблицы (для SQL):
- AspNetUsers
- AspNetUserRoles
- AspNetRoles
- AspNetRoleClaims
- AspNetUserTokens
- AspNetUserLogins
- AspNetUserClaims


### Сервисы

Из коробки доступны 2 основных необходимых объектов:
 
- SignInManager
- UserManager

### Кастомизация пользователей

Переопределяем базовый DbContext - IdentityDbContext (можно использовать IdentityUserContext - без ролей).
Наследуемся от IdentityUser и добавляем/переопределяем что нужно. 
Везде где нужен тип пользователя - даем наш тип.

### Кастомные claims

Можно хранить не только предопределенные типы Claims (Email, UserName...),
но и свои - `new Claim("CustomClaimName", claimValue);`

### Simple Authorization

`[Authorize]`

### Авторизация по ролям

`[Authorize(Roles = "Admin, Manager")]`

### Authorization Policy

Политика авторизации - правило для доступа к ресурсу.
Проверка не только того, что пользователь вошел в аккаунт,
но и того, что соответствует какому-то правилу.

### Добавление политики авторизации

1. Добавляем политики авторизации в builder
```csharp
builder.Services.AddAuthorization(options => {
    options.AddPolicy("OnlyInRussia", p => p.RequireClaim(ClaimTypes.Locality, "Russia"));
});
```
2. Указываем политику в атрибуте `[Authorization("OnlyInRussia")]`

### Ограничения политик (методы)

- RequireAuthenticatedUser() - пользователь аутентифицирован
- RequireClaim(claim) - есть claim с таким названием
- RequireClaim(claim, value) - есть claim с таким названием и значением
- RequireRole(role) - в одной из роли
- RequireUserName(name) - UserName равен этому
- RequireAssertion(handler) - свой тип проверки
- AddRequirements(requirement) - добавить свои требования

### RequireAssertion(handler)

```csharp
builder.Services.AddAuthorization(options => 
    options.AddPolicy("DungeonMaster", policy => 
        policy.RequireAssertion(context => 
            context.User.HasClaim(c => 
                c.Type == "Role"
                && c.Value == "DungeonMaster"))));
```

### Пример авторизации
```csharp
[Authorize("DungeonMaster")]
public IActionResult SlavesCount()
{
    return Ok(new {_slaves.Count});
}

[Authorize(Roles = "Slave, Timur")]
public IActionResult GoToDungeon()
{
    if (_slaves.Any())
    {
        _slavesManager.AddSlaveToDungeon(_slaves.First());
        return Ok();
    }
    return NotFound();
}
```

### Пример своего ограничения

1. Определяем тип своего ограничения
```csharp
class MinimumAgeRequirement
{
    public int MinimumAge { get; }
    public MinimumAgeRequirement(int age)
    {
        MinimumAge = age;
    }
}
```
2. Определяем свой обработчик
```csharp
class MinimumAgeRequirementHandler: AuthorizationHandler<MinimumAgeRequiremnt>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var birthDate = DateTime.Parse(context.User.First(c => c.Type == ClaimTypes.DateOfBirth));
        if ((birthDate.Today.Year - birthDate.Year) < requirement.Age) context.Successed(requirement);
        return Task.CompletedTask;
    }
}
```
3. Регистрация своего ограничения
```csharp
builder.Services.AddAuthorization(options => 
    options.AddPolicy("WorldOfTanksEnjoyers", policy =>
        policy.Requirements.Add(new MinimumAgeRequirement(40))));
```

### Использование контекста MVC. 

В объекте `AuthorizationHandlerContext` есть свойство Resource. Его тип - `object?`.
Через него можно передавать различные объекты необходимые для проверки прав.

### Resource-based authorization

Мы можем проверять основываясь не только на AuthorizationContext,
но и на объекте, предоставленном нам.

Например, мы хотим передавать в handler объект документа, для проверки прав редактирования.
Тогда мы можем вызвать метод `AuthorizeAsync` интерфейса `IAuthorizationService` и передать этот документ.
Он будет доступен через свойство `Resource` объекта `AuthorizationHandlerContext`.

В представления можно внедрять зависимости. Поэтому можно внедрить интерфейс IAuthorizationService и 
уже в самом коде представления проверять уровень доступа (*.cshtml)

```csharp
@inject IAuthorizationService Service
@if (await Service.AuthorizeAsync(User, "EditImage").Succeeded)
{
    <button id='enter-edit-mode'>Edit</button>_
}
```

## ASP.NET Core. Security

### SSL

SSL (Secure Socket Layer) - криптографический протокол, для более безопасной связи. 
Шифрование происходит над HTTP трафиком. 

- Ассиметричное шифрование - обмен ключами
- Симметричное шифрование - сохрание конфиденциальности
- Коды аутентификации - целостность сообщений

Принцип работы:
1. Клиент шифрует открытым ключом сообщение
2. Сервер дешифрует принятое сообщение приватным

И наоборот

### Сертификаты

Сертификат - спец. документ, удостоверяющий что у владельца есть опеределенные права. 
В случае с криптографией (TLS, SSL) это файл формата X.509, в котором содержится информация о:

- Имени, адреса держателя, названия организации
- Открытый ключ
- Дата проверки сертификата
- Серийный номер серитфиката

Используется для установления защищенного соединения при подключении. 
Хранится на сервере в определенной директории. 


### Атака Open Redirect. Защита

В URL может быть прописан адрес *redirectUri*, который ведет на совершенно другой сервер.
Например, после авторизации может быть редирект ссылка на вредоносный сайт, тогда при получении такого запроса
хакер знает, что запрос пришел с такого адреса и попытается получить данные аккаунта.

Шаблон параметра: redirectUrl, returnUrl, return-url, redirect-url 

Для защиты необходимо не просто проверять, что параметр returnUrl присутствует, 
но и валидировать его хост (DNS имя сервера), 
чтобы возврат происходил на тот же адрес

### Защита данных

Секреты приложения должны быть доступны только авторизованным пользователям.
Чтобы ограничить доступ к ним можно:

- Шифровать весь проходящий трафик
- Хранить важные данные только в зашифрованном виде
- Не хранить критические данные в общедоступном месте (не в репозитории, например)

### Шифрование данных (CryptoAPI)

Чтобы данные были защищены, их нужно зашифровать. 
Из коробки есть интерфейс IDataProtector у которого есть метод Protect: byte[] -> byte[], string -> string 

### Установка времени жизни

Для некоторых типов данных нужно уметь хранить их определенное время.
У IDataProtector есть метод ToTimeLimitedDataProtector.
Он может установить период валидности зашифрованных данных. 

### Хранение паролей

Пароли хранить только в шифрованном виде!
Использовать криптостойкие алгоритмы и желательно пройти по несколько раз.
Также стоит добавить к ним соль, чтоб уж наверняка.

### Настройка криптографии

Настройка криптографии в ASP.NET Core - также как и остальные сервисы.
Есть встроенная криптография: 
```cs
builder.Services.AddDataProtection()
                .SetDefaultKeyLifetime(TimeSpan.FromMinutes(30));
```

### Клиентские уязвимости

- XSS, Cross Site Scripting
- L/RFI, Remote/Local File Include
- JSON Injection
- XEE, XML extenal entity
- ClickJacking

### Same-origin policy (SOP)

SOP - политика, определяющая как документ или скрипт, 
загруженный из одного источника может взаимодействовать с ресурсом из другого источника.
Изоляция потенциально вредоносных документов.
В кратце, запись - разрешена, чтение - нет (не везде, например, между iframe ничего cross-origin) 

### Что такое Origin

Origin = scheme + host + port.
Поменяешь хоть что-то одно - это другой Origin.

- http != https
- 80 != 443
- app.domain.com != app2.domain.com
- http://vk.com:20 == http://vk.com:20/me
- https://github.com != https://github.com:444

### Суть XSS. Пример

Нельзя с другого Origin просто так получить контент/сделать запрос. 
Для доступа с других Origin нужно выставить CORS заголовок.

Пример:
1. Захожу на рандомный сайт.
2. Оставляю коммент, в котором есть скрипт
3. Этот скрипт отправляет GET запрос на мой сервер, в котором есть все куки
4. Среди кук я нахожу твой Access/Refresh token
5. Через время запускаю DDoS на Яндекс
6. Виноват ты (формально)

### Как предотвратить инъекции

Нужно:
1. Валидировать/фильтровать входные данные
2. Санитизировать (экранизировать, например) выходные данные

### Валидация и фильтрация. Санитизация. Общие правила. Razor

- Фильтрация предпочтительнее по белым спискам ("всем кому можно", а не "всем, кроме")
- Используем специальные политики для каждого запроса (страна, возраст, пасспорт и т.д.)
- Не размещать недоверенные данные во входе
- Профильтровать каждый вход URL/HTML/JS
- Razor автоматически санитизирует HTML

### Content Security Policy (CSP)

Content Secure Policy - политика, определяющая из каких источников можно получать контент (скрипты, css, html ...).
В ответе сервера выставляется заголовок Content-Security-Policy, в котором выставляются специальные директивы использования. 
Обязательно нужно включать default-src (fallback).

Примеры применений (атрибуты для выставления):
- Только с сервера: default-src 'self'
- Только с сервера и доверенного источника: default-src 'self' *.trusted.com
- Только сервера, но если пользователь вставит медиа, то с разрешенных: default-src 'self'; img-src *; media-src trusted-media.com; script-src static.domain.com
- Весь получаемый контент по SSL: default-src https://some-address.com
- Изображения из любых источников, но запретить JS: default-src 'self' site.com; img-src *;

### CSP Report Request

Надо протестировать работу CSP. 
Для этого при каждом сработанном запрете будет отсылаться отчет в формате json по указанному адресу (report-uri *url*).
В нем есть поля:

- blocked-uri - что заблокировано
- disposition - 'enforce' | 'reporiting' - в зависимости от используемого заголовка
- document-uri - где заблокировано
- effective-directive - нарушенная директива
- original-policy - исходная политика
- referrer - реферер
- script-sample - первые 40 символов документа, спровоцировавшего нарушение
- status-code - статус код страницы 
- violated-directive - нарушенная директива

### Тег base

`<base href="..." target="...">` - HTML тег, определяющий базовый URL, используемый для всех относительных URL.
Может быть только один на весь документ (остальные игнорируются).
Кто-то может вручную поменять base так, что запросы будут идти на сторонний сайт. 
Например, подменить /Account/Login на редирект на http://fuck-you.com/Account/Login, где я заберу твои почту/пароль, а ты не заметишь.

### X-XSS-Protection

X-XSS-Protection - заголовок для остановки загрузки контента при обнаружении XSS атаки.
Значения:

1) 0 - отключить
2) 1 - включить, при обнаружении - удилить небезопасное содержимое
3) 1; mode=block - включить, при обнаружении - предотвратить отображение страницы
4) 1; report=*uri* - включить, при обнаружении - очистить и сообщить (только Chromium)

CSP более функционален, поэтому предпочтительнее, но лишним не будет. Не является частью какой-либо спецификации.

### Cross-Site Request Forgery (CSRF)

Same-Site все равно посылает запрос, хоть не получает ответ. Мы например, можем в параметрах все куки отправить и они сохранятся.

CSRF - тип атаки, использующий такую уязвимость. 

Пример:

На моем сайте slave.cum я делаю `<img src='https://tinkoff.com/transfer?to=slave&amount=1000'>'`.
Затем ты на нее кликаешь, и твои деньги у меня. Так как ты переходишь на сайт и твои куки (то что ты аутентифицирован) отправились тоже.
Со стороны кажется, что ты мне деньги перевел сам.

Защита: 
1. Проверять Referer (не безопасно, можно самим подделать)
2. Посылать вместе с формой секретный ключ

### Double-Submit Cookie Pattern. Валидация Anti Forgery Token

Вариант защиты от CSRF. Клиенту даем 2 токена - один в куках, другой в параметрах ответа (в форме например). 
При получении ответа сверяемся. 
Реализация Stateless, поэтому хорошо масштабируется.

В ASP.NET Core поддержка из коробки для MVC.
```cs
builder.Services.AddMvc(options => 
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()))
```

либо добавляем атрибут `[AutoValidateAntiforgeryToken]` для каждого класса/метода

### Anti Forgery Token в AJAX, WebAPI, SPA

Принцип тот же, только выставление этих токенов, теперь в наших руках. 
На сервере генерируем скрытый токен. В JS находим его, и с запросом добавляем (например в заголовок или параметр)

### Cross Origin Request Sharing (CORS)

Если запрос делается с других сайтов, то могут возникнуть проблемы.
Чтобы их избежать, лучше указывать сайты, которые могут получить к серверу доступ.
Также указываем и методы HTTP, и заголовки (допустимые).

```
Access-Control-Allow-Origin: http://foo.example
Access-Control-Allow-Methods: POST, GET, OPTIONS
Access-Control-Allow-Headers: X-PINGOTHER, Content-Type
Access-Control-Max-Age: 86400
```

При запросе нужно также указывать, что знаем про CORS. Для fetch: 
```js
await fetch('server.com', {
    mode: 'cors', // no-cors, same-origin, cors
    credentials: 'same-origin', // include, omit, same-origin
})
```

Запросы 3 типов:
1) Простые - нет CORS preflight; GET, HEAD; POST; Content-Type (некоторые типы)
2) Предварительные запросы - запрос методом OPTIONS; PUT, DELETE, CONNECT, OPTIONS, TRACE, PATCH

Сначала посылается запрос доступа методом OPTIONS, в котором сервер говорит о методах доступа в заголовках:
- Access-Control-Allow-Origin
- Access-Control-Expose-Headers
- Access-Control-Max-Age
- Access-Control-Allow-Credentials
- Access-Control-Allow-Methods
- Access-Control-Allow-Headers

3) Предварительные запросы и переадресация (устарел и не поддерживается)

### Безопасность кук

Для кук, есть своя безопасность. Для каждой куки можно указать ее свойства:
- Secure - только по HTTPS/SSL
- HttpOnly - недоступны из JS
- Domain - хосты, на которые отсылаются куки
- Path - URL, который должен быть в запрашиваемом ресурсе
- SameSite - когда и как отправлять куки с межсайтовыми запросами, значения - Strict, Lax, None 

### SQL-инъекции.

НЕ ВСТАВЛЯТЬ/ИНТЕРПОЛИРОВАТЬ СТРОКИ В SQL ЗАПРОСАХ!!! ИСПОЛЬЗОВАТЬ ДРУГИЕ МЕТОДЫ:
- Параметризованные запросы: 

```sql
select * from accounts where id = @id;
```
- Проверять/санитизировать строки
- Использовать спец. библиотеки для санитизации, запросов
- Хранимые процедуры

8. REST. Web API.

Что такое web-сервисы
Протоколы веб-сервисов
SOAP
REST
Преимущества REST
Когда использовать REST
Что такое RESTful
Client-Server
Stateless
Cache
Layered System
Code-On-Demand
Принципы единого интерфейса
HATEOAS с примером
Реализация REST
Идемпотентность
HTTP методы
REST vs SOAP
Информирование потребителя
Contract First
Code First
Безопасность – уязвимости
Безопасность – аутентификация
Алгоритм Token-Based
Недостатки контроля доступа к объектам
Небезопасная десериализация
Отсутствие проверок и ограничений
Недостатки управления API
REST API Best Practices
Введение в Web API
Приложение
Атрибуты
Тестирование
Статусы
Возвращаемое значение в ASP.NET Core
IActionResult
Content negotiation
Accept
xml - возвращаемое значение
Аутентификация – JWT
JWT – сервисы и конвеер
JWT – генерация токена
Swagger / OpenAPI
Обработка ошибок.

9. Микросервисная архитектура

Общее описание
Сравнение с монолитом
Проблемы монолита
Преимущества микросервисов
Принципы проектирования
High Cohesion (высокая сплоченность)
Autonomous (автономность)
Business Domain Centric (сфокусированность на конкретной бизнес-задаче)
Resilience (отказоустойчивость)
Observable (наблюдаемость)
Automation (автоматизируемость)
Минусы микросервисной архитектуры
Реализация архитектуры
Модули
Слабая связанность
Взаимодействие микросервисов
Взаимодействие в .Net
Слабая связанность
Отказоустойчивость
API Gateway
Легкая заменяемость
Наблюдаемость
Health Check
Логгирование
