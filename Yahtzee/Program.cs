using System;

namespace Yahtzee
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            int[] diceRolls = new int[5];
            diceRolls = RollTheDice(5);
            Random r = new Random();


            Console.WriteLine("Yahtzee!");
            Console.WriteLine("Here is your first roll:");

            for (int i = 0; i < diceRolls.Length; i++)
            {
                Console.Write(i + 1 + ": ");
                Console.WriteLine(diceRolls[i]);
            }
            Console.WriteLine("Which of the 5 dice would you like to keep? Please, separate by comma");
            string keptDiceUserInput = Console.ReadLine();
            string[] keptDiceString = keptDiceUserInput.Split(',');
            int[] keptDiceInt = new int[keptDiceString.Length];

            for (int i = 0; i < keptDiceString.Length; i++)
            {
                int keptDice1 = int.Parse(keptDiceString[i]) - 1;
                keptDiceInt[i] = diceRolls[keptDice1];
                
            }

            int remainingDiceOne = 5 - keptDiceInt.Length;
            int[] diceRollsTwo = RollTheDice(remainingDiceOne);

            diceRollsTwo.CopyTo(diceRolls, 0);
            keptDiceInt.CopyTo(diceRolls, diceRollsTwo.Length);

            Console.WriteLine("Here is your second roll: ");
            for (int i = 0; i < diceRolls.Length; i++)
            {

                Console.Write(i + 1 + ": "); ;
                Console.WriteLine(diceRolls[i]);
            }

            Console.WriteLine("Which of these dice do you want to keep? Please separate by comma");

            string keptDiceUserInputTwo = Console.ReadLine();
            string[] keptDiceStringTwo = keptDiceUserInputTwo.Split(',');
            int[] keptDiceIntTwo = new int[keptDiceStringTwo.Length];

            for (int i = 0; i < keptDiceStringTwo.Length; i++)
            {
                int keptDiceOne = int.Parse(keptDiceStringTwo[i]) - 1;
                keptDiceIntTwo[i] = diceRolls[keptDiceOne];
            }

            int remainingDiceTwo = 5 - keptDiceIntTwo.Length;
            int[] diceRollsThree = RollTheDice(remainingDiceTwo);

            diceRollsThree.CopyTo(diceRolls, 0);
            keptDiceIntTwo.CopyTo(diceRolls, diceRollsThree.Length);

                       
            Console.WriteLine("Here is your third and final roll: ");

            for (int i = 0; i < diceRolls.Length; i++)
            {
                Console.Write(i + 1 + ": ");
                Console.WriteLine(diceRolls[i]);
            }

            int playerScore = DuplicateCount(diceRolls);

            int [] computerRollOne = RollTheDice(5);
            int [] computerRollTwo = RollTheDice(5);
            int[] computerRollThree = RollTheDice(5);

            int[] rollET = new int[3];
            rollET[0] = DuplicateCount(computerRollOne);
            rollET[1] = DuplicateCount(computerRollTwo);
            rollET[2] = DuplicateCount(computerRollThree);

            int computerHighestScore = 0;
            for (int i = 0; i < 3; i++)
            {
              
                if (rollET[i] > computerHighestScore)
                {
                    computerHighestScore = rollET[i];
                }
            }

            if (playerScore >= computerHighestScore)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("Computer wins" +
                    "!");
            }

            Console.ReadLine();
                                        

        }

        public static int DuplicateCount(int[] rolledDice)
        {
            int[] score = new int[6];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (rolledDice[i] == j + 1)
                    {
                        score[j]++;
                    }
                }

             }

            int maxValue = 0;
            for (int i = 0; i < 6; i++)
            {
                if (score[i] > maxValue)
                {
                    maxValue = score[i];
                }
            }

            return maxValue;
        }

        public static int Dice()
        {
            int randomNum = new Random().Next(1, 6);
            int dice = randomNum;
            return dice;
        }

        public static int[] RollTheDice(int numberOfRolls)
        {

            int[] rollDice = new int[numberOfRolls];
            for (int i = 0; i < numberOfRolls; i++)
            {
                rollDice[i] = r.Next(1, 6);
            }
            return rollDice;
        }

    }
}
