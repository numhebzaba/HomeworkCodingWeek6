using System;

namespace Homework_coding_6_No1
{
    class Program
    {
        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }
        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }

        static void Main(string[] args)
        {
            double Score = 0;
            Difficulty difficulty = 0;

            mainMenu(Score,difficulty);
            
        }
        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }

            return randomProblems;
        }
        static void mainMenu(double score, Difficulty difficulty)
        {
            bool loopMainMenu = true;
            while (loopMainMenu)
            {
                Console.WriteLine("Score: {0}, Difficulty: {1}",score,difficulty.ToString());

                int action = int.Parse(Console.ReadLine());
                if(action == 0)
                {
                    gamePlay(difficulty,score);
                    break;
                }
                else if(action == 1)
                {
                    settingMenu(difficulty,score);
                    break;
                }
                else if(action == 2)
                {

                    break;
                }
                else
                {
                    Console.WriteLine("Please input 0 - 2.");
                }
            }
        }
        static void gamePlay(Difficulty difficulty, double score)
        {
            double Qc = 0;
            double Qa = 0;
            long startTime = 0;

            if (difficulty == Difficulty.Easy)
            {
                Problem[] problemArray = GenerateRandomProblems(3);
                startTime = DateTimeOffset.Now.ToUnixTimeSeconds();

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(problemArray[i].Message);
                    int inputAns = int.Parse(Console.ReadLine());
                    Qa++;
                    if (inputAns == problemArray[i].Answer)
                        Qc++;
                }
            }
            else if (difficulty == Difficulty.Normal)
            {
                Problem[] problemArray = GenerateRandomProblems(5);
                startTime = DateTimeOffset.Now.ToUnixTimeSeconds();

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(problemArray[i].Message);
                    int inputAns = int.Parse(Console.ReadLine());
                    Qa++;
                    if (inputAns == problemArray[i].Answer)
                        Qc++;
                }
            }
            else if (difficulty == Difficulty.Hard)
            {
                Problem[] problemArray = GenerateRandomProblems(7);
                startTime = DateTimeOffset.Now.ToUnixTimeSeconds();

                for (int i = 0; i < 7; i++)
                {
                    Console.WriteLine(problemArray[i].Message);
                    int inputAns = int.Parse(Console.ReadLine());
                    Qa++;
                    if (inputAns == problemArray[i].Answer)
                        Qc++;
                }
            }

            long endTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            long t = endTime - startTime;

            score = (Qc / Qa) 
                    * ((25.0 - Math.Pow((int)Difficulty.Easy, 2))/Math.Max(t, (25 - Math.Pow((int)Difficulty.Easy, 2))))
                    *Math.Pow((2* (int)Difficulty.Easy + 1),2);

            mainMenu(score,difficulty);
        }
        static void settingMenu(Difficulty difficulty, double score)
        {
            bool loopSetting = true;
            while (loopSetting)
            {
                int inputDifficulty = int.Parse(Console.ReadLine());

                if (inputDifficulty == 0 )
                {
                    difficulty = Difficulty.Easy;
                    mainMenu(score, difficulty);
                    break;
                }
                else if(inputDifficulty == 1)
                {
                    difficulty = Difficulty.Normal;
                    mainMenu(score, difficulty);
                    break;
                }
                else if (inputDifficulty == 2)
                {
                    difficulty = Difficulty.Hard;
                    mainMenu(score, difficulty);
                    break;
                }
                else
                {
                    Console.WriteLine("Please input 0 - 2.");
                }
            }
        }

    }
}
