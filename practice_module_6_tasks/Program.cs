/* Курс: Шаблоны проектирования приложений

Тема: Модуль 06 Паттерны поведения. Стратегия. Наблюдатель
Баллы: 

Задача:
Создать сложное приложение, которое симулирует работу системы бронирования путешествий. В системе пользователи могут выбирать различные типы транспорта (самолет, поезд, автобус и т.д.), а также различные методы расчета стоимости поездки в зависимости от множества факторов (расстояние, класс обслуживания, тип транспорта и дополнительные услуги).
Описание:
•	Контекст: Система бронирования путешествий, которая может использовать различные стратегии расчета стоимости поездки.
•	Стратегии: Каждая стратегия будет представлять собой алгоритм для расчета стоимости поездки с учетом различных факторов (расстояние, тип транспорта, класс обслуживания и другие).
•	Дополнительные факторы: В задачу вводятся дополнительные требования, такие как класс обслуживания (эконом, бизнес), наличие скидок, скидки для детей или пенсионеров, количество пассажиров и пр.
Цели:
1.	Построить гибкую систему, в которой можно добавлять новые алгоритмы расчета стоимости поездки (стратегии) без изменения основного кода.
2.	Организовать архитектуру таким образом, чтобы клиент мог легко менять стратегии на лету.
3.	Поддержать дополнительные факторы, влияющие на расчет стоимости поездки (скидки, дополнительные услуги и т.д.).
Шаги выполнения:
1.	Создайте интерфейс ICostCalculationStrategy, который будет представлять стратегию расчета стоимости поездки.
2.	Создайте несколько классов-стратегий, которые реализуют интерфейс ICostCalculationStrategy. Каждая стратегия будет рассчитывать стоимость в зависимости от типа транспорта: самолет, поезд, автобус и т.д.
3.	Создайте класс контекста TravelBookingContext, который будет использовать различные стратегии для расчета стоимости поездки в зависимости от выбора пользователя.
4.	Добавьте возможность выбора дополнительных факторов, влияющих на стоимость, таких как скидки (например, скидка для детей или пенсионеров) и класс обслуживания (эконом, бизнес).
5.	Напишите клиентский код, который будет взаимодействовать с контекстом, позволяя пользователю выбрать тип транспорта, ввести необходимые данные и рассчитать стоимость поездки.
Дополнительные условия:
1.	Расширяемость: Добавьте новые виды транспорта или расширьте существующие стратегии с учетом дополнительных факторов (например, учитывайте топливо, налоги, региональные коэффициенты).
2.	Обработка ошибок: Включите валидацию пользовательских данных и обработку ошибок (например, неверные входные значения, отсутствие стратегии).
3.	Расширение на более сложные факторы: Добавьте возможность расчета для более сложных сценариев, таких как наличие багажа, бронирование групповых поездок или поездок с пересадками.
Требования:
•	В коде должно быть минимум 3 различных стратегии.
•	Клиент должен иметь возможность настраивать контекст для выбора подходящей стратегии.
•	Необходимо учитывать дополнительные факторы, такие как скидки, класс обслуживания и количество пассажиров.
•	Программа должна быть гибкой и расширяемой для добавления новых стратегий. */
/*using System;
public interface ICostCalculationStrategy
{
    decimal CalculateCost(decimal distance, int passenger, string serviceClass, bool hasDiscount);
}

public class AirplaneCostStrategy : ICostCalculationStrategy
{
    public decimal CalculateCost(decimal distance, int passenger, string serviceClass, bool hasDiscount)
    {
        decimal basePrice = 0.20m * distance;
        if (serviceClass.ToLower() == "business")
            basePrice *= 1.5m;

        if (hasDiscount)
            basePrice *= 0.9m;

        return basePrice * passenger;
    }
}

public class TrainCostStrategy : ICostCalculationStrategy
{
    public decimal CalculateCost(decimal distance, int passenger, string serviceClass, bool hasDiscount)
    {
        decimal basePrice = 0.08m * distance;
        if (serviceClass.ToLower() == "business")
            basePrice *= 1.2m;

        if (hasDiscount)
            basePrice *= 0.85m;

        return basePrice * passenger;
    }
}

public class BusCostStrategy : ICostCalculationStrategy
{
    public decimal CalculateCost(decimal distance, int passenger, string serviceClass, bool hasDiscount)
    {
        decimal basePrice = 0.05m * distance;
        if (serviceClass.ToLower() == "business")
            basePrice *= 1.1m;

        if (hasDiscount)
            basePrice *= 0.8m;

        return basePrice * passenger;
    }
}


public class TravelBookingContext
{
    private ICostCalculationStrategy calculationStrategy;

    public void SetCostCalculation(ICostCalculationStrategy strategy)
    {
        this.calculationStrategy = strategy;
    }

    public decimal GetTravelCost(decimal distance, int passenger, string serviceClass, bool hasDiscount)
    {
        if (calculationStrategy == null)
            throw new InvalidOperationException("Не выбрана стратегия расчёта!");
        return calculationStrategy.CalculateCost(distance, passenger, serviceClass, hasDiscount);
    }
}


class Program
{
    static void Main(string[] args)
    {
        TravelBookingContext travelBooking = new TravelBookingContext();

        travelBooking.SetCostCalculation(new AirplaneCostStrategy());
        Console.WriteLine("Самолёт: " +
            travelBooking.GetTravelCost(1500m, 2, "business", true) + " $");

        travelBooking.SetCostCalculation(new TrainCostStrategy());
        Console.WriteLine("Поезд: " +
            travelBooking.GetTravelCost(1500m, 2, "econom", false) + " $");

        travelBooking.SetCostCalculation(new BusCostStrategy());
        Console.WriteLine("Автобус: " +
            travelBooking.GetTravelCost(500m, 3, "econom", true) + " $");
    }
}*/

/* Задача:
Необходимо разработать систему управления биржевыми торгами на C#, которая использует паттерн Наблюдатель (Observer). Система должна позволять различным пользователям подписываться на обновления цен акций и получать уведомления при изменении стоимости акций в режиме реального времени. Ваша задача — реализовать гибкую архитектуру, позволяющую добавлять новых наблюдателей (например, торговых роботов, уведомления по электронной почте, мобильные приложения) и легко управлять подписками.
Описание:
1.	Субъект (Биржа): Система управления биржевыми торгами, которая хранит информацию о различных акциях и изменениях их цен. При изменении цены акции биржа уведомляет всех подписчиков об изменении.
2.	Наблюдатели (Трейдеры, Роботы и т.д.): Это объекты, которые подписаны на изменение цен акций. Каждый наблюдатель будет реагировать по-своему: один может просто выводить информацию, другой может совершать действия на основе определенных условий (например, автоматически покупать или продавать акции).
3.	Клиентский код: Клиент должен иметь возможность добавлять и удалять наблюдателей на лету, а также подписывать каждого наблюдателя только на интересующие его акции.
Цели:
1.	Построить систему, которая позволяет подписчикам (наблюдателям) подписываться на изменения цен конкретных акций.
2.	Обеспечить возможность гибкого добавления и удаления наблюдателей на лету.
3.	Разработать стратегию, по которой биржа может одновременно обрабатывать множество акций и уведомлять наблюдателей только о тех акциях, на которые они подписаны.
4.	Предусмотреть возможность расширения системы, добавив новых наблюдателей с различными сценариями обработки данных.
Шаги выполнения:
1.	Создайте интерфейс IObserver для наблюдателей
2.	Создайте интерфейс ISubject для субъекта (Биржа)
3.	Реализуйте класс StockExchange, который будет играть роль субъекта и хранить информацию о различных акциях
4.	Создайте несколько классов-наблюдателей:
a.	Трейдер, который реагирует на изменение цены акции, выводя информацию на экран.
b.	Автоматический торговый робот, который автоматически покупает или продает акции в зависимости от определенных условий (например, цена выше или ниже определенного значения).
5.	Реализуйте клиентский код, который будет имитировать биржевые торги и взаимодействовать с наблюдателями

Дополнительные условия:
1.	Фильтрация уведомлений: Добавьте возможность для наблюдателей фильтровать уведомления (например, чтобы они получали уведомления только при превышении определенной цены).
2.	Асинхронные уведомления: Добавьте возможность асинхронного уведомления наблюдателей, чтобы имитировать реальное время в биржевых торгах.
3.	Расширяемость системы: Реализуйте поддержку подписки на несколько акций одновременно и возможность гибкого расширения системы новыми типами наблюдателей.
4.	Логирование: Добавьте логирование событий, таких как добавление и удаление наблюдателей, а также изменения цен акций.
Дополнительные факторы:
1.	Отчеты по подписчикам: Реализуйте возможность генерации отчетов, которые показывают, какие наблюдатели подписаны на те или иные акции и как часто они получают уведомления.
2.	Реальные сценарии: Добавьте сценарии изменения цен акций в реальном времени с использованием событий (например, новостные события, выход финансовых отчетов).
Требования:
•	Система должна поддерживать подписку наблюдателей на различные акции.
•	При изменении цены акции система должна уведомлять только тех наблюдателей, которые подписаны на конкретную акцию.
•	Наблюдатели должны получать данные о конкретной акции и ее новой цене. */

/* using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IObserver
{
    void Update(string stockName, decimal newPrice);
}

public interface ISubject
{
    void Attach(string stockName, IObserver observer);
    void Detach(string stockName, IObserver observer);
    void Notify(string stockName);
}

public class StockExchange : ISubject
{
    private Dictionary<string, decimal> _stocks = new Dictionary<string, decimal>();
    private Dictionary<string, List<IObserver>> _observers = new Dictionary<string, List<IObserver>>();

    public void AddStock(string name, decimal price)
    {
        _stocks[name] = price;
        _observers[name] = new List<IObserver>();
        Console.WriteLine($"Добавлена акция {name} по цене {price}$");
    }

    public void UpdateStockPrice(string name, decimal newPrice)
    {
        if (_stocks.ContainsKey(name))
        {
            _stocks[name] = newPrice;
            Console.WriteLine($"\nАкция {name} изменила цену: {newPrice}$");
            Notify(name);
        }
    }

    public void Attach(string stockName, IObserver observer)
    {
        if (_observers.ContainsKey(stockName))
        {
            _observers[stockName].Add(observer);
            Console.WriteLine($"Подписчик добавлен на {stockName}");
        }
    }

    public void Detach(string stockName, IObserver observer)
    {
        if (_observers.ContainsKey(stockName))
        {
            _observers[stockName].Remove(observer);
            Console.WriteLine($"Подписчик удалён с {stockName}");
        }
    }

    public async void Notify(string stockName)
    {
        if (_observers.ContainsKey(stockName))
        {
            foreach (var observer in _observers[stockName])
            {
                await Task.Delay(200);
                observer.Update(stockName, _stocks[stockName]);
            }
        }
    }
}

public class Trader : IObserver
{
    public string Name { get; }

    public Trader(string name)
    {
        Name = name;
    }

    public void Update(string stockName, decimal newPrice)
    {
        Console.WriteLine($"{Name}: новая цена {stockName} - {newPrice}$");
    }
}

public class TradingBot : IObserver
{
    public string BotName { get; }
    private decimal BuyThreshold;
    private decimal SellThreshold;

    public TradingBot(string botName, decimal buy, decimal sell)
    {
        BotName = botName;
        BuyThreshold = buy;
        SellThreshold = sell;
    }

    public void Update(string stockName, decimal newPrice)
    {
        if (newPrice <= BuyThreshold)
            Console.WriteLine($"{BotName}: покупаю {stockName} (цена {newPrice}$ <= {BuyThreshold}$)");
        else if (newPrice >= SellThreshold)
            Console.WriteLine($"{BotName}: продаю {stockName} (цена {newPrice}$ >= {SellThreshold}$)");
        else
            Console.WriteLine($"{BotName}: наблюдаю за {stockName}, цена {newPrice}$");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        StockExchange exchange = new StockExchange();
        exchange.AddStock("AAPL", 150);
        exchange.AddStock("GOOG", 1200);

        Trader trader1 = new Trader("Дархан");
        Trader trader2 = new Trader("Петр");
        TradingBot bot1 = new TradingBot("SmartBot", 100, 160);
        TradingBot bot2 = new TradingBot("ProfitBot", 1100, 1300);

        exchange.Attach("AAPL", trader1);
        exchange.Attach("AAPL", bot1);
        exchange.Attach("GOOG", trader2);
        exchange.Attach("GOOG", bot2);

        await Task.Delay(1000);
        exchange.UpdateStockPrice("AAPL", 140);
        await Task.Delay(1000);
        exchange.UpdateStockPrice("AAPL", 160);
        await Task.Delay(1000);
        exchange.UpdateStockPrice("GOOG", 1150);
        await Task.Delay(1000);
        exchange.UpdateStockPrice("GOOG", 1310);
    }
} */