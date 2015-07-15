namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    using global::Minesweeper.Models;

    public class Minesweeper
    {
        public const int MaxBoardRows = 5;

        public const int MaxBoardColumns = 10;

        public const int MaxBombsOnBoard = 15;

        public const int MaxTurn = 35;

        private static readonly Random MyRandom = new Random();

        private static void Main()
        {
            char[,] playingField = CreatePlayingField(MaxBoardRows, MaxBoardColumns);
            char[,] bombsOnFiled = PutsBombsOnField(MaxBoardRows, MaxBoardColumns, MaxBombsOnBoard);
            int countTurns = 0;
            bool isBombExplode = false;
            List<Rating> playersRatings = new List<Rating>(6);
            int rowNumber = 0;
            int columnNumber = 0;
            bool isMaxTurnReached = false;

            string command;
            bool isNewGame = true;
            do
            {
                if (isNewGame)
                {
                    Console.WriteLine(
                        "Lets play “Minesweeper”. Try you luck."
                        + " Command 'top' view current rating, 'restart' new game, 'exit' exit from game!");
                    WriteToConsole(playingField);
                    isNewGame = false;
                }

                Console.Write("Enter a row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out rowNumber) 
                        && int.TryParse(command[2].ToString(), out columnNumber)
                        && rowNumber <= playingField.GetLength(0) 
                        && columnNumber <= playingField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        GetRating(playersRatings);
                        break;
                    case "restart":
                        playingField = CreatePlayingField(MaxBoardRows, MaxBoardColumns);
                        bombsOnFiled = PutsBombsOnField(MaxBoardRows, MaxBoardColumns, MaxBombsOnBoard);
                        WriteToConsole(playingField);
                        isBombExplode = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;
                    case "turn":
                        if (bombsOnFiled[rowNumber, columnNumber] != '*')
                        {
                            if (bombsOnFiled[rowNumber, columnNumber] == '-')
                            {
                                NextTurn(playingField, bombsOnFiled, rowNumber, columnNumber);
                                countTurns++;
                            }

                            if (MaxTurn == countTurns)
                            {
                                isMaxTurnReached = true;
                            }
                            else
                            {
                                WriteToConsole(playingField);
                            }
                        }
                        else
                        {
                            isBombExplode = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command. Try again\n");
                        break;
                }

                if (isBombExplode)
                {
                    WriteToConsole(bombsOnFiled);
                    Console.Write("\nHrrrrrr! You died with {0} points. " + "Enter ypu nickname: ", countTurns);
                    string nickName = Console.ReadLine();
                    Rating playerRating = new Rating(nickName, countTurns);
                    if (playersRatings.Count < 5)
                    {
                        playersRatings.Add(playerRating);
                    }
                    else
                    {
                        for (int i = 0; i < playersRatings.Count; i++)
                        {
                            if (playersRatings[i].RecordPoints < playerRating.RecordPoints)
                            {
                                playersRatings.Insert(i, playerRating);
                                playersRatings.RemoveAt(playersRatings.Count - 1);
                                break;
                            }
                        }
                    }

                    playersRatings.Sort((Rating r1, Rating r2) => string.Compare(r2.Player, r1.Player, StringComparison.Ordinal));
                    playersRatings.Sort((Rating r1, Rating r2) => r2.RecordPoints.CompareTo(r1.RecordPoints));
                    GetRating(playersRatings);

                    playingField = CreatePlayingField(MaxBoardRows, MaxBoardColumns);
                    bombsOnFiled = PutsBombsOnField(MaxBoardRows, MaxBoardColumns, MaxBombsOnBoard);
                    countTurns = 0;
                    isBombExplode = false;
                    isNewGame = true;
                }

                if (isMaxTurnReached)
                {
                    Console.WriteLine("\nBravo! You open {0} fields.", MaxTurn);
                    WriteToConsole(bombsOnFiled);
                    Console.WriteLine("Enter ypu name, champion : ");
                    string nameChampion = Console.ReadLine();
                    Rating ratingChampion = new Rating(nameChampion, countTurns);
                    playersRatings.Add(ratingChampion);
                    GetRating(playersRatings);
                    playingField = CreatePlayingField(MaxBoardRows, MaxBoardColumns);
                    bombsOnFiled = PutsBombsOnField(MaxBoardRows, MaxBoardColumns, MaxBombsOnBoard);
                    countTurns = 0;
                    isMaxTurnReached = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.Read();
        }

        private static void GetRating(List<Rating> pointsRatings)
        {
            Console.WriteLine("\nPoints:");
            if (pointsRatings.Count > 0)
            {
                for (int i = 0; i < pointsRatings.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, pointsRatings[i].Player, pointsRatings[i].RecordPoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty records!\n");
            }
        }

        private static void NextTurn(char[,] playingField, char[,] bombsOnFiled, int row, int col)
        {
            char bombsOnFieldResult = HowManyBombsOnField(bombsOnFiled, row, col);
            bombsOnFiled[row, col] = bombsOnFieldResult;
            playingField[row, col] = bombsOnFieldResult;
        }

        private static void WriteToConsole(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardCols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < boardRows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < boardCols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayingField(int boardRows, int boardColumns)
        {
            char[,] board = new char[boardRows, boardColumns];
            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] PutsBombsOnField(int boardRows, int boardColumns, int bombsOnBoard)
        {
            char[,] boardField = new char[boardRows, boardColumns];

            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    boardField[row, col] = '-';
                }
            }

            List<int> positionOfBombs = new List<int>();
            while (positionOfBombs.Count < bombsOnBoard)
            { 
                int randomPosition = MyRandom.Next(50);
                if (!positionOfBombs.Contains(randomPosition))
                {
                    positionOfBombs.Add(randomPosition);
                }
            }

            foreach (int position in positionOfBombs)
            {
                int col = position / boardColumns;
                int row = position % boardColumns;
                if (row == 0 && position != 0)
                {
                    col--;
                    row = boardColumns;
                }
                else
                {
                    row++;
                }

                boardField[col, row - 1] = '*';
            }

            return boardField;
        }

        /*private static void smetki(char[,] pole)
        //{
        //    int kol = pole.GetLength(0);
        //    int red = pole.GetLength(1);

        //    for (int i = 0; i < kol; i++)
        //    {
        //        for (int j = 0; j < red; j++)
        //        {
        //            if (pole[i, j] != '*')
        //            {
        //                char kolkoo = HowManyBombsOnField(pole, i, j);
        //                pole[i, j] = kolkoo;
        //            }
        //        }
        //    }
        //}
        */

        private static char HowManyBombsOnField(char[,] field, int row, int col)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}