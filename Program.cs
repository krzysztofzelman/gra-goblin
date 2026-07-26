using System;
enum  WeaponType {Sword, Axe, Dagger }
class Program
{
    static WeaponType ChooseWeapon()
    {
        Console.WriteLine("Wybierz swoja broń");
        Console.WriteLine("1 - Miecz (3 - 8 dmg)");
        Console.WriteLine("2 - Topór (4 - 10dmg)");
        Console.WriteLine("3 - Sztylet (2-5 dmg, dwa ataki)");
        string input =  Console.ReadLine() ?? "";

        switch (input)
        {
            case "1": return WeaponType.Sword;
            case "2": return WeaponType.Axe;
            case "3": return WeaponType.Dagger;
            default: return WeaponType.Sword;

        }
    }
    static void DrawEnemy(Enemy enemy)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (enemy.Name == "Goblin")
        Console.WriteLine("        ⊂(◉‿◉)⊃");
        else if (enemy.Name == "Ork")
        Console.WriteLine("        ᗜˬᗜ");
        Console.ResetColor();
    }
static void Main ()
    {
        int hp = 30;
        int maxHp = 30;
        Enemy? enemy = null;
        int potions = 3;
        int gold = 0;
        int stage = 1;

        Random rng  = new Random();     

        Console.WriteLine("Witaj w lochu!");

        WeaponType weapon = ChooseWeapon();      

        while (hp > 0)
        {

            if (enemy == null || enemy.CurrentHp <= 0)
            {
                if (stage == 1)
                enemy = new Enemy("Goblin", 25,2,6);

                else if (stage == 2)
                enemy = new Enemy("Ork",40,3,8);
                DrawEnemy(enemy);
                Console.WriteLine($"\nPrzed tobą stoi {enemy.Name}, zaczyna się walka!");
            }

            Console.WriteLine($"\nHP: {hp} | Mikstury: {potions}");
            Console.WriteLine("Co chcesz zrobic?");
            Console.WriteLine("1- Atakuj");
            Console.WriteLine("2- Użyj mikstury (+5 HP)");
            String actions = Console.ReadLine() ?? "";

            if (actions == "1")
            {

                int dmg = 0;

                switch (weapon)
                {
                    case WeaponType.Sword: 
                    dmg = rng.Next(3, 9);
                    Console.WriteLine($"⚔️ Atakujesz mieczem i zadajesz {dmg} obrażeń! ");
                    break;

                    case WeaponType.Axe: 
                    dmg = rng.Next(4, 11);
                    Console.WriteLine($"🪓 Atakujesz toporem i zadajesz {dmg} obrażeń!");
                    break;

                    case WeaponType.Dagger:
                    int hit1 = rng.Next(2, 6);
                    int hit2 = rng.Next(2, 6);
                    dmg = hit1 + hit2;
                    Console.WriteLine($"🗡️ Atakujesz sztyletem: {hit1} + {hit2} = {dmg} obrażeń!");                    break;

                    default:
                    dmg = 0;
                    Console.WriteLine("❌ Nie masz broni, pudłujesz!");
                    break;
                }

                if (rng.Next (1, 101) <= 15)
                {
                    Console.WriteLine($"💨 {enemy.Name} uniknął Twojego ataku!");
                    continue;
                }

                if (rng.Next (1, 101) <= 20)
                {
                    dmg *= 2;
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine($"⚡ KRYTYCZNY CIOS! {dmg} obrażeń!");
                     Console.ResetColor();
                }
                
                enemy.CurrentHp -= dmg;

            }   
            else if (actions =="2" && potions > 0)
            {
                hp += 5;
                if (hp > maxHp) hp = maxHp;
                potions--;
                Console.WriteLine($"💚 Leczysz się! HP: {hp}, zostało mikstur: {potions}");
                Console.WriteLine($"🛡️ Przegrywasz atak, {enemy.Name} nie atakuje w tej turze!");
                continue;
            }        
            else
            {
                Console.WriteLine("❌ Nie możesz tego zrobić!");
                continue;
            }

            if (enemy.CurrentHp <= 0)
            {
                gold += 10;
                Console.WriteLine($"🎉 Pokonałeś {enemy.Name}! Zdobyłes 10 złota (masz: {gold})");
                stage++;
                if(stage > 2)
                {
                    Console.WriteLine($"🏆 Gratulacje! Ukończyłeś loch! Zdobyłeś {gold} złota!");
                    return;
                }
                Console.WriteLine("Nacisnij ENTER, aby porzejść dalej...");
                Console.ReadLine();
                continue;
            }
            int enemyDmg = rng.Next(enemy.MinDmg, enemy.Maxdmg + 1);
            hp -= enemyDmg;
            Console.WriteLine($"👹 {enemy.Name} zadaje Ci {enemyDmg} obrażeń. Masz teraz {hp} HP.");

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