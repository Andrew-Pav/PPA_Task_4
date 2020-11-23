using System;

namespace PAA_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int heroHp = 300, bossHp = 1000, bossDamage, heroDamage, amountOfHealPotion = 2, dodgeChance = 50;
            char move;
            bool chance, armor = true;

            Random rand = new Random();

            while (heroHp > 0 && bossHp > 0)
            {
                heroDamage = 60;
                if (armor)
                    bossDamage = rand.Next(40, 51);
                else
                    bossDamage = 75;
                Console.WriteLine($"{heroHp}|300 Hero HP\t\t{bossHp}|1000 Boss HP\n");
                Console.WriteLine
                    ("\t! - Обычная атака\n\t" +
                    $"% - Выпить большое лечебное зелье (восполняет 300 hp) | осталось {amountOfHealPotion} Зелий\n\t" +
                    $"^ - Нанести атаку в увороте (если вам повезёт (шанс {dodgeChance}%) вы избежите урона,\n\t   " +
                    " если нет то урон по вам будет увеличен на один ход)");
                if (armor)
                    Console.WriteLine("\t# - Снять доспехи (Увеличивает шанс удачной атаки в увороте на 75%, но также увеличивает урон по вам)\n\n\n");
                move = Convert.ToChar(Console.ReadLine());
                switch (move)
                {
                    case '!':
                        bossHp -= heroDamage;
                        break;
                    case '%':
                        if (amountOfHealPotion > 0)
                        {
                            heroHp = 300;
                            amountOfHealPotion--;
                            Console.WriteLine("\t\t\tВы восполнили здоровье до 300 HP");
                        }
                        else
                            Console.WriteLine("\t\t\tПока вы искали зелья, которых у вас нет. Вы пропустили атаку");
                        heroDamage = 0;
                        break;
                    case '^':
                        if (armor)
                        {
                            chance = Convert.ToBoolean(rand.Next(2));
                            if (chance)
                            {
                                bossHp -= heroDamage;
                                Console.WriteLine("\t\t\tВы удачно увернулись");
                                bossDamage = 0;
                            }
                            else
                            {
                                bossHp -= heroDamage;
                                Console.WriteLine("\t\t\tВы неудачно увернулись");
                                bossDamage = 75;
                            }
                        }
                        else
                        {
                            chance = Convert.ToBoolean(rand.Next(4));
                            if (chance)
                            {
                                bossHp -= heroDamage;
                                Console.WriteLine("\t\t\tВы удачно увернулись");
                                bossDamage = 0;
                            }
                            else
                            {
                                bossHp -= heroDamage;
                                Console.WriteLine("\t\t\tВы неудачно увернулись");
                                bossDamage = 90;
                            }
                        }
                            break;
                    case '#':
                        armor = false;
                        dodgeChance = 75;
                        heroDamage = 0;
                        break;
                }
                heroHp -= bossDamage;
                Console.WriteLine($"\t\t\tВы получили {bossDamage} урона");
                Console.WriteLine($"\t\t\tБосс получил {heroDamage} урона\n");
                Console.WriteLine("Нажмите любую клавишу для начала следующего хода");
                Console.ReadKey();
                Console.Clear();
            }
            if (heroHp <= 0 && bossHp <= 0)
                Console.WriteLine("Вы победили босса, но также пали сами(");
            else if (heroHp > 0 && bossHp <= 0)
                Console.WriteLine("Вы выиграли)");
            else
                Console.WriteLine("Вы проиграли(");
        }
    }
}
