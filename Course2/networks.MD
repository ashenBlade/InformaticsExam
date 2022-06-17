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
- MAN:
  - LAN, но больше
  - Подключение баз данных, серверов, других LAN
  - Ethernet (10-100 Gbit/s), WiMAX
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

Первоначальная настройка:
- Дать название устройству - `sysname *Name*`
- Настроить часовой пояс - `clock timezone *Timezone*`
- Настроить время/дату - `clock datetime *date/time*`
- Уровень привилегий - `command-priviledge level *level* view *для какого view*`
- Логин/Пароль для пользователей - `user-interace vty 0 4`
- Время простоя - `idle-timeout *timeout*`

Сохранение настроек:
1. Входим в User-View (`return`)
2. `save`

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

Команда для настройки адреса: `ip address *ip-address* *mask*`

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

###  OSPF Basics

###  Ethernet Switching Basics

###  VLAN Principles and Configuration

###  STP Principles and Configuration

###  Inter-VLAN Communication

###  Eth-Trunk iStack and CSS

###  ACL Principles and Configuration

###  AAA Principles and Configuration

###  Network Address Translation

###  Network Services and Applications

###  WLAN Overview

###  WAN Technologies

###  Network Management and OM

###  IPv6 Basics

###  Introduction to SDN and NFV

###  Network Programmability and Automation

###  Typical Campus Network Architectures and Practices


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
