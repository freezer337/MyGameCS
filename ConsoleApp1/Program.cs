using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    public static string Character;
    public static int PlayerHealth;

    static void Main(string[] args)
    {
        CheckAnswer();
        MainGame.Game();
    }

    public static void CheckAnswer()
    {
        int playerHealth = 0;
        string character = string.Empty;

        // Доступные персонажи
        string Joker = "Joker";
        string Prison_guy = "Prison guy";
        string Forest_guy = "Forest guy";
        string Villager = "Some sort of villager";

        Console.WriteLine("Welcome to my game!");
        Console.WriteLine(new string('*', 19));

        Console.WriteLine("Choose your character: \n");
        Console.WriteLine("1. Some sort of villager \n");
        Console.WriteLine("2. Forest guy \n");
        Console.WriteLine("3. Prison guy \n");
        Console.WriteLine("4. Joker \n");

        string answerChar = Console.ReadLine();

        switch (answerChar)
        {
            case "1":
            case "Some sort of villager":
                character = Villager;
                playerHealth = 75;
                break;
            case "2":
            case "Forest guy":
                character = Forest_guy;
                playerHealth = 90;
                break;
            case "3":
            case "Prison guy":
                character = Prison_guy;
                playerHealth = 80;
                break;
            case "4":
            case "Joker":
                character = Joker;
                playerHealth = 85;
                break;
            default:
                Console.WriteLine("Invalid choice, defaulting to 'Villager'.");
                character = Villager;
                playerHealth = 75;
                break;
        }

        Program.Character = character;
        Program.PlayerHealth = playerHealth;
    }
}

#region Enemy
public class Enemy
{
    // Enemy parameters
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }

    public Enemy(string name, int health, int damage, int minDamage, int maxDamage)
    {
        Name = name;
        Health = health;
        Damage = damage;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    public void TakeDamage()
    {
        Random random = new Random();

        int Attack = random.Next(MinDamage, MaxDamage);
        string character = Program.Character;

        Health -= Attack;
        Program.PlayerHealth -= Damage;
        Console.WriteLine($"You dealt {Attack} damage to the {Name}! Remaining HP: {Math.Max(Health, 0)}");
        Console.WriteLine($"The {Name} is damaged you on {Damage}! Remaining HP: {Math.Max(Program.PlayerHealth, 0)}");
        if (Health <= 0)
        {
            Console.WriteLine($"Враг {Name} погиб!");
        }
        if (Program.PlayerHealth <= 0)
        {
            Console.WriteLine("Вы погибли!");
        }
    }
}
#endregion

class MainGame
{

    public static void Game()
    {
        Random random = new Random();
        string character = Program.Character;
        int playerHealth = Program.PlayerHealth;

        int currentPosition = 0;
        int damage = random.Next(1, 2);

        List<Enemy> mobs = new List<Enemy>
        {
            new Enemy("Zombie", 95, random.Next(20, 25), 30, 40),
            new Enemy("Koala", 85, random.Next(10, 20), 30, 38),
            new Enemy("Guy", 60, random.Next(8, 12), 13, 25),
            new Enemy("Cow", 70, random.Next(12, 14), 25, 35),
            new Enemy("Bear", 85, random.Next(25, 45), 30, 35)
        };

        string Joker = "Joker";
        string Prison_guy = "Prison guy";
        string Forest_guy = "Forest guy";
        string Vilager = "Some sort of villager";

        List<string> map = new List<string> { "Village", "Abound school", "Jail", "Toilet", "Box" };
        List<string> art = new List<string> { "Water", "Iron", "Fire", "Sun", "Moon" };
        List<string> situatuation = new List<string> { "You felt down the hill and you get :", $"You got beated up by {mobs[currentPosition].Name}, while you was running and you get : ", "You felt into cave and you get : ", "You felt from waterfall and you get : " };

        while (playerHealth > 0)
        {
            Console.WriteLine($"\nYour location: {map[currentPosition]}");
            Console.WriteLine($"You Found artefact: {art[currentPosition]}");


            int mobHealth = random.Next(50, 101);
            Console.WriteLine($"A wild {mobs[currentPosition].Name} appears with {mobHealth} HP!");
            Console.WriteLine($"You're HP is - {playerHealth}");
            while (mobHealth > 0 && playerHealth > 0)
            {
                Console.WriteLine("\nChoose an action: Attack or Defend or Run?");
                string action = Console.ReadLine();

                if (character == Vilager)
                {
                    if (action == "Attack")
                    {

                        int mobDamage = random.Next(1, 13);
                        playerHealth -= mobDamage;
                        Console.WriteLine($"You dealt {damage} damage to the {mobs[currentPosition]}! Remaining HP: {Math.Max(mobHealth, 0)}");
                        Console.WriteLine($"Your HP is {playerHealth}");
                    }

                    else if (action == "Defend")
                    {
                        int reducedDamage = random.Next(1, 31);
                        playerHealth -= reducedDamage;
                        Console.WriteLine($"You defended and reduced the damage, but still took {reducedDamage} damage. Your HP: {playerHealth}");
                    }

                    else if (action == "Run" && currentPosition < 4)
                    {
                        if (damage == 1)
                        {
                            int randomSituation = random.Next(0, 3);
                            int reducedDamage = random.Next(1, 10);
                            playerHealth -= reducedDamage;
                            Console.WriteLine(situatuation[randomSituation] + $"{reducedDamage} - damage");
                            damage = random.Next(1, 3);
                            currentPosition++;
                            Console.WriteLine($"\nYour location: {map[currentPosition]}");
                            Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                            Console.WriteLine($"You found {mobs[currentPosition]}! Mob's HP: {Math.Max(mobHealth, 0)}");
                            Console.WriteLine($"Your HP is {playerHealth}");
                        }

                        else if (damage == 2 || damage == 3 && currentPosition <= 4)
                        {
                            currentPosition--;
                            Console.WriteLine("You run back");
                            Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                            Console.WriteLine($"You found {mobs[currentPosition]}! Mob's HP: {Math.Max(mobHealth, 0)}");
                            Console.WriteLine($"Your HP is {playerHealth}");
                            damage = random.Next(1, 3);

                        }
                    }

                    else if (action == "Run" && currentPosition == 4)
                    {
                        currentPosition--;
                        Console.WriteLine($"\nYour location: {map[currentPosition]}");
                        Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                        Console.WriteLine($"You found {mobs[currentPosition].Name}! Mob's HP: {Math.Max(mobHealth, 0)}");
                        Console.WriteLine($"Your HP is {playerHealth}");
                    }
                }

                else if (character == Forest_guy)
                {
                    if (action == "Attack")
                    {
                        mobs[currentPosition].TakeDamage();
                    }

                    else if (action == "Defend")
                    {
                        int reducedDamage = random.Next(1, 31);
                        playerHealth -= reducedDamage;
                        Console.WriteLine($"You defended and reduced the damage, but still took {reducedDamage} damage. Your HP: {playerHealth}");
                    }

                    else if (action == "Run" && currentPosition < 4)
                    {
                        if (damage == 1)
                        {
                            int randomSituation = random.Next(0, 3);
                            int reducedDamage = random.Next(1, 10);
                            playerHealth -= reducedDamage;
                            Console.WriteLine(situatuation[randomSituation] + $"{reducedDamage} - damage");
                            damage = random.Next(1, 3);
                            currentPosition++;
                            Console.WriteLine($"\nYour location: {map[currentPosition]}");
                            Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                            Console.WriteLine($"You found {mobs[currentPosition].Name}! Mob's HP: {Math.Max(mobHealth, 0)}");
                            Console.WriteLine($"Your HP is {playerHealth}");
                        }

                        else if (damage == 2 || damage == 3 && currentPosition <= 4)
                        {
                            currentPosition--;
                            Console.WriteLine("You run back");
                            Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                            Console.WriteLine($"You found {mobs[currentPosition].Name}! Mob's HP: {Math.Max(mobHealth, 0)}");
                            Console.WriteLine($"Your HP is {playerHealth}");
                            damage = random.Next(1, 3);

                        }
                    }

                    else if (action == "Run" && currentPosition == 4)
                    {
                        currentPosition--;
                        Console.WriteLine($"\nYour location: {map[currentPosition]}");
                        Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                        Console.WriteLine($"You found {mobs[currentPosition].Name}! Mob's HP: {Math.Max(mobHealth, 0)}");
                        Console.WriteLine($"Your HP is {playerHealth}");
                    }
                }

                else if (character == Prison_guy)
                {
                    if (action == "Attack")
                    {
                        int playerDamage = random.Next(14, 25);
                        mobHealth -= playerDamage;
                        int mobDamage = random.Next(4, 20);
                        playerHealth -= mobDamage;
                        Console.WriteLine($"You dealt {playerDamage} damage to the {mobs[currentPosition]}! Remaining HP: {Math.Max(mobHealth, 0)}");
                        Console.WriteLine($"Your HP is {playerHealth}");
                    }

                    else if (action == "Defend")
                    {
                        int reducedDamage = random.Next(1, 31);
                        playerHealth -= reducedDamage;
                        Console.WriteLine($"You defended and reduced the damage, but still took {reducedDamage} damage. Your HP: {playerHealth}");
                    }

                    else if (action == "Run" && currentPosition < 4)
                    {
                        if (damage == 1)
                        {
                            int randomSituation = random.Next(0, 3);
                            int reducedDamage = random.Next(1, 10);
                            playerHealth -= reducedDamage;
                            Console.WriteLine(situatuation[randomSituation] + $"{reducedDamage} - damage");
                            damage = random.Next(1, 3);
                            currentPosition++;
                            Console.WriteLine($"\nYour location: {map[currentPosition]}");
                            Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                            Console.WriteLine($"You found {mobs[currentPosition]}! Mob's HP: {Math.Max(mobHealth, 0)}");
                            Console.WriteLine($"Your HP is {playerHealth}");
                        }

                        else if (damage == 2 || damage == 3 && currentPosition <= 4)
                        {
                            currentPosition--;
                            Console.WriteLine("You run back");
                            Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                            Console.WriteLine($"You found {mobs[currentPosition]}! Mob's HP: {Math.Max(mobHealth, 0)}");
                            Console.WriteLine($"Your HP is {playerHealth}");
                            damage = random.Next(1, 3);

                        }
                    }

                    else if (action == "Run" && currentPosition == 4)
                    {
                        currentPosition--;
                        Console.WriteLine($"\nYour location: {map[currentPosition]}");
                        Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                        Console.WriteLine($"You found {mobs[currentPosition]}! Mob's HP: {Math.Max(mobHealth, 0)}");
                        Console.WriteLine($"Your HP is {playerHealth}");
                    }
                }
                else if (character == Joker)
                {
                    if (action == "Attack")
                    {
                        int playerDamage = random.Next(7, 16);
                        mobHealth -= playerDamage;
                        int mobDamage = random.Next(1, 19);
                        playerHealth -= mobDamage;
                        Console.WriteLine($"You dealt {playerDamage} damage to the {mobs[currentPosition].Name}! Remaining HP: {Math.Max(mobHealth, 0)}");
                        Console.WriteLine($"Your HP is {playerHealth}");
                    }

                    else if (action == "Defend")
                    {
                        int reducedDamage = random.Next(1, 31);
                        playerHealth -= reducedDamage;
                        Console.WriteLine($"You defended and reduced the damage, but still took {reducedDamage} damage. Your HP: {playerHealth}");
                    }

                    else if (action == "Run" && currentPosition < 4)
                    {
                        if (damage == 1)
                        {
                            int randomSituation = random.Next(0, 3);
                            int reducedDamage = random.Next(1, 10);
                            playerHealth -= reducedDamage;
                            Console.WriteLine(situatuation[randomSituation] + $"{reducedDamage} - damage");
                            damage = random.Next(1, 3);
                            currentPosition++;
                            Console.WriteLine($"\nYour location: {map[currentPosition]}");
                            Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                            Console.WriteLine($"You found {mobs[currentPosition].Name}! Mob's HP: {Math.Max(mobHealth, 0)}");
                            Console.WriteLine($"Your HP is {playerHealth}");
                        }

                        else if (damage == 2 || damage == 3 && currentPosition <= 4)
                        {
                            currentPosition--;
                            Console.WriteLine("You run back");
                            Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                            Console.WriteLine($"You found {mobs[currentPosition].Name}! Mob's HP: {Math.Max(mobHealth, 0)}");
                            Console.WriteLine($"Your HP is {playerHealth}");
                            damage = random.Next(1, 3);

                        }
                    }

                    else if (action == "Run" && currentPosition == 4)
                    {
                        currentPosition--;
                        Console.WriteLine($"\nYour location: {map[currentPosition]}");
                        Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                        Console.WriteLine($"You found {mobs[currentPosition].Name}! Mob's HP: {Math.Max(mobHealth, 0)}");
                        Console.WriteLine($"Your HP is {playerHealth}");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid action. You missed your turn!");
                }

            }

            if (playerHealth <= 0)
            {
                Console.WriteLine("You have been defeated. Game over!");
                break;
            }

            if (mobHealth <= 0)
            {

                Console.WriteLine("You defeated the mob!");

                Console.WriteLine("Where do you want to go? (Straight, Back, or Exit)");
                string answer = Console.ReadLine();

                if (answer == "Straight")
                {
                    currentPosition++;
                }
                else if (answer == "Back")
                {
                    currentPosition--;
                }
                else if (answer == "Exit")
                {
                    Console.WriteLine("Thanks for playing!");
                    break;
                }

                if (currentPosition < 0)
                {
                    currentPosition = 0;
                    Console.WriteLine("You can't go back further!");
                }
                else if (currentPosition >= map.Count)
                {
                    currentPosition = map.Count - 1;
                    Console.WriteLine("You can't go further ahead!");
                }

            }
        }

        if (playerHealth > 0)
        {
            Console.WriteLine("Congratulations, you survived the Fight!");
        }
    }
}
