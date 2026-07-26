class Enemy
    {
        public string Name; 
        public int MaxHp; 
        public int CurrentHp;
        public int MinDmg;
        public int Maxdmg; 

        public Enemy(string name, int maxHp, int minDmg, int maxDmg)
        {
            Name = name;
            MaxHp = maxHp;
            CurrentHp = maxHp;
            MinDmg = minDmg;
            Maxdmg = maxDmg;
        }
    } 