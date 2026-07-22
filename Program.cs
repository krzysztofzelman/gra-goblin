using System;
class Program
{
    static string   ChooseWeapon()
    {
        Console.WriteLine("Wybierz swoja broń");
        Console.WriteLine("1 - Miecz (3 - 8 dmg)");
        Console.WriteLine("2 - Topór (4 - 10dmg)");
        Console.WriteLine("3 - Sztylet (2-5 dmg, dwa ataki)");
        return Console.ReadLine() ?? "";
    }
static void Main ()
    {
        int hp = 30;
        int maxHp = 30;
        int enemyHp = 0;
        int potions = 3;
        int gold = 0;
        int stage = 1;

        Random rng  = new Random();     

        Console.WriteLine("Witaj w lochu!");

        string weapon = ChooseWeapon();      

        while (hp > 0 && enemyHp > 0)
        {
            string enemyName = "";

            if (enemyHp <= 0)
            {
                int enemyMaxHp = 0;
                if (stage == 1)
                {
                    enemyName = "goblin";
                    enemyMaxHp = 25;
                }
                else if (stage == 2)
                {
                    enemyName = "orc";
                    enemyMaxHp = 40;
                }

                enemyHp = enemyMaxHp;
                Console.WriteLine($"\nPrzed tobą stoi {enemyName}, zaczyna się walka!");
            }

            Console.WriteLine($"\nHP: {hp} | Mikstury: {potions}");
            Console.WriteLine("Co chcesz zrobic?");
            Console.WriteLine("1- Atakuj");
            Console.WriteLine("2- Użyj mikstury (+5 HP)");
            String actions = Console.ReadLine() ?? "";

            if (actions == "1")
            {
                int dmg = 0;

                if(weapon == "1")
                {
                    dmg = rng.Next(3, 9);
                    Console.WriteLine($"⚔️ Atakujesz mieczem i zadajesz {dmg} obrażeń! ");
                }

                else if (weapon == "2")
                {
                    dmg = rng.Next(4, 11);
                    Console.WriteLine($"🪓 Atakujesz toporem i zadajesz {dmg} obrażeń!");
                }

                else if (weapon == "3") 
                {
                    int hit1 = rng.Next(2, 6);
                    int hit2 = rng.Next(2, 6);
                    dmg = hit1 + hit2;
                    Console.WriteLine($"🗡️ Atakujesz sztyletem: {hit1} + {hit2} = {dmg} obrażeń!");
                }
                else
                {
                    Console.WriteLine("❌ Nie masz broni, pudłujesz!");
                    dmg = 0;
                }

                if (rng.Next (1, 101) <= 15)
                {
                    Console.WriteLine("💨 Goblin uniknął Twojego ataku!");
                    continue;
                }

                if (rng.Next (1, 101) <= 20)
                {
                    dmg *= 2;
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine($"⚡ KRYTYCZNY CIOS! {dmg} obrażeń!");
                     Console.ResetColor();
                }
                
                enemyHp -= dmg;

            }   
            else if (actions =="2" && potions > 0)
            {
                hp += 5;
                if (hp > maxHp) hp = maxHp;
                potions--;
                Console.WriteLine($"💚 Leczysz się! HP: {hp}, zostało mikstur: {potions}");
                Console.WriteLine("🛡️ Przegrywasz atak, goblin nie atakuje w tej turze!");
                continue;
            }        
            else
            {
                Console.WriteLine("❌ Nie możesz tego zrobić!");
                continue;
            }

            if (enemyHp <= 0)
            {
                gold += 10;
                Console.WriteLine($"🎉 Pokonałeś {enemyName}! Zdobyłes 10 złota (masz; {gold})");
                stage++;
                Console.WriteLine("Nacisnij ENTER, aby porzejść dalej...");
                Console.ReadLine();
                continue;
            }
            int enemyDmg = rng.Next(2, 7);
            hp -= enemyDmg;
            Console.WriteLine($"👹 Goblin zadaje Ci {enemyDmg} obrażeń. Masz teraz {hp} HP.");

            if(hp <= 0)
            {
                Console.WriteLine("💀 Zginąłeś. koniec gry.");
                return;
            }

            Console.WriteLine("Nacisnij ENTER, aby kontynuować ....");
            Console.ReadLine();
        } 
    }
}