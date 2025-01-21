using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Game();
    }

    static void Game()
    {
        Random random = new Random();

        int currentPosition = 0;
        int playerHealth = 100;
        int damage = random.Next(1, 2);

        Console.WriteLine("Welcome to my game!");
        Console.WriteLine(new string('*', 19));

        Console.WriteLine("Choose your character: \n");
        Console.WriteLine("Some sort of villager \n");
        Console.WriteLine("Forest guy \n");
        Console.WriteLine("Prison guy \n");
        Console.WriteLine("Joker \n");
        string answerChar = Console.ReadLine();

        List<string> map = new List<string> { "Village", "Abound school", "Jail", "Toilet", "Box" };
        List<string> mobs = new List<string> { "Zombie", "Coala", "guy", "Cow", "Bear" };
        List<string> art = new List<string> { "Water", "Iron", "Fire", "Sun", "Moon" };
        List<string> situatuation = new List<string> { "You felt down the hill and you get :", $"You got beated up by {mobs[currentPosition]}, while you was running and you get : ", "You felt into cave and you get : ", "You felt from waterfall and you get : " };

        while (playerHealth > 0)
        {
            Console.WriteLine($"\nYour location: {map[currentPosition]}");
            Console.WriteLine($"You Found artefact: {art[currentPosition]}");


            int mobHealth = random.Next(50, 101);
            Console.WriteLine($"A wild {mobs[currentPosition]} appears with {mobHealth} HP!");

            while (mobHealth > 0 && playerHealth > 0)
            {
                Console.WriteLine("\nChoose an action: Attack or Defend or Run?");
                string action = Console.ReadLine();
                
                if (answerChar == "Some sort of villager")
                {
                    if (action == "Attack")
                    {
                        int playerDamage = random.Next(7, 41);
                        mobHealth -= playerDamage;
                        int mobDamage = random.Next(1, 13);
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
 
                if (answerChar == "Forest guy")
                {
                    if (action == "Attack")
                    {
                        int playerDamage = random.Next(24, 30);
                        mobHealth -= playerDamage;
                        int mobDamage = random.Next(1, 16);
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

                if (answerChar == "Prison guy")
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
                if (answerChar == "Joker")
                {
                    if (action == "Attack")
                    {
                        int playerDamage = random.Next(7, 16);
                        mobHealth -= playerDamage;
                        int mobDamage = random.Next(1, 19);
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

                    else if(action == "Run" && currentPosition == 4)
                    {
                        currentPosition--;
                        Console.WriteLine($"\nYour location: {map[currentPosition]}");
                        Console.WriteLine($"You Found artefact: {art[currentPosition]}");
                        Console.WriteLine($"You found {mobs[currentPosition]}! Mob's HP: {Math.Max(mobHealth, 0)}");
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

        if (playerHealth > 0)
        {
            Console.WriteLine("Congratulations, you survived the Fight!");
        }
    }
}
