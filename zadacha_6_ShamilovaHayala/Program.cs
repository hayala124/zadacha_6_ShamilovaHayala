namespace zadacha_6_ShamilovaHayala
{
    class Program
    {
        static int gameTact = 0;
        static int exitFromFault = 0;
        static void Main(string[] args)
        {
            ShadowMagician shadowMagician = new ShadowMagician();
            int maxHpMagician = shadowMagician.GetMaxHp();
            int hpMagician = shadowMagician.GetStartHp();

            Boss boss = new Boss();
            int maxHpBoss = boss.GetMaxHp();
            int hpBoss = boss.GetStartHp();

            string nameFirstPlayer = "";
            int impactForce;
            string spell = "";
            RulesOfGame(maxHpBoss, maxHpMagician);
            Console.WriteLine($"Начальное значение здоровья у игрока - {hpMagician}\n" +
                $"Начальное значение здоровья у БОССА - {hpBoss}\n");
            
            do
            {
                gameTact++;
                Console.WriteLine($"Игровой такт № {gameTact}");

                if (gameTact == 1)
                {
                    Console.WriteLine($"Атакует {nameFirstPlayer = GetNameFirstPlayer()}");
                    if (nameFirstPlayer == "БОСС")
                    {
                        impactForce = boss.firstBossMove();
                        hpMagician -= impactForce;
                        Console.WriteLine($"Сила удара - {impactForce} единиц");
                    }
                    else
                    {
                        Console.Write("Введите заклинание: ");
                        spell = Console.ReadLine();
                        var values = shadowMagician.GetValues(hpMagician, hpBoss, maxHpMagician, spell);
                        hpMagician = values.Item1;
                        hpBoss = values.Item2;
                        exitFromFault = values.Item4;
                        if (values.Item3.HasValue)
                        {
                            impactForce = values.Item3.Value;
                            Console.WriteLine($"Сила удара - {impactForce} единиц");
                        }
                    }
                    OutputHpMagician_HpBoss(hpMagician, hpBoss);
                }
                else
                {
                    if (nameFirstPlayer == "БОСС")
                    {
                        nameFirstPlayer = "Теневой маг";
                        Console.Write($"Атакует {nameFirstPlayer}\nВведите заклинание: ");
                        spell = Console.ReadLine();
                        var values = shadowMagician.GetValues(hpMagician, hpBoss, maxHpMagician, spell);
                        hpMagician = values.Item1;
                        hpBoss = values.Item2;
                        exitFromFault = values.Item4;
                        if (values.Item3.HasValue)
                        {
                            impactForce = values.Item3.Value;
                            Console.WriteLine($"Сила удара - {impactForce} единиц");
                        }
                    }
                    else if (nameFirstPlayer == "Теневой маг")
                    {
                        nameFirstPlayer = "БОСС";
                        Console.WriteLine($"Атакует {nameFirstPlayer}");
                        var values = boss.bossMove(hpMagician, exitFromFault, maxHpMagician);
                        hpMagician = values.Item1;
                        impactForce = values.Item2;
                        Console.WriteLine($"Сила удара - {impactForce} единиц");
                    }
                    OutputHpMagician_HpBoss(hpMagician, hpBoss);
                }
            }
            while (hpMagician > 0 && hpBoss > 0);

            GetResultOfGame(hpMagician);
        }

        static private void OutputHpMagician_HpBoss(int hpMagician, int hpBoss)
        {
            Console.WriteLine($"Осталось здоровья у игрока - {hpMagician} единиц\nОсталось здоровья у БОССА - {hpBoss}\n");
        }

        static private void GetResultOfGame(int hpMagician)
        {
            if (hpMagician <= 0)
            {
                Console.WriteLine("БОСС победил!");
            }
            else
            {
                Console.WriteLine("Вы победили!");
            }
        }
        static private string GetNameFirstPlayer()
        {
            Random random = new Random();
            string nameFirstPlayer = "";
            int firstMove = random.Next(1, 3);
            if (firstMove == 1)
            {
                nameFirstPlayer = "БОСС";
            }
            else if (firstMove == 2)
            {
                nameFirstPlayer = "Теневой маг";
            }
            return nameFirstPlayer;
        }
        static private void RulesOfGame(int maxHpBoss, int maxHpMagician)
        {
            Console.WriteLine($"Игра - Победи БОССА\nУсловия:\nМаксимальный уровень жизни у БОССА - {maxHpBoss}\n" +
                $"Максимальный уровень жизни у теневого мага - {maxHpMagician}\n" +
                $"Случайным образом выбирается игрок, делающий первый ход\n" +
                "Величина урона, наносимого БОССОМ, для каждого хода случайна\n" +
                "Теневой маг может пользоваться следующими заклинаниями:\n\n" +
                "расенган - наносит удар противнику от 80 до 150 единиц урона \n\n" + 
                "рашамон – призывает теневого духа для нанесения атаки (Отнимает 100 хп игроку)\n\n" +
                "хуганзакура (Может быть выполнен только после призыва теневого духа) - наносит 110 ед. урона\n\n" +
                "межпространственный разлом – позволяет скрыться в разломе и восстановить 150 хп. Тратится 70 единиц здоровья.\n" +
                "Урон БОССА по вам не проходит, но вы также не можете атаковать БОССА\n\n" +
                "межпространственный возврат - позволяет выйти из межпространственного разлома\n\n" +
                "лечение - восстанавливает игроку рандомно от 100 до 150 хп\n");
        }
    }
}