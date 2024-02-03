using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AnarchyHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Hospital
    {
        private List<Patient> _patients;

        public Hospital()
        {
            _patients = new List<Patient>
            {
                new Patient("Иванов Иван Иванович", 72, "Инфаркт"),
                new Patient("Чистяков Иван Юрьевич", 25, "Переломы ребер"),
                new Patient("Ковалев Марк Елисеевич", 30, "Чахотка"),
                new Patient("Мельников Даниил Владиславович", 22, "Чахотка"),
                new Patient("Трофимов Сергей Иванович", 35, "Глухонемота"),
                new Patient("Быков Егор Захарович", 44, "Побои"),
                new Patient("Горбачев Егор Макарович", 21, "Синяки"),
                new Patient("Колесников Илья Иванович", 24, "Головная боль"),
                new Patient("Фокин Артур Андреевич", 27, "Головная боль"),
                new Patient("Антонов Али Григорьевич", 66, "Инсульт")
            };
        }

        public void Work()
        {
            const string SortPatientsByFullNameCommand = "1";
            const string SortPatientsByAgeCommand = "2";
            const string ShowPatientsByDiseaseCommand = "3";
            const string ExitMenu = "4";

            bool isWork = true;

            do
            {
                Console.WriteLine("Добро пожаловать в больницу.");

                Console.WriteLine($"{SortPatientsByFullNameCommand}) - отсортировать всех больных по ФИО.");
                Console.WriteLine($"{SortPatientsByAgeCommand}) - отсортировать всех больных по возрасту.");
                Console.WriteLine($"{ShowPatientsByDiseaseCommand}) - выписать больных с определенными заболеваниями.");
                Console.WriteLine($"{ExitMenu}) - выход.");

                Console.Write("Дейстиве: ");
                string diciredAction = Console.ReadLine();

                switch (diciredAction)
                {
                    case SortPatientsByFullNameCommand:
                        SortPatientsByFullName();
                        break;

                    case SortPatientsByAgeCommand:
                        SortPatientsByAge();
                        break;

                    case ShowPatientsByDiseaseCommand:
                        ShowPatientsCertainDisease();
                        break;

                    case ExitMenu:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Хм.. Такой команды нету.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
            } while (isWork);
        }

        private void SortPatientsByFullName()
        {
            _patients = _patients.OrderBy(patient => patient.FullName).ToList();
            ShowPatientsInfo(_patients);
        }

        private void SortPatientsByAge()
        {
            _patients = _patients.OrderBy(patient => patient.Age).ToList();
            ShowPatientsInfo(_patients);
        }

        private void ShowPatientsCertainDisease()
        {
            ShowAllDisease();

            Console.Write("Введите заболевание: ");
            string disease = Console.ReadLine();

            if (disease.Any(char.IsLetter))
            {
                var patientsCertainDisease = _patients.Where(patient => patient.Disease.ToLower() == disease.ToLower()).ToList();

                Console.WriteLine($"\nВсе пацинты с заболеванием {disease}");
                ShowPatientsInfo(patientsCertainDisease);
            }
            else
            {
                Console.WriteLine("Не верный ввод.");
            }
        }

        private void ShowPatientsInfo(List<Patient> patients)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                patients[i].ShowPatient();
            }
        }
        private void ShowAllDisease()
        {
            Console.WriteLine("\nПеречень всех заболеваний в больнице: ");

            foreach (Patient patient in _patients)
            {
                Console.WriteLine(patient.Disease);
            }

            Console.WriteLine();
        }
    }

    class Patient
    {
        public Patient(string fullName, int age, string disease)
        {
            FullName = fullName;
            Age = age;
            Disease = disease;
        }

        public string FullName { get; }
        public int Age { get; }
        public string Disease { get; }

        public void ShowPatient()
        {
            Console.WriteLine($"ФИО: {FullName}. Возраст: {Age}. Заболевание: {Disease}.");
        }
    }
}