//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace War
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;
//    using System.Threading.Tasks;

//    namespace Homework
//    {
//        class Program
//        {
//            static void Main(string[] args)
//            {
//                World world = new World();

//                world.CreateCountry("Один");
//                world.CreateCountry("Два");

//                foreach (var country in world.GetCountries())
//                {
//                    int number = World.Rand.Next(101);
//                    country.CreatePlatoon(number, 20);
//                    foreach (var platoon in country.GetPlatoons())
//                    {
//                        platoon.CreateWarriors(number, country.Name);
//                        platoon.ShowWarriors();
//                    }
//                }
//                War war = new War(world.GetCountries());
//                war.Start();
//                Console.ReadLine();
//            }
//        }

//        class World
//        {
//            public static Random Rand = new Random();
//            private List<Country> _countries = new List<Country>();

//            public void CreateCountry(string name)
//            {
//                _countries.Add(new Country(name));
//            }
//            public List<Country> GetCountries()
//            {
//                return _countries.ToList<Country>();
//            }
//        }

//        class War
//        {
//            private List<Country> _countries = new List<Country>();
//            private List<Battle> _battles = new List<Battle>();

//            public War(List<Country> countries)
//            {
//                _countries = countries;
//            }

//            public void Start()
//            {
//                for (int i = 1; GetLifeCountries().Count > 1; i++)
//                {
//                    Console.WriteLine("Бой " + i);
//                    ExecuteBattle();
//                }
//            }
//            private void ExecuteBattle()
//            {
//                var battle = new Battle(_countries);
//                _battles.Add(battle);
//                battle.ExecuteThis();
//            }
//            private List<Country> GetLifeCountries()
//            {
//                List<Country> lifeCountries = new List<Country>();
//                foreach (var country in _countries)
//                {
//                    foreach (var platoon in country.GetPlatoons())
//                    {
//                        if (platoon.CountWarriors > 0)
//                        {
//                            lifeCountries.Add(country);
//                        }
//                    }
//                }

//                return lifeCountries.ToList<Country>();
//            }
//        }

//        class Battle
//        {
//            private List<Country> _countries = new List<Country>();

//            public Battle(List<Country> countries)
//            {
//                _countries = countries;
//            }

//            private List<Warrior> GetAllWarriors()
//            {
//                List<Warrior> allWarrior = new List<Warrior>();
//                foreach (var country in _countries)
//                {
//                    foreach (var platoon in country.GetPlatoons())
//                    {
//                        foreach (var warrior in platoon.GetWarriors())
//                        {
//                            allWarrior.Add(warrior);
//                        }
//                    }
//                }
//                return allWarrior.ToList<Warrior>();
//            }
//            public void ExecuteThis()
//            {
//                var allwarriors = GetAllWarriors();
//                foreach (var warrior in GetAllWarriors())
//                {
//                    warrior.Attack(allwarriors);
//                }

//                foreach (var country in _countries)
//                {
//                    foreach (var platoon in country.GetPlatoons())
//                    {
//                        platoon.BuryItWarriors();
//                        Console.WriteLine($"{country.Name} - Потери: {platoon.MaxCountWarriors - platoon.CountWarriors} Солдат");
//                        platoon.ShowWarriors();
//                    }
//                }
//            }
//        }

//        class Country
//        {
//            private List<Platoon> _platoons = new List<Platoon>();

//            public string Name { get; }

//            public Country(string name)
//            {
//                Name = name;
//            }

//            public void CreatePlatoon(int number, int maxCount)
//            {
//                _platoons.Add(new Platoon(number, maxCount));
//            }
//            public List<Platoon> GetPlatoons()
//            {
//                return _platoons.ToList<Platoon>();
//            }
//        }

//        class Platoon
//        {
//            private List<Warrior> _warriors = new List<Warrior>();
//            private List<IWeapon> _weapons = new List<IWeapon>() { new Rifle(50), new MachineGun(20) };

//            public int Number { get; }
//            public int CountWarriors { get { return _warriors.Count; } }
//            public int MaxCountWarriors { get; }

//            public Platoon(int number, int maxCount)
//            {
//                Number = number;
//                MaxCountWarriors = maxCount;
//            }
//            public List<Warrior> GetWarriors()
//            {
//                return _warriors.ToList<Warrior>();
//            }
//            public void CreateWarriors(int numberPlatoon, string nationality)
//            {
//                for (int i = 1; i <= MaxCountWarriors; i++)
//                {
//                    _warriors.Add(new Warrior(i, numberPlatoon, nationality, GiveWeapon()));
//                }
//            }
//            public void ShowWarriors()
//            {
//                foreach (var warrior in _warriors)
//                {
//                    Console.WriteLine(warrior.ShowInfo());
//                }
//            }
//            public void BuryItWarriors()
//            {
//                _warriors.RemoveAll(warrior => warrior.Health <= 0);
//            }
//            private IWeapon GiveWeapon()
//            {
//                int numberWeapon = World.Rand.Next(_weapons.Count);
//                IWeapon weapon = _weapons[numberWeapon];
//                return weapon;
//            }
//        }

//        class Warrior
//        {
//            public int Health;

//            public int Number { get; private set; }
//            public int NumberPlatoon { get; private set; }
//            public string Nationality { get; private set; }
//            public IWeapon Weapon { get; private set; }

//            public Warrior(int number, int numberPlatoon, string nationality, IWeapon weapon, int health = 100)
//            {
//                Number = number;
//                NumberPlatoon = numberPlatoon;
//                Nationality = nationality;
//                Health = health;
//                Weapon = weapon;
//            }

//            public string ShowInfo()
//            {
//                return $"{Nationality}.{NumberPlatoon}.{Number}.{Weapon.Name}.{Health}";
//            }
//            public void Attack(List<Warrior> targets)
//            {
//                Weapon.Attack(this, targets);
//            }
//        }

//        interface IWeapon
//        {
//            string Name { get; }
//            void Attack(Warrior warrior, List<Warrior> targets);
//        }

//        class Rifle : IWeapon
//        {
//            string IWeapon.Name { get { return "Винтовка"; } }
//            public int Damage;

//            public Rifle(int damage)
//            {
//                Damage = damage;
//            }

//            public void Attack(Warrior warrior, List<Warrior> targets)
//            {
//                List<Warrior> enemies = new List<Warrior>();
//                foreach (var t in targets)
//                {
//                    if (warrior.Nationality != t.Nationality)
//                    {
//                        enemies.Add(t);
//                    }
//                }
//                var target = enemies[World.Rand.Next(enemies.Count)];
//                if (target != null)
//                {
//                    target.Health -= Damage;
//                    Console.WriteLine($"{warrior.ShowInfo()} -> -{Damage} -> {target.ShowInfo()}");
//                }

//            }
//        }

//        class MachineGun : IWeapon
//        {
//            public int Damage;
//            string IWeapon.Name { get { return "Пулемёт"; } }

//            public MachineGun(int damage)
//            {
//                Damage = damage;
//            }

//            public void Attack(Warrior warrior, List<Warrior> targets)
//            {
//                var rifle = new Rifle(Damage);
//                for (var i = 0; i < 3; i++)
//                {
//                    rifle.Attack(warrior, targets);
//                }
//            }
//        }
//    }
//}
