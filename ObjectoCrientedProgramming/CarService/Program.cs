using System;
using System.Collections.Generic;

namespace CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService();
            carService.Work();
        }
    }

    class CarService
    {
        private Warehouse _details;
        private Queue<Car> _cars;
        private int _money;

        public CarService()
        {
            _money = 2000;
            _details = new Warehouse();
            _cars = new Queue<Car>();
            СreateCar(5);
        }

        public void Work()
        {
            bool isWork = true;

            while (isWork && 0 <= _cars.Count)
            {
                _details.ShowStorage();
                Console.WriteLine($"\nБаланс автомастерской - {_money} монет.");
                Console.Write($"В мастерской {_cars.Count} машин, стоят на ремонт. " +
                    $"\nДля их обслуживания введите \"1\". " +
                    $"\nДля завершения работы введите\"exit\"" +
                    $"\nДействие: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ServiceСar();
                        break;
                    case "exit":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Хм.. Такой команды нету.");
                        break;
                }
            }
        }

        private void СreateCar(int numberOfCar)
        {
            for (int i = 0; i < numberOfCar; i++)
            {
                _cars.Enqueue(new Car());
            }
        }

        private void ShowBrakdown(Car car)
        {
            Console.WriteLine($"У авто сломано - {car.BreakdownDetail}. ");
            Console.WriteLine($"\nЦена за работу будет - {_details.GetRepairPrice(car)} монет.");
        }

        private void ServiceСar()
        {
            Console.Clear();
            var car = _cars.Dequeue();
            ShowBrakdown(car);
            Console.Write("Что вы будете делать. " +
                "\n(1) Ремонтировать " +
                "\n(2) Отказать клиенту " +
                "\n Действие: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    RepairCar(car);
                    break;
                case "2":
                    DenyService();
                    break;
                default:
                    Console.WriteLine("Хм.. Такой команды нету.");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void RepairCar(Car car)
        {
            if (_details.TryRepairCar(car))
            {
                Console.WriteLine($"Вы успешно починили автомобиль!\n И заработали {_details.GetRepairPrice(car)} монет.");
                _money += _details.GetRepairPrice(car);
            }
            else
            {
                Console.WriteLine("Вы установили не ту деталь. Клиент не доволен вашей работой. " +
                     $"\n Вы возместитли ущерб клиенту в размере - {_details.GetRepairPrice(car)} монет.");
                _money -= _details.GetRepairPrice(car);
            }
        }

        private void DenyService()
        {
            int penalty = 500;
            Console.WriteLine($"Вы отказали клиенту. С вас шраф - {penalty} монет.");
            _money -= penalty;
        }
    }

    class Car
    {
        private string[] _numbersBreakdown = new string[] { "2", "3",
            "4", "5", "6" };
        private Random _random = new Random();

        public Car()
        {
            СreateBreakdown();
        }

        public string BreakdownDetail { get; private set; }

        private void СreateBreakdown()
        {
            int detailId = _random.Next(0, _numbersBreakdown.Length);
            BreakdownDetail = GetBreakdown(detailId);
        }

        private string GetBreakdown(int breakdownId)
        {
            switch (_numbersBreakdown[breakdownId])
            {
                case "2":
                    return "Колесо";
                case "3":
                    return "Стекло";
                case "4":
                    return "Фары";
                case "5":
                    return "Бампер";
                case "6":
                    return "Замок";
            }

            return null;
        }
    }

    class Warehouse
    {
        private List<Detail> _storage = new List<Detail>();
        private Random _random = new Random();
        private string[] _listDetail = new string[] { "Колесо", "Стекло", "Фары", "Бампер", "Замок" };

        public Warehouse()
        {
            СreateDetail(10);
        }

        public void ShowStorage()
        {
            Console.WriteLine("На складе есть такие детали: ");

            for (int i = 0; i < _storage.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Название - {_storage[i].Name}. Стоимость - {_storage[i].Cost}");
            }
        }

        public int GetRepairPrice(Car car)
        {
            int repairPrice = 0;
            int costWork = 10;

            foreach (var detail in _storage)
            {
                if (car.BreakdownDetail == detail.Name)
                {
                    repairPrice += detail.Cost * costWork;
                    break;
                }
            }

            return repairPrice;
        }

        public bool TryRepairCar(Car car)
        {
            ShowStorage();
            Console.Write("\nКакую деталь вы хотитель установить: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int inputNumberDetail);

            if (isNumber == false)
            {
                Console.WriteLine("Ошибка! Вы ввели не коректные данные.");
                return false;
            }
            else if (inputNumberDetail > 0 && inputNumberDetail - 1 < _storage.Count && car.BreakdownDetail == _storage[inputNumberDetail - 1].Name)
            {
                int indexDetail = inputNumberDetail - 1;
                _storage.RemoveAt(indexDetail);
                return true;
            }
            else
            {
                Console.WriteLine("Кажется это на та деталь.");
                return false;
            }
        }

        private void СreateDetail(int numberOfDetails)
        {
            for (int i = 0; i < numberOfDetails; i++)
            {
                _storage.Add(GetDetail());
            }
        }

        private Detail GetDetail()
        {
            int detailId = _random.Next(0, _listDetail.Length);

            switch (_listDetail[detailId])
            {
                case "Колесо":
                    return new Detail("Колесо", 60);
                case "Стекло":
                    return new Detail("Стекло", 80);
                case "Фары":
                    return new Detail("Фары", 40);
                case "Бампер":
                    return new Detail("Бампер", 30);
                case "Замок":
                    return new Detail("Замок", 50);
            }

            return null;
        }
    }

    class Detail
    {
        public Detail(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; private set; }
        public int Cost { get; private set; }
    }
}