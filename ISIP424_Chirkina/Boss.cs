using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Chirkina
{
    // ВВГ (Гоблин): здоровье ×2.0, атака ×1.5, защита ×1.2, крит +10%
    class VvgBoss : Enemy
    {
        public VvgBoss()
        {
            Name = "ВВГ (Босс-Гоблин)";
            Hp = (int)(40 * 2.0);
            Attack = (int)(12 * 1.5);
            Defense = (int)(3 * 1.2);
            TypeId = 0;
        }

        public override void SpecialAbility(ref int playerHp, ref bool isFrozen, Random rand)
        {
            int finalDamage = Attack;
            // Шанс крита обычного гоблина (20%) + 10% = 30%
            if (rand.NextDouble() < 0.3)
            {
                finalDamage = (int)(finalDamage * 1.5);
                Console.WriteLine("Мощный критический удар босса ВВГ!");
            }
            finalDamage -= 5;
            if (finalDamage < 1) finalDamage = 1;
            playerHp -= finalDamage;
            Console.WriteLine($"Босс нанес вам {finalDamage} урона. Ваше HP: {playerHp}");
        }
    }

    // Ковальский (Скелет): здоровье ×2.5, атака ×1.3, защита ×1.4, игнор брони
    class KowalskiBoss : Enemy
    {
        public KowalskiBoss()
        {
            Name = "Ковальский (Босс-Скелет)";
            Hp = (int)(50 * 2.5);
            Attack = (int)(10 * 1.3);
            Defense = (int)(5 * 1.4);
            TypeId = 1;
        }

        public override void SpecialAbility(ref int playerHp, ref bool isFrozen, Random rand)
        {
            Console.WriteLine("Ковальский полностью игнорирует вашу защиту!");
            playerHp -= Attack; // Чистый урон
            Console.WriteLine($"Босс нанес вам {Attack} чистого урона. Ваше HP: {playerHp}");
        }
    }

    // Архимаг C++ (Маг): здоровье ×1.8, атака ×1.6, защита ×1.1, заморозка +10%
    class ArchmageBoss : Enemy
    {
        public ArchmageBoss()
        {
            Name = "Архимаг C++ (Босс-Маг)";
            Hp = (int)(35 * 1.8);
            Attack = (int)(14 * 1.6);
            Defense = (int)(2 * 1.1);
            TypeId = 2;
        }

        public override void SpecialAbility(ref int playerHp, ref bool isFrozen, Random rand)
        {
            int finalDamage = Attack;
            // Шанс заморозки обычного мага (15%) + 10% = 25%
            if (rand.NextDouble() < 0.25)
            {
                isFrozen = true;
                Console.WriteLine("Архимаг C++ наложил ледяную заморозку!");
            }
            finalDamage -= 5;
            if (finalDamage < 1) finalDamage = 1;
            playerHp -= finalDamage;
            Console.WriteLine($"Босс нанес вам {finalDamage} урона. Ваше HP: {playerHp}");
        }
    }

    // Пестов С-- (Скелет): здоровье ×1.3, атака ×1.8, защита ×0.6, игнор брони + заморозка +15%
    class PestovBoss : Enemy
    {
        public PestovBoss()
        {
            Name = "Пестов С-- (Босс)";
            Hp = (int)(50 * 1.3);
            Attack = (int)(10 * 1.8);
            Defense = (int)(5 * 0.6);
            TypeId = 1;
        }

        public override void SpecialAbility(ref int playerHp, ref bool isFrozen, Random rand)
        {
            //игнор брони (как скелет) + шанс заморозки +15% (как у мага 15% + 15% = 30%)
            if (rand.NextDouble() < 0.3)
            {
                isFrozen = true;
                Console.WriteLine("Пестов С-- заморозил вас синтаксической ошибкой!");
            }

            Console.WriteLine("Пестов С-- игнорирует вашу защиту!");
            playerHp -= Attack;
            Console.WriteLine($"Босс нанес вам {Attack} чистого урона. Ваше HP: {playerHp}");
        }
    }
}
