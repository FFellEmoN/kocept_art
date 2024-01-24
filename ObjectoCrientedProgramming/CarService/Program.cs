﻿using System;
using System.Collections.Generic;

namespace CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManagerCarService managerCarService = new ManagerCarService();
            managerCarService.Work();
        }
    }

    class ManagerCarService
    {
        private CarService _carService;
        private Warehouse _warehouse;
        private List<string> _deliverySetCar;

        public ManagerCarService()
        {
            _deliverySetCar = new List<string>
            {
                "Колесо",
                "Стекло",
                "Фары",
                "Бампер",
                "Замок"
            };
            new FabricRandomDetails(new List<string>(_deliverySetCar));
            _warehouse = new Warehouse();
            _carService = new CarService(_warehouse);
        }

        public void Work()
        {
            const string AddCarQueueCommand = "1";
            const string ServiceСarCommand = "2";
            const string ExitMenu = "3";

            bool isWork = true;

            do
            {
                _warehouse.ShowStorage();
                Console.WriteLine($"\nБаланс автомастерской - {_carService.Money} монет.");
                Console.WriteLine($"Авто на обслуживании в очереди: {_carService.CountCars}");
                Console.WriteLine($"\n{AddCarQueueCommand} - запустить авто для обслуживания.");
                Console.WriteLine($"{ServiceСarCommand} - обслужить автомобиль.");
                Console.WriteLine($"{ExitMenu} - завершить работу.");

                Console.Write("\nВведите желаемое действие: ");
                string diceredAction = Console.ReadLine();

                switch (diceredAction)
                {
                    case AddCarQueueCommand:
                        _carService.AddCar(CreateCar());
                        break;

                    case ServiceСarCommand:
                        _carService.TryServe();
                        break;

                    case ExitMenu:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Хм.. Такой команды нету.");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();

                Console.Clear();
            } while (isWork);
        }

        private Car CreateCar()
        {
            return new Car(_deliverySetCar);
        }
    }

    class CarService
    {
        private Queue<Car> _cars;
        private Warehouse _warehouse;
        private int _carServiceCapacity;
        private int _penaltyError = 500;

        public CarService(Warehouse warehouse)
        {
            Money = 2000;
            _carServiceCapacity = 3;
            _cars = new Queue<Car>();
            _warehouse = warehouse;
        }

        public int Money { get; private set; }
        public int CountCars => _cars.Count;

        public void AddCar(Car car)
        {
            if (CountCars < _carServiceCapacity)
            {
                _cars.Enqueue(car);

                Console.WriteLine("Авто успешно поставленно в автосервис.");
            }
            else
            {
                Console.WriteLine("Автосервис заполнен.");
            }
        }

        public void TryServe()
        {
            if (_cars.Count != 0)
            {
                if (Money >= _penaltyError && Money >= _warehouse.GetMaxCostWork())
                {
                    Console.Clear();

                    Car firstCarQueue = _cars.Peek();

                    _warehouse.ShowStorage();
                    Console.WriteLine();

                    if (_warehouse.IsHaveDetailStorage(firstCarQueue.BreakdownDetail))
                    {
                        ShowBrakdown(firstCarQueue.BreakdownDetail);
                        TryRepair();
                    }
                    else
                    {
                        Console.WriteLine($"К сожилению у нас нет на складе подходящей детали: {firstCarQueue.BreakdownDetail.Name} для вас.");

                        DenyService();
                        _cars.Dequeue();
                    }
                }
                else
                {
                    Console.WriteLine("К сожилению у вас недостаточно денег для выплоты штрафа в случаи ошибки.");
                    Console.WriteLine("Закрывайтесь!");
                }
            }
            else
            {
                Console.WriteLine("В автосервисе нет машин.");
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");

                Console.ReadKey();
            }
        }

        private void ShowBrakdown(Detail detail)
        {
            Console.WriteLine($"У авто сломано - {detail.Name}. ");
            Console.WriteLine($"\nЦена за работу будет - {_warehouse.RepairPrice} монет.");
        }

        private void TryRepair()
        {
            Car car = _cars.Dequeue();

            if (_warehouse.TryGetDetail(car.BreakdownDetail, out Detail detail))
            {
                car.ReplacePart(detail);
                car.CheckAllServiceabilityDetails();

                Console.WriteLine($"Вы успешно починили автомобиль!" +
                    $"\nИ заработали {_warehouse.RepairPrice} монет.");

                Money += _warehouse.RepairPrice;
            }
            else
            {
                Console.WriteLine("Вы установили не ту деталь. Клиент не доволен вашей работой. " +
                     $"\n Вы возместитли ущерб клиенту в размере - {_warehouse.RepairPrice} монет.");
                Money -= _warehouse.RepairPrice;
            }
        }

        private void DenyService()
        {
            Console.WriteLine($"Вы отказали клиенту. С вас шраф - {_penaltyError} монет.");
            Money -= _penaltyError;
        }
    }

    class Car
    {
        private List<Detail> _details = new List<Detail>();
        private List<string> _deliverySet;

        public Car(List<string> deliverySet)
        {
            _deliverySet = deliverySet;

            InstallParts();
            СreateBreakdown();
        }

        public Detail BreakdownDetail { get; private set; }

        public void ReplacePart(Detail newDetail)
        {
            foreach (Detail detail in _details)
            {
                if (detail.Name == newDetail.Name)
                {
                    _details.Remove(detail);
                    _details.Add(newDetail);
                    break;
                }
            }
        }

        public void CheckAllServiceabilityDetails()
        {
            int valueServiceabilityDetails = 0;

            foreach (Detail detail in _details)
            {
                if (detail.IsServiceability)
                {
                    valueServiceabilityDetails++;
                }
            }

            if (valueServiceabilityDetails == _details.Count)
            {
                Console.WriteLine("У автомобиля все детали исправны.");
            }
        }

        private void СreateBreakdown()
        {
            int indexDetail = RandomValue.GetValue(0, _details.Count);

            BreakdownDetail = _details[indexDetail];

            BreakdownDetail.Break();
        }

        private void InstallParts()
        {
            foreach (string nameDetail in _deliverySet)
            {
                _details.Add(new Detail(nameDetail));
            }
        }
    }

    class FabricRandomDetails
    {
        private static List<string> s_deliverySetCar;

        public FabricRandomDetails(List<string> deliverySetCar)
        {
            s_deliverySetCar = deliverySetCar;
        }

        public static Detail GetDetail()
        {
            int indexDetail = RandomValue.GetValue(0, s_deliverySetCar.Count);

            switch (s_deliverySetCar[indexDetail])
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

    class Warehouse
    {
        private List<Detail> _storage = new List<Detail>();
        private int _costWork;

        public Warehouse()
        {
            _costWork = 10;

            Fill();
        }

        public int RepairPrice { get; private set; }

        public int GetMaxCostWork()
        {
            int maxCost = 0;

            foreach (Detail detail in _storage)
            {
                if (maxCost < detail.Cost)
                {
                    maxCost = detail.Cost;
                }
            }

            return maxCost * _costWork;
        }

        public bool IsHaveDetailStorage(Detail carDetail)
        {
            foreach (Detail detail in _storage)
            {
                if (carDetail.Name == detail.Name)
                {
                    Pricing(detail);

                    return true;
                }
            }

            return false;
        }

        public bool TryGetDetail(Detail breakdownDetail, out Detail detail)
        {
            bool isActionIncorrect = false;

            do
            {
                Console.Write("\nВведите номер детали со склада: ");

                if (int.TryParse(Console.ReadLine(), out int numberDetail) == false)
                {
                    Console.WriteLine("Ошибка! Вы ввели не коректные данные.");

                    isActionIncorrect = true;
                }
                else if (numberDetail > 0 &&
                    numberDetail <= _storage.Count)
                {
                    if (breakdownDetail.Name == _storage[numberDetail - 1].Name) {
                        int indexDetail = numberDetail - 1;

                        Detail detailStorage = _storage[indexDetail];

                        detail = detailStorage;
                        _storage.Remove(detailStorage);

                        return true;
                    }
                    else
                    {
                        detail = null;

                        return false;
                    }
                }
            } while (isActionIncorrect);

            detail = null;

            return false;
        }

        public void ShowStorage()
        {
            Console.WriteLine("На складе есть такие детали: ");

            for (int i = 0; i < _storage.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Название - {_storage[i].Name}. Стоимость - {_storage[i].Cost}");
            }
        }

        private void Pricing(Detail carDetail)
        {
            foreach (Detail detail in _storage)
            {
                if (carDetail.Name == detail.Name)
                {
                    RepairPrice = detail.Cost * _costWork;
                    break;
                }
            }
        }

        private void Fill()
        {
            int numberDetails = 10;

            for (int i = 0; i < numberDetails; i++)
            {
                _storage.Add(FabricRandomDetails.GetDetail());
            }
        }
    }

    class Detail
    {
        public Detail(string name, int cost)
        {
            Name = name;
            Cost = cost;
            IsServiceability = true;
        }

        public Detail(string name)
        {
            Name = name;
            Cost = 50;
            IsServiceability = true;
        }

        public string Name { get; private set; }
        public int Cost { get; private set; }
        public bool IsServiceability { get; private set; }

        public void Break()
        {
            IsServiceability = false;
        }
    }

    class RandomValue
    {
        private static Random s_random = new Random();

        public static int GetValue(int min, int max)
        {
            return s_random.Next(min, max);
        }
    }
}