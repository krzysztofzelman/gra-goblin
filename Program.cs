using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices.Marshalling;
class Program
{
static void Main ()
    {
        int hp = 20;
        int enemyHp = 25;
        int potions = 3;
        Random rng  = new Random();

        Console.WriteLine("Witaj w lochu!");
        Console.WriteLine("Wybierz swoją broń");
        Console.WriteLine("1 - Miecz (3-8 dmg)");
        Console.WriteLine("2 - Topór (4-10 dmg)");
        Console.WriteLine("3 - Sztylet (2-5 dmg, dwa ataki)");

        String weapon = Console.ReadLine();

        Console.WriteLine("Przed tobą stoi goblin, zaczyna się walka!");

        while (hp > 0 && enemyHp > 0)
        {
            Console.WriteLine($"\nHP: {hp} | Mikstury: {potions}");
            Console.WriteLine("Co chcesz zrobic?");
            Console.WriteLine("1- Atakuj");
            Console.WriteLine("2- Użyj mikstury (+5 HP)");
            String actions = Console.ReadLine();

            if (actions == "1")
            {
                int dmg = 0;

                if(weapon == "1")
                {
                    dmg = rng.Next(3, 9);
                    Console.WriteLine($"Atakujesz mieczem i zadajesz {dmg} obrażeń! ");
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
                    Console.WriteLine($"Atakujesz sztyletem: {hit1} + {hit2} = {dmg} obrażeń!");
                }
                else
                {
                    Console.WriteLine("Nie masz broni, pudłujesz!");
                    dmg = 0;
                }
                
                enemyHp -= dmg;
                Console.WriteLine("Nie masz broni pudłujesz!");

            }   
            else if (actions =="2" && potions > 0)
            {
                hp += 5;
                if(hp > 20) hp=20;
                potions--;
                Console.WriteLine($"Ledczysz się! HP: {hp}, zostało mikstur: {potions}");
                Console.WriteLine("Przegrywasz atak, goblin nie atakuje w tej turze!");
                continue;
            }        
            else
            {
                Console.WriteLine("❌ Nie możesz tego z robić!");
                continue;
            }

            if (enemyHp <= 0)
            {
                Console.WriteLine("🎉 Pokonałeś goblina! Wygrałeś");
                return;
            }
            int enemyDmg = rng.Next(2, 7);
            hp -= enemyDmg;
            Console.WriteLine($"👹 Goblin zadaje Ci {enemyDmg} obrażeń. Masz teraz {hp} HP.");

            if(hp <= 0)
            {
                Console.WriteLine("Zginąłeś. koniec gry.");
                return;
            }

            Console.WriteLine("Nacisnij ENTER, aby kontynuować ....");
            Console.ReadLine();
        } 
    }
}