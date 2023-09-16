using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SpellDarkSpiritMenu = 1;
            const int SpellVanduMenu = 2;
            const int SpellFireBallMenu = 3;
            const int SpellBloodSpearMenu = 4;
            const int AbsurdPrayerMenu = 5;
            const int Attack = 0;
            const int PowerfulAttack = 1;

            float hpPlayer = 600;
            float startHpPlayer = hpPlayer;
            float hpBoss = 1000;
            float spellDarkSpiritDamage = 50;
            float spellVanduDamage = 200;
            float spellFireBallDamage = 50;
            float spellBloodSpearDamagePlayer = 50;
            float spellBloodSpearDamage = 100;
            float attackDamage = 50;
            float powerfulAttackDamage = 100;
            float attackMultiplier = 0.25f;
            float absurdPrayerDamage = 100;
            float absurdPrayerHealing = 200;
            float realyAbsurdPlayerHealing;
            float borderAbsurdPlayerHeling = startHpPlayer - absurdPrayerHealing;

            int choosingActionPlayer;
            int choosingActionBoss;
            int maxRandomAttackBossValue = 2;
            int blessing;
            int maxBlessingValue = 2;
            
            string namePlayer = "Темный маг";
            string nameBoss = "Дракула";
            string spellDarkSpirit = "Темный дух"; //Призывает темного духа (-100 хп игроку)
            string spellVandu = "Ванду"; //Темный дух наносит урон (исп. только после его призыва)(-200 хп врагу)
            string spellFireBall = "Огненный шар"; //Игрок наносит урон (-50 хп врагу)
            string spellBloodSpear = "Кровавое копье"; //- 50 хп игроку, -100 хп врагу
            string absurdPrayer = "Абсурдная молитва";
            string attack = "Удар";//hit -50 hp player
            string powerfulAttack = "Мощный удар";//hit -100 hp player
            string attackMultiplierLine = Convert.ToString(attackMultiplier * 100) + "%";

            bool doesDarkSpiritExist = false;
            bool isBossAttacking = true;

            Console.WriteLine($"Вы вошли в комнату и на вас напал разъеренный {nameBoss}");

            do
            {
                Console.WriteLine($"{namePlayer} здоровье: {hpPlayer}");

                if (doesDarkSpiritExist)
                {
                    Console.WriteLine($"{spellDarkSpirit} призван");
                }
                Console.WriteLine($"{nameBoss} здоровье: {hpBoss}");
                Console.WriteLine();
                Console.WriteLine($"Выбирите заклинание:");
                Console.WriteLine($"{SpellDarkSpiritMenu} - {spellDarkSpirit} (Призывает {spellDarkSpirit}, -{spellDarkSpiritDamage} урона {namePlayer})");
                Console.WriteLine($"{SpellVanduMenu} - {spellVandu} ({spellDarkSpirit} наносит -{spellVanduDamage} урона {nameBoss}, " + "\n"
                    + $"можно использовать только после призыва {spellDarkSpirit})");
                Console.WriteLine($"{SpellFireBallMenu} - {spellFireBall} (наносит -{spellFireBallDamage} урона {nameBoss})");
                Console.WriteLine($"{SpellBloodSpearMenu} - {spellBloodSpear} (наносить -{spellBloodSpearDamagePlayer} урона {namePlayer}, " +
                    $"и -{spellBloodSpearDamage} урона {nameBoss}," + "\n" + $" усиливает все заклинания на {attackMultiplierLine})");
                Console.WriteLine($"{AbsurdPrayerMenu} - {absurdPrayer} ({namePlayer} может получить {absurdPrayerDamage} урона, " +
                    $"а может исцелиться на {absurdPrayerHealing} здоровья и отразить все атаки {nameBoss})");

                Console.WriteLine("Выбирите действие");
                choosingActionPlayer = Convert.ToInt32(Console.ReadLine());

                switch (choosingActionPlayer)
                {
                    case SpellDarkSpiritMenu:
                        if (!doesDarkSpiritExist)
                        {
                            doesDarkSpiritExist = true;
                            hpPlayer -= spellDarkSpiritDamage;

                            Console.WriteLine($"Вы призвали {spellDarkSpirit}, теперь вы можите использовать заклинание {spellVandu}");
                            Console.WriteLine($"-{spellDarkSpiritDamage} хп {namePlayer}");
                        }
                        else
                        {
                            Console.WriteLine($"{spellDarkSpirit} уже призван");

                            isBossAttacking = false;
                        }
                        break;

                    case SpellVanduMenu:
                        if (doesDarkSpiritExist)
                        {
                            hpBoss -= spellVanduDamage;

                            Console.WriteLine($"{spellDarkSpirit} наносит -{spellVanduDamage} урона {nameBoss}");
                        }
                        else
                        {
                            Console.WriteLine($"{spellDarkSpirit} не призван, заклинание не может быть использованно");

                            isBossAttacking = false;
                        }
                        break;

                    case SpellFireBallMenu:
                        hpBoss -= spellFireBallDamage;

                        Console.WriteLine($"{namePlayer} наносить -{spellFireBallDamage} урона {nameBoss}");
                        break;

                    case SpellBloodSpearMenu:
                        hpBoss -= spellBloodSpearDamage;
                        hpPlayer -= spellBloodSpearDamagePlayer;

                        Console.WriteLine($"{namePlayer} создает копье из своей крови и получает -{spellBloodSpearDamagePlayer} урона");
                        Console.WriteLine($"{nameBoss} получает -{spellBloodSpearDamage}");
                        Console.WriteLine($"{namePlayer} высасывыет жизненные силы из {nameBoss}, урон {namePlayer} вырас на ");

                        spellVanduDamage += (attackMultiplier * spellVanduDamage);
                        spellFireBallDamage += (attackMultiplier * spellFireBallDamage);
                        spellBloodSpearDamage += (attackMultiplier * spellBloodSpearDamage);
                        break;

                    case AbsurdPrayerMenu:
                        Random random = new Random();
                        blessing = random.Next(maxBlessingValue);
                        realyAbsurdPlayerHealing = startHpPlayer - hpPlayer;

                        if (hpPlayer < startHpPlayer)
                        {
                            if (blessing > 0)
                            {
                                Console.WriteLine($"{namePlayer} отпущены все грехи, на него снезошла благодать, появляется святой щит отражающий атаки {nameBoss}");

                                if (hpPlayer >= borderAbsurdPlayerHeling)
                                {
                                    Console.WriteLine($"Здоровье {namePlayer} повышенно на {realyAbsurdPlayerHealing}");
                                }
                                else 
                                {
                                    Console.WriteLine($"Здоровье {namePlayer} повышенно на {absurdPrayerHealing}");
                                }

                                hpPlayer += absurdPrayerHealing;

                                if (hpPlayer > startHpPlayer)
                                {
                                    hpPlayer = startHpPlayer;
                                }

                                isBossAttacking = false;
                            }
                            else
                            {
                                hpPlayer -= absurdPrayerHealing;
                                Console.WriteLine($"{namePlayer} припомнились все его грешки, на него снезошла божья кара");
                                Console.WriteLine($"Здоровье {namePlayer} пониженно на {absurdPrayerDamage}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы может и совершали множество глупостей за свою темную карьеру, " + "\n" +
                                "но еще не опустились до того, чтобы взывать к помощи бога будучи в полном здравии");
                            isBossAttacking = false;
                        }
                        break;

                    default:
                        Console.WriteLine("Такого заклинания не существует, выбирите одно из существующих");

                        isBossAttacking = false;
                        break;
                }

                if (isBossAttacking)
                {
                    Random random = new Random();
                    choosingActionBoss = random.Next(maxRandomAttackBossValue);

                    switch (choosingActionBoss)
                    {
                        case Attack:
                            hpPlayer -= attackDamage;

                            Console.WriteLine($"{nameBoss} нанес {attack} {namePlayer} -{attackDamage} урона");
                            break;

                        case PowerfulAttack:
                            hpPlayer -= powerfulAttackDamage;

                            Console.WriteLine($"{nameBoss} нанес {powerfulAttack} {namePlayer} -{powerfulAttackDamage} урона");
                            break;
                    }
                }

                isBossAttacking = true;
                Console.WriteLine();
            } while (hpBoss > 0 && hpPlayer > 0);

            if(hpPlayer > hpBoss)
            {
                Console.WriteLine($"{namePlayer} победил!");
            }
            if(hpPlayer < hpBoss)
            {
                Console.WriteLine($"{nameBoss} победил!");
            }
            else
            {
                Console.WriteLine("Ничья!");
            }
        }
    }
}