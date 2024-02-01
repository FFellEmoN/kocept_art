using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddCarQueueCommand = "1";
            const string ServiceСarCommand = "2";
            const string ExitCommand = "3";

            List<Detail> detailsPrefabs = new List<Detail>
            {
                new Detail("Колесо", 60),
                new Detail("Стекло", 100),
                new Detail("Фары", 50),
                new Detail("Бампер", 120),
                new Detail("Замок", 30)
            };

            FabricDetails fabricDetails = new FabricDetails(new List<Detail>(detailsPrefabs));

            Warehouse warehouse = new Warehouse(fabricDetails);

            CarService carService = new CarService(warehouse);

            FabricCar fabricCar = new FabricCar(new List<Detail>(detailsPrefabs));

            bool isWork = true;

            do
            {
                warehouse.ShowDetails();
                Console.WriteLine($"\nБаланс автомастерской - {carService.Money} монет.");
                Console.WriteLine($"Авто на обслуживании в очереди: {carService.CarsCount}");
                Console.WriteLine($"\n{AddCarQueueCommand} - запустить авто для обслуживания.");
                Console.WriteLine($"{ServiceСarCommand} - обслужить автомобиль.");
                Console.WriteLine($"{ExitCommand} - завершить работу.");

                Console.Write("\nВведите желаемое действие: ");
                string diceredAction = Console.ReadLine();

                switch (diceredAction)
                {
                    case AddCarQueueCommand:
                        carService.Enqueue(fabricCar.CreateCar());
                        break;

                    case ServiceСarCommand:
                        carService.Serve();
                        break;

                    case ExitCommand:
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
    }

    class FabricCar
    {
        private List<Detail> s_detailsPrefabs;

        public FabricCar(List<Detail> deliverySetCar)
        {
            s_detailsPrefabs = deliverySetCar;
        }

        public Car CreateCar()
        {

            List<Detail> detailsForCar = new List<Detail>();

            for (int i = 0; i < s_detailsPrefabs.Count; i++)
            {
                detailsForCar.Add(new Detail(s_detailsPrefabs[i].Name, s_detailsPrefabs[i].Cost));
            }

            return new Car(detailsForCar);
        }
    }

    class CarService
    {
        private Queue<Car> _cars;
        private Warehouse _warehouse;
        private int _capacity;
        private int _penalty = 500;

        public CarService(Warehouse warehouse)
        {
            Money = 2000;
            CoefficientWork = 10;
            _capacity = 3;
            _cars = new Queue<Car>();
            _warehouse = warehouse;
        }

        public int CoefficientWork { get; }
        public int Money { get; private set; }
        public int CarsCount => _cars.Count;

        public void Enqueue(Car car)
        {
            if (_capacity == CarsCount)
            {
                Console.WriteLine("Автосервис заполнен.");

                return;
            }

            Console.WriteLine("Авто успешно поставленно в автосервис.");
            _cars.Enqueue(car);
        }

        public void Serve()
        {
            if (_cars.Count == 0)
            {
                Console.WriteLine("В автосервисе нет машин.");

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();

                return;
            }

            if (Money <= _penalty && Money <= _warehouse.GetMaxCostWork(CoefficientWork))
            {
                Console.WriteLine("К сожилению у вас недостаточно денег для выплоты штрафа в случаи ошибки.");
                Console.WriteLine("Закрывайтесь!");

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();

                return;
            }

            Console.Clear();

            Car firstCarQueue = _cars.Dequeue();

            _warehouse.ShowDetails();
            Console.WriteLine();

            if (firstCarQueue.HasBreakdown() == false)
            {
                Console.WriteLine("Автомобиль полностью исправен и не нуждается в починки.");

                return;
            }

            if (_warehouse.IsContains(firstCarQueue.BreakdownDetail))
            {
                _warehouse.CalculatePrice(firstCarQueue.BreakdownDetail, CoefficientWork);
                ShowBrakdown(firstCarQueue.BreakdownDetail);
                TryRepair(firstCarQueue);
            }
            else
            {
                Console.WriteLine($"К сожилению у нас нет на складе подходящей детали: {firstCarQueue.BreakdownDetail.Name} для вас.");

                DenyService();
            }
        }

        private void ShowBrakdown(Detail detail)
        {
            Console.WriteLine($"У авто сломано - {detail.Name}. ");
            Console.WriteLine($"\nЦена за работу будет - {_warehouse.RepairPrice} монет.");
        }

        private void TryRepair(Car car)
        {
            if (_warehouse.TryFindDetail(car.BreakdownDetail, out Detail detail))
            {
                car.ReplacePart(detail);

                if (car.HasBreakdown())
                {
                    Console.WriteLine("Вы не поченили авто. У него есть поломка.");

                    return;
                }

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
            Console.WriteLine($"Вы отказали клиенту. С вас шраф - {_penalty} монет.");

            Money -= _penalty;
        }
    }

    class Car
    {
        private List<Detail> _details;

        public Car(List<Detail> detailsPrefabs)
        {
            _details = detailsPrefabs;
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
                    BreakdownDetail = null;

                    break;
                }
            }
        }

        public bool HasBreakdown()
        {
            bool hasBreakdown = false;

            foreach (Detail detail in _details)
            {
                if (detail.IsBroken)
                {
                    hasBreakdown = true;

                    return hasBreakdown;
                }
            }

            return hasBreakdown;
        }

        private void СreateBreakdown()
        {
            int indexDetail = RandomUtility.Get(0, _details.Count);

            BreakdownDetail = _details[indexDetail];

            BreakdownDetail.Break();
        }
    }

    class FabricDetails
    {
        private List<Detail> s_detailsPrefabs;

        public FabricDetails(List<Detail> deliverySetCar)
        {
            s_detailsPrefabs = deliverySetCar;
        }

        public Detail GetDetail()
        {
            int indexDetail = RandomUtility.Get(0, s_detailsPrefabs.Count);

            return new Detail(s_detailsPrefabs[indexDetail].Name, s_detailsPrefabs[indexDetail].Cost);
        }
    }

    class Warehouse
    {
        private List<Detail> _details = new List<Detail>();

        public Warehouse(FabricDetails fabricDetails)
        {
            Fill(fabricDetails);
        }

        public int RepairPrice { get; private set; }

        public int GetMaxCostWork(int coefficientWork)
        {
            int maxCost = 0;

            foreach (Detail detail in _details)
            {
                if (maxCost < detail.Cost)
                {
                    maxCost = detail.Cost;
                }
            }

            return maxCost * coefficientWork;
        }

        public bool IsContains(Detail carDetail)
        {
            foreach (Detail detail in _details)
            {
                if (carDetail.Name == detail.Name)
                {
                    //CalculatePrice(detail, coefficientWork);

                    return true;
                }
            }

            return false;
        }

        public bool TryFindDetail(Detail breakdownDetail, out Detail detail)
        {
            bool IsRunning = false;

            do
            {
                Console.Write("\nВведите номер детали со склада: ");

                if (int.TryParse(Console.ReadLine(), out int numberDetail) == false)
                {
                    Console.WriteLine("Ошибка! Вы ввели не коректные данные.");

                    IsRunning = true;
                }
                else if (numberDetail > 0 && numberDetail <= _details.Count)
                {
                    if (breakdownDetail.Name == _details[numberDetail - 1].Name)
                    {
                        int indexDetail = numberDetail - 1;

                        Detail detailStorage = _details[indexDetail];

                        detail = detailStorage;
                        _details.Remove(detailStorage);

                        return true;
                    }
                    else
                    {
                        detail = null;

                        return false;
                    }
                }
            } while (IsRunning);

            detail = null;

            return false;
        }

        public void ShowDetails()
        {
            Console.WriteLine("На складе есть такие детали: ");

            for (int i = 0; i < _details.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Название - {_details[i].Name}. Стоимость - {_details[i].Cost}");
            }
        }

        public void CalculatePrice(Detail carDetail, int coefficientWork)
        {
            foreach (Detail detail in _details)
            {
                if (carDetail.Name == detail.Name)
                {
                    RepairPrice = detail.Cost * coefficientWork;

                    return;
                }
            }
        }

        public void Fill(FabricDetails fabricDetail)
        {
            int amountDetails = 10;

            for (int i = 0; i < amountDetails; i++)
            {
                _details.Add(fabricDetail.GetDetail());
            }
        }
    }

    class Detail
    {
        public Detail(string name, int cost)
        {
            Name = name;
            Cost = cost;
            IsBroken = false;
        }

        public Detail(string name)
        {
            Name = name;
            Cost = 50;
            IsBroken = false;
        }

        public string Name { get; }
        public int Cost { get; private set; }
        public bool IsBroken { get; private set; }

        public void Break()
        {
            IsBroken = true;
        }
    }

    class RandomUtility
    {
        private static Random s_random = new Random();

        public static int Get(int min, int max)
        {
            return s_random.Next(min, max);
        }
    }
}