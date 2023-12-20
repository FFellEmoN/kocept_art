using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

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

    struct Position
    {
        public Position(int left, int top)
        {
            Left = left;
            Top = top;
        }

        public int Left { get; private set; }
        public int Top { get; private set; }
    }

    class RailwayStation
    {
        private Depot _depot;
        private TicketOffice _ticketOffice;
        private Train _train;
        private Direction _direction;
        private List<Person> _people;
        private List<string> _cities;
        private int _valueVansType = 6;
        private bool _didSellTickets = false;

        public RailwayStation()
        {
            _depot = new Depot(_valueVansType);
            _cities = new List<string>();
            _ticketOffice = new TicketOffice();
            _cities.Add("Москва");
            _cities.Add("Санкт-Петербург");
            _cities.Add("Тверь");
        }

        public void Work()
        {
            const string CreateDirectionMenu = "1";
            const string CreatePeopleListMenu = "2";
            const string FormTrainMenu = "3";
            const string FillTicketOfficeMenu = "4";
            const string OpenTicketSaleMenu = "5";
            const string SentTrainMenu = "6";
            const string ResetAllSeting = "7";
            const string ExitMenu = "8";

            List<String> lines = new List<String>();

            string diciredAction;

            bool isRunning = true;
            int dehaultValueLeft = 0;
            int dehaultValueTop = 0;
            int positionTitleLeft = 15;
            int nextLine = 1;
            int stepRight = 30;
            int windowWidth = 150;
            int windowHeight = 40;
            int secondParagraph = 5;

            Position start = new Position(dehaultValueLeft, dehaultValueTop);
            Position title = new Position(positionTitleLeft, start.Top);
            Position direction = new Position(start.Left, title.Top + nextLine);
            Position people = new Position(direction.Left + stepRight, direction.Top);
            Position train = new Position(people.Left + stepRight, direction.Top);
            Position ticketOffice = new Position(direction.Left, direction.Top + secondParagraph);

            Console.WindowHeight = windowHeight;
            Console.WindowWidth = windowWidth;

            do
            {
                ShowAllInformation(ref lines, title, direction, people, train, ticketOffice, start);

                Console.WriteLine($"{CreateDirectionMenu}) - сформировать направление.");
                Console.WriteLine($"{CreatePeopleListMenu}) - сформировать список пассажиров.");
                Console.WriteLine($"{FormTrainMenu}) - сформировать поезд.");
                Console.WriteLine($"{FillTicketOfficeMenu}) - заполнить кассу продажи билетов.");
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

                    case FillTicketOfficeMenu:
                        FillTicketOffice();
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

        private void ShowAllInformation(ref List<String> lines, Position title, Position direction, Position people, Position train, Position ticketOffice, Position start)
        {
            int secondParagraph = 5;
            int thirdParagraph = 10;

            if (_direction != null)
            {
                lines.Add("Подробная информация о маршруте");

                ShowDirectonInformation(title.Left, title.Top, ref lines);

                lines.Add("Направление:");
                lines.Add(_direction.Get());
                lines.Add($"Затраты: {_direction.Coast}");

                ShowDirectonInformation(direction.Left, direction.Top, ref lines);
            }

            if (_people != null)
            {
                lines.Add("Пассажиры:");
                lines.Add($"Количество: {_people.Count}");
                lines.Add($"Количество без билетов: {GetPeopleWithoutTicket()}");

                ShowDirectonInformation(people.Left, people.Top, ref lines);
            }

            if (_train != null)
            {
                lines.Add("Поезд:");
                lines.Add($"Общее число посадочных мест: {_train.GetValueAllSets()}");
                lines.Add($"Средняя затраты на посадочное место: {_train.GetAverageCoatSetsTrain()}");
                ShowDirectonInformation(train.Left, train.Top, ref lines);
            }

            if (_ticketOffice != null)
            {
                lines.Add("Касса:");
                lines.Add($"Количество билетов: {_ticketOffice.ValueAllTickets}");
                lines.Add($"Средняя цена на билет: {_ticketOffice.TryGetAvergeCoastTicket()}");
                lines.Add($"Денег в кассе: {_ticketOffice.Money}");

                ShowDirectonInformation(ticketOffice.Left, ticketOffice.Top, ref lines);
            }

            if (_direction != null)
            {
                Console.SetCursorPosition(direction.Left, direction.Top + secondParagraph);
            }

            if (_ticketOffice != null)
            {
                Console.SetCursorPosition(direction.Left, direction.Top + thirdParagraph);
            }

            if (_direction == null && _ticketOffice == null)
            {
                Console.SetCursorPosition(start.Left, start.Top);
            }
        }

        private void ShowDirectonInformation(int positionLeft, int positionTop, ref List<String> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Console.SetCursorPosition(positionLeft, positionTop + i);

                Console.WriteLine(lines[i]);
            }

            lines = new List<String>();
        }

        private string ChooseCity(int sequenceNumber)
        {
            Console.Write($"\nВыбирите {sequenceNumber} город: ");
            string numberCity = Console.ReadLine();

            if (int.TryParse(numberCity, out int index) && index > 0 && index <= _cities.Count)
            {
                Console.WriteLine(_cities[index - 1]);
                return _cities[index - 1];
            }
            else
            {
                Console.WriteLine("Вы ввели не число или города под таким номером нет.");
                return null;
            }
        }

        private void ShowAllCity()
        {
            for (int i = 0; i < _cities.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_cities[i]}");
            }
        }

        private int GetPeopleWithoutTicket()
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
            _didSellTickets = false;
            _ticketOffice = new TicketOffice();
            _depot = new Depot(_valueVansType);

            Console.WriteLine("Все настройки маршрута сброшенны до начальных.");
        }

        private void SentTrain()
        {
            if (_didSellTickets)
            {
                PutPassengersTrain();

                Console.WriteLine($"Поезд отправлен в путь по маршруту {_direction.Get()}");

                _direction = null;
                _train = null;
                _people = null;
                _ticketOffice.Clear();
                _didSellTickets = false;

                Console.WriteLine("Формируйте новое отправление.");
            }
            else
            {
                Console.WriteLine("Необходимо посадить всех пассажиров.");
            }
        }

        private void PutPassengersTrain()
        {
            foreach (Person person in _people)
            {
                if (person.HaveTicket == true)
                {
                    _train.PutPerson(person);
                }
                else
                {
                    Console.WriteLine("У пассажира нет билета.");
                }
            }

            if (_people.Count == _train.GetCountListPeople())
            {
                _people.Clear();

                Console.WriteLine("Все пассажиры на поезде!");
            }
            else
            {
                Console.WriteLine("Не все сели на поезд, у кого нет билета.");
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

                    if (_train.GetValueAllSets() == 0)
                    {
                        _train = null;

                        Console.WriteLine("Поезд не сформирован.");
                    }
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
                ShowAllCity();

                firstCity = ChooseCity(sequenceNumber);

                if (firstCity != null)
                {
                    sequenceNumber++;
                    secondCity = ChooseCity(sequenceNumber);
                    Console.WriteLine();
                }

                if (firstCity != null && secondCity != null && firstCity != secondCity)
                {
                    Console.WriteLine($"Введите растояние от {firstCity} -> {secondCity}");

                    value = Console.ReadLine();

                    if (int.TryParse(value, out kilometer) && kilometer > 0)
                    {
                        coast = kilometer * coastOneKilometer;
                        _direction = new Direction(firstCity, secondCity, coast);
                    }
                    else
                    {
                        Console.WriteLine("Растояние между городами должно быть больше 0");
                        Console.WriteLine("Вы ввели не число.");
                        Console.WriteLine("Попробуйте сформировать направление заново.");
                    }
                }
                else
                {
                    Console.WriteLine("Нельзя выбрать 1 и 2 город одинаковыми.");
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
                if (_didSellTickets == false)
                {
                    if (_ticketOffice.ValueAllTickets != 0)
                    {
                        foreach (Person person in _people)
                        {
                            _ticketOffice.TrySellTicket(person);
                        }

                        _didSellTickets = true;
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

        private void FillTicketOffice()
        {
            if (_train != null)
            {
                if (_ticketOffice.IsEmpty)
                {
                    foreach (Van van in _train.GetCopyListVans())
                    {
                        _ticketOffice.Fill(van, _direction.Coast);
                    }

                    Console.WriteLine("Касса заполненна.");
                }
                else
                {
                    Console.WriteLine("Касса уже заполненна.");
                }
            }
            else
            {
                Console.WriteLine("Сначало необходимо сформировать поезд.");
            }
        }

        private void FillPeople()
        {
            int minNumberPeople = 100;
            int maxNumberPeople = 500;
            int minValueMoneyPerson = 3000;
            int maxValueMoneyPerson = 5000;

            if (_direction != null)
            {
                if (_people == null)
                {
                    _people = new List<Person>();

                    Random random = new Random();

                    int numberPeople = random.Next(minNumberPeople, maxNumberPeople);

                    for (int i = 0; i < numberPeople; i++)
                    {
                        _people.Add(new Person(random.Next(minValueMoneyPerson, maxValueMoneyPerson)));
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

        public int GetMaxSets()
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
        private List<Person> _people;

        public Train()
        {
            _vans = new List<Van>();
            _people = new List<Person>();
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
                setsVan = depot.GetMaxSets();
                numberSets += setsVan;
                _vans.Add(depot.GetVanSets(setsVan));
            } while (numberSets < people && setsVan != 0);

            if (setsVan == 0)
            {
                _vans.Clear();

                Console.WriteLine("К сожалению не получилось заполнить полностью поезд для всех пассажиров.");
                Console.WriteLine("Больше нельзя отправить поезд до возврата поездов в депо.");
            }
        }

        public void PutPerson(Person person)
        {
            _people.Add(person);
        }

        public int GetCountListPeople()
        {
            return _people.Count;
        }
    }

    class Ticket
    {
        private float _procentCoast = 1.1f;

        public Ticket(Van van, float directionCoast)
        {
            Coast = (directionCoast + van.CoastSeat) * _procentCoast;
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
            IsEmpty = true;
        }

        public float Money { get; private set; }
        public int ValueAllTickets
        {
            get { return _tickets.Count; }
        }
        public bool IsEmpty { get; private set; }

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
            IsEmpty = true;
        }

        public void Fill(Van van, float directionCoast)
        {
            for (int i = 0; i < van.NumberSets; i++)
            {
                _tickets.Add(new Ticket(van, directionCoast));
            }

            IsEmpty = false;
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
            else
            {
                IsEmpty = true;
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

        public Ticket GiveTicket()
        {
            Ticket ticket = _ticket;
            _ticket = null;
            return ticket;
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