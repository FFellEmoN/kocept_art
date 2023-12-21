using System;
using System.Collections.Generic;

namespace GladiatorArena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            arena.Work();
        }
    }

    class Arena
    {
        private List<Character> _characters;
        private Character _firstCharacter;
        private Character _secondCharacter;

        public Arena()
        {
            _characters = new List<Character>();
            _characters.Add(new Wizard());
            _characters.Add(new Vampire());
            _characters.Add(new Knight());
            _characters.Add(new Demon());
            _characters.Add(new Human());
        }

        public void Work()
        {
            const string ChooseCharacterMenu = "1";
            const string StartFightMenu = "2";
            const string StartNewFightMenu = "3";
            const string ExitMenu = "4";

            string diciredAction;

            bool isRunning = true;

            do
            {
                Console.WriteLine($"{ChooseCharacterMenu}) - выбрать персонажа.");
                Console.WriteLine($"{StartFightMenu}) - Начать бой.");
                Console.WriteLine($"{StartNewFightMenu}) - Начать новый бой.");
                Console.WriteLine($"{ExitMenu}) - выйти.");

                Console.Write("\nВведите желаемое действие: ");
                diciredAction = Console.ReadLine();
                Console.WriteLine();

                switch (diciredAction)
                {
                    case ChooseCharacterMenu:
                        ChooseCharacter();
                        break;

                    case StartFightMenu:
                        StartFight();
                        break;

                    case StartNewFightMenu:
                        StartNewFight();
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
            } while (isRunning);
        }

        private void StartNewFight()
        {
            _firstCharacter = null;
            _secondCharacter = null;

            Console.WriteLine("Можите выбрать новых бойцов.");
        }

        private void ChooseCharacter()
        {
            string diciredCharacter;

            Console.WriteLine("Выбирите первого персонажа: ");
            ShowCharacter();

            Console.Write("\nВведите номер желаемого пересонажа: ");

            diciredCharacter = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(diciredCharacter, out int firstCharacter) && firstCharacter <= _characters.Count 
                && firstCharacter > 0)
            {
                _firstCharacter = CreateCharacter(firstCharacter);
            }
            else
            {
                Console.WriteLine("Вы ввели не чилсо или неверное значение.");
            }

            Console.WriteLine("Выбирите второго персонажа: ");
            Console.Write("\nВведите номер желаемого пересонажа: ");

            diciredCharacter = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(diciredCharacter, out int secondCharacter) && secondCharacter <= _characters.Count
                && secondCharacter > 0)
            {
                _secondCharacter = CreateCharacter(secondCharacter);
            }
            else
            {
                Console.WriteLine("Вы ввели не чилсо или неверное значение.");
            }
        }

        private void ShowCharacter()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_characters[i].Name}");
            }
        }

        private Character CreateCharacter(int index)
        {
            const int Wizard = 1;
            const int Vampire = 2;
            const int Knight = 3;
            const int Demon = 4;
            const int Human = 5;

            switch (index)
            {
                case Wizard:
                    return new Wizard();

                case Vampire:
                    return new Vampire();

                case Knight:
                    return new Knight();

                case Demon:
                    return new Demon();

                case Human:
                    return new Human();

                default:
                    return null;
            }
        }

        private void StartFight()
        {
            Console.Clear();

            if (_firstCharacter != null && _secondCharacter != null)
            {
                while (_firstCharacter.IsAlive() && _secondCharacter.IsAlive())
                {
                    Attack(_firstCharacter, _secondCharacter);

                    if (_secondCharacter.IsAlive())
                    {
                        Attack(_secondCharacter, _firstCharacter);

                    }

                    Console.WriteLine();

                    ShowStatsCharacters();

                    Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить.");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (_firstCharacter.IsAlive())
                {
                    Console.WriteLine($"Победил 1 персонаж {_firstCharacter.Name}");
                }
                else
                {
                    Console.WriteLine($"Победил 2 персонаж {_secondCharacter.Name}");
                }
            }
            else
            {
                Console.WriteLine("Сначало необходимо выбрать бойцов.");
            }
        }

        private void Attack(Character firstCharacter, Character secondCharacter)
        {
            if (firstCharacter.CanUseSpecialAbilityAttack)
            {
                firstCharacter.UseSpecialAbilityAttack(secondCharacter);
            }
            else
            {
                firstCharacter.Attack(secondCharacter);
            }
        }

        private void ShowStatsCharacters()
        {
            Console.WriteLine($"1) {_firstCharacter.Name} Здоровье: {_firstCharacter.Health}");
            Console.WriteLine($"2) {_secondCharacter.Name} Здоровье: {_secondCharacter.Health}");
        }
    }

    class Character
    {
        public Character(float health, float damage, string name, bool hasHeSpecialAbilityAttack, bool hasHeSpecialAbilityDefence)
        {
            Health = health;
            Damage = damage;
            Name = name;
            CanUseSpecialAbilityAttack = hasHeSpecialAbilityAttack;
            CanUseSpecialAbilityDefence = hasHeSpecialAbilityDefence;
        }

        public float Health { get; protected set; }
        public float Damage { get; protected set; }
        public string Name { get; private set; }
        public bool CanUseSpecialAbilityAttack { get; protected set; }
        public bool CanUseSpecialAbilityDefence { get; protected set; }

        public virtual void TakeDamage(float damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} получает {damage} урона\n");
        }

        public virtual void Attack(Character character)
        {
            Console.WriteLine($"Атакует {Name}");
            character.TakeDamage(Damage);
        }

        public virtual void Attack(Character character, float damage)
        {
            character.TakeDamage(damage);
            Console.WriteLine($"Атакует {Name}");
        }

        public virtual void UseSpecialAbilityAttack(Character character)
        {
        }

        protected virtual void UseSpecialAbilityDefence()
        {
        }

        public bool IsAlive()
        {
            if (Health <= 0)
                Console.WriteLine($"{Name} мертв.");

            return Health > 0;
        }
    }

    class Wizard : Character
    {
        private static float _health = 100;
        private static float _damage = 10;
        private static string _name = "Волшебник";
        private static bool _hasHeSpecialAbilityAttack = true;
        private static bool _hasHeSpecialAbilityDefence = false;
        private float _mana = 100;

        public Wizard() : base(_health, _damage, _name, _hasHeSpecialAbilityAttack, _hasHeSpecialAbilityDefence)
        {
        }

        public override void UseSpecialAbilityAttack(Character character)
        {
            string nameSpecialSkill = "Огненный шар";
            float manaCoast = 50;
            float fireBallDamage = 25;

            if (_mana >= manaCoast)
            {
                Console.WriteLine($"{Name} использует {nameSpecialSkill}");
                _mana -= manaCoast;
                character.TakeDamage(fireBallDamage);

                if (_mana <= 0)
                {
                    CanUseSpecialAbilityAttack = false;
                }
            }
            else
            {
                Console.WriteLine("Недостаточно маны");
            }
        }
    }

    class Vampire : Character
    {
        private static float _health = 90;
        private static float _damage = 12;
        private static string _name = "Вампир";
        private static bool _hasHeSpecialAbilityAttack = true;
        private static bool _hasHeSpecialAbilityDefence = false;

        public Vampire() : base(_health, _damage, _name, _hasHeSpecialAbilityAttack, _hasHeSpecialAbilityDefence)
        {
        }

        public override void UseSpecialAbilityAttack(Character character)
        {
            float vampirismCoefficient = 0.3f;
            float vampirism = Damage * vampirismCoefficient;
            Health += vampirism;

            if (Health <= _health)
            {
                Console.WriteLine($"Востонавливает {vampirism} здоровья.");
            }

            if (Health > _health)
            {
                vampirism -= (Health - _health);

                Console.WriteLine($"Востонавливает {vampirism} здоровья.");

                Health = _health;
            }

            Attack(character);
        }
    }

    class Knight : Character
    {
        private static float _health = 110;
        private static float _damage = 10;
        private static string _name = "Рыцарь";
        private static bool _hasHeSpecialAbilityAttack = false;
        private static bool _hasHeSpecialAbilityDefence = true;

        public Knight() : base(_health, _damage, _name, _hasHeSpecialAbilityAttack, _hasHeSpecialAbilityDefence)
        {
        }

        public override void TakeDamage(float damage)
        {
            float armor = 3;
            float newDamage = damage - armor;

            base.TakeDamage(newDamage);

            Console.WriteLine($"{Name} блокирует {armor} урона.");
        }
    }

    class Demon : Character
    {
        private static float _health = 120;
        private static float _damage = 10;
        private static string _name = "Демон";
        private static bool _hasHeSpecialAbilityAttack = false;
        private static bool _hasHeSpecialAbilityDefence = true;

        public Demon() : base(_health, _damage, _name, _hasHeSpecialAbilityAttack, _hasHeSpecialAbilityDefence)
        {
        }

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            UseSpecialAbilityDefence();
        }

        protected override void UseSpecialAbilityDefence()
        {
            if (Health <= 0)
            {
                int chanceResurrection = 3;
                int minValue = 0;
                int maxValue = 10;

                float healthAfterResurrection = 60;

                Random random = new Random();

                if (random.Next(minValue, maxValue) <= chanceResurrection)
                {
                    Health = healthAfterResurrection;

                    Console.WriteLine("Демон востал из пепла.");
                }
                else
                {
                    Console.WriteLine("Пепел демона развеяло по ветру, никакие силы больше ему не помогут.");
                }
            }
        }
    }

    class Human : Character
    {
        private static float _health = 100;
        private static float _damage = 7;
        private static string _name = "Человек";
        private static bool _hasHeSpecialAbilityAttack = true;
        private static bool _hasHeSpecialAbilityDefence = false;

        public Human() : base(_health, _damage, _name, _hasHeSpecialAbilityAttack, _hasHeSpecialAbilityDefence)
        {
        }

        public override void UseSpecialAbilityAttack(Character character)
        {
            Random random = new Random();

            int minValue = 0;
            int maxValue = 10;
            int critMultiplier = 2;
            float chanseCrit = 3;
            float newDamage;

            if (random.Next(minValue, maxValue) <= chanseCrit)
            {
                newDamage = Damage * critMultiplier;

                Console.WriteLine($"{Name} усливает атаку.");

                Attack(character, newDamage);
            }
            else
            {
                Attack(character);
            }
        }
    }
}