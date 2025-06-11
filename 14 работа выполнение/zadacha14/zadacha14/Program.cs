
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

public class clsSite
{
    private static short counter = 0; // Статический счётчик для уникального ID

    private short id;                  // Уникальный идентификатор сайта
    private string protocol;           // Протокол (http, https и т.д.)
    private string domainZone;         // Доменная зона (например, "com", "ru")
    private string hosting;            // Хостинг (предпоследний уровень домена)
    private string[] upperDomains;     // Все уровни домена (массив)
    private long ip;                   // IP-адрес в виде числа
    private string mainPageTitle;      // Заголовок главной страницы
    private string currentPageTitle;   // Заголовок текущей страницы
    private long visitDate;            // Дата посещения в Unix-времени (секунды)
    private bool isSecure;             // Флаг безопасности (https = true)

    public clsSite(string address, string mainTitle, string currentTitle, string ipString, string dateString)
    {
        this.id = ++counter;            // Присваиваем уникальный ID объекту

        Uri uri = new Uri(address);     // Парсим URL
        protocol = uri.Scheme;          // Сохраняем протокол
        isSecure = detectSecurity();   // Определяем безопасность (https ли)

        string host = uri.Host;
        upperDomains = host.Split('.');// Разбиваем домен на части
        domainZone = upperDomains[upperDomains.Length - 1];            // Получаем доменную зону
        hosting = upperDomains.Length > 1 ? upperDomains[upperDomains.Length - 2] : upperDomains[0]; // Получаем "хостинг" — предпоследний уровень домена

        this.mainPageTitle = mainTitle;
        this.currentPageTitle = currentTitle;

        ip = convertIpToLong(ipString); // Конвертируем IP из строки в число
        this.visitDate = changeVisitDateByString(dateString); // Конвертируем дату посещения из строки в Unix-время
    }

    public string createSiteString()
    {
        // Формируем URL в виде "протокол://домен"
        return protocol + "://" + string.Join(".", upperDomains);
    }

    public string[] getUpperDomainLevels()
    {
        // Возвращаем массив уровней домена
        return upperDomains;
    }

    public void formatBibliography()
    {
        // Вывод формата библиографической ссылки с датой посещения
        string dateStr = formatUnixDate(visitDate);
        Console.WriteLine(mainPageTitle + " [Электронный ресурс] : " + currentPageTitle +
                          ". URL: " + createSiteString() +
                          " (дата обращения: " + dateStr + ")");
    }

    public long changeVisitDateByString(string dateString)
    {
        // Конвертация даты в формате "дд.мм.гггг" в Unix-время (секунды с 1970-01-01)
        DateTime dt;
        if (DateTime.TryParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                                   DateTimeStyles.None, out dt))
        {
            TimeSpan ts = dt - new DateTime(1970, 1, 1);
            return (long)ts.TotalSeconds;
        }
        return 0; // Возвращаем 0 при ошибке парсинга
    }

    public bool detectSecurity()
    {
        // Если протокол заканчивается на 's' (https), возвращаем true
        return protocol.ToLower().EndsWith("s");
    }

    private long convertIpToLong(string ipStr)
    {
        // Конвертация IP из стандартного формата в число
        IPAddress ipAddr = IPAddress.Parse(ipStr);
        byte[] bytes = ipAddr.GetAddressBytes();
        long value = ((long)bytes[0] << 24) + ((long)bytes[1] << 16) + ((long)bytes[2] << 8) + bytes[3];
        return value;
    }

    private string formatUnixDate(long seconds)
    {
        // Форматирует Unix-время в строку "дд.мм.гггг"
        DateTime dt = new DateTime(1970, 1, 1).AddSeconds(seconds);
        return dt.ToString("dd.MM.yyyy");
    }

    public override string ToString()
    {
        // Возвращает строковое представление объекта: заголовок и IP-адрес
        string ipStr = convertLongToIp(ip);
        return mainPageTitle + " [" + createSiteString() + "] – IP: " + ipStr;
    }

    private string convertLongToIp(long ip)
    {
        // Конвертация числа обратно в IP-адрес в строковом формате
        byte a = (byte)((ip >> 24) & 0xFF);
        byte b = (byte)((ip >> 16) & 0xFF);
        byte c = (byte)((ip >> 8) & 0xFF);
        byte d = (byte)(ip & 0xFF);
        return string.Format("{0}.{1}.{2}.{3}", a, b, c, d);
    }
}
class Program
{
    static void Main()
    {// Установка цвета фона консоли белым
        Console.BackgroundColor = ConsoleColor.White;

        // Установка цвета текста консоли черным
        Console.ForegroundColor = ConsoleColor.Black;

        // Применяем изменения (очищая окно, чтобы фон изменился у всего окна)
        Console.Clear();
        // Создаём объект clsSite с информацией о сайте
        clsSite site = new clsSite(
            "https://mansard-moscow.ru",   // URL сайта
            "Ресторан MANSARD",            // Заголовок главной страницы
            "Главная",                    // Заголовок текущей страницы
            "185.165.123.36",             // IP-адрес сайта
            "23.05.2025"                  // Дата посещения сайта в формате дд.мм.гггг
        );

        // Выводим информацию, вызвав метод ToString() класса clsSite
        Console.WriteLine("ToString()");
        Console.WriteLine(site.ToString());

        // Выводим полную строку формирования URL
        Console.WriteLine("createSiteString()");
        Console.WriteLine(site.createSiteString());

        // Получаем и выводим уровни домена (части доменного имени)
        Console.WriteLine("getUpperDomainLevels()");
        string[] levels = site.getUpperDomainLevels();
        foreach (string level in levels)
            Console.WriteLine(level);

        // Форматируем и выводим библиографическую ссылку с информацией о сайте
        Console.WriteLine("formatBibliography()");
        site.formatBibliography();

        // Конвертируем строку с датой в Unix-время и выводим результат
        Console.WriteLine("changeVisitDateByString(\"01.06.2025\")");
        long newVisitDate = site.changeVisitDateByString("01.06.2025");
        Console.WriteLine("New visit date (Unix time): " + newVisitDate);

        // Проверяем, использует ли сайт защищённый протокол (HTTPS)
        Console.WriteLine("detectSecurity()");
        Console.WriteLine("Is secure protocol: " + site.detectSecurity());

        // Ожидаем нажатия клавиши, чтобы программа не закрылась сразу
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
        Console.ReadKey();
        
    }
}