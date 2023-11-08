using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class MastermindGame
    {
        Random random = new Random();

        List<string> colors = new List<string> { "blue", "green", "red", "orange", "yellow", "purple" };

        public void PlayMastermind()
        {
            List<string> answer = new List<string>
            {
                colors[random.Next(0, 6)],
                colors[random.Next(0, 6)],
                colors[random.Next(0, 6)],
                colors[random.Next(0, 6)],
            };
            foreach (string item in answer)
            {
                Console.Write($"{item} ");
            };
            Console.WriteLine();

            Console.WriteLine("You will now pick four colors, attempting to guess the answer");

            int roundCount = 1;
            bool youWon = false;
            while (roundCount < 5 && !youWon)
            {
                int correct = 0;
                int close = 0;
                int wrong = 0;
                string[] answers = new string[] { answer[0], answer[1], answer[2], answer[3] };
                string[] guesses = new string[4];

                Console.WriteLine($"Round {roundCount}:");

                Console.WriteLine("Position 1 - pick one of the following colors: blue, green, red, orange, yellow, purple");
                guesses[0] = Console.ReadLine();
                Console.WriteLine("Position 2 - pick one of the following colors: blue, green, red, orange, yellow, purple");
                guesses[1] = Console.ReadLine();
                Console.WriteLine("Position 3 - pick one of the following colors: blue, green, red, orange, yellow, purple");
                guesses[2] = Console.ReadLine();
                Console.WriteLine("Position 4 - pick one of the following colors: blue, green, red, orange, yellow, purple");
                guesses[3] = Console.ReadLine();

                for (int i = 0; i < guesses.Length; i++)
                {
                    if (guesses[i] == answers[i])
                    {
                        guesses[i] = "guessed";
                        answers[i] = "guessed";
                        correct++;
                    }
                    else if (!answers.Contains(guesses[i]))
                    {
                        wrong++;
                    }
                    else
                    {
                        close++;
                    }
                }

                Console.WriteLine($"You got {correct} with the correct color in the correct spot, {close} of the right color in the wrong spot, and {wrong} of the wrong color.");
                Console.WriteLine();

                if (correct == 4)
                {
                    youWon = true;
                }
                roundCount++;
            }

            if (youWon)
            {
                Console.WriteLine($"Congratulations! You won in {roundCount} guesses!");
            }
            else
            {
                Console.WriteLine("Better luck next time chump!");
            }
        }
    }
}
