namespace zadacha_6_ShamilovaHayala
{
    class ShadowMagician
    {
        static int exitFromFault = 0;
        static int summoningShadowSpirit = 0;
        public int GetMaxHp()
        {
            Random random = new Random();
            return random.Next(500, 1000);
        }
        public int GetStartHp()
        {
            Random random = new Random();
            return random.Next(100, 500);
        }

        public (int, int, int?, int) GetValues(int hpMagician, int hpBoss, int maxhpMagician, string spell)
        {
            Random random = new Random();
            int? impactForce = null;
            switch (spell)
            {
                case "расенган":
                    if (exitFromFault != 1)
                    {
                        impactForce = random.Next(80, 150);
                        hpBoss -= (int)impactForce;
                    }
                    else
                        impactForce = random.Next(80, 150);
                    break;
                case "рашамон":
                    if (exitFromFault != 1)
                    {
                        summoningShadowSpirit++;
                        hpMagician -= 100;
                    }
                    break;
                case "хуганзакура":
                    if (exitFromFault != 1)
                    {
                        if (summoningShadowSpirit > 0)
                        {
                            impactForce = 110;
                            hpBoss -= (int)impactForce;
                            summoningShadowSpirit = 0;
                        }
                        else
                        {
                            Console.WriteLine("Перед использованием заклинания 'хуганзакура' необходимо призвать теневого духа с помощью заклинания 'рашамон'");
                        }
                    }
                    break;
                case "межпространственный разлом":
                    exitFromFault = 1;
                    hpMagician -= 70;
                    break;
                case "межпространственный возврат":
                    if (exitFromFault == 0)
                    {
                        Console.WriteLine("Вы зря использовали свой ход. Вы не находились в межространственном разломе");
                    }
                    else if (exitFromFault == 1)
                    {
                        exitFromFault = 0;
                        Console.WriteLine("Вы вернулись из межпространственного разлома. Берегитесь удара босса!");
                    }
                    break;
                case "лечение":
                    if (exitFromFault != 1)
                    {
                        if (hpMagician < maxhpMagician)
                        {
                            hpMagician += random.Next(100, 150);
                            if (hpMagician > maxhpMagician)
                                hpMagician = maxhpMagician;
                        }
                        else
                            Console.WriteLine("Вы больше не можете использовать данное заклинание.\n" +
                                "Так как ваш максимальный уровень жизни " + maxhpMagician);
                    }
                    break;
                default:
                    if (hpMagician < maxhpMagician && exitFromFault == 1)
                    {
                        hpMagician += 150;
                        if (hpMagician > maxhpMagician)
                            hpMagician = maxhpMagician;
                    }
                        
                    Console.WriteLine("Вы волнуетесь и сказали неправильное заклинание!\n" +
                        "Ход переходит к боссу");
                    break;
            }
            return (hpMagician, hpBoss, impactForce, exitFromFault);
        }
    }
}
