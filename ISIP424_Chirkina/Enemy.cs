using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Chirkina
{
    // Базовый класс врага
    class Enemy
    {
        public string Name;
        public int Hp;
        public int Attack;
        public int Defense;
        public int TypeId;

        // Виртуальный метод для особенностей врага (чтобы переопределять у боссов)
        public virtual void SpecialAbility(ref int playerHp, ref bool isFrozen, Random rand)
        {
            // Обычная логика для рядовых врагов
            int finalDamage = Attack;

            if (TypeId == 0) // Гоблин (крит 20%)
            {
                if (rand.NextDouble() < 0.2)
                {
                    finalDamage = (int)(finalDamage * 1.5);
                    Console.WriteLine(" Критический удар от гоблина!");
                }
                finalDamage -= 5; // вычитаем броню игрока
            }
            else if (TypeId == 1) // Скелет (игнор брони)
            {
                Console.WriteLine(" Скелет игнорирует вашу защиту!");
                // Защиту не вычитаем, урон чистый
            }
            else if (TypeId == 2) // Маг (заморозка 15%)
            {
                if (rand.NextDouble() < 0.15)
                {
                    isFrozen = true;
                    Console.WriteLine("Маг заморозил вас!");
                }
                finalDamage -= 5;
            }

            if (finalDamage < 1) finalDamage = 1;
            playerHp -= finalDamage;
            Console.WriteLine($"Враг нанес вам {finalDamage} урона. Ваше HP: {playerHp}");
        }
    }
}
