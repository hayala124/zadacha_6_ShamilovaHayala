namespace zadacha_6_ShamilovaHayala
{
    class Boss
    {
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

        public int firstBossMove()
        {
            int impactForce;
            Random random = new Random();
            impactForce = random.Next(100, 150);
            return impactForce;
        }

        public (int, int) bossMove(int hpMagician, int exitFromFault, int maxhpMagician)
        {
            Random random = new Random();
            int impactForce;
            switch (exitFromFault)
            {
                case 0:
                    impactForce = random.Next(100, 150);
                    hpMagician -= impactForce;
                    break;
                case 1:
                    impactForce = random.Next(100, 150);
                    if (hpMagician < maxhpMagician)
                    {
                        hpMagician += 150;
                        if (hpMagician > maxhpMagician)
                            hpMagician = maxhpMagician;
                    }
                    break;
                default:
                    impactForce = random.Next(100, 150);
                    break;
            }
            return (hpMagician, impactForce);
        }

    }
}
