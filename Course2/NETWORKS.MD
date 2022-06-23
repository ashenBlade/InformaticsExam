# Вопросы по сетям

## Datacom

###  Data Communication Network Basis

Broadcast domain - все узлы в одном domain получают сообщение, отправленное одним.

Узлы коммункации:
- Switches, Коммутаторы
  - L2
  - Близкая коммуникация (ПК рядом)
  - Broadcast domain
- Routers, Маршрутизаторы
  - L3
  - Перенаправление пакетов, обнаружение путей, WAN, NAT, безопасность
  - Изоляция Broadcast domain
- Firewalls, Файрвол
  - Безопасность
  - Проверка уровня доступа
  - Управление коммункцией между сетями
  - VPN
  - Шифрование
- Wireless, Беспроводные
  - WLAN
  - Радиоволны, лазер, инфракрасные сигналы
  - IEEE 802.11 (Wi-Fi)
  - AP - Access Point (Fat, Fit)
  - AC - Access Controller

Типы сетей:
- LAN:
  - Несколько км^2
  - Подключение нескольких ПК 
  - Ethernet, Wi-Fi
  - Дом, офис
- MAN:
  - LAN, но больше
  - Подключение баз данных, серверов, других LAN
  - Ethernet (10-100 Gbit/s), WiMAX
  - Школа, сеть между домами администрации города 
- WAN

Типы топологий:
- Star, Звезда - все подключены к центральному
- Bus, Общая шина - все со всеми через 1 кабель
- Ring, Кольцо - каждый с передним и задним (образуют кольцо)

Топологии могут быть физическими и логическими. 
Причем физ. и логич. не обязательно одинаковы.

#### Вопросы
1. A star network is robust and therefore not prone to faults. ***false***

2. A router can break broadcast domains ***true***

3. What is the disadvantage of a tree network? 

- ***Nodes at higher layers will cause more serious network problems if they become faulty.***

4. Which functions does a firewall provide?
- ***Isolates networks of different security levels.*** 
- ***Uses security policies to implement access control between networks of different security levels.***
- ***Implements remote access.***
- ***Implements data encryption and virtual private network services.***
- ***Implements network address translation.***

###  Network Reference Model

OSI - Open System Interconnection.
ISO 7489 standard. Выпущен в 1984.
Состоит из 7 слоев:
1. Физический, Physical:
- Передача потока битов между устройствами
- Требования к физическому каналу: напряжение, скорость, разъем...
2. Канальный, Data:
- Определяет физические адреса 
- Инкапсуляция битов во октеты (8 шт), а октеты во фреймы
- Перенос данных в 1 сети 
- Использует MAC адреса (XX-XX-XX-XX-XX-XX)
- Проверка ошибок
3. Сетевой, Network
- Определяет логические адреса
- Нахождение путей для передачи данных
4. Транспортный уровень
- Connection/Non connection oriented data transmission
- Передача данных
- Проверка ошибок
5. Сессионный, Session
- Создание, поддержание, прекращение сессии
- Работает для уровня представления
6. Представления, Presentation
- Кодирование/Декодирование данных отправляемых приложением
7. Прикладной, Application
- Само приложение, логика

PDU - packet data unit, единица передачи данных (frame, bit, packet)

TCP/IP:
1. Канальный, Data Link: Ethernet, PPP:
- PDU - фрейм
- Ethernet, PPP, PPPoE
2. Сетевой, Network: 
- PDU - пакет
- IPv4, IPv6, ICMP, IGMP
3. Транспортный, Transport: 
- PDU - сегмент 
- TCP, UDP
4. Прикладной, Application: 
- HTTP
- FTP (передача файлов)
- Telnet (удаленный доступ)

Организации стандартизации:
- IETF, Internet Engineering Task Force
- IEEE, Institute of Electrical and Electronics Engineers
- ISO, International Organization for Standardization

TCP:
- PDU = segment
- Пакет
  1. Source port(откуда), 16
  2. Destination port(куда), 16
  3. Sequence number(какой пакет передаю), 32
  4. Acknowledgment number(какой пакет собираюсь принять = последний успешно полученный + 1), 32
  5. Header length(размер TCP заголовка, если дополнительного ничего нет, то = 5), 32
  6. Reserved(для будущего), 32
  7. Control bits(флаги для FIN, ACK, SYN)
  8. Window (размер передаваемого окна), 16
  9. Checksum(для проверки, обязателен), 16
- TCP handshake
  1. A посылает B пакет с флагом SYN (sequence number - a (рандомный), acknowledgement - 0)
  2. B отвечает A пакет с флагом SYN + ACK (sequence number - b (рандомный), acknowledgement - a + 1)
  3. А посылает B пает с флагом ACK (sequence number - a + 1, acknowledgement number - b + 1)
  4. Соединение установлено
- Sliding window
  - Отправка сообщений целым окном (буффером)
  - Если какое-то сообщение не дошло, то новое окно отправляется, начиная с первого недошедшего
- TCP shutdown
  1. A посылает B пакет с FIN
  2. B отвечает A с флагом ACK
  3. B проверяет на необходимость дослать данные
     1. Если есть - шлет данные, затем пакет с FIN
     2. Если нет - сразу пакет с FIN
  4. A посылает B пакет с ACK
  5. Соединение закрыто

MAC:
- 6 групп из 2 раделенных 16-ых чисел (0-F)
- XX-XX-XX-XX-XX-XX
- Работает на канальном уровне

ARP, Address Resolution Protocol:
- Нахождение MAC данного IP адреса
- Поддержка, кэширование найденных адресов (ARP entries)
- Нахождение дупликатов IP в сегменте
- Алгоритм:
  1. Проверка ARP кэша:
     - Запись существует
     - Не истек срок валидности
     - Если из другой сети - адрес шлюза (gateway)
  2. Посылка ARP Request:
     - В Ethernet заголовке - Destination MAC = FF-FF-FF-FF-FF-FF
     - В ARP Request заголовке - Destination MAC = 00-00-00-00-00-00
     - ARP Request message = Source MAC, Source IP, Destination MAC, Destination IP
     - Broadcast
  3. Получение хостами ARP Request:
     - Обновление своих ARP entries
  4. Посылка ARP Reply:
     - IP, MAC отправителя - свои (которые нужно было узнать)
     - IP, MAC получателя - кто запрашивал
     - Unicast 
  5. Обновление ARP entry

Физический уровень:
- PDU: bitstream, поток битов
- Нужно стандартизировать физические особенности: напряжение, кабель, входы
- Передача:
  - Витая пара:
    - STP: shielded twisted pair
    - UTP: unshielded twisted pair
  - Оптоволокно
  - Последовательный кабель (для WAN)
  - Беспроводная передача (радио-канал)

Процесс коммуникации:
1. Отправитель передает данные нижележащему уровню (Application -> Transport -> Network ...)
2. Каждый слой добавляет информацию о своем уровне 
3. Доходим до физического слоя - производим саму передачу 
4. Получатель развертывает сообщение по слоям в соответствии с использованными протоколами (Data Link -> Network -> Transport ...)

В общем случае:
- Switch - передача в текущей сети, используя заголовок L2
- Router - передача между сетями, используя заголовок L3

Вопросы:
1. A MAC address is 48 bits (6 bytes) in length and consists of 12 hexadecimal digits.
- *true*
2. An ARP Reply packet is broadcast so that all hosts can receive it.
- *false*
3. Common data link layer protocols include Ethernet, PPPoE, and PPP.
- *true*
4. The Open System Interconnection (OSI) reference model divides a network into seven layers. Which of the following lists the seven layers in the correct order, from bottom to top?
- *Physical, Data link, Network, Transport, Session, Presentation, Application*
5. Which of the following port numbers is used by Telnet?
- *23*
6. What are functions of the network layer?
- *Provide logical addresses for network devices*
- *Send packets from source hosts to destination hosts*
- *Route and forward data packets*
7. Which of the following statements are true about the layers in the OSI reference model?
- *Application layer: provides network services for applications and is closest to end users.*
- *Transport layer: implements connection-oriented and non-connection-oriented data transmission, as well as error detection before retransmission.*
- *Network layer: defines logical addresses for routers to determine paths and transmits data from source networks to destination networks.*
- *Session layer: establishes, manages, and terminates sessions between entities at the presentation layer.*

###  Huawei VRP

VRP - ОС для устройств Huawei:
- UI + управление
- Control Plane + Forwarding Plane
- Коммуникация между другими устройствами

Файловая система: 
- Файл конфигурации (Команды при запуске)
- PAF файл (Поддержка фичей конкретного устройства)
- Патч файл
- Системные файлы

Хранение доп. информации:
- SD Card (конфигурация, системные файлы)
- USB (для увеличения объема памяти)
- SDRAM ~ память ПК
- Flash (конфигурация, системные файлы)
- NVRAM - Non Volatile (не изменяемая)

Управление устройством + подключение:
- Веб интерфейс (HTTP)
- CLI (SSH, Telnet, Console port)

VRP UI:
- Console UI - через порт консоли/последовательный
- VTY UI - через SSH(STelnet)/Telnet

Уровни привилегий:
- 0 - Visit (диагностика сети (ping, tracert) + некоторые display)
- 1 - Monitoring (display)
- 2 - Configuration
- 3-15 - Management (системные операции, дебаг, FTP...)

Команды:
- Все организовано в виде *-view:
  - system-view
  - user-view
  - когда вводишь interface GigabitEthernet 0/0/0 - входишь в GigabitEthernet-0/0/0-view
  - Каждый view - поддерживает свои команды и свой контекст
- Командная строка:
  - Tab - autocomplete
  - ? - команды начинающиеся на предыдущий ввод
  - Есть шорткаты: Ctrl+U, Ctrl+A, Ctrl+C, Ctrl+X....
  - Можно зарегистрировать свои шорткаты: Ctrl+L
- Откат команды - undo + "команда для отката"

Базовые команды:
- pwd - текущий путь
- dir - файлы в текущей папке
- more - содержимое файла
- cd - перейти по пути
- mkdir - создать папку
- ....

Системные команды:
- Изменить название устройства - `sysname *name*`
- Изменить уровень привилегий/доступа - `command-privilege level *level-number* view *view-name* *command-name*`
- Состояние CPU - `display cpu-usage`

Первоначальная настройка:
1. Дать название устройству - `sysname *Name*`
2. Настроить часовой пояс - `clock timezone *Timezone*`
3. Настроить время/дату - `clock datetime *date/time*`
4. Уровень привилегий - `command-priviledge level *level* view *для какого view*`
5. Логин/Пароль для пользователей - `user-interace vty 0 4`
6. Указать максимальное время простоя - `idle-timeout *timeout*`

Сохранение настроек:
1. Входим в User-View (`return`)
2. `save`

Вопросы:
1. There are two commonly used device management modes: CLI and web system.
- *true*
2. Which of the following statements about command functions is false?
- *undo //Deletes a file*
3. Which of the following are types of storage device?
- *SDRAM*
- *Flash*
- *NVRAM*
- *SD card*
- *USB Flash drive*
4. Which of the following functions are provided by the VRP?
- *Provides a unified user interface and a unified management interface.*
- *Implements functions of the control plane and defines interface standards of the forwarding plane.*
- *Implements communication between the device forwarding plane and VRP control plane.*
- *Eliminates the differences between the link layer and network layer of each product.*

###  Network Layer Protocols and IP Addressing

IP - Internet Protocol.

IPv4:
- Заголовок:
  1. Версия
     - 4 bits
     - Значение = 4
  2. Длина, Header Length
     - 4 bits
  3. Тип сервиса, Type Of Service
     - 8 bits
     - Работает при включенном QoS
  4. Общая длина (включая заголовок), Total Length
     - 16 bits
     - В октетах
     - Минимальное - 20
     - Максимальное - 65535
  5. Идентификатор, Identification
     - 16 bits
     - Назначается отправителем для корректного восстановления пакета
  6. Флаги, Flags
     - 3 bits
     - [0] всегда равен 0 (зарезирвирован)
     - [1] DF (Don't fragment) - запрет на фрагментацию
     - [2] MF (More fragments) - есть ли еще пакеты
  7. Offset:
     - 12 bits
     - При разбиении пакета
     - Относительная позиция в исходном пакете (который разбили, а не передают)
  8. TTL
     - 8 bits
     - Время жизни - макс. кол-во хопов (роутеров), которое может пройти
     - Если пришел с 0, то отбрасывать + послать ICMP error, иначе - декрементировать и передать
  9. Протокол, Protocol
     - 8 bits
     - Какой протокол инксапсулирует (TCP(6), UDP(17), ICMP(1)...)
  10. Header checksum
      - 16 bits
  11. SourceIP
      - 32 bits
  12. DestinationIP
      - 32 bits
  13. Options:
      - 1 - 32 bits
      - Необязателен
      - Макс. - 10 параметров
  14. Padding:
      - Занимает оставшееся место для выравнивания строки с параметром по 32 bits
  15. Сами данные
- Сам загловок (без данных) имеет размеры:
  - Фиксированный - 20 байт
  - С параметрами - 20 + (0 - 40 байт)
- Адрес:
  - 32 bits
  - 4 байта разделенные точками
  - 0.0.0.0 - 255.255.255.255
  - Разделяется на сетевую и хостовую части. Сетевая - адрес сети, Хостовая - адрес хоста (компа).
  - Для определения сети/хоста используется маска - 32 бита, сначала 1 затем 0, обычно представляется в виде числа - кол-ва единиц в маске
- Классификация
  - Различия в количестве единиц перед первым 0 в адресе (most significant bits)
  - Class A
    - 0.0.0.0 - 127.255.255.255
    - 0NNNNNNN.X.X.X
    - /8
  - Class B
    - 128.0.0.0 - 192.255.255.255
    - 10NNNNNN.X.X.X
    - /16
  - Class C
    - 192.0.0.0 - 223.255.255.255
    - 110NNNNN.X.X.X
    - /24
  - Class D
    - 224.0.0.0 - 239.255.255.255
    - 1110NNNN.X.X.X
    - Для мультикаста
  - Class E
    - 240.0.0.0 - 255.255.255.255
    - 1111NNNN.X.X.X
    - Зарезирвировано, для исследований
- Типы адресов
  - Адрес сети
    - Адрес сети X, адрес хоста - 0
    - Не может быть отдан хосту
  - Broadcast
    - Адрес сети X, адрес хоста - 1
    - Не может быть отдан хосту
  - "Доступный" адрес
    - Может быть отдан хосту
    - Все кроме выше перечисленных (в кратце все, у которых адрес хоста не все 0 или 1)
    - Кол-во доступных = 2^n - 1, n - длина хостовой части в битах (32 - длина маски)
  - Публичный, Белый IP
    - Назначается IANA (для каждого географического региона есть свой представитель)
  - Приватный, Частный, Серый IP
    - Для тех, что не выходят в Интернет (для обхода использовать NAT)
    - 10.0.0.0 - 10.255.255.255
    - 172.16.0.0 - 172.31.255.255
    - 192.168.0.0 - 192.168.255.255
  - Особые
    - Limited broadcast:
      - 255.255.255.255
      - Для всех в текущей сети (не выходят за границы шлюзов)
    - Any IP
      - 0.0.0.0
      - Для разных контекстов - разные значения (путь по умолчанию, текущий все адреса на локальном компьютере)
    - Loopback
      - 127.0.0.0/8
      - Прослушивается на текущем ПК
    - Link-local
      - 169.254.0.0/24
      - Если не выделяется адрес при помощи DHCP, клиент выделяет себе адрес сам из этой сети (рандомом)
      - 

Subnetting - объединяем хосты в группы под определенной маской.
Для объединения нескольких сетей в одну:
1. Получаем маски всех сетей
2. Находим самую длинную
3. Вычитаем 1 (чтобы не было коллизий)
4. Объединяем сети под этой новой маской (сами разберутся куда отсылать дальше)


ICMP - Internet Control Message Protocol. Для управления, получения статуса в сети.
Некоторые функции:
- Редирект. Перенаправление.
Например, отправляю пакет на default gateway, он понимает, что пакет нужно отправть на другой шлюз и шлет мне ICMP Redirect.
- Обнаружение ошибок. Например, кончился TTL (используется в ping).
- Отчет об ошибках
  - Циклы в сети
  - Destination unreachable

Команды 
- Настройка адреса - `ip address *ip-address* *mask*`
- Просмотр таблицы маршрутизации - `display ip routing-table`
  - Только статические маршруты - `display ip routing-table protocol static`

Вопросы
1. The router discards packets with a TTL value of 0.
- *true*
2. Which of the following is a private IP address?
- *172.17.1.254
3. How many IP addresses are available in network segment 172.16.0.0/30?
- *2*
4. Which of the following ICMP packets is used to detect the connectivity between the source and destination IP addresses?
- *ICMP Echo*
5. Which of the following IP addresses can be manually configured and used by host interfaces?
- *10.2.3.4*
- *192.168.100.254*

###  IP Routing Basics

Для адресации к конкретному хосту в конкретной сети используются IP адреса.
Каждому устройству назначается свой собственный адрес.

Устройства, использующиеся при коммуникации:
- Узел, Хост - тот, кому назначается сообщение, конечный получатель
- Шлюз, Gateway - устройство для коммуникации между сетями (портал в другое измерение)
- Маршрутизатор - устройство для построения маршрутов IP сообщений
  - Может быть и шлюзом, и узлом, и конечным устройством

Для определения пути сообщения используется таблица маршрутизации.
Записи в ней должны содержать (обязательно):
- Destination - куда предназначается
- Mask - определение сети/хоста получателя (без них не понятно)
- Next hop - по какому следующему адресу сообщение посылать (IP)
- Outbound interface - на какой физический интерфейс подавать сообщение (Wi-Fi, Gigabit Ethernet...)

Таблица может содержать дополнительно:
- Protocol - откуда получен путь
- Pre(ference) - число, показывающее предпочтительность пути. Чем меньше, тем лучше.
- Cost - стоимость пути, метрика. Если в одну и ту же точку ведут несколько одинаковых по Pre путей, то используется Cost. Чем меньше, тем лучше.

AS (Autonomous system) - автономная система.
Группа взаимосвязанных хостов, роутеров, образующих единую систему.

Путь может проходить несколькими способами:
- Direct, Прямой 
  - Соединяет хост напрямую в той же сети, что и роутер
  - Соединяет другую подсеть напрямую - не транзитивно
  - Определяется автоматически
  - Использует ARP для нахождения MAC адреса
  - Default Pre - 0
- Static, Статический
  - Настраивается администратором вручную
  - Default Pre - 60
  - `ip route-static *ip-address* *mask* *next-hop*`
  - Указание шлюза по умолчанию - `ip route-static 0.0.0.0 *default-gateway-ip-address*`
  - Типичное использование - выходной шлюз из корпоративной сети(выход в интернет, в другие корпоративные сети, выход на VPN)
- Dynamic, Динамический 
  - Пути обнаруживается с помощью протоколов (OSPF, IS-IS, BGP)
  - По алгоритмам:
    - Distance-vector (RIP)
    - Link-state (OSPF, IS-IS)
  - По области применения:
    - IGP (Interior Gateway Protocol) - внутри AS
    - EGP (Exterior Gateway Protocol) - между AS
  - OSPF internal default Pre - 10
  - OSPF external default Pre - 150

Возможные граничные случаи:
- Рекурсия
  1. A -> B (1.1.1.1 -> 1.1.1.2)
  2. B -> A (1.1.1.2 - нет, отправляю по Default -> 1.1.1.1)
- Одинаковые по стоимости пути (Equal-Cost)
  - На один и тот же маршрут - разные Next-Hop с одинаковыми стоимостями
  - Распределение трафика между ними - Load Balancing
- Запасные пути, Floating Route
  - Если использующийся оптимальный путь обрубился - использовать запасной

CIDR (Classless Inter-Domain Routing) - безклассовая маршрутизация:
- ~ Route Aggregation, Route Summarization
- Замена классовой адресации (A, B, C, D, E)
- Использует маски переменной длины (VLSM - variable length subnet mask)
- Зачем хранить информацию для различных сетей, если они все идут через один и тот же путь 
- Разделение адресного пространства используя суммаризацию (объединение масок из различных сетей) 
  1. Находим адреса с одинаковыми NextHop
  2. Среди них выбираем те, у которых есть общая часть в адресе сети
  3. Берем маску длиной в эту общую часть
  4. Объединяем сети - всем адресам ставим новую, найденную маску
- 192.168.12.0/22 + 192.168.10.0/23 + 192.168.9.0/21 + 192.168.14/0/23 = 192.168.8.0/21
- В результате: минимизация таблицы маршрутизации
- Может возникнуть цикл (для предотвращения - отбрасывание пакетов, приводящих к циклам)

Вопросы
1. The summary route of 172.16.1.0/24, 172.16.2.0/24, and 172.16.5.0/24 is 172.16.0.0/22.
- *false* - правильно 172.16.0.0/23
2. Which of the following fields is not included in the output of the display ip routing-table command?
- *AdvRouter*
3. What is the default preference of static routes?
- *60*
4. According to the longest match rule, which of the following routes will the data packet destined for 172.16.10.1 match?
- *172.16.10.0/24*
5. Which of the following are link-state routing protocols?
- *OSPF*
- *IS-IS*

###  OSPF Basics

Алгоритмы маршрутизации:
- Distance-vector
  - Передача возможных путей передачи
  - Без информации о топологии сети
- Link-state
  - Передача LSA (Link-State Advertisement) - информации о каждой напрямую присоединенной сети (название, стоимость...)
  - Каждый строит у себя топологию всей сети
    
OSPF - Open Shortest Path First:
- RFC 2328
- Использует SPF - shortest path first алгоритм 
- Поддерживает маски переменной длины
- Существует несколько версий (OSPFv2, OSPFv3) 

Типы сообщений:
- Hello - обнаружение соседей, проверка параметров, мониторинг доступности...
- LSA (Link state advertisement) - сообщение с инфорацией о своей + присоединенных сетях (офиц. Объявление о состоянии канала). Существует несколько типов.
- LSR (Link state request) - запрос определенных записей о состоянии канала (для синхронизации)
- LSU (Link state update) - обновление записей о состоянии канала (ответ на LSR)
- LSAck (Link state Acknowledgement) - подтверждение получения пакета
- DBD (Database Description) - описание базы данных топологии

LSDB (Link state database) - база данных с информацией о топологии:
- Type - тип LSA, который добавил информацию
- LinkStateID
- AdvRouter - кто отправил LSA
- Age
- Len
- Sequence
- Metric

OSPF Routing Table - таблица маршрутизации только для OSPF

Типы маршрутизаторов:
- DR - Designated Router - чтобы избежать заводнения LSA
  - Устанавливают связь с другими роутерами
  - Если параметр роутера = 0, то никогда не станет DR
  - Выбор: (DR Priority, Router ID) - первый после сортировки во убыванию
(самый большой DR Priority, затем самый большой Router ID)
- BDR (Backup Designated Router) - если DR вышел из строя
  - Когда он заменяет DR, проводятся выборы нового BDR
- DRother, Internal - простой роутер
  - Между собой связь не устанавливают
- ABR, Area Border Router - принадлежит к нескольким Area, но как минимум один - к Backbone
  - ~ Входные точки в Backbone Area 
- Backbone router - присоединяет Backbone area
- ASBR, AS Boundary Router - общается с другими AS. 
  - Напрямую присоединять внешние AS - нельзя

Концепции OSPF:
- Area - логическая группа, определяемая своим IP. Всегда существует Backbone Area - 0.0.0.0. Если Area - одна, то 
  - Кол-во DRothers сильно увеличивается. Чтобы избежать нужно разбивать на отдельные Area
  - Роутер должен строить топологию для всей сети, а она будет большой. Нужно дробить.
  - Производительность DR - падает из-за большого кол-ва DRothers
  - Типы Area:
    - Backbone, Магистральная - 0.0.0.0, ядро сети, должна быть всегда
    - Standard, Стандартная - обычная зона
    - Stub, Тупиковая - не принимает информацию о внешних сетях (не выходит в свет/интернет/мир)
    - Totally stubby - не принимает информацию о внешних сетях И маршруты других зон (Прям тупик, говорят только с одной зоной и туда все посылают)
    - Not-so-stubby (NSSA) - ~ Stub, но может быть ASBR
    - Totally NSSA - ~NSSA, но не передает информацию о других зонах
- Domain - сеть, состоящая из нескольких соединенных OSPF сетей
- RouterID - идентификация роутера в своей Area. Настраивается вручную
- Cost Value - метрика для выбора пути. По умолчанию, 100 Mbit/s / Bandwidth

Алгоритм OSPF(самый простой, без DR/BDR и прочего):
1. Обменяться HELLO пакетами друг с другом
2. Установить соседство - добавить каждого в свою таблицу соседей
3. Сформировать свой LSA пакет:
   - Свой Router ID
   - Соседские Router ID
   - Сеть
   - Префикс сети
   - Тип сети (P2P, MA...)
   - Метрика (стоимость линка)
4. Флудингом (лавинно) отправить LSA другим соседям
5. Обновить свою LSDB пришедшими LSA
6. Построить топологию сети с помощью составленной LSDB
7. Найти кратчайшие пути до всех других роутеров

При потере соединения с каким-нибудь роутером:
1. Обнаруживший потерю - начать флудить LSA с сообщением о потере
2. Сброс своей LSDB
3. Начать построение сети заново (алгоритм выше)

Замечания:
- OSPF напрямую инкапсулируется в IP (не TCP, UDP)
- Для каждого типа сетей  (Broadcast, P2P, NBMA...) - свои заморочки. 
Для сетей NBMA - Non-Broadcast Multiple Access (одной шиной соединены), таймеры другие - нужно больше времени, т.к. других надо ждать, а не то сообщение сбиваются и ломаются. 
Рассказанное выше относится для сетей Broadcast (Ethernet, Wi-Fi)
- Аутентификацию сообщений (Plain text/MD5)
- Безклассовая маршрутизация (CIDR)
- Поддерживает балансировку нагрузки для путей одинаковой стоимости

Таймеры:
- HelloInternal, Рассылка пакетов HELLO (я живой!) - 10с
- Dead-Time, RouterDeadInterval, Ожидание пакетов HELLO, не менее 4 интервалов рассылки (Hello-Internal) (они живые?) - 40с
- Wait Timer - по его истичении выбирается новый DR - 40с
- Retransmit-Interval, RxmtInterval, Повторная передача LSA (при неудачи посылки LSA, время между отправками) - 5с, макс 60мин
- Transmit-Delay, Время передачи LSA (время корректности записи = время содержания записи в таблице + время передачи(Transmit-Delay)) - 1с (для всех каналов)

Вопросы
1. On an MA network, the final state of the OSPF neighbor relationship between DR others is 2-way.
- *true* - в данном случае MA значит соединены одним проводом, и в результате получается отношение 2-way - каждый получил от других Hello пакет
2. Which of the following packets are used by OSPF to discover and maintain neighbor relationships?
- *Hello*
3. By default, what are the OSPF cost values of a serial port working at 1.544 Mbit/s, FE interface, and GE interface, respectively?
- *64, 1, 1*
4. Which of the following tables is used by OSPF to store link status information?
- *OSPF LSDB*
5. Which of the following are OSPF network types?
- *P2P*
- *P2MP*
- *NBMA*
- *Broadcast*

###  Ethernet Switching Basics

Ethernet - протокол L1 и L2. 

Collision Domain (Домен коллизий) - множество соединенных узлов с одним пространством распространения сообщений (крч, отправляют сообщения по одному кабелю).
Просто - если один шлет, то все другие принимают, а если несколько шлет - то сообщения "бьются" друг о друга и ломаются.

CSMA/CD (Carrier Sense Multiple Access with Collision Detection) - коллизии только обнаруживаются, а не исправляются:
1. Постоянно прослушиваю канал. Слушаю несущую частоту.
   1. Если линия свободна - шлю сообщения
   2. Иначе жду освобождения
2. Обнаружилась коллизия:
   1. Оба устройства прекращают слать данные
   2. Кто-то шлет jam последовательность - сигнал о том, что произошла коллизия
   3. Ждем какой-то (случайный) период времени
   4. Начинаем слать заново

Вкратце: слушаем перед/во время передачи, при коллизии - стоп и ждем рандомное время

Broadcast domain - область, в которой все получают Broadcast сообщения по L2.
Нужно слать Ethernet фреймы с MAC = FF-FF-FF-FF-FF-FF.
Можно образовать:
- Подсоединяя все узлы одним кабелем
- Соединяя хосты через хабы, концентраторы, повторители

NIC (Network Interface Card) - устройство принимающее/посылающее Ethernet кадры

Кадры:
- Существует в 2 версиях - Ethernet_II и IEEE 802.3. В IEEE добавлены поля LLC и SNAP
- Ethernet_II:
  1. Destination MAC, 6B - кому
  2. Source MAC, 6B - от кого
  3. Type, 2B - какой протокол выше (0x0800 - IPv4, 0x0806 - ARP)
  4. User Data, 36-1500B
  5. Frame Check Sum (FCS), 4B
- IEEE 802.3:
  1. Destination MAC, 6B - кому
  2. Source MAC, 6B - от кого
  3. Length, 2B - длина заголовка
  4. LLC, Logical Link Control:
     1. DSAP, Destination Service Access Point, 1B - ~ кому предназначается. Если инзлежащий - IP, то 0x06.
     2. SSAP, Source Service Access Point, 1B - откуда. Если низлежащий - IP, то 0x06.
     3. Ctrl, 1B - обычно 0x03.
  5. SNAP, Subnetwork Access Protocol, 2B - если DSAP, SSAP - 0xAA
     1. OUI, 3B
     2. Protocol ID, 2B
  6. User Data, 36-1500B
  7. Frame Check Sum (FCS), 4B

MAC, Media Access Control - для идентификации NIC:
- 6 байтов
- XX-XX-XX-XX-XX-XX
- Первые 3 байта - OUI, Organization Unique Identifier, ID производителя
- Вторые 3 байта - CID, Company ID, назначается производителем

Типы MAC:
- Unicast - идентификация узла, глобально уникален:
  - Ethernet frame, у которого уникальный MAC называется уникальным  
- Broadcast - всем узлам в сети (на L2 уровне) - FF-FF-FF-FF-FF-FF
  - Ethernet frame, у которого broadcast MAC называется multicast
  - Для групповой рассылки
- Multicast - отображаются в Multicast IP
  - Начинаются на 0x01005e + следующий (25) бит равен 0, остальное - из IP адреса
  - Multicast IP - 224.0.0.0/4 -> берем последние 23 бита IP и вставляем в последние MAC

Коммутаторы:
- Уровни работы:
  - L2:
    - Только Ethernet frame
    - Организуют Broadcast domain
    - Изолируют Collision domain
  - L3:
    - Может читать IP заголовок (всм, заговок 3 уровня)
- Для коммутации используются таблицы коммутации:
  - MAC адрес назначения
  - Интерфейс/порт куда отправлять (физический, GigabitEthernet0/0/0...)
- Заполнение таблицы - Обратное обучение:
0. Таблица не заполнена. Ни о ком не знаю
1. Получаю Ethernet frame.
2. Добавляю адрес отправителя в таблицу коммутации
3. Адрес получателя есть в таблице?:
   - Нет:
     1. Отправляю на все порты фрейм с требуемым MAC (получают все, кроме отправителя)
     2. Обладатель требуемого MAC отправляет на коммутатор Ethernet frame со своими данными
     3. Запись данных в таблицу коммутации
4. Отправить данные на требуемый адрес


Состояния порта коммутатора:
- Flooding - отправка всем (не знаю кто получатель, запишу его адрес потом)
  - Если получаю неизвестный MAC
  - Если получаю Broadcast MAC (FF-FF-FF-FF-FF-FF)
- Forwarding - отправка конкретному получателю (запись о нем есть)
- Discarding - пошел нахуй!! (отбрасываю полученные кадры)
  - Если полученный MAC - unicast и по таблице коммутации перенаправляется на другой коммутатор
  - Т.к. может случиться цикл - появляется запись в получающем коммутаторе, и когда в следующий раз фрейм придет к нему, то перенаправит обратно, а тот еще раз и так далее....
  
Процесс коммуникации:
0. Скорее всего я использую ARP кэш для хранения пары IP - MAC. Вначале он пуст.
1. Отправляю ARP запрос (В самом пакете MAC - Broadcast)
2. В процессе отправки/получения ответа заполняются необходимые таблицы коммутации
3. Я получил ответ. Узнал требуемый MAC адрес получателя.
4. Отправляю сами данные - настоящий Ethernet frame с только что узнанным MAC адресом получателя

Вопросы
1. A switch floods unknown unicast frames and frames whose destination MAC address is a broadcast MAC address.
- *true* - коммутатор отбрасывает кадры 
2. What type of MAC address is 01-00-5e-00-00-01?
- *Multicast* - начинется на 01-00-5e + 25 бит = 0
3. Which of the following actions does a switch take by default after it receives an unknown unicast frame?
- *Learns the mapping between the source MAC address and interface that receives this data frame, and floods this data frame. correct*
4. Which of the following ARP packets is used to request the MAC address corresponding to an IP address?
- *ARP Request*
5. Which of the following fields are contained in an Ethernet frame in the IEEE 802.3 format?
- *Source MAC*
- *Destination MAC*
- *FCS*
- *Length*

###  VLAN Principles and Configuration

Проблемы Ethernet:
- Создает Broadcast domain:
  - В нашей сети все получат фрейм - даже те кому он нах*й не нужон!
- Безопасность:
  - Все могут прочитать отправляемые данные: если неизвестен, то отправляется всем + сами коммутаторы получают

VLAN, Virtual LAN - технология создания виртуальных (изолированных локальных сетей, там только MAC - не IP).
IEEE 802.1Q - добавляет поле VLAN Tag (4 байта) в Ethernet Frame. 
Можем разделить большие сети на несколько меньших:
- Данные получают только те кому они реально могут предназначаться
- Уменьшение загруженности трафика
- Если одна сеть упадет - не затронет другие

Реализация:
- С каждым портом коммутатора (присоединенного к конечному хосту) ассоциирован VLAN, к которому он закреплен.
- При получении кадра с этого порта, к его Ethernet frame добавляется VLAN Tag и работа продолжается. 
- VLAN Tag добавляется после Source MAC, перед Length/Type:
  - TPID, 2 байта - тип кадра, для совместимости с другими версиями (0x0800 - обычный Ethernet frame), здесь равен 0x8100 - IEEE 802.1Q
  - Pri(ority), 3 бита - приоритет кадра, для QoS
  - CFI, Canonical Format Indicator, 1 бит:
    - 0 - канонический кадр
    - 1 - не канонический кадр (FDDI, Token Ring)
  - VLAN ID, 12 бит - к какому VLAN относится
    - 1 - 4094
    - 0 и 4095 - зарезервированы

Компьютеры шлют кадры без VLAN тэгов. 
Их назначением занимается коммутатор.
Варианты назначения VLAN ID:
- По порту получателю.
  - PVID - Port VLAN ID. От его лица (его значение в VLAN ID) будут отправляться нетегированные фреймы
  - Настроить PVID на каждом физическом порте коммутатора
  - PVID: 1-4096. По умолчанию - 1
  - По типу интерфейса:
    - Access - к конечному пользователю
      - От клиента:
        - Без тега - тэгируется 
        - Тэгированный - проверяется VID и PVID
      - Клиенту: 
        - Тэгированный - проверяется VID и PVID и возвращается без тега 
    - Trunk - к другому роутеру, коммутатору, AP....
      - От клиента:
        - Без тега - тэгируется
        - Тэгированный - проверяется VID и PVID
      - Клиенту:
        - Тэгированный - убрать VLAN tag если VID = PVID интерфейса
    - Hybrid - и к тем, и к другим может быть подключен
      - От клиента
        - Без тега - тэгируется, затем проверить доступ
        - Тэгированный - проверить VID и PVID
      - Клиенту
        - Без тега - отправить
        - Тэгированный - в зависимости от получателя (убрать или нет)
- По MAC адресу отправителя
  - Заполнить таблицу отображений MAC - VLAN ID на каждом коммутаторе

Команды:
- `vlan *vlan id/batch*` - создание VLAN
- `interface GigabitEthernet 0/0/0` - заходим на требуемый интерфейс
- Access:
  - `port link-type access`
  - `port default vlan *vlan id*` - назначаемый VLAN ID проходящим фреймам
- Trunk:
  - `port link-type trunk`
  - `port trunk pvid vlan *vlan id*` - назначение PVID порту
  - `port trunk allow-pass vlan *ids*` - разрешить доступ VLAN
- Hybrid:
  - `port link-type hybrid`
  - `port hybrid pvid vlad *id*` - назначение PVID
  - `port hybrid untagged vlan *ids*` - какие назначать нетегированным

Вопросы
1. An access interface cannot process VLAN-tagged data frames, and immediately discards them upon receipt.
- *False* - пропускает, только если тэг в полученном допустимый, иначе отклоняет
2. What is the TPID value of an 802.1Q-tagged frame?
- *0x8100* - это база!
3. Which of the following is a valid VLAN ID?
- *4094*
4. Based on which of the following cannot VLANs be assigned?
- *Transport-layer protocol* - VLAN работает на L2
5. Which of the following interfaces can process data frames carrying multiple VLAN tags?
- *Trunk*
- *Hybrid* - Access только 1 разрешенный, а Bridge - не существует

###  STP Principles and Configuration

STP, Spanning Tree Protocol - протокол остовного/покрывающего дерева.
- Работает на L2.
- IEEE 802.1D.
- Основная задача - избавление от петель в топологии сети при коммуникации путем блокировки соединения.
- Используется в Ethernet.

Последствия петель
- Broadcast storm - если куда-то пришел Broadcast MAC, то он отправляется всем, а в цикле он будет путешествовать всегда1
- MAC address flapping - Ethernet фрейм может прийти с разных портов (т. к. круг/цикл) и из-за этого постоянно меняется таблица коммутации

Термины:
- BID, Bridge ID = Приоритет (2 байта) + MAC (6 байт):
  - Приоритет по умолчанию - 32768
  - Должен делиться на 4096
  - 
- RB, Root Bridge
  - Корень построенного дерева
  - Выбирается с наименьшим BID
- Cost - стоимость пути
  - С большей пропускной способностью - меньше стоимость
  - Huawei по умолчанию использует IEEE 802.1t для вычисления (есть таблица)
- RPC, Root Path Cost
  - Стоимость пути до корня = сумма стоимостей
- PID, Port ID = Приоритет (4 бита) + Номер порта (12 бит)
  - Приоритет: 
    - 0-240, должен быть кратен 16
    - По умолчанию - 128 (Huawei)
  - Для установления роли порта
- BPDU, Bridge Protocol Data Unit
  - Configuration BPDU
    - Для построения дерева, выбора RB
    - После построения дерева, шлет только RB
  - TCN BPDU, Topology Changed Notification
    - Шлется к RB, для уведомления об изменении топологии

Роли портов:
- Designated - к другим подключенным сетям (соединяет другие роутеры)
  - Соединяет другие участики сети (т.е. другие деревья, т.к. мы строим дерево)
  - У Root все порты Designated
- Root - к RB (соединяет себя с корнем)
  - Самый короткий маршрут к Root
- Alternate - заблокирован (не Root или Designated, избыточный)
  - Не передает никакой информации, но принимает пакеты от других для отслеживания состояния

Алгоритм STP:
1. Роутер включается и назначает себя RB
2. Шлет другим свой BPDU
3. При получении BPDU от других
   1. Сравнивает полученный BID со своим
   2. Если полученный BID - меньше, то он становится RB
4. Выбрать глобальный RB, когда топология больше не меняется
5. Теперь только RB может слать BPDU
6. Выбрать свой Root порт на каждом из роутеров
7. Выбрать Designated порты на основании полученных от RB BPDU
   1. Выбирается порт с наименьшим RPC
   2. При одинаковых - выбрать с наименьшим PID
8. Заблокировать остальные порты (они Alternate)

Состояния портов:
- Disabled - отключен
- Blocking - только слушает BPDU (ничего не шлет и не принимает другого)
- Listening - слушает BPDU
- Learning - слушает служебные фреймы, но не передает их. После изучает MAC адреса
- Forwarding - делает всю работу
  - Только для Root и Designated.
  - У Root все порты в Forwarding, даже если роль - Alternate

Причины изменения топологии:
- Отказ корня (обычно занимает 50с):
  1. Корень отказал - остальные не получают BPDU
  2. Ждут MaxAge Timer
  3. Начинается выбор нового RB
- Потеря соединения с Root, но есть запасной
  1. Работать начинает Alternate порт, соединенный с RB
  2. Ждем 2 * FowardDelay Timer (30с) пока новый порт обучится
- Потеря соединения с Root
  1. Ждем MaxAge Timer
  2. Выбираем себя RB
  3. Шлем свои BPDU другим
  4. Т.к. в предыдущий раз Root получил высший приоритет, то он останется Root
  5. Новый порт, подключенный к запасному станет Root или Designated
  
STP имеет большое время схождения - 50с (2 * ForwardDelay + MaxAge). 
Чтобы избавиться от этой проблемы был создан RSTP - Rapid STP.
Изменения:
- 3 состояния портов:
  - Discarding
  - Learning
  - Forwarding
- 5 ролей портов:
  - Root
  - Designated
  - Alternate
  - Backup - 
  - Edge - напрямую соединен с клиентом
- Меньше интервал рассылки BPDU
- Изменение формата BPDU


Таймеры:
- MaxAge Timer - 20с, время ожидания BPDU
- ForwardDelay Timer - 15с, таймер перехода в Forwarding State порта. Для предотвращения временных циклов

MSTP, Multiple STP - версия STP для нескольких сетей (VLAN)

RSTP, Rapid STP - обновленная версия STP. Работет быстрее (таймеры меньше + меньшее кол-во этапов). 
- Порт, подключенный к клиенту, - Edge port (переходит из Blocking в Forwarding сразу - ускорение сходимости)

Вопросы
1. By default, a switch runs RSTP.
- *false* - STP по умолчанию
2. 2. The bridge IDs of SW1, SW2, SW3, and SW4 are 4096.4c1f-aabc-102a, 4096.4c1f-aabc-102b, 4096.4c1f-aabc-001a and 8192.4c1f-aabc-112b, respectively. If the four switches are on the same Layer 2 network and have STP enabled, which switch acts as the root bridge?
- *SW3* - у него наименьшая (Bridge Priority, MAC) пара
3. What is the default Forward Delay value in STP?
- *15s* - значение по умолчанию для NBMA (мы на них учились, современный Ethernet)
4. The root ID, bridge ID, interface ID, and root path cost (RPC) are the main fields used to determine priorities of configuration BPDUs. 
To select a superior configuration BPDU, in which of the following sequences does a switch compare these fields?
- *Root ID, RPC, Bridge ID, Interface ID*
5. Which of the following fields are contained in a configuration BPDU?
- *Root ID*
- *Port ID*
- *Bridge ID*
- *Forward Delay*
6. Which of the following statements about the role of STP protocol Forward Delay is correct?
- *Prevent temporary loops*

###  Inter-VLAN Communication

Общение через VLAN может происходить на L2 и L3 уровнях.
Если на L2, то как мы узнаем IP. 
А если на L3, то все будут получать Ethernet кадры.
Чтобы избавиться от этой проблемы нужно соединить эти 2 уровня вместе.

1 способ - только физические интерфейсы:
1. Настраиваем коммутаторы на работу в режиме VLAN
2. Для каждого VLAN отдельный кабель к роутеру
3. Т.к. Роутер не поддерживает VLAN, то перед отправкой - убираем VLAN (делаем обычный Ethernet II кадр) 

2 способ - VLANIF (нужен коммутатор работающий на L3)
1. Настраиваем коммутаторы на работу в режиме VLAN
2. Настраиваем VLANIF интерфейсы:
   1. `interface vlanif *id*` - создать интерфейс
   2. `ip address *ip* *mask*` - указать Gateway для перенаправления

Процесс коммуникации:
1. Клиент отправляет нетэгированные кадры на коммутатор
2. Коммутатор 1 получает кадр:
   1. Смотрит куда напрявлять кадр.
   2. Если в другую сеть, то добавляет VLAN ID
3. Коммутатор 1 направляет кадр коммутатору 2
4. На коммутаторе 2 установлен VLANIF интерфейс:
   1. Направляет кадр на свой интерфейс (Routing module)
   2. Ищет в специальной таблице коммутации путь для дальнейшей пересылки кадра
5. После нахождения адреса, удаляет свой VLAN ID тэг и направляет на другое устройство
6. Через какое-то время приходит ответ и он в обратном порядке возвращается отправителю

В общем, VLANIF - фича коммутаторов для коммуникации между различными VLAN. 
С ее помощью можно обнаруживать IP пакеты (соответственно сами IP адреса кому предназначается) 
внутри Ethernet кадров и перенаправлять эти кадры по своим правилам (на другой интерфейс коммутатора и он сам подменить VLAN Tag), 
чтобы не нагружать роутеры (они про VLAN не знают).
Таким образом, из своей физической L3 сети мы не выходим и 
общаемся через различные VLAN. 

Router-on-a-Stick
- Архитектура сети для общения между различными VLAN 
- Хосты подключены к своим коммутаторам -> Коммутаторы подключены к одному роутеру (Trunk) -> Роутер может передавать пакеты между этими VLAN. 
- Требуется только 1 физический канал между коммутатором и роутером.
- Позволяет сократить кол-во соединений L2 (от хостов к коммутатору) 
- Для роутера нужно создавать под-интерфейсы (sub-interfaces)

Вопросы
1. During Layer 3 communication, the source and destination MAC addresses of a packet are changed each time it passes through a Layer 3 device.
- *true* - от коммутатора до коммутатора
2. To implement inter-VLAN communication through sub-interfaces, which of the following commands needs to be configured for VLAN termination on the sub-interfaces?
- *dot1q termination vid vlan-id*
3. Which of the following statements about a Layer 3 switch is false?
- *A Layer 3 switch can forward packets only at Layer 3* - L3 коммутация просто доп. функциональность
4. Which of the following statements is false about routing on Layer 3 switches?
- *A Layer 3 switch forwards the packet to the next hop specified in the matching routing entry, without re-encapsulating the data frame* - как минимум изменяет MAC в L2 заголовке
5. If sub-interfaces are configured to implement inter-VLAN communication, which of the following interfaces should be configured to connect a switch to a router?
- *Trunk*
- *Hybrid*

###  Eth-Trunk iStack and CSS

Eth-Trunk - технология аггрегирования Ethernet кабелей (каналов).
Если несколько кабелей подлючены и ведут в одно и то же место, 
то можно их объединить в один логический.
Таким образом, увеличиваем пропускную способность без обновления физического (самих коммутаторов).

Для создания Eth-Trunk интерфейса нужны:
- Несколько (1+) установленных соединений
- Одинаковые:
  - Скорости интерфейсов
  - Конфигурации VLAN (если используется)
- Дуплексный режим

Режимы:
- Ручной:
  - Все создается и настраивается вручную
  - Нет автоматического отслеживания неполадок 
- LACP:
  - Использует LACP - Link Aggregation Control Protocol (название протокола такое же)
  - Устройства обмениваются LACPDU (LACP Data Unit) для управления состоянием
  - LACPDU = приоритет устройства + MAC + приоритет интерфейса + номер интерфейса
  - Можно настроить макс. кол-во активных интерфейсов (другие - резервные)
  - Алгоритм:
  1. Выбираются Actor (главный) - наименьший приоритет устройства, и Partner (зависимый)
  2. Выбираются активные интерфейсы. Меньшее значение приоритета. Если одинаковые - меньший номер интерфейса.
- Балансировка нагрузки
  - На основании MAC или IP (и в ту, и в другую, и в обе стороны одновременно)

iStack, Intelligent Stack - несколько физических коммутаторов объединяются в один логический.
Соединяются через специальный кабель. 
Используют одни и те же правила. 
Действуют как один организм.

CSS, Cluster Switch System - несколько физических коммутаторов соединяются друг с другом, 
чтобы в случае отказа одного, другой начал работать вместо него. 
Используется CSS канал между ними

Обычно используется связка iStack, CSS, Eth-Trunk:
- Увеличение надежности сети (есть замена, CSS)
- Увеличение пропускной способности (аггрегация каналов, Eth-Trunk)
- Увеличение кол-ва клиентов - просто добавить еще один коммутатор в специальный разъем (iStack)
- Не требуется MSTP (для коммутаторов использующих CSS)

Вопросы
1. Configuring the lower threshold for the number of active interfaces in an Eth-Trunk ensures that the Eth-Trunk has the minimum required bandwidth
- *true*
2. What is the default LACP interface priority?
- *32768*
3. Which of the following configurations can be different on member interfaces in an Eth-Trunk interface?
- *Spanning Tree Configurations*
4. Which of the following statements is false about selecting active links in LACP mode?
- *The Actor enables active interfaces and disables backup interfaces, and notifies the device on the other end of the selected active interfaces based on the physical interface status*
5. Which of the following fields in an LACPDU is used to select the Actor?
- *Device priority*
- *Device MAC address*

###  ACL Principles and Configuration

ACL, Access Control List - технология, использующаяся для настройки правил маршрутизации.
По сути, это просто последовательный список правил - 
поступивший запрос проходит по нему шаг за шагом пока не наткнется на условие касающееся его и выполняет, что там написано.
В общем случае - для любого правила ACL есть только 2 исхода - permit или deny.
Может применяться как к входящему, так и исходящему трафику.
Варианты применения:
- Фильтрация трафика
- NAT
- Политика маршрутизации
- Файрвол
- QoS

Задание правила:
1. `acl number *acl-number*` - создание списка правил (ACL)
2. `rule *rule-number* {deny|permit} *rest*` - добавление правила
3. `traffic-filter {inbound|outbound} acl *acl-number*` - фильтрация трафика на интерфейсе

Каждое правило имеет свой ID - номер в списке
(можно вставить правило между другими существующими). 
По умолчанию, добавляется в конец с номером +5 от последнего.

Варианты ACL:
1. Базовый
   - 2000-2999
   - IPv4, источник и назначение, временные диапазоны
2. Расширенный
   - 3000-3999
   - То, что в Базовом + типы IPv4, типы ICMP, номера портов TCP/UDP

Вопросы
1. An advanced ACL can match the source and destination port numbers of packets, enabling it to filter TCP packets with a specified destination port number
- *true*
2. What is the default increment of ACL rule IDs?
- *5*
3. What is the number range of advanced ACLs?
- *3000-3999*
4. If the number of an ACL is 4010, which of the following fields can the ACL match?
- *Source MAC address, destination MAC address, and L2 Protocol type*
5. Which of the following packets can match the ACL rule: rule 1 permit tcp source any destination 192.168.1.1 0.0.0.0 destination-port eq 80?
- *Source IP address: 10.0.0.1; destination IP address: 192.168.1.1; source port number: 30000; destination port number: 80; transport layer protocol: TCP*
- *Source IP address: 10.1.1.1; destination IP address: 192.168.1.1; source port number: 62012; destination port number: 80; transport layer protocol: TCP*

###  AAA Principles and Configuration

AAA - Authentication, Authorization, Accounting - механизм сетевой безопасности.
Архитектура сети с AAA:
- User - сами пользователи. Подключаются к NAS
- NAS, Network Access Server - сетевой сервер доступа: управление (перенаправление) пользователями в зависимости от их области (домена). 
  - Каждый домен может иметь свой собственный AAA.
  - Каждый пользователь присоединен к какому-то домену
  - Определение домена пользователя - в Username после самого имени пользователя через '@' указывается название домена (если нет, то используется домен по умолчанию)
- AAA Server - сам сервер занимающийся AAA

Имя пользователя: username@domain, username - имя пользователя, domain - домен, в котором зарегистирован.
Если домен не указан, то используется по умолчанию.

Режимы аутентификации:
- Non-authentication
  - Пользователи доверенные
  - Ничего не проверять
- Local authentication
  - На сервере NAS хранятся данные о пользователе
  - NAS используется как (вместо) AAA сервер
  - Ограничение памятью устройства
  - Часто используется в связке с Telnet, FTP
- Remote authentication
  - На сервере AAA хранятся данные о пользователе
  - Могут использоваться RADIUS или HWTACACS. В таком случае, NAS используется как клиент к этим серверам.

Режимы авторизации:
- Non-authorization
  - Без ограничений
- Local authorization
  - Авторизация на основе правил указанных при конфигурации NAS
- Remote authorization
  - HWTACACS - все пользователи авторизуются HWTACACS сервером
  - RADIUS - только к аутентифицорованным этим RADIUS сервером пользователей. 
RADIUS авторизация не может быть многоразовой - говори, что будешь делать сразу.

Режимы учета (accounting):
- Non-accounting
  - Свободный доступ без логов
- Remote accounting
  - Логирование происходит на стороне AAA сервера

RADIUS:
- Часто используется как протокол в AAA
- NAS - клиент RADIUS сервера и действует только на основании ответа от RADIUS сервера
- Работает по схеме клиент/сервер
- Порты UDP:
  - 1812 - Аутентификация
  - 1813 - Авторизация
- Процесс работы:
1. Клиент аутентифицируется на RADIUS сервере, используя свои username/password, через NAS
2. При необходимости доступа отправляет запрос на RADIUS сервер (со своими username/password)
- Типичное использование
  - Проверка доступа в Интернет + учет их аутивности (история, утилизация...)
  - Локальный auth* привилигированных пользователей

Настройка:
1. `aaa` - входим в AAA View
2. `authentication-scheme *scheme*` выбираем схему аутентификации. Автоматический переход в собственный View
3. `authentication-mode {hwtacacs|local|radius}` - выбираем режим аутентификации
4. `domain *name*` - создаем домен с именем. Входим в свой Domain View
5. `authentication-scheme *scheme-name*` - привязываем схему аутентификации к домену
   - Можно указать несколько. Они будут применяться последовательно. Если один из них удален/деактивирован, обрабатывать начнет следующий.
6. `local-user *username* password {cipher|plain} *password*` - создаем пользователя с паролем
7. `local-user *username* service-type { {terminal|telnet|snmp} | ppp | none }` - настраиваем как пользователь будет подключаться
8. `local-user *username* privilege level *level*` - устанавливаем уровень доступа 

Вопросы
1. When receiving a user access request, the NAS determines the domain to which the user belongs based on the user name, and performs user management and control based on the AAA schemes configured for the domain.
- *true*
2. Which of the following roles is not included in the common AAA network architecture?
- *Portal server*
3. What are the transport layer protocol and authentication port number used by RADIUS?
- *UDP, 1812*
4. Which of the following authorization modes is not supported by AAA?
- *Mutual authorization*
5. Which of the following concepts are involved in AAA?
- *Authentication*
- *Authorization*
- *Accounting*

###  Network Address Translation

NAT, Network Address Translation - технология отображения (+ проверки досутупа) адресов

Типы NAT:
- Static NAT
  - Private IP -> Fixed Public IP
  - 192.168.1.1 -> 32.56.9.129 (что видят другие)
  - Для каждого устройства - свой отдельный IP
  - Работает в обе стороны: Интернет -> Сеть + Сеть -> Интернет
  - Настройка
    - `nat static global *ip-outside* inside *ip-inside*` - заполнение таблицы
    - `nat static enable`
- Dynamic NAT
  - Private IP -> Public IP (из пула свободных адресов)
  - 192.168.1.1 -> Смотрю свободные Public IP -> 32.56.9.129 (а может выдаться и 32.56.9.130)
  - Назначается временно - в этот период работает как Static NAT
  - Настройка
    - `nat address-group *group-index* *ip-start* *ip-end*` - создаем пул адресов
    - `acl *number* + rule permit source *source-ip* *wildcard*` - настраиваем ACL
    - `nat outbound *acl-number* address-group *group-index* no-pat` - включаем Dynamic NAT с созданным ACL и пулом, no-pat - без трансляции портов (будет дальше)
- NAPT, Network Address and Port Translation
  - Private IP -> Public IP + Port (из пула)
  - 192.168.1.1 -> 32.56.9.129:3242
  - Для одного Public IP может быть выделено несколько внутренних хостов
  - Настройка - такая же как Dynamic NAT, только не указываем no-pat
- Easy IP
  - Private IP -> Public IP + Port (могут выбираться динамически)
  - Возможна трансляция IP адреса и порта транспортного уровня
  - Настройка:
    - `nat outbound *acl-number*` - также как Dynamic NAT, но не нужен пул адресов - нужен только ACL
  
NAT server
- Занимается отображением адресов.
- Внешние клиенты могут обратиться к клиенту внутри локальной сети
- Например, внутри есть веб-сервер с IP 192.168.0.1 и другие могут сделать к нему запрос на 32.56.9.129
- `nat server protocol *protocol* global *ip-outside* inside *ip-inside* *port-inside*`

Вопросы
1. NAPT translates not only IP addresses but also port numbers to implement 1:N mappings between public and private addresses.
- *true* - Static, Dynamic NAT выделяют только IP, но не порты
2. Which of the following NAT technologies can only use an interface address as the post-NAT public address?
- *Easy IP* 
3. Which of the following NAT technologies can be deployed on egress network devices to enable external users to access only a TCP port of an intranet server?
- *NAT Server* - тот, кто занимается отображением адресов
4. Which of the following are not translated by NAPT?
- *Destination port number*
- *Destination IP address*
5. Which of the following NAT technologies can be used to enable external users to proactively access an intranet server?
- *Static NAT*
- *NAT Server*

###  Network Services and Applications

FTP, File Transfer Protocol:
- Проктол обмена файлами
- Client/Server
- TCP, 20/21
- Режимы передачи:
  - ASCII, Для текстовых файлов
  - Binary, Для остальных
- Режимы работы:
  - Active
  1. Клиент с рандомного порта устанавливает соединение на 21 порт Сервера
  2. Сервер устанавливает Control Connection
  3. Клиент выбирает другой случайный порт P
  4. Если необходимо переслать файлы, то сервер шлет их на порт P клиента
  - Passive
  1. Клиент с рандомного порта устанавливает соединение на 21 порт Сервера
  2. Сервер устанавливает Control Connection
  3. Клиент выбирает другой случайный порт P и отправляет серверу комманду PASV
  4. Сервер выбирает случайный порт N и отправляет клиенту Enter PASV
  5. Если необходимо переслать файлы, клиент открывает соединение с P на N

TFTP, Trivial FTP:
- Простая версия FTP
- Для маленьких файлов
- UDP 69
- Нельзя просматривать файлы директории

Telnet:
- Простое подключение и управление сервером/хостом
- TCP 23
- Для подключения - VTY интерфейс (Virtual Terminal Interface)
- Telnet server - тот, к кому подключаются, Telnet client - тот, кто подключается

DHCP, Dynamic Host Configuration Protocol:
- Динамическое выделение IP адресов
- Client/Server
- Алгоритм
1. Clinet: DHCP Discover - найти DHCP сервер, Broadcast
2. Server: DHCP Offer - предложить IP, Broadcast
3. Client: DHCP Request - соглашение на использование предоставленного, Broadcast
4. Server: DHCP Ack - подтверждение, Unicast
- Адреса выдаются на время. Перед их окончанием нужно продливать
- По умолчанию, адрес выдается на 24 часа

DNS, Domain Name System:
- Отображение названий серверов на их реальные IP адреса
- Доменное имя - иерархический формат (разделение .)
- DNS Серверы - иерархический формат (в соответствии с обсуживаемым доменом)
- Разрешение имени:
  - Рекурсивное: Если не найдено - Сервера обращаются друг к другу
  - Итеративное: Если не найдено - Клиент последовательно обращается к другим серверам

NTP, Network Time Protocol:
- Синхронизация времени на устройствах
- UDP, 123

Вопросы
1. FTP works in active or passive mode. TCP port 20 is used in both modes.
- *false* - только в активном режиме, в пассивном выделяется рандомный порт
2. What is the level of the domain '.com' in the URL www.huawei.com?
- *Top-level domain* - первое слово с конца
3. Which of the following messages is sent by a DHCP server to carry the IP address assigned to a client during DHCP interaction?
- *DHCP Offer* 
4. Which of the following is the default destination port number of the FTP control channel?
- *21*
5. Which of the following parameters can be assigned by a DHCP server to a DHCP client?
- *DNS server address*
- *Gateway address*
- *Local IP address*
- *Mask*

###  WLAN Overview

WLAN, Wireless LAN - беспроводная локальная сеть.
IEEE 802.11 - Wi-Fi.

Устройства:
- STA, Station
  - Клиент (называется в WLAN) - телефон, ноутбук, компьютер (конечное устройство)
- AC, Access Controller
  - Логика учета клиентов (аутентификация, авторизация, DHCP...)
  - Можно указать адрес/интерфейс источника CAPWAP туннеля вручную
- Fit AP
  - Только раздает Wi-Fi
  - Конфигурация - из AC
- Fat AP
  - Вся логика внутри них (AC + Fit AP)

CAPWAP, Control And Provisioning Wireless Access Points:
- Протокол управления и конфигурированием AP
- Создание CAPWAP туннулей
- Типы сообщений:
  - Data - пользовательские данные, UDP 5247
  - Control - управление AP, UDP 5246

Соединение AP и AC
- In-Path - только AC напрямую соединен с сетью, все данные идут через него
- Off-Path - AC используется как источник конфигурации

BSS, Basic Service Set - область, которую покрывает AP

BSSID, BSS Identifier - ID области покрытия AP, обычно MAC

SSID, Service Set Identifier - ID WLAN строкой, user-friendly

VAP, Virtual AP - для создания нескольких AP из одного физического. 
Например, один для клиентов, другой для сотрудников.

ESS, Extended Service Set - объединение нескольких AP.
Большие сети состоят из нескольких отдельных физических BSS.
Чтобы переходя от одного к другому связь не терялась, нужно объединить их в один логический BSS.

Установление CAPWAP туннеля:
1. Обнаружение AC (Broadcast запросы)
2. Создание туннеля
   1. AC получает Join Request
   2. AC аутентифицирует AP

Поддержание туннеля:
1. Data - обмен Keepalive
2. Control - обмен Echo

Безопасность:
- WEP
- WPA/WPA2
- WPA/WPA2 PSK

Вопросы:
1. Two CAPWAP tunnels are established: data tunnel and control tunnel. They are both kept alive using Keepalive messages. 
- *false* - для Control используется Echo
2. Which of the following 802.11 protocols works only on the 5 GHz frequency band?
- *802.11ac* - остальные используют 2.4GHz
3. Which of CAPWAP message types is used by an AC to deliver configuration files to APs?
- *Configuration Update Response* - Image - для данных, а Configuration Update Request - для информирования о доступных обновлениях
4. Which of the following data frames is used by an AP to periodically broadcast its SSID?
- *Beacon*
5. Which of the following modes are used by APs to dynamically discover an AC?
- *DHCP Mode*
- *DNS Mode*
- *Broadcast Mode*
- Остался только *Manually...*, но он вручную, а нужен dynamically

###  WAN Technologies

WAN, Wide Area Network
- Покрывает огромные территории (км^2)
- Состоит из множества LAN

Типы устройств:
- CE, Customer Edge - расположен у пользователя, соединяется только к PE 
- PE, Provider Edge - расположен у поставщика, соединяется к CE и P
- P, Provider - расположен у поставщика, соединяется только к PE (огрожден от мира, с помощью PE)

PPP, Point-to-Point Protocol:
- P2P соединение - только 2 устройства
- PAP (Password Authentication Protocol) + CHAP (Challenge Handshake Authentication Protocol) - безопасность
- LCP (Link Control Protocol) - согласование на L2
- NCP (Network Control Protocol) - согласование на L3

Настройка соединения между точками
1. Установление L2 соединения. LCP:
    1. Один шлет свою конфигурацию (что будет использоваться) - Configure-Request
    2. Второй проверяет присланную конфигурацию и отвечает на него - Configure-Ack, затем шлет свой Configure-Request
    3. Если в Configure-Request:
       - Неправильные/неподдерживаемые параметры - Configure-Nak, затем другой присылает Configure-Request с другими параметрами
       - Непонятно, что это за параметр - Configure-Reject, затем другой отправляет конфигурацию без этих параметров
2. Аутентификация (Если была указана)
   - PAP
     1. Передача Username/Password в нешифрованном виде
     2. Ответ: Authenticate-Ack - успех, Authenticate-Nak - провал
   - CHAP
     1. Сервер отправляет пакет (Challenge) (ID, рандомное число)
     2. Клиент вычисляет MD5 хэш по формуле и отправляет результат (Response)
     3. Сервер отправляет результат проверки
3. Установление L3 соединения NCP
   - Выбор L3 протокола (Часто IPCP)
   - Согласование параметров конкретного протокола 
   
PPPoE, PPP over Ethernet:
- Инкапсуляция PPP пакетов в Ethernet
- L2

Установление сессии:
1. PPPoE Discovery
   1. Клиент шлет PPPoE Request - PADI (Broadcast)
   2. Свободные сервера отвечают - PADO (Unicast)
   3. Клиент выбирает сервер - PADR (Unicast)
   4. Сервер подтверждает клиента и создает сессию - PADS (Unicast)
2. PPPoE Session.
   1. Согласование PPP (как в обычном)
   2. Сама работа (передача данных)
3. PPPoE Terminating
   1. Клиент шлет пакет серверу - PADT (обрыв сессии как только получил пакет)
   
> PAD* - PPPoE Active Discovery
>> I - Initiation  
>> O - Offer  
>> R - Request  
>> S - Session-confirmation 
>> T - Termination

Вопросы:
1. During CHAP authentication, the password configured for a user is carried by PPP packets in plaintext.
- *false* - это в PAP  
2. Which of the following packet types is used by PPPoE to terminate a session?
- *PADT* - T = Termination  
3. If a packet with unmatched parameters is received during LCP negotiation, which of the following packet types is used by PPP to respond to the packet?
- *Configure-Nak* - Nak - для тех, что не поддерживаются, но понятно для чего они (например, версия не поддерживается), Reject - для тех, которые вообще не понятны (даже название параметра)
4. Which of the following authentication protocols are supported by PPP?
- *PAP*
- *CHAP*
5. Which of the following packet types are used during PPP negotiation?
- *LCP* - L2
- *PAP* - аутентификация
- *CHAP* - аутентификация
- *IPCP* - L3

###  Network Management and OM

Network Management
- Configuration - возможность настройки оборудования
- Performance - минимальная загруженность и потребление ресурсов + производительность
- Fault - если что-то отлетает, то система все равно работает
- Security - авторизованный доступ
- Accounting - записи об использовании сети (как, кто, когда...)

Традиционные методы:
- CLI - коммандная строка
- GUI - спец. программы, HTTP
- SNMP - посылать команды SNMP для конфигурирования
  - Simple Network Management Protocol
  - Устройство с запущенным на нем NMS (Network Management System) отслеживает состояние сети, при необходимости отправляет какие-то команды + 
предоставляет интерфейс клиенту для мониторинга
  - Версии:
    - SNMPv1 - {Get|Set|Get-Next}-Request, Response, Trap (простые CRUD операции)
    - SNMPv2(c) - +GetBulkRequest - сразу несколько результатов в одном ответе, Базовая безопасность
    - SNMPv3 - + зашифрованный заголовок аутентификации
  - Типы операций
    - Query/Modify - запрос/модификация
    - Trap - какое-то событие не связанное с Query/Modify случилось (например TTL истек)
  - Каждое устройство имеет MIB, Management Information Bases - база данных с объектами устройства, которыми можно управлять:
    1. OID - ID объекта
    2. Status - статус объекта
    3. Access permition - кто, может им управлять, и что делать
    4. Data types - другие свойства объекта
  - Порты:
    - 161, UDP - команды/запросы (Get, Response)
    - 162, UDP - уведомления (Trap)

Выебистые методы:
- iMaster NCE - платформа Huawei для управлением сетью:
  - Использует NETCONF - механизм для управления
  - Есть Client и Server NETCONF
  - Установление сессии только по защищенному соединению (SSH, TLS, SSL...)
  - Свой синтаксис для управления YANG

Вопросы:
1. Network devices enabled with SNMP run the agent process. The management process of an NMS interacts with the agent process through SNMP packets.
- *true* - архитектура SNMP - Клиент/Сервер
2. Which of the following packet types is used by SNMPv2c to proactively send traps to an NMS and requires a response from the NMS?
- *Inform* - добавлен в v2 для подтверждения доставки Trap (т.к. UDP не гарантирует доставки)
3. Unlike SNMPv1, SNMPv2c uses which of the following packet types to query OIDs in batches?
- *GetBulk* - добавлен в v2
4. Which of the following are attributes of managed devices defined in the MIB?
- *OID* 
- *Status*
- *Access permission*
- *Data types*
5. Which of the following new security features that SNMPv3 provides over SNMPv1 and SNMPv2c?
- *The MD5 algorithm is supported for user authentication*
- *DES is supported for data encryption*

###  IPv6 Basics

Заголовок:
1. Version
   - 4 bits
   - 0x06
2. Traffic class
   - 8 bits
   - Приоритет пакета
   - QoS
3. Flow label
   - 20 bits
   - Поддержка real-time данных
4. Payload length
   - 16 bits
   - Размер Payload 
5. Next header
   - 8 bits
   - Есть ли дополнительные загловки 
6. Hop limit
   - 8 bits
   - ~ TTL
   - Кол-во роутеров через которые может еще пройти
7. Source address
   - 128 bits 
   - Адрес отправителя
8. Destination address
   - 128 bits
   - Адрес получателя

Дополнительные заголовки:
- Hop-by-hop 
- IPv6 Authentication
- TCP

IPv6 Адрес:
- 128 бит длина
- Имеется маска подсети (как и в IPv4)
- Сокращения
  - :: - пропуск нулевых сегментов (если последние сегменты 0, то ::0)
  - Начальные 0 можно опустить

Классы IPv6 адресов:
- Multicast - для определенной группы адресов (замена Broadcast)
- Unicast
  - Global - 2000::/3
  - ULA, Unique local - FD00::/8
  - Link-local - FE80::/10
  - Special
    - ::/128 - Unspecified
    - ::1/128 - Loopback
  - Others
- Anycast - для любого (ближайшего) из указанной группы адресов

> Broadcast нет

Unicast = Network + Interface ID

Назначение Unicast
- Вручную
- Автогенерация (DHCP)
- EUI-64 - Interface ID = MAC (длина маски 64)

ULA:
- Только внутри своей сети - не маршрутизируется в Интернете
- Начинается с FD::/8, но имеет свой псевдоглобальный префикс (все равно можно определить, что не из этой сети)

LLA:
- Назначается хостом себе
- Network всегда равен FE80::/64 (после FE80 - только 0 в сетевой части - одна сеть)

Multicast:
- Начинается на FF (первые 8 бит - 11111111)
- 4 бита - флаги (0000 - Transient, 0001 - Permanent)
- 4 бита - область (scope):
  - 0 - Reserved (0000)
  - 1 - Interface-local (0001)
  - 2 - Link-local (0010)
  - 5 - Site-local (0101)
  - 8 - Organization-local (1000)
  - E - Global (1110)
  - F - Reserved (1111)
- Дальше 80 бит - 0
- Последние 32 бит - ID группы
  
Solicited-Node Multicast Address:
- Разрешение адресов в Local-link
- DAD, Duplicate Address Detenction
- Из моего Unicast создаю специальный Multicast:
  - FE02::1:FF:*последние биты моего адреса*
  - Если кто-то получает - адреса дублируются

NDP, Network Discovery Protocol. Использует ICMPv6.

Настройка адресов:
- Stateful
  - DHCPv6
- Stateless
  - ICMPv6 (RA и RS сообщения)
    
Разрешение MAC адресов
- Клиент посылает NS сообщение (Source - он сам, Destination - solicited-address кому нужно) на роутер
- Роутер ищет в своей таблице требуемый IPv6 и отправляет его клиенту NA
- Клиент берет из полученного сооющения необходимые IPv6 и MAC

Вопросы:
1. An IPv6 unicast address consists of a network prefix and an interface ID. 
Common IPv6 unicast addresses, such as global unicast addresses and link-local addresses, 
require the network prefix and interface ID to be 64 bits.
- *true*
2. What is the length of an IPv6 address?
- *128*
3. What is the abbreviated version of the IPv6 address 2001:0AF8:0000:1234:FB00:0000:5000:EF14?
- *2001:AF8:0:1234:FB00::5000:EF14* - только 1 секция может быть экранирована через ::
4. Which of the following fields is used in a basic IPv6 header but not in an IPv4 header?
- *Flow label* - отслеживание потока для Real-Time
5. Depending on the IPv6 address prefix, which of the following address types can IPv6 addresses be classified into?
- *Anycast*
- *Multicast* - замена Broadcast
- *Unicast*

###  Introduction to SDN and NFV

OpenFlow - протокол управления процессом обработки данных в сетях.
- Лежит между контроллером и коммутатором.
- Flow table - используется в OpenFlow
  - Соответствие MAC и IP одновременно (вместо стандартной по сети + маске)
  

Типы сообщений:
- Controller to Switch - отправляется контроллером для управления коммутатором
- Asynchronous - сообщение коммутатора об обновлении его состояния
- Symmetric - Hello, Echo, Error от коммутатора или контроллера
    
SDN, Software Defined Network:
- Orchestration application layer - то, что хочешь сделать
- Controller layer - тот, кто думает как это сделать (само ядро SDN)
- Device layer - тот, кто делает (получает инструкции от Controller layer)

Да пошло все в жопу!

Вопросы (просто запомнить):
1. An OpenFlow switch forwards packets based on the flow table, and matches the destination MAC and IP addresses and other fields in the packets.
- *true* 
2. In the standard NFV architecture, which of the following modules is responsible for virtualization of the underlying hardware?
- *NFVI*
3. In the SDN architecture, which of the following interfaces is used for communication between the controller and an SDN switch?
- *Southbound interface*
4. In the OpenFlow architecture, which of the following packets are sent from the controller to a switch?
- *Controller-to-Switch*
- *Symmetric*
5. Which of the following are NFV features?
- *Partition division*
- *Isolation*
- *Encapsulation*
- *Hardware independence*

###  Network Programmability and Automation

Для автоматизации рутинных задач можно использовать языки программирования.
В сетях наиболее используемым (после Bash) является Python:
- Интерпретируемый - можно запускать везде, где есть интерпретатор
- Много готовых библиотек (для сетей, автоматизации...)

Вопросы:
1. Python programs use indentation to represent code blocks. Statements in the same code block must have the same number of indented spaces.
- *true*
2.To improve code modularization and utilization, which of the following is used to describe a collection of objects with the same attributes and methods?
- *class*
3.Which of the following methods is used to write data to the telnetlib module?
- *write* - метод из библиотеки
4. Which of the following characters can be used as Python identifiers?
- *Letters*
- *Digits*
- *Underscore*
5. Which of the following are compiled high-level programming languages?
- *C*
- *C++*

###  Typical Campus Network Architectures and Practices

Типичная архитектура состоит из нескольких разных областей (layers):
- Core - соединяет другие слои
  - Routing
  - OSPF
  - ACL
  - Stacking (iStack, CSS, Eth-Trunk)
- Access - соединяет конечные узлы (ПК, терминалы...)
  - VLAN
  - Link aggregation
  - AAA
  - Stacking (iStack, CSS, Eth-Trunk)
  - STP
- Aggregation - соединяет слои Access
  - DHCP
  - OSPF
  - STP
  - Routing
- Egress - соединяет внешние сети (напр. Интернет) со внутренними
  - NAT
  - OSPF
  - PPPoE
- Data center - содержит базы данных и другие конечные узлы с данными
- Network management - контроллеры сети (SDN, AC...)

Вопросы:
1. Certain terminals, such as servers and printers, can be allocated fixed IP addresses.
- *true* - почему бы и нет?
2. To conserve IP addresses, what mask size is used for IP addresses on router to router connections on an enterprise network?
- *30* - точка-точка соединение
3. On a campus network, which of the following functions can be enabled on access switches to prevent employees from accessing the unauthorized DHCP-enabled router?
- *DHCP snooping* - смотреть в кадры напрямую, искать запрещенные DHCP Discover пакеты и отбрасывать их
4. Which of the following technologies can be used on a campus network to improve network reliability?
- *iStack* - соединить несколько коммутаторов в один (общая таблица коммутации)
- *CSS* - добавить дополнительный роутер, чтобы если один вышел из строя, другой его заменил
- *VRRP* - запасные роутеры-шлюзы-по-умолчанию
- *Link Aggregation* - несколько физ. кабелей в один логический
5. Which of the following are stages in the lifecycle of a campus network project?
- *Planning and design*
- *Deployment and implementation*
- *Network O&M*
- *Network optimization*

-------

## Ответы на Final

### TRUE/FALSE

- During IP packet forwarding, … route ***(true)***
- Frames transmitted on the trunk link between … tagged ***(false)***
- WLAN technology enables transmission of information by radio waves … are used ***(false)***
- Switches can implement communication between homogeneous … broadcast domains ***(false)***
- Python can run in both interactive mode … mode ***(true)***
- A blackhole route (or null route) … loops ***(true)***
- SNMP is a standards-based network management protocol … protocol ***(false)***
- Segment routing (SR) provides … path ***(true)***
- To prevent out-of-order packets, it is recommended that … balancing ***(true)***
- After receiving a tagged frame … frame ***(false)***
- Software-defined networking (SDN) … interfaces ***(true)***
- AAA is short for … application ***(false)***
- The PVID of a trunk port … port ***(true)***
- Before sending an IPv6 packet, an interface … detection (DAD) ***(false)***
- In STP, a non-root-bridge … ports ***(false)***
- In the WLAN network architecture, ACs can … mode ***(true)***
- Specific routes can be … address ***(true)***
- FTP is a file transfer protocol … mode ***(true)***
- Network design and planning … construction ***(true)***
- In an OSPF AS, … ASBR ***(true)***
- A CAPWAP tunnel is … traffic ***(false)***
- The precision of telemetry-based … milliseconds ***(false)***
- Static routes and OSPF … routes ***(false)***
- When two static routes work as the primary … routes ***(true)***
- When a static route is configured … network ***(false)***
- As every two nodes in a full-mesh … costs ***(true)***
- The vlan batch 4 10 commands … VLAN 10 ***(true)***
- A hybrid port on a switch can connect to either a user … ***(true)***
- The Point-to-Point Protocol (PPP) is a common data link layer protocol … is false ***(The establishment … )***
- TFTP uses TCP to transfer files … number is 21 ***(false)***
- Segment routing (SR) can be deployed with or without controllers ***(true)***

### Single answer

 - The ping and tracert commands are used … false ***(The ping -s source-ip-address … packets)***
 - Which of the following statements … networking ***(Typically … deployment)***
 - The process for an AP to go … AC ***(Password authentication)***
 - When a ping command is run … device ***(ICMP)***
 - The Versatile Routing Platform … a device ***(pwd)***
 - Refer to the following ACL … satime ***(The ACL rule … days)***
 - Which is the most widely … method ***(Interface-based VLAN … )***
 - The MAC address table of a switch … frames ***(Floods the first frame and discards … frame)***
 - Which of the following statements about … true ***(A data tunnel and a control … AP)***
 - A WLAN is constructed using … false ***(A virtual access point ***(VAP)*** is a service … BSSID)***
 - Which of the following lists the correct … top ***(Physical layer, data link layer, network layer, transport layer, and application layer)***
 - Network address Translation (NAT) translates … of NAT ***(Implementing accurate … efficiency)***
 - Refer to the following AAA configuration … telnet ***(The authentication mode is local … )***
 - How many bytes does an MPLS label contain ***(4 bytes)***
 - Which of the following statements about STP and RSTP false ***(There are three RSTP port … Blocking)***
 - Which of the following statements about edge ports is false ***(It takes 15 seconds for an …)***
 - If the PVID a trunk port on a switch … is true ***(Data frames of VLANs 1, 7 and 9 can be … )***
 - Which of the following statements is false … Access Points ***(CAPWAP is an application … )***
 - Which of the following commands can be used … device ***(display ospf Isdb)***
 - The Domain Name System (DNS) protocol is used to resolve … is false ***(DNS supports traversal query)***
 - A router has the following four specific routes … be run ***(ip route-static 10.1.20.0 22 12.1.1.2)***
 - The Network Configuration Protocol ***(NETCONF)*** … is false ***( NETCONF … XML)***
 - The establishment of an OSPF … is true ***(The devices establish … LSDBs)***
 - Which of the following states indicates that … network ***(Two-way)***
 - Mastering the basic operations of the file system … files ***(A PAF … )***
 - An AC manages and controls APs in a centralized … AC ***(Multicast)***
 - NTP is a network protocol … false ***(NTP is a network … )***
 - The following shows the routing table of a specific router … used ***(OSPF route … )***
 - In the TCP/IP reference … protocol ***(PPP)***
 - OSPF has multiple types of protocol packets … routers ***(DD packet)***
 - OSPF authentication enables a device … is false ***(The authentication … )***
 - Refer to the following configuration … is true ***(The router allows a … Telnet)***
 - Various profiles are designed … is false ***(Only … )***
 - IPv6 addresses can be … type ***(Broadcast address)***
 - In STP, which of the following … priority ***(22528)***
 - Dynamic routing protocols … EGP ***(BGP)***
 - Which of the following port numbers is used by the Telnet protocol ***(23)***
 - Which of the following is not a method for an AP to discover an AC address ***(OSPF)***
 - What is the length range of a Ethernet frame ***(64 to 1518 bytes)***
 - As shown in the following networking, the … is true ***(The routing table of R1 contains only the OSPF …)***
 - Which of the following is not a valid port role in RSTP ***(Forwarding port)***
 - A WLAN is constructed using wireless .. is false ***(A virtual … )***
 - OSPF is configured on RTA, RTB … network ***(RTB functions as the DR, and RTC as the BDR)***
 - What is the valid VLAN ID range ***(1 to 4094)***
 - An IPv6 address is 128 bits long … ***(Each…)***
 - In which of the following modes are DHCP Discover messages sent ***(Broadcast)***
 - What is the network ID for the IP address 192.168.1.1/29 ***(192.168.1.0)***
 - The following shows partial OSPF … is false ***(The router is the slave…)***
 - It the same Ethernet network segment … is true ***(The neighbor status of a router on … 2 way)***
 - Refer to the following configuration  on a … command ***(VLANs 2 to 10 will be created)***
 - Which of the following statements about BPDUs in STP is false ***(When the network…)***
 - Network address Translation ***(NAT) translates the IP address in an IP packet header into another IP address … NAT ***(Implementing accurate …)***
 - In the same Ethernet network segment, five routers are running … is true? ***(The neighbor status of a router … )***
 - SNMP is used to manage network devices … is false? ***(The encryption…)***
 - Which in the most widely used VLAN assignment method ***(Interface-based VLAN … )***
 - Python can be used to implement automatic…is false? ***(Two forward slashes (//))***

### Multiple asnwers

An administrator wants to allocate … hosts ***(2 ответа)*** ***(172.16.4.35 255.255.255.258)*** ***(172.16.4.33 255.255.255.248)***
 - Which of the following are advantages of switch … clustering ***(3 ответа)*** ***(Simplifies network structure)*** ***(Improves network reliability)*** ***(Simplifies network management)***
 - A router can advertise … are false ***(2 ответа)*** ***(After … )*** ***(The preference … )***
 - Which of the following statements are false about the forwarding … a switch ***(2 ответа)*** ***(When an access … the port discards the frame)*** ***(When an access port of the switch sends … the port adds its default VLAN ID to the frame)***
 - Network Address Translation ***(NAT)*** … NAT ***(все варианты ответы)***
 - A WLAN is a network that uses wireless … a WLAN ***(все варианты ответа)***
 - The route preference is an indicator … routes ***(3 ответа)*** ***(Все кроме: The default preference of an OSPF … 255)***
 - In OSPF, which of the following … BDR ***(2 ответа)*** ***(NBMA)*** ***(BMA)***
 - PPP over Ethernet ***(PPPoE)*** … are true ***(все варианты ответа)***
 - Which of the following are IPv6 address types ***(Все кроме: Broadcast address)***
 - Which of the following are valid MAC address types? ***(Все кроме: Anycast MAC address)***
 - For the IPv6 address … rules ***(2 otveta)*** ***(2000:2A::A:20C:23D)*** ***(2000:2A:0:0:0A:20C:23D)***
 - The concept of Network Functions … architecture ***(Все кроме: OS)***
 - IPv6 have many advantages … are true ***(Все кроме: Uses gratuitous … )***
 - An IPv6 address is 128 bits … rules ***(Все кроме: 2001:DB8:0:1234:FB00::5:45FF)***
 - A host at 192.168.1.1/24 on an intranet.. are true ***(2 otveta)*** ***(The administrator … IP)*** ***(The address … gateway router)***
 - Which of the following statements about OSPF areas are true ***(Все варианты ответа)***
 - Which of the following are possible causes … online ***(Все варианты ответа)***
 - Refer to the following … are true ***(2 otveta)*** ***(This command enables a layer 3 … 3 link aggregation)*** ***(This command enables a router … 3 link aggregation)***
 - ACLs are used to match and … rules ***(Все варианты ответа)***
 - When troubleshooting a spanning …are true ***(2 otveta)*** ***(The administrator has changed the path … )*** ***( The switch uses … )***
 - Which of the following IP addresses are private IP addresses ***(3 otveta)*** ***(10.0.1.1/30)*** ***(192.168.1.1/30)*** ***(172.16.1.1/30)***
 - Which of the following are the advantages of a VLAN ***(Все варианты ответа)***
 - Which of the following statements about static and dynamic routes are true ***(Все кроме: When creating … )***
 - A WLAN is a constructed using wireless … scope ***(Все варианты ответа)***
 - Which of the following statements about collision domains and broadcast domains are true ***(Все варианты ответа)***
 - Which of the following parameters can be specified when an … ACL ***(Все кроме: Source and destination MAC addresses)***
 - In contrast with SNMPv1, … SNMPv2c ***(2 ответа)*** ***(Inform…)******(GetBulk…)***
 - The Domain Name System ***(DNS)*** protocol … domain name ***(Все варианты ответа)***
 - Refer to the following configuration on the … level 2 ***(Все кроме: The user can use the debugging…)***
 - Which of the following statements about layer 2 hybrid ports are true ***(3 otveta ***(When a tagged … frame)*** ***(When a tagged … link)*** ***(After receiving a tagged … frame)***
 - Network address Translation ***(NAT)*** translates the IP address in an IP packet … NAT ***(Все варианты ответа)***
 - Which of the following statements about IP addresses and MAC addresses are true ***(Все кроме: IP addresses are unchangeable)***
 - Which of the following statements about Layer 2 and  Layer 3 loops are true ***(Все кроме: The TTL field…)***
 - A WLAN is constructed  using wireless technologies … scope ***(Все варианты ответа)***
 - Which of the following statements about OSPF router IDs are true ***(3 otveta)*** ***(The router ID…)*** ***(To ensure …)*** ***(A router…)***
 - Refer to the following ACL configuration on a device … number 200 ***(2 otveta)*** ***(Packets with the source IP address 10.1.1.2 will be…)*** ***(Packets with the source IP address 10.1.1.3)***
 - As shown in the following networking, the interfaces connecting R1, R2, R3 … performed ***(2 otveta)*** ***(Run the … on GE0/0/1 of R1)*** ***(Run the … on GE0/0/3 R2)***
 - Which of the following are valid MAC address types?***(Всё, кроме Anycast MAC address)***


## Ответы на Гугл

1. Which of the following port roles are added to Rapid Spanning Tree Protocol(RSTP) compared with STP?"         	"Какая из следующих ролей порта добавлена ​​в протокол быстрого охватывания дерева(RSTP) по сравнению со STP?
- **Alternate**
- **Backup**
- Designated
- Root

Пояснение: в STP есть только 2 роли порта: Root, Designated 

2. A network administrator wishes to assign an IP address to a router interface G0/0/0. Which of the following IP addresses can be assigned?"	"Администратор сети желает назначить IP -адрес на интерфейс маршрутизатора G0/0/0. Какой из следующих IP -адресов может быть назначен?
- 127.3.1.4/28 - Loopback
- 192.168.10.112/30 - Private IP
- 237.6.1.2/24 - Class D, Multicast
- **145.4.2.55/26**

3. The administrator cannot use telnet to manage the AR2200. The administrator is able to verify connectivity to the router and has been informed that other administrators have no difficulties using telnet.Which statements describe the possible reasons for this problem?	                Администратор не может использовать telnet для управления AR2200. Администратор может проверить подключение к маршрутизатору, и ему сообщили, что другие администраторы не испытывают трудностей с использованием telnet. Какие утверждения описывают возможные причины этой проблемы?
- **The user has been deleted.**
- The telnet service in the AR2200 router has been disabled. - нет т.к. другие могут зайти
- **The user’s status has been blocked**
- The user’s privilege level has been changed to 0 - он все равно мог бы зайти

4. What is the TPID value defined by IEEE 802.1Q? Какое значение TPID определяется IEEE 802.1Q?
- 0x9100 - 802.1ad
- 0x7200 - 802.3cg
- 0x8200 - CVLAN & SVLAN
- **0x8100** - 802.1Q

5. When the lost accesses web service of the server, the value of the "Protocol" field at the network layer is 6.  |  Когда утерянные веб -службы сервера обращаются к сетевому серверу, значение поля «протокола» на сетевом уровне составляет 6.
- **True**
- False

6. In a broadcast address, all host bits are set to 1 and a broadcast address can be used as a host address. 	В трансляционном адресе все биты хоста устанавливаются на 1, а адрес трансляции может использоваться в качестве хост -адреса.
- True
- **False** - все биты = 1 - да, но как хост быть не может

7. What is the UDP port number used by the DHCPv6 server?	      Какой номер порта UDP используется сервером DHCPV6?
- **547**

8. Which of the following working modes are supported by Huawei Enterprise API?	   Какой из следующих рабочих режимов поддерживается Huawei Enterprise API?
- **FIT**
- **FAT**
- Local - не существует
- Cloud - не существует

9. Ping 10.0.0.2: 56 data bytes, press CTRL_C to break             Reply from 10.0.0.2: bytes=800 Sequence=1 ttI=255 time=2 ms                    Reply from 10.0.0.2: bytes=800 Sequence=2 ttl=255 time=10 ms               --- 10.0.0.2 ping statistics ---2 packet(s) transmited              2 packet(s) received                0.00% packet loss                 round-trip min/avg/max = 2/6/10 ms                  Администратор сети использует команду Ping для проверки подключения к пункту назначения 10.0.0.2 на маршрутизаторе серии Huawei AR. Какой оператор, касающийся вывода, является правильным?"  
- **The network administrator used the command ping -c 2 -s 800 10.0.0.2**

Пояснение: ping - для пропинговки, -c - кол-во раз (в выводе было 2 записи), -s - размер сообщения (bytes=800)

10. \[R1\]display interface GigabitEthernet0/0/0 GigabitEthernet0/0/0 current state - Administratively DOWN Line protocol current state : DOWN Refer to the display output. What can be determined based on the output of the display command?"	"[R1] отображение интерфейса GigabitEthernet0/0/0GigabitEthernet0/0/0 Текущее состояние - административно вниз Линейное протокол Текущее состояние: вниз Обратитесь к выводу дисплея. Что можно определить на основе вывода дисплея командование?
- **Interface Gigabit Ethernet 0/0/0 has been manually shut down by an administrator**

Пояснение: `current state - Administratively DOWN` - порт отключен административно (кем-то)

11. Which of the following statements is true about the alternate port in RSTP?           	Какое из следующих утверждений верно относительно альтернативного порта в RSTP?
- **An alternate port acts as a backup of the root port and provides an alternate path from the designated bridge to the root bridge**

12. What are the roles of OSPF protocol DR and BDR?	Каковы роли протокола OSPF DR и BDR?
- **Reduce the number of exchanges of link state information**
- **Reduce the number of adjacencies**
- Reduce the time to establish adjacency - время сходимости зависит от таймеров
- Reduce the types of OSPF protocol packets - DR, BDR не вляют на типы пакетов определенные в стандарте

13. Which of the following commands can be used to view the router's CPU usage?	            Какая из следующих команд можно использовать для просмотра использования процессора маршрутизатора?
- **display cpu-usage**

14. In the network shown in the figure, the administrator hopes that all hosts cannot access the web service (the port number is 80), and other services are normally accessed, so in the interface configuration of G0/0/1, traffic-filter outbound needs todefine which ACL rule?                   В сети, показанной на рисунке, администратор надеется, что все узлы не могут получить доступ к веб-службе (номер порта 80), а к другим службам доступ осуществляется нормально, поэтому в конфигурации интерфейса G0/0/1 для фильтрации исходящего трафика необходимо определить какое правило ACL?
- **acl number 3000 rule 5 deny tcp destination-port eq www rule 10 permit ip**

15. Примените следующий ACL к Telnet. Какое из следующих утверждений является верным?                       acl number 2000            rule 5 deny source 172.16.105.3 0            rule 10 deny source 172.16.105.4 0            rule 15 deny source 172.16.105.5 0            rule 20 permit
- **The device whose IP address is 172.16.105.6 can use the Telnet service**

Пояснение: это единственный IP, который в данном acl не отвергается

16. Какую скорость разгоняет 802.11g?
- **54 Мбит/с** - медленный пидарас!

17. Which of the following statements is true about root bridge election of STP?          	Какое из следующих утверждений верно относительно выборов Root Bridge STP?
- **The device with the smallest bridge priority becomes the root bridge**
- The device with the largest bridge priority becomes the root bridge - ортогонально правильному
- If the bridge priorities of devices are the same, the device with the largest MAC address becomes the root bridge - с наименьшим MAC
- If the bridge priorities are the same, the device with the largest number of ports becomes the root bridge - кол-во портов не играет роли

18. Which of the following parameters are used for STP calculation on a switching network running STP?	        Какой из следующих параметров используется для расчета STP в сети коммутации, работающей на STP?
- **Root path cost**
- **Port ID**
- Forward Delay - просто передается
- **Bridge ID**

19. The network administrator has decided to configure link aggregation in the enterprise network. Which of the following represent advantages of link aggregation? 	Администратор сети решил настроить агрегацию ссылок в корпоративной сети. Что из следующего представляет преимущества агрегации ссылок?
- **Load balancing**
- Improved security
- **Enhanced reliability**
- **Improved bandwidth**

20. Which of the following descriptions about STP designated ports is correct?            	Какое из следующих описаний, обозначенных STP, является правильным?
- **Designated ports are responsible for sending BPDU to connected network segments**
- Designated ports represent the path leading to the root switch - это Root port делает
- Designated ports forward frames destined for the root switch - это Root port делает
- Each bridge can have only one designated port - нет, к примеру Root Bridge - у него все порты Designated

21. In OSPFv3, router Ids can be used automaticall generated by the system  |  В OSPFV3 идентификаторы маршрутизатора могут использоваться автоматически, генерируемые системой
- **False** - так же как и в старых - вручную
- True

22. What is the default value of switch priority when STP is enabled on Huawei switch?             	Каково значение по умолчанию приоритета переключения, когда STP включен на коммутатор Huawei?
- **32768**
- 16384
- 4096
- 8192

23. <Huawei>display startup     MainBoard:               Startup system software: sd1:/ar2220-v200r003c00spc200.cc               Next startup system software: sd1/ar2220-v200r003c00spc200.cc               Backup system software for next startup: null     Startup saved-configuration file: null     Next startup saved-configuration file: null     Startup license file: null               Next startup license file: null               Startup patch package: null               Nest startup patch package: null               Startup voice-files: null               Next startup voice-files: null     Обратитесь к выводу дисплея. Какое утверждение ложное?
- **The next startup system software cannot be changed** - оно всегда может быть изменено, пока не перезагрузился (просто файл поменять)

24. When configuring a static route on a broadcast interface, you must specify the next-hop IP address.	При настройке статического маршрута на интерфейсе вещания необходимо указать IP-адрес следующего хода.
- **False** 
- True

25. The function of OSPF hello message is            Функция сообщения OSPF hello заключается в следующем
- **Neighbor discovery**
- **Maintain neighbor relationships**
- Synchronize the LSDB of the router - для этого LSU/DBD сообщения
- Update LSA information - для этого LSU сообщения

26. With what kind of routers does a DRother router exchange link state information and route information?	С какими маршрутизаторами информация состояния и маршрута обмена маршрутизатором Drother Router?
- **BDR**
- DRother - DRother напрямую говорит только с DR и BDR
- All OSPF neighbors - DRother напрямую говорит только с DR и BDR
- **DR** 


Примечание: DRother - это не DR или BDR (все остальные)

27. UDP does not guarantee data transmission reliability and does not provide packet sorting and traffic control functions. It is suitable for the traffic that has low requirements for data transmission for data transmission reliability, but high requirement for the transmission speed and delay. 	UDP не гарантирует надежность передачи данных и не обеспечивает функции сортировки пакетов и управления трафиком. Он подходит для трафика, который имеет низкие требования к надежности передачи данных, но высокие требования к скорости передачи и задержке.
- **True**
- False

28. There is no channel overlap in the 14 available frequency bands in the 2.4GHz frequency band | Отсутствует перекрытие каналов в 14 доступных частотных диапазонах в полосе частот 2,4 ГГц
- **False** - 14 канал стоит дальше остальных, но все равно перекрывает другие
- True

29. Which of the following descriptions about Trunk port and Access port is correct?    Какое из следующих описаний Trunk  порта и Access  порта является верным?
- **Access port can only send untagged frames** - предполается что любой проходящий через Access будет иметь требуемый VLAN, так что необходимость в доп. тегировании - нет

30. You can configure a static route on a broadcast interface by specifying the next-hop IP address or outbound interface  |  	Вы можете настроить статический маршрут на интерфейсе вещания, указав IP-адрес следующего хода или исходящий интерфейс
- **True**
- False

31. If an Ethernet data frame is forwarded by the switch and is added with two VLAN tags, how many extra bytes are added to the data frame?	          Если кадр данных Ethernet пересылается коммутатором и добавляется двумя тегами VLAN, сколько дополнительных байтов добавляется в кадр данных?
- **4**

32. Which of the following fields is/are contained in an IPv6 packet header?	Какое из следующих полей содержится в заголовке пакета IPv6?
- **Version**
- **Traffic class**
- **Next header**
- TOS - это че??

33. Which of the following statements regarding the router ID in OSPF are incorrect?	 Какое из следующих утверждений, касающихся идентификатора маршрутизатора в OSPF, неверно?
- **The router ID must be the IP address of an OSPF router interface** - Router ID просто выглядит как IP, но не обязательно им является, можно любой Router ID ему дать
- **The router ID of OSPF routers in the same area must be the same, but can be different in different areas** - скорее наоборот - в одной Area - разные, но в разных Area - могут повтряться
- A router running OSPF must have a router ID for it to operate properly
- **The router ID must be configured manually** - может и автоматически быть настроен

34. Сколько состояний у RSTP ?
- **3** - из 5 состояний STP убрали 2

35. The link aggregation interface can only be used as a Layer 2 interface.        Интерфейс агрегации ссылок можно использовать только в качестве интерфейса уровня 2.  
- **False** - можно и на L3
- True

36. What percentage does the DHCP client expect to send the lease renewal message for the first time?                     Какой процент ожидает клиент DHCP при первой отправке сообщения о продлении аренды?
- **0.5**

37. Before the STA associates with the AP, it needs to exchange some messages to obtain the SSID. What are these messages?                     Прежде чем STA свяжется с точкой доступа, ему необходимо обменяться некоторыми сообщениями, чтобы получить SSID. Что это за сообщения?
- **ResponseProbe Request** - здесь скорее всего используется пассивый режим
- Probe - для активного режима
- Beacon - поддержание состояния
- Discovery - обнаружение 

38. An authentication router has been configured with two domains named“Area1” and “Area2”, following which a user is created with the username “huawei”and the password “hello” for authentication. Which domain does this user belongs to?"         	"Маршрутизатор аутентификации был настроен с двумя названными доменами«Area1» и «Area2», после чего пользователь создается с именем пользователя «Huawei»и пароль «привет» для аутентификации. К какому домену принадлежит этот пользователь?
- **Default domain** - если не указан домен при регистрации, то выдается домен по умолчанию

39. "Which of the following parameters is/are used to identify a security association(SA)?"	   "Какой из следующих параметров используется  для идентификации ассоциации безопасности(SA)?"
- **Security parameter index (SPI)**
- **Security protocol (AH or ESP)**
- **Destination IP address**
- Source IP address - я могу просто из одной сети в другую перейти, но это все же буду я

40. Какое из следующих утверждений о порте на коммутаторе  является ложным?                interface GigabitEthernet0/0/1                 port link-type trunk                 port trunk pvid vlan 200                 port trunk allow-pass vlan 100
- **If the VLAN tag carried in a data frame is 100, the switch removes the VLAN tag and sends the frame** - он оставит его

41. By default, all SNMP versions (SNMPv1, SNMPv2c and SNMPv3) are enabled on Huawei AGR3 series routers	По умолчанию все версии SNMP (SNMPV1, SNMPV2C и SNMPV3) включены на маршрутизаторах серии Huawei Agr3
- **True**
- False

42. Какие из этих этапов есть в DHSP?
- **Discover**
- **Release**
- Reduce
- Inform

43. Примените следующий ACL к SNMP. Какое из следующих утверждений является ложным?                acl number 2000                rule 5 permit source 192.168.1.2 0                rule 10 permit source 192.168.1.3 0                rule 15 permit source 192.168.1.4 0 
- **The device whose IP address is 192.168.1.5 can use the SNMP service** - применяется первое правло

44. Which of the following IPv6 extension headers can occur twice?"	"Какие из следующих заголовков расширения IPv6 могут возникнуть дважды?
- **Destination Options header** - он может использоваться как для конечной точки, так и для промежуточных, поэтому логично, что их может быть несколько

45. In order to join the wireless network STA needs to obtain wireless network information first. Which of the following messages is used by the STA to actively obtain the SSID information?                Чтобы подключиться к беспроводной сети, персоналу необходимо сначала получить информацию о беспроводной сети. Какое из следующих сообщений используется персоналом для активного получения информации SSID?
- **Probe** - в активном режиме

46. The IPv6 address 2001:ABEF:224E:FFE2:BCC0:CD00:DDB:8D58 cannot be abbreviated	Адрес IPv6 2001: ABEF: 224E: FFE2: BCC0: CD00: DDB: 8D58 не может быть сокращено
- **True** - нулевых хестетов нигде нет

47. For multiple paths to the same destination network, the router needs to compare cost values of the paths. If the cost values are the same, the router selects the paths based on the preference value.	Для нескольких путей в одну и ту же сеть назначения маршрутизатор должен сравнивать значения затрат путей. Если значения стоимости одинаковы, маршрутизатор выбирает пути на основе значения предпочтения.
- **True**
- False

48. In the case of Huawei router, what is the "-i" parameter in a Ping command issued on a VRP operating system used to set?	                 В случае с маршрутизатором Huawei, для чего используется параметр "-i" в команде Ping, выданной в операционной системе VRP?
- **Interface for sending an Echo Request packet** - '-i' - означает интерфейс с которого отправлять

49. A hybrid port can be connected to either a user host or a switch	Гибридный порт может быть подключен либо к хосту пользователя, либо к переключателю
- **True** - на то он и гибридный, что = Trunk + Access

50. Дан acl,  какие адреса пройдут             Acl 2000              Rule 5 permit 172.16.0.32 0              Rule 10 permit 172.16.0.0 0.255.0.0
- **172.16.0.32/32** - полное совпадение
- **172.17.0.0/24** - совпадение со 2
- **172.18.0.0.24** - совпадение со 2
- 172.16.0.3/24 - ни с кем не совпадает

51. If the transport-layer protocol is UDP, the value of the “Protocol” field at the network layer is 6."	"Если протокол транспортного слоя является UDP, значение поля «протокола» на сетевом уровне составляет 6
- **False** - для UDP - 17 (0x11)
- True

52. Which of the following commands can switch a view from the system view to the user view?         	Какая из следующих команд может переключить представление с представления системы на представление пользователя?
- **Quit**

53. Which stage of the life cycle of campus network construction is the beginning of a project?                Какой этап жизненного цикла строительства сети кампуса является началом проекта?
- **Planning and design**

54. <Huawei> system-view         [Huawei] user-interface console 0         [Huawei-ui-console0] user privilege level 15         [Huawei-ui-console0] authentication-mode password         [Huawei-ui-console0] set authentication password cipher huawei2012         [Huawei-ui-console0] quit         См. Вывод конфигурации. Администратор настроил устройство, используя команды в выходе конфигурации. Что касается этих команд, какое утверждение является ложным
- **The password of a user logged in through console is ‘cipher huawei2012’** - сам пароль 'huawei2012', cipher- метод хранения

55. Which of the following description of static and dynamic routing is wrong?                            Какое из следующих описаний статической и динамической маршрутизации неверно?
- **After the link fails, the static route can automatically complete the network convergence** - статический маршрут не подстраивается под изменения сети

56. When a router is powered on, the router reads the configuration file saved in the default save directory to get itself initialized. If the configuration file does not exist in the default save directory, what does the router use to initialize itself?	                   Когда маршрутизатор включен, маршрутизатор считывает файл конфигурации, сохраненный в каталоге сохранения по умолчанию, чтобы получить инициализированное. Если файл конфигурации не существует в каталоге сохранения по умолчанию, что использует маршрутизатор для инициализации?
- **Default parameters**

57. The administrator plans to implement route backup by configuring static floating routes, what is the correct way to achieve this?                  Администратор планирует реализовать резервирование маршрутов путем настройки статических плавающих маршрутов, что является правильным способом достижения этой цели?
- **The administrator needs to configure different protocol priority values for the main static route and the standby static route**

58. What is the default priority of OSPF routes on a Huawei AR router?"	        "Каков приоритет по умолчанию маршрутов OSPF на маршрутизаторе Huawei AR?
- **10**

59. Now there are the following four segments: 10.24.0.0/24, 10.24.1.0/24, 10.24.2.0/24, 10.24.3.0/24, which route can point to these four network segments at the same time?                       Теперь есть следующие четыре сегмента: 10.24.0.0/24, 10.24.1.0/24, 10.24.2.0/24, 10.24.3.0/24, какой маршрут может указывать на эти четыре сегмента сети одновременно?
- **10.24.0.0/22** - минимальная маска
- **10.24.0.0/21** - маска на 1 бит меньше, захватывает больший диапазон
- **0.0.0.0/0** - маршрут по умолчанию (захватывает все)

60. In the history of WLAN development, which of the following are included in the main wireless protocol standards in the primary mobile office era?    	В истории разработки WLAN, что из перечисленного включено в основные стандарты беспроводного протокола в эпоху основного офиса?
- **802.11a**
- **802.11b**
- 802.11ac - это Wi-Fi 5
- **802.11g**

61. Which of the following command line views exist on the Versatile Routing Platform (VRP)	Какие из следующих представлений командной строки существуют на универсальной платформе маршрутизации (VRP)
- **System view**
- **Interface view**
- **Protocol view**
- **User view**

62. Which of the following methods are supported by VRP to configure the router?                Какие из следующих методов поддерживаются VRP для настройки маршрутизатора?
- **Through the Console port**
- **Through Telnet.**
- **Through the mini-USB port.**
- Through FTP - через него только файл кидать

63. При выборе root комутатора что будет учитываться первым?
- **Bridge ID**

64. What is the length (in bits) of the "Traffic Class" field in the IPv6 packet header?	 Какова длина (в битах) поля «класса трафика» в заголовке пакета IPv6?
- **8** - в IPv6 только Version - 4 бита, остальное не меньше 8

65. According to the VLAN frame format defined in IEEE 802.1Q, how many bits does a VLAN ID contain? 	          Согласно формату кадра VLAN, определенным в IEEE 802.1Q, сколько бит содержит ID VLAN?
- **12** - диапазон VLAN - 0-4096, это занимает 12 бит

66. The Network Management Station uses SNMP to manage devices, which SNMP message is sent when an SNMP registered abnormal event occurs?           	Станция управления сетью использует SNMP для управления устройствами, какое сообщение SNMP отправляется, когда происходит зарегистрированное аномальное событие SNMP?
- **Trap** - остальное это CRUD с состоянием

67. If the Length/Type of an Ethernet data frame = 0x8100, which of the following statements is correct?                Если длина/тип кадра данных Ethernet = 0x8100, какое из следующих утверждений верно?
- **This data frame must carry VLAN TAG** - 0x8100 это 802.1Q (VLAN)

68. \[Router\] ip pool pool1                  [Router-ip-pool-pool1] network 10.10.10.0 mask 255.255.255.0                  [Router-ip-pool-pool1] gateway-list 10.10.10.1                  [Router-ip-pool-pool1] quit                  [Router] ip pool pool2.                  [Router-ip-pool-pool2] network 10.20.20.0 mask 255.255.255.0                  [Router-ip-pool-pool2] gateway-list 10.20.20.1                  [Router-ip-pool-pool2] quit                  [Router] interface GigabitEthernet 1/0/0                  [Router-GigabitEthernet1/0/0] ip address 10.10.10.1 24                  [Router-GigabitEthernet1/0/0] dhcp select global                                    После того, как администратор выполняет предыдущие конфигурации на маршрутизаторе, какой из следующих IP -адресов может подключить хост с G1/0/0 на маршрутизаторе?
- **IP address on the 10.10.10.0/24 network segment** - скорее всего IP адрес выдается из пула с наименьшим значением (10.20.20.0/24 по числам больше), но это предположение

69. A port directly connects to a designated port on the peer device and is used to receive BPDU to monitor the changes occurring in the network. However, it does not forward any packet. Which of the following ports represents this port?	              Порт непосредственно подключается к указанному порту на одноранговом устройстве и используется для приема BPDU для мониторинга изменений, происходящих в сети. Тем не менее, он не пересылает пакет. Какой из следующих портов представляет этот порт?
- **Alternate Port**

70. When using ftp for file transfer how many connections will be established   Сколько соединений будет установлено при использовании ftp для передачи файлов
- **2** - для управления и передачи - разные порты

71. When using the ping command on the VRP platform, if you need to specify an IP address as the source address of the echo request message, which of the following parameters should be used?      При использовании команды ping на платформе VRP, если вам нужно указать IP-адрес в качестве адреса источника сообщения эхо-запроса, какой из следующих параметров следует использовать?  
- **-a** - '-a' - адрес назначения

72. Which of the following IEEE802.11 standards only supports 2.4GHz frequency for communication ?Какой из следующих стандартов IEEE802.11 поддерживает только частоту 2,4 ГГц для связи?
- **802.11g** - остальные поддерживают 5GHz

73. Which of the following fields exist in both IPv6 and IPv4 packet headers?	Какие из следующих полей существуют в заголовках пакетов IPv6 и IPv4?
- **Destination Address**
- **Version**
- Next header - IPv6 only
- **Source Address**

74. display startup              MainBoard:               Startup system software: sd1:/ar2220-v200r003c00spc200.cc               Next startup system software: sd1:/ar2220-v200r003c00spc2001cc               Backup system software for next startup: null               Startup saved-configuration file: null               Next startup saved-configuration file: null               Startup license file: null               Next startup license file: null               Startup patch package: null               Next startup patch package: null               Startup voice-files: null               Next startup voice-files: null               The preceding information is the \""display startup\"" command output on the AR2200 router.  Какое из следующих утверждений неверно относится к такой информации?
- **The system file for next startup cannot be modified.** - может быть изменено

75. Which of the following statements regarding static and dynamic routing is incorrect?      	Какое из следующих утверждений относительно статической и динамической маршрутизации неверно?
- **The static route can automatically recover when a link failure is encountered**

76. The network administrator of a certain company wants to uniformly divide the users who often access the company network from different switches into VLAN 10 when they frequently change office locations. Which of the following methods should be used to divide VLANs?          Сетевой администратор определенной компании хочет равномерно разделить пользователей, которые часто получают доступ к сети компании с разных коммутаторов, на VLAN 10, когда они часто меняют местоположение офиса. Какой из следующих методов следует использовать для разделения VLAN? 
- **Divide VLAN based on MAC address** - нужно, чтобы один и тот же компьютер использовал один и тот же VLAN

77. Following a failure of services in the network, an administrator discovered that the configuration in one of the enterprise routers had been changed.What actions can be taken by the administrator to prevent further changes?       	После сбоя услуг в сети администратор обнаружил, что конфигурация в одном из корпоративных маршрутизаторов была изменена. Администратор может предпринять действия, чтобы предотвратить дальнейшие изменения?
- The administrator should configure port-security on the router
- **The administrator should limit access by setting the login privilege of users to 0**
- **The administrator should configure AAA to manage user authorization on the router**
- **The administrator should configure an ACL to allow only the administrator to manage the router**

78. What functions does a Hello packet of OSPF implement? 	Какие функции реализует Hello Packet of OSPF?
- **Neighbor discovery**
- Negotiation of parameters among adjacent ports - это DBD пакеты
- Deletion of unreachable neighbors - это делает сам роутер без уведомления других
- **Maintaining of neighbor relationships**

79. When redundant links exist on a switching network, STP can be used to eliminate loops	если есть петли, STP может с ними справится
- **True**
- False

80. The Layer 2 switch is a data link layer device, which can identify the MAC address information in the data frame, forward data according to the MAC address, and record these MAC addresses and corresponding port information in its own MAC address table.                    Коммутатор уровня 2 - это устройство канального уровня, которое может идентифицировать информацию о MAC-адресе в кадре данных, пересылать данные в соответствии с MAC-адресом и записывать эти MAC-адреса и соответствующую информацию о порте в свою собственную таблицу MAC-адресов.
- **True** 

81. On a serial interface, you can configure a static route by specifying the next hop address or outbound interface.	На последовательном интерфейсе вы можете настроить статический маршрут, указав следующий адрес хопа или исходящий интерфейс.
- **True**

82. In what state does the OSPF protocol determine the master-slave relationship of DD packets?       В каком состоянии протокол OSPF определяет отношение ведущий-ведомый пакетов DD?
- **2-way** - работа начинается в этом состоянии, другие достигаются ВО ВРЕМЯ разбора отношений

83. Информация о радиусе маршрутизатора настроена следующим образом. Какие из Следующие утверждения являются правильными? radius-server template huawei             radius-server shared-key cipher huawei             radius-server authentication 200.0.12.1 1812             radius-server accounting 200.0.12.1 1813             radius-attribute nas-ip 200.0.12.2
- **The IP address of the authentication server is 200.0.12.1.**
- **The IP address of the accounting server is 200.0.12.1.**
- **The source IP address of the RADIUS packets sent by the router is 200.0.12.2.**
- The IP address of the authorization server is 200.0.12.1 - у RADIUS нет отдельного AUTHORIZATION сервера, там аутентификация и авторизация вместе

84. After a network administrator enables the traceroute function on a router, what is the value of the "Protocol" field in the IPv4 header of the data packet sent by the router?	           После того, как сетевой администратор включает функцию Traceroute на маршрутизаторе, каково значение поля «протокола» в заголовке IPv4 пакета данных, отправленного маршрутизатором?
- **1**

85. In RSTP, an edge port becomes a common STP port after receiving a configuration BPDU 	в RSTP крайний порт становится обычным STP портом
- **Ture** - Edge порт сразу переходит в Forwarding

86. ICMP packets do not contain port numbers. Thereforem NAPT cannot be used.  |  Пакеты ICMP не содержат номера портов. Таким образом, NAPT не может быть использован.
- **False** - порты используют приложения, которые имеют порты

87. Which of the following commands is used to display the OSPF neighbor relationship establishment?  	Какая из следующих команд используется для отображения установления отношений между соседями OSPF?
- **display ospf peer**

88. MPLS is often used on IP backbone networks. Forwarding equivalence class (FEC) is a term used in MPLS to describe a collection of packets with the same characteristics.	MPLS часто используется в сетях IP -магистрали. Класс эквивалентности пересылки (FEC) - это термин, используемый в MPLS для описания коллекции пакетов с одинаковыми характеристиками.
- **True**

89. Which field in the IPv6 packet header can be used for QoS?	      Какое поле в заголовке пакета IPv6 можно использовать для QOS?
- **Traffic class**

90. After a switch receives a unicast data frame, it searches the MAC address table for the destination MAC address. Which of the following statements is false?                    	После того, как коммутатор получает unicast data frame, он ищет таблицу MAC -адресов для MAC -адреса назначения. Какое из следующих утверждений является ложным?
- **If the MAC address cannot be found, the switch discard the frame** - должно быть это

91. Which of the following statement about Python is incorrect?                    Какое из следующих утверждений о Python неверно?
- **Is a fully open source high-level programming language**

92. Какие типы ACL существуют
- **Basic**
- **User**
- **Advanced**
- **Layer 2**

93. On Huawei switches, you can rut the vlan batch command to create multiple VLANs in batches  |  На коммутаторах Huawei вы можете направить команду VLAN Pactor, чтобы создать несколько VLAN в партиях
- **True**

94. Информация о конфигурации G0/0/1 на коммутаторе выглядит следующим образом. Какие из следующих кадров данных VLAN являются нетегированными, когда коммутатор пересылает эти кадры?             #             interface GigabitEthernet0/0/1              port link-type trunk              port trunk pvid vlan 10              port trunk allow-pass vlan 10 20 30 40              #
- **Data frames from VLAN 10**

95. The controller is the core component of SDN. The controller connects to the device through the southbound interface. Which of the following belong to the controller southbound protocol?                 Контроллер является основным компонентом SDN. Контроллер подключается к устройству через интерфейс southbound. Что из перечисленного ниже относится к протоколу южного соединения контроллера?
- **OpenFlow**
- **SNMP**

96. If a loop occurs on a switching network, a broadcast storm may occur."	"Если в переключающей сети происходит цикл, может произойти шторм вещания
- **True**

97. After a network administrator enables the traceroute function on a router, what is the value of the "TTL" field in the IPv4 header of the first data packet sent by the router?	После того, как сетевой администратор включает функцию Traceroute на маршрутизаторе, каково значение поля «TTL» в заголовке IPv4 первого пакета данных, отправленного маршрутизатором?
- **1** - другой получает, декрементирует, получает 0 и возвращает ICMP

98. \[RTA\]acl 2001 \[RTA-acl-basic-2001\] rule permit source 10.0.1.0 0.0.0.255                [RTA-acl-basic-2001] rule deny source 10.0.1.0 0.0.0.255. Какое из следующих утверждений, касающихся ACL 2001 правильный?
- **00:26:57:00:1F:02**
- **02:26:57:00:1F:02**
- 03:26:57:00:1F:02
- 01:26:57:00:1F:02

Пояснение: в MAC адресе 1 бит первого октета - бит мультикаста. Если 1 - адрес групповой, иначе для одного устройства

99. What is the default priority of static routes on a Huawei AR router?	Каков приоритет по умолчанию статических маршрутов на маршрутизаторе Huawei AR?
- **60**

100. In IPv6, the flow label field, source address field, and destination address field specify a forwarding path for a specific data flow.	В IPv6 поле метки потока, поле адреса источника и поле адреса назначения указывают путь пересылки для конкретного потока данных.
- **True**