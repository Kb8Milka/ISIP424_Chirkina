using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Chirkina
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            // Характеристики игрока
            int playerHp = 100;
            int maxHp = 100;
            int playerAttack = 15;
            int playerDefense = 5;

            // Начальная экипировка
            Item currentWeapon = new Item("Ржавый меч", "Weapon", 5);
            Item currentArmor = new Item("Тряпки", "Armor", 2);

            int turns = 0;

            while (playerHp > 0)
            {
                turns++;
                Console.WriteLine($"\nХод {turns}");
                Console.WriteLine($"Здоровье: {playerHp}/{maxHp}");
                Console.WriteLine($"Оружие: {currentWeapon.Name} (+{currentWeapon.Value}) | Броня: {currentArmor.Name} (+{currentArmor.Value})");
                Console.WriteLine("Нажмите Enter для продолжения");
                Console.ReadLine();

                // Каждые 10 ходов - босс
                if (turns % 10 == 0)
                {
                    Console.WriteLine("\nПоявился БОСС!");

                    int bossRoll = rand.Next(4);
                    Enemy boss = null;

                    if (bossRoll == 0)
                    {
                        boss = new VvgBoss();
                    }
                    else if (bossRoll == 1)
                    {
                        boss = new KowalskiBoss();
                    }
                    else if (bossRoll == 2)
                    {
                        boss = new ArchmageBoss();
                    }
                    else boss = new PestovBoss();

                    Fight(ref playerHp, playerAttack, playerDefense, currentWeapon, boss, rand);
                }
                else
                {
                    // 50 на 50: сундук или враг
                    if (rand.Next(2) == 0)
                    {
                        Console.WriteLine("\n Вы нашли сундук!");
                        OpenChest(ref playerHp, maxHp, ref currentWeapon, ref currentArmor, rand);
                    }
                    else
                    {
                        Console.WriteLine("\n На вас напал враг!");

                        int enemyRoll = rand.Next(3);
                        Enemy enemy = new Enemy();

                        if (enemyRoll == 0)
                        {
                            enemy.Name = "Гоблин";
                            enemy.Hp = 40;
                            enemy.Attack = 12;
                            enemy.Defense = 3;
                            enemy.TypeId = 0;
                        }
                        else if (enemyRoll == 1)
                        {
                            enemy.Name = "Скелет";
                            enemy.Hp = 50;
                            enemy.Attack = 10;
                            enemy.Defense = 5;
                            enemy.TypeId = 1;
                        }
                        else
                        {
                            enemy.Name = "Маг";
                            enemy.Hp = 35;
                            enemy.Attack = 14;
                            enemy.Defense = 2;
                            enemy.TypeId = 2;
                        }

                        Fight(ref playerHp, playerAttack, playerDefense, currentWeapon, enemy, rand);
                    }
                }
            }

            Console.WriteLine("\n Вы погибли! Игра окончена.");
            Console.ReadKey();
        }

        //Бой
        static void Fight(ref int playerHp, int pAttack, int pDefense, Item weapon, Enemy enemy, Random rand)
        {
            Console.WriteLine($"Начался бой с: {enemy.Name} (HP: {enemy.Hp})");
            bool isFrozen = false;

            while (playerHp > 0 && enemy.Hp > 0)
            {
                // Проверка заморозки
                if (isFrozen)
                {
                    Console.WriteLine("\n Вы заморожены и пропускаете этот ход!");
                    isFrozen = false;
                    enemy.SpecialAbility(ref playerHp, ref isFrozen, rand);
                    continue;
                }

                Console.WriteLine("\nВаш ход:");
                Console.WriteLine("1. Атаковать");
                Console.WriteLine("2. Защищаться");
                Console.Write("Выберите действие (1 или 2): ");
                string choice = Console.ReadLine();

                bool defending = false;

                if (choice == "1")
                {
                    int totalAtk = pAttack + weapon.Value;
                    int damageToEnemy = totalAtk - enemy.Defense;
                    if (damageToEnemy < 1) damageToEnemy = 1;

                    enemy.Hp -= damageToEnemy;
                    Console.WriteLine($"Вы ударили врага и нанесли {damageToEnemy} урона. У врага осталось {Math.Max(0, enemy.Hp)} HP.");
                }
                else if (choice == "2")
                {
                    defending = true;
                    Console.WriteLine("Вы встали в защитную стойку.");
                }
                else
                {
                    Console.WriteLine("Неверный выбор, вы пропустили удар!");
                }

                if (enemy.Hp <= 0)
                {
                    Console.WriteLine($"\n Вы победили противника {enemy.Name}!");
                    break;
                }

                // Ход врага
                Console.WriteLine($"\nХод противника ({enemy.Name}):");
                if (defending)
                {
                    // 40% уклонение
                    if (rand.NextDouble() < 0.4)
                    {
                        Console.WriteLine(" Вы успешно уклонились от атаки!");
                        continue;
                    }
                    else
                    {
                        // Блок снижает урон на 70-100% от защиты (берем базовую защ игрока = 5)
                        double blockPercent = 0.7 + (rand.NextDouble() * 0.3);
                        int mitigated = (int)(pDefense * blockPercent);
                        int incoming = enemy.Attack - mitigated;
                        if (incoming < 1) incoming = 1;

                        playerHp -= incoming;
                        Console.WriteLine($"Блок смягчил удар. Вы получили {incoming} урона. Ваше HP: {playerHp}");
                        continue;
                    }
                }

                // Обычная или особенная атака врага
                enemy.SpecialAbility(ref playerHp, ref isFrozen, rand);
            }
        }

        // Сундук
        static void OpenChest(ref int playerHp, int maxHp, ref Item weapon, ref Item armor, Random rand)
        {
            int roll = rand.Next(3);

            if (roll == 0)
            {
                playerHp = maxHp;
                Console.WriteLine(" Вы нашли лечебное зелье! Здоровье полностью восстановлено.");
            }
            else if (roll == 1)
            {
                int power = rand.Next(5, 18);
                Item newWeapon = new Item($"Меч (+{power})", "Weapon", power);

                Console.WriteLine($"Вы нашли новое оружие: {newWeapon.Name} (Атака: {newWeapon.Value})");
                Console.WriteLine($"Текущее оружие: {weapon.Name} (Атака: {weapon.Value})");
                Console.Write("Взять предмет? (1 - Да, 2 - Выбросить): ");

                if (Console.ReadLine() == "1")
                {
                    weapon = newWeapon;
                    Console.WriteLine("Вы экипировали новое оружие.");
                }
                else
                {
                    Console.WriteLine("Вы выбросили предмет.");
                }
            }
            else
            {
                int power = rand.Next(3, 12);
                Item newArmor = new Item($"Доспех (+{power})", "Armor", power);

                Console.WriteLine($"Вы нашли новый доспех: {newArmor.Name} (Защита: {newArmor.Value})");
                Console.WriteLine($"Текущий доспех: {armor.Name} (Защита: {armor.Value})");
                Console.Write("Взять предмет? (1 - Да, 2 - Выбросить): ");

                if (Console.ReadLine() == "1")
                {
                    armor = newArmor;
                    Console.WriteLine("Вы экипировали новый доспех.");
                }
                else
                {
                    Console.WriteLine("Вы выбросили предмет.");
                }
            }
        }
    }
}
