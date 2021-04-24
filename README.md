# INI-Editor

## [ENG]
## Overview
This project is a graphical user interface tool for processing configuration files with the extension “.ini”, developed on the WPF (Windows Presentation Foundation) platform.
An INI file is a text document divided into sections, each of which contains name-value pairs.
All parameter and section names are strings without spaces, consisting of Latin characters, numbers and underscores. Section names are enclosed in square brackets, no spaces. Parameter values ​​are separated from parameter names with an equal sign (=).
Parameter values can be one of the types:
- integer
- float
- string: no spaces, but unlike the parameter name, it can also contain the "dot" character

The file may contain comments. Anything after the semicolon is considered a comment. Comments as well as the semicolon itself should be ignored.

##### INI-file sample:
#
```INI
[COMMON]
StatisterTimeMs = 50000
LogNCMD = 1 ; Logging ncmd proto
LogXML = 0 ; Logging XML proto
DiskCachePath = /sata/panorama ; Path for file cache
OpenMPThreadCount = 2

[ADC_DEV]
BufferLenSeconds = 0.65 ; Buffer length for ADC data in GPU memory, seconds
SampleRate = 120000000.0 ; Sample rate of ADC
Driver = libusb ; cypress / libusb / random / fileIQS

[NCMD]
EnableChannelControl = 1 ; Use or not CHG / CHGEXT commands
SampleRate = 900000.0 ; ANOTHER Sample Rate
TidPacketVersionForTidControlCommand = 2

; TidPacket versions
; 0 - no packets
; 1 - header: data size, tid
; 2 - header: data size, tid, timestamp

[LEGACY_XML]
ListenTcpPort = 1976

[DEBUG]
PlentySockMaxQSize = 126
```

## Features

- Parsing INI-file.
- Displaying INI-file with changes.
- Adding a new section / pair.
- Removing an existing section / pair.
- Working with comments: adding / removing
- Methods for getting a value of a certain type with a certain name from a certain section.
- Handling file system errors, file format, invalid parameter types and more.

## Author
- **Alexander Ssorin** - project developer - [Sashanator](github.com/Sashanator)

## Appearance
##### Main window:
![MainWindow](https://i.ibb.co/J33mB3V/2021-04-24-16-16-12.png)
##### Working process:
![Work](https://imagizer.imageshack.com/img923/4853/lf7i9S.gif)

## License
[MIT](https://choosealicense.com/licenses/mit/)

## [RUS]
## Обзор

Данный проект представляет собой инструмент для обработки конфигурационных файлов с расширением ".ini" с графическим пользовательским интерфейсом, разработанный на платформе WPF (Windows Presentation Foundation). 
INI-файл представляет собой текстовый документ, разделённый на секции, каждая из которых содержит пары имя-значения.
Все имена параметров и секций – это строки без пробелов, состоящие из символов латинского алфавита, цифр и знаков нижнего подчёркивания. Имена секций заключены в квадратные скобки, без пробелов. Значения параметров отделены от имён параметров знаком равенства ( = ).
Значения параметров могут быть одним из типов:
- целочисленным
- вещественным
- строковым: без пробелов, но в отличие от имени параметра может содержать также символ "точка"

Файл может содержать комментарии. Комментарием считается всё, что находится после знака "точка с запятой". Комментарии, как и сам знак "точка с запятой" должны быть проигнорированы.

##### Пример INI-файла
#
```INI
[COMMON]
StatisterTimeMs = 50000
LogNCMD = 1 ; Logging ncmd proto
LogXML = 0 ; Logging XML proto
DiskCachePath = /sata/panorama ; Path for file cache
OpenMPThreadCount = 2

[ADC_DEV]
BufferLenSeconds = 0.65 ; Buffer length for ADC data in GPU memory, seconds
SampleRate = 120000000.0 ; Sample rate of ADC
Driver = libusb ; cypress / libusb / random / fileIQS

[NCMD]
EnableChannelControl = 1 ; Use or not CHG / CHGEXT commands
SampleRate = 900000.0 ; ANOTHER Sample Rate
TidPacketVersionForTidControlCommand = 2

; TidPacket versions
; 0 - no packets
; 1 - header: data size, tid
; 2 - header: data size, tid, timestamp

[LEGACY_XML]
ListenTcpPort = 1976

[DEBUG]
PlentySockMaxQSize = 126
```

## Возможности программы

- Парсинг INI-файла.
- Отображение INI-файла с изменениями.
- Добавление новой секции/пары.
- Удаление существующей секции/пары
- Работа с комментариями: добавление/удаление
- Реализованы методы получения значения определённого типа с определённым именем из определённой секции.
- Обработка ошибок файловой системы, формата файлов, неверного типа параметров и прочего.

## Автор
- **Александр Ссорин** - разработчик проекта - [Sashanator](github.com/Sashanator)

## Внешний вид
##### Главное рабочее окно:
![MainWindow](https://i.ibb.co/J33mB3V/2021-04-24-16-16-12.png)
##### Рабочий процесс:
![Work](https://imagizer.imageshack.com/img923/4853/lf7i9S.gif)

## Лицензия
[MIT](https://choosealicense.com/licenses/mit/)
