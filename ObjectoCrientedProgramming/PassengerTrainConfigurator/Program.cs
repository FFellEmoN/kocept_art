using System;
using System.Collections.Generic;

namespace PassengerTrainConfigurator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RailwayStation railwayStation = new RailwayStation();
            railwayStation.Work();
        }
    }

    class RailwayStation
    {
        private Depot _depot;
        private TicketOffice _ticketOffice;
        private Train _train;
        private Direction _direction;
        private List<Person> _people;
        private int _valueVansType = 6;
        private bool _isTicketsSold = false;

        public RailwayStation()
        {
            _depot = new Depot(_valueVansType);
        }

        public void Work()
        {
            const string CreateDirectionMenu = "1";
            const string CreatePeopleListMenu = "2";
            const string FormTrainMenu = "3";
            const string FormTicketOfficeMenu = "4";
            const string OpenTicketSaleMenu = "5";
            const string SentTrainMenu = "6";
            const string ResetAllSeting = "7";
            const string ExitMenu = "8";

            string diciredAction;

            bool isRunning = true;

            int startPositionLeft = 0;
            int startPositionTop = 0;
            int positionTitleLeft = 15;
            int positionTitleTop = 0;
            int positionLineDirectionLeft = 0;
            int positionLineDirectionTop = positionTitleTop + 1;
            int positionTitlePeopleLeft = positionLineDirectionLeft + 30;
            int positionTitlePeopleTop = positionTitleTop + 1;
            int positionLineTrainLeft = positionTitlePeopleLeft + 45;
            int positionLineTrainTop = positionTitleTop + 1;
            int positionLineTicketOfficeLeft = positionLineDirectionLeft;
            int positionLineTicketOfficeTop = positionLineDirectionTop + 5;
            int windowWidth = 150;
            int windowHeight = 40;

            do
            {
                Console.WindowHeight = windowHeight;
                Console.WindowWidth = windowWidth;

                if (_direction != null)
                {
                    Console.SetCursorPosition(positionTitleLeft, positionTitleTop);

                    Console.WriteLine("Подробная информация о маршруте");

                    Console.SetCursorPosition(positionLineDirectionLeft, positionLineDirectionTop);

                    Console.WriteLine("Направление:");
                    Console.WriteLine(_direction.Get());
                    Console.WriteLine($"Затраты: {_direction.Coast}");
                }

                if (_people != null)
                {
                    Console.SetCursorPosition(positionTitlePeopleLeft, positionTitlePeopleTop);

                    Console.WriteLine("Пассажиры:");

                    Console.SetCursorPosition(positionTitlePeopleLeft, positionTitlePeopleTop + 1);

                    Console.WriteLine($"Количество: {_people.Count}");

                    Console.SetCursorPosition(positionTitlePeopleLeft, positionTitlePeopleTop + 2);

                    Console.WriteLine($"Количество без билетов: {GetPepleWithoutTicket()}");
                }

                if (_train != null)
                {
                    Console.SetCursorPosition(positionLineTrainLeft, positionLineTrainTop);

                    Console.WriteLine("Поезд:");

                    Console.SetCursorPosition(positionLineTrainLeft, positionLineTrainTop + 1);

                    Console.WriteLine($"Общее число посадочных мест: {_train.GetValueAllSets()}");

                    Console.SetCursorPosition(positionLineTrainLeft, positionLineTrainTop + 2);

                    Console.WriteLine($"Средняя затраты на посадочное место: {_train.GetAverageCoatSetsTrain()}");
                }

                if (_ticketOffice != null)
                {
                    Console.SetCursorPosition(positionLineTicketOfficeLeft, positionLineTicketOfficeTop);

                    Console.WriteLine("Касса:");

                    Console.SetCursorPosition(positionLineTicketOfficeLeft, positionLineTicketOfficeTop + 1);

                    Console.WriteLine($"Количество билетов: {_ticketOffice.ValueAllTickets}");

                    Console.SetCursorPosition(positionLineTicketOfficeLeft, positionLineTicketOfficeTop + 2);

                    Console.WriteLine($"Средняя цена на билет: {_ticketOffice.TryGetAvergeCoastTicket()}");

                    Console.SetCursorPosition(positionLineTicketOfficeLeft, positionLineTicketOfficeTop + 3);

                    Console.WriteLine($"Денег в кассе: {_ticketOffice.Money}");
                }

                if (_direction != null)
                {
                    Console.SetCursorPosition(positionLineDirectionLeft, positionLineDirectionTop + 5);
                }

                if (_ticketOffice != null)
                {
                    Console.SetCursorPosition(positionLineDirectionLeft, positionLineDirectionTop + 10);
                }

                if (_direction == null && _ticketOffice == null)
                {
                    Console.SetCursorPosition(startPositionLeft, startPositionTop);
                }

                Console.WriteLine($"{CreateDirectionMenu}) - сформировать направление.");
                Console.WriteLine($"{CreatePeopleListMenu}) - сформировать список пассажиров.");
                Console.WriteLine($"{FormTrainMenu}) - сформировать поезд.");
                Console.WriteLine($"{FormTicketOfficeMenu}) - сформировать кассу продажи билетов.");
                Console.WriteLine($"{OpenTicketSaleMenu}) - открыть продажу билетов на направление.");
                Console.WriteLine($"{SentTrainMenu}) - отправить поезд.");
                Console.WriteLine($"{ResetAllSeting}) - сбросить все настройки.");
                Console.WriteLine($"{ExitMenu}) - выйти.");

                Console.Write("\nВведите желаемое действие: ");
                diciredAction = Console.ReadLine();
                Console.WriteLine();

                switch (diciredAction)
                {
                    case CreateDirectionMenu:
                        CreateDirection();
                        break;

                    case CreatePeopleListMenu:
                        FillPeople();
                        break;

                    case FormTrainMenu:
                        FormTrain();
                        break;

                    case FormTicketOfficeMenu:
                        FormTicketOffice();
                        break;

                    case OpenTicketSaleMenu:
                        SellTickets();
                        break;

                    case SentTrainMenu:
                        SentTrain();
                        break;

                    case ResetAllSeting:
                        ResetSeting();
                        break;

                    case ExitMenu:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Такого пункта нет или вы ввели не число.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить.");

                Console.ReadKey();
                Console.Clear();
                Console.SetCursorPosition(0, 0);
            } while (isRunning);
        }

        private string ChooseCity(int sequenceNumber)
        {
            const string TakeMoscowMenu = "1";
            const string TakeSaintPetersburgMenu = "2";
            const string TakeTverMenu = "3";

            string moscow = "Москва";
            string saintPetersburg = "Санкт - Петербург";
            string tver = "Тверь";

            Console.WriteLine($"{TakeMoscowMenu}) - {moscow}");
            Console.WriteLine($"{TakeSaintPetersburgMenu}) - {saintPetersburg}");
            Console.WriteLine($"{TakeTverMenu}) - {tver}");

            Console.Write($"\nВыбирите {sequenceNumber} город: ");
            string diciredAction = Console.ReadLine();
            Console.WriteLine();

            switch (diciredAction)
            {
                case TakeMoscowMenu:
                    return moscow;

                case TakeSaintPetersburgMenu:
                    return saintPetersburg;

                case TakeTverMenu:
                    return tver;

                default:
                    Console.WriteLine("Города под таким номером нету или вы ввели не число.");
                    return null;
            }
        }

        private int GetPepleWithoutTicket()
        {
            int peopleWithoutTickets = 0;

            foreach (Person person in _people)
            {
                if (person.HaveTicket == false)
                    peopleWithoutTickets++;
            }

            return peopleWithoutTickets;
        }

        private void ResetSeting()
        {
            _direction = null;
            _train = null;
            _people = null;
            _ticketOffice = null;
            _depot = new Depot(_valueVansType);
            _isTicketsSold = false;

            Console.WriteLine("Все настройки маршрута сброшенны до начальных.");
        }

        private void SentTrain()
        {
            if (_isTicketsSold)
            {
                Console.WriteLine($"Поезд отправлен в путь по маршруту {_direction.Get()}");

                _direction = null;
                _train = null;
                _people = null;
                _ticketOffice.Clear();
                _isTicketsSold = false;

                Console.WriteLine("Формируйте новое отправление.");
            }
            else
            {
                Console.WriteLine("Сначало необходимо продать открыть продажу билетов.");
            }
        }

        private void FormTrain()
        {
            if (_people != null)
            {
                if (_train == null)
                {
                    _train = new Train();
                    _train.Fill(_depot, _people.Count);

                    Console.WriteLine("Поезд сформирован.");
                }
                else
                {
                    Console.WriteLine("Поезд уже сформирован.");
                }
            }
            else
            {
                Console.WriteLine("Сначало необходимо сформировать список пассажиров.");
            }
        }

        private void CreateDirection()
        {
            string firstCity = null;
            string secondCity = null;
            string value;

            int sequenceNumber = 1;
            int kilometer;

            float coastOneKilometer = 3;
            float coast;

            if (_direction == null)
            {
                firstCity = ChooseCity(sequenceNumber);

                if (firstCity != null)
                {
                    sequenceNumber++;
                    secondCity = ChooseCity(sequenceNumber);
                }

                if (firstCity != null && secondCity != null)
                {
                    Console.WriteLine($"Введите растояние от {firstCity} -> {secondCity}");

                    value = Console.ReadLine();

                    if (int.TryParse(value, out kilometer))
                    {
                        coast = kilometer * coastOneKilometer;
                        _direction = new Direction(firstCity, secondCity, coast);
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели не число.");
                        Console.WriteLine("Попробуйте сформировать направление заново.");
                    }
                }
                else
                {
                    Console.WriteLine("Попробуйте сформировать направление заново.");
                }
            }
            else
            {
                Console.WriteLine("Направление уже сформированно.");
            }
        }

        private void SellTickets()
        {
            if (_ticketOffice != null)
            {
                if (_isTicketsSold == false)
                {
                    if (_ticketOffice.ValueAllTickets != 0)
                    {
                        foreach (Person person in _people)
                        {
                            _ticketOffice.TrySellTicket(person);
                        }

                        _isTicketsSold = true;
                    }
                    else
                    {
                        Console.WriteLine("В кассе не билетов.");
                    }
                }
                else
                {
                    Console.WriteLine("Билеты уже проданны.");
                }
            }
            else
            {
                Console.WriteLine("Сначало необходимо сформировать кассу.");
            }
        }

        private void FormTicketOffice()
        {
            if (_train != null)
            {
                if (_ticketOffice == null)
                {
                    _ticketOffice = new TicketOffice();

                    foreach (Van van in _train.GetCopyListVans())
                    {
                        _ticketOffice.Fill(van, _direction.Coast);
                    }
                }
                else
                {
                    Console.WriteLine("Касса уже сформированна.");
                }
            }
            else
            {
                Console.WriteLine("Сначало необходимо сформировать поезд.");
            }
        }

        private void FillPeople()
        {
            if (_direction != null)
            {
                if (_people == null)
                {
                    _people = new List<Person>();

                    Random random = new Random();

                    int numberPeople = random.Next(100, 500);

                    for (int i = 0; i < numberPeople; i++)
                    {
                        _people.Add(new Person(random.Next(3000, 5000)));
                    }
                }
                else
                {
                    Console.WriteLine("Список пассажиров уже сформирован.");
                }
            }
            else
            {
                Console.WriteLine("Сначала необходимо сформировать направление.");
            }
        }
    }

    class Depot
    {
        private List<Van> _vans;

        public Depot(int valueVans)
        {
            _vans = new List<Van>();
            Fill(valueVans);
        }

        public Van GetVanSets(int sets)
        {
            foreach (Van van in _vans)
            {
                if (van.NumberSets == sets)
                {
                    _vans.Remove(van);
                    return van;
                }
            }

            Console.WriteLine($"В депо нет вагонов с {sets} посадочными местами.");

            return null;
        }

        public int MaxSets()
        {
            int maxValue = 0;

            foreach (Van van in _vans)
            {
                if (van.NumberSets > maxValue)
                    maxValue = van.NumberSets;
            }

            return maxValue;
        }

        private void Fill(int value)
        {
            for (int i = 0; i < value; i++)
            {
                AddVan(new BigVan());
                AddVan(new MidleVan());
                AddVan(new SmallVan());
            }

            _vans.Sort(new TypeVanComparer());
        }

        private void AddVan(Van van)
        {
            _vans.Add(van);
        }
    }

    class Direction
    {
        public Direction(string firstCity, string secondCity, float coast)
        {
            FirstCity = firstCity;
            SecondCity = secondCity;
            Coast = coast;
        }

        public float Coast { get; private set; }
        public string FirstCity { get; private set; }
        public string SecondCity { get; private set; }

        public string Get()
        {
            return $"{FirstCity} -> {SecondCity}";
        }
    }

    class Van
    {
        public Van(int numberSets, char type, float coastSeat)
        {
            NumberSets = numberSets;
            Type = type;
            CoastSeat = coastSeat;
        }

        public int NumberSets { get; private set; }
        public char Type { get; private set; }
        public float CoastSeat { get; private set; }
    }

    class SmallVan : Van
    {
        private static int _numberSets = 30;
        private static char _type = 'A';
        private static float _coastSeat = 500;

        public SmallVan() : base(_numberSets, _type, _coastSeat) { }
    }

    class MidleVan : Van
    {
        private static int _numberSets = 40;
        private static char _type = 'B';
        private static float _coastSeat = 400;

        public MidleVan() : base(_numberSets, _type, _coastSeat) { }
    }

    class BigVan : Van
    {
        private static int _numberSets = 50;
        private static char _type = 'C';
        private static float _coastSeat = 300;

        public BigVan() : base(_numberSets, _type, _coastSeat) { }
    }

    class Train
    {
        private List<Van> _vans;

        public Train()
        {
            _vans = new List<Van>();
        }

        public float GetAverageCoatSetsTrain()
        {
            float allCoastSetsTrain = 0;

            foreach (Van van in _vans)
            {
                allCoastSetsTrain += van.CoastSeat;
            }

            return allCoastSetsTrain / _vans.Count;
        }

        public List<Van> GetCopyListVans()
        {
            return new List<Van>(_vans);
        }

        public int GetValueAllSets()
        {
            int sets = 0;

            foreach (Van van in _vans)
            {
                sets += van.NumberSets;
            }

            return sets;
        }

        public void Fill(Depot depot, int people)
        {
            int numberSets = 0;

            int setsVan;

            do
            {
                setsVan = depot.MaxSets();
                numberSets += setsVan;
                _vans.Add(depot.GetVanSets(setsVan));
            } while (numberSets < people);
        }
    }

    class Ticket
    {
        private float procentCoast = 1.1f;

        public Ticket(Van van, float directionCoast)
        {
            Coast = (directionCoast + van.CoastSeat) * procentCoast;
            Type = van.Type;
        }

        public float Coast { get; private set; }
        public char Type { get; private set; }
    }

    class TicketOffice
    {
        private List<Ticket> _tickets;

        public TicketOffice()
        {
            _tickets = new List<Ticket>();
        }

        public float Money { get; private set; }
        public int ValueAllTickets
        {
            get { return _tickets.Count; }
        }

        public float TryGetAvergeCoastTicket()
        {
            if (_tickets.Count != 0)
            {
                float allCoastTickets = 0;

                foreach (Ticket ticket in _tickets)
                {
                    allCoastTickets += ticket.Coast;
                }

                return allCoastTickets / _tickets.Count;
            }
            else
            {
                return 0;
            }
        }

        public void Clear()
        {
            _tickets.Clear();
        }

        public void Fill(Van van, float directionCoast)
        {
            for (int i = 0; i < van.NumberSets; i++)
            {
                _tickets.Add(new Ticket(van, directionCoast));
            }
        }

        public void TrySellTicket(Person person)
        {
            float money = person.Money;

            Ticket ticket = SearchSuitableTicket(money);

            if (ticket != null)
            {
                SellTicket(money, ticket);
                person.BuyTicket(ticket);
            }
        }

        private Ticket SearchSuitableTicket(float money)
        {
            _tickets.Sort(new TypeComparer());

            foreach (Ticket ticket in _tickets)
            {
                if (money >= ticket.Coast)
                {
                    return ticket;
                }
            }

            if (_tickets.Count == 0)
            {
                Console.WriteLine("Билетов на поезд не осталось.");
            }
            else
            {
                Console.WriteLine("Недостаточно средств.");
            }

            return null;
        }

        private void SellTicket(float money, Ticket ticket)
        {
            Money += money;
            _tickets.Remove(ticket);
        }
    }

    class Person
    {
        private Ticket _ticket;

        public Person(float money)
        {
            Money = money;
            HaveTicket = false;
        }

        public float Money { get; private set; }
        public bool HaveTicket { get; private set; }

        public void BuyTicket(Ticket ticket)
        {
            Console.WriteLine($"Куплен: билет тапа {ticket.Type}.");
            Money -= ticket.Coast;
            _ticket = ticket;
            HaveTicket = true;
        }
    }

    class TypeComparer : Comparer<Ticket>
    {
        public override int Compare(Ticket first, Ticket second)
        {
            return first.Type.CompareTo(second.Type);
        }
    }

    class TypeVanComparer : Comparer<Van>
    {
        public override int Compare(Van first, Van second)
        {
            return first.Type.CompareTo(second.Type);
        }
    }
}