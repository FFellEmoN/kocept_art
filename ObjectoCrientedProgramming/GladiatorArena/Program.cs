﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

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
            const string ChooseCharacterCommand = "1";
            const string StartFightMenu = "2";
            const string StartNewFightMenu = "3";
            const string ExitMenu = "4";

            string diciredAction;

            bool isRunning = true;

            do
            {
                Console.WriteLine($"{ChooseCharacterCommand}) - выбрать персонажа.");
                Console.WriteLine($"{StartFightMenu}) - Начать бой.");
                Console.WriteLine($"{StartNewFightMenu}) - Начать новый бой.");
                Console.WriteLine($"{ExitMenu}) - выйти.");

                Console.Write("\nВведите желаемое действие: ");
                diciredAction = Console.ReadLine();
                Console.WriteLine();

                switch (diciredAction)
                {
                    case ChooseCharacterCommand:
                        ChooseCharacters();
                        break;

                    case StartFightMenu:
                        Fight();
                        break;

                    case StartNewFightMenu:
                        CreateNewFight();
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

        private void CreateNewFight()
        {
            _firstCharacter = null;
            _secondCharacter = null;

            Console.WriteLine("Можите выбрать новых бойцов.");
        }

        private void ChooseCharacters()
        {
            ShowCharacters();

            Console.WriteLine("Выбирите первого персонажа: ");

            Console.Write("\nВведите номер желаемого пересонажа: ");

            _firstCharacter = CreateCharacter();

            if (_firstCharacter == null)
            {
                return;
            }

            Console.WriteLine("Выбирите второго персонажа: ");
            Console.Write("\nВведите номер желаемого пересонажа: ");

            _secondCharacter = CreateCharacter();
        }

        private Character CreateCharacter()
        {
            _characters = new List<Character>();
            _characters.Add(new Wizard());
            _characters.Add(new Vampire());
            _characters.Add(new Knight());
            _characters.Add(new Demon());
            _characters.Add(new Human());

            string numberCharacter;

            numberCharacter = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(numberCharacter, out int character) && character <= _characters.Count
                && character > 0)
            {
                return _characters[character - 1];
            }
            else
            {
                Console.WriteLine("Вы ввели не чилсо или неверное значение.");

                return null;
            }
        }

        private void ShowCharacters()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_characters[i].Name}");
            }
        }

        private void Fight()
        {
            Console.Clear();

            if (_firstCharacter != null && _secondCharacter != null)
            {
                while (_firstCharacter.IsAlive && _secondCharacter.IsAlive)
                {
                    _firstCharacter.Attack(_secondCharacter);

                    if (_secondCharacter.IsAlive)
                    {
                        _secondCharacter.Attack(_firstCharacter);
                    }

                    Console.WriteLine();

                    ShowStatsCharacters();

                    Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить.");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (_firstCharacter.IsAlive)
                {
                    Console.WriteLine($"Победил 1 персонаж {_firstCharacter.Name}");
                }
                else
                {
                    Console.WriteLine($"Победил 2 персонаж {_secondCharacter.Name}");
                }

                if (_secondCharacter.IsAlive == false && _firstCharacter.IsAlive == false)
                {
                    Console.WriteLine("Ничья.");
                }
            }
            else
            {
                Console.WriteLine("Сначало необходимо выбрать бойцов.");
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
        public float Health { get; protected set; }
        public float Damage { get; protected set; }
        public string Name { get; protected set; }
        public bool CanUseSpecialAbilityAttack { get; protected set; }
        public bool IsAlive => Health > 0;

        public virtual void TakeDamage(float damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} получает {damage} урона\n");
        }

        public void Attack(Character character)
        {
            Console.WriteLine($"Атакует {Name}");

            if (CanUseSpecialAbilityAttack == true)
            {
                UseSpecialAbilityAttack(character);
            }
            else
            {
                character.TakeDamage(Damage);
            }
        }

        public virtual void UseSpecialAbilityAttack(Character character)
        {
        }
    }

    class UserUtils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return s_random.Next(min, max);
        }
    }

    class Wizard : Character
    {
        private float _mana = 100;

        public Wizard()
        {
            Health = 100;
            Damage = 10;
            Name = "Волшебник";
            CanUseSpecialAbilityAttack = true;
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
        private float _maxHealth;
        public Vampire()
        {
            Health = 90;
            _maxHealth = Health;
            Damage = 12;
            Name = "Вампир";
            CanUseSpecialAbilityAttack = true;
        }

        public override void UseSpecialAbilityAttack(Character character)
        {
            float vampirismCoefficient = 0.3f;
            float vampirism = Damage * vampirismCoefficient;
            Health += vampirism;

            if (Health <= _maxHealth)
            {
                Console.WriteLine($"Востонавливает {vampirism} здоровья.");
            }

            if (Health > _maxHealth)
            {
                vampirism -= (Health - _maxHealth);

                Console.WriteLine($"Востонавливает {vampirism} здоровья.");

                Health = _maxHealth;
            }

            character.TakeDamage(Damage);
        }
    }

    class Knight : Character
    {
        public Knight()
        {
            Health = 110;
            Damage = 10;
            Name = "Рыцарь";
            CanUseSpecialAbilityAttack = false;
        }

        public override void TakeDamage(float damage)
        {
            float armor = 3;
            float newDamage;

            if (damage < armor)
            {
                newDamage = damage - armor;
            }
            else
            {
                newDamage = 0;
            }
            base.TakeDamage(newDamage);

            Console.WriteLine($"{Name} блокирует {armor} урона.");
        }
    }

    class Demon : Character
    {
        public Demon()
        {
            Health = 120;
            Damage = 10;
            Name = "Демон";
            CanUseSpecialAbilityAttack = false;
        }

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            UseSpecialAbilityDefence();
        }

        public override void UseSpecialAbilityAttack(Character character)
        {
            int attenuationImpact = 2;
            float halfCharacterHealth = character.Health / 2;

            if (character.Health == halfCharacterHealth)
            {
                float newDamage = Damage - attenuationImpact;
                character.TakeDamage(newDamage);
            }
            else
            {
                character.TakeDamage(Damage);
            }
        }

        private void UseSpecialAbilityDefence()
        {
            if (Health <= 0)
            {
                int chanceResurrection = 3;
                int minValue = 0;
                int maxValue = 10;

                float healthAfterResurrection = 60;

                if (UserUtils.GenerateRandomNumber(minValue, maxValue) <= chanceResurrection)
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
        public Human()
        {
            Health = 100;
            Damage = 7;
            Name = "Человек";
            CanUseSpecialAbilityAttack = true;
        }

        public override void UseSpecialAbilityAttack(Character character)
        {
            int minValue = 0;
            int maxValue = 10;
            int critMultiplier = 2;
            float chanseCrit = 3;
            float newDamage;

            if (UserUtils.GenerateRandomNumber(minValue, maxValue) <= chanseCrit)
            {
                newDamage = Damage * critMultiplier;

                Console.WriteLine($"{Name} усливает атаку.");

                character.TakeDamage(newDamage);
            }
            else
            {
                character.TakeDamage(Damage);
            }
        }
    }
}