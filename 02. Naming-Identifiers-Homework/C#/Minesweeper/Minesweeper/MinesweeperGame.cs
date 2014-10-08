namespace Mines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MinesweeperGame
    {
        private static void Main()
        {
            string command = string.Empty;
            char[,] playField = CreatePlayField();
            char[,] mines = SetMines();
            int counter = 0;
            bool explode = false;
            List<Player> champions = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool showStartMessage = true;
            const int MaxOpenedCells = 35;
            bool openAllCells = false;

            do
            {
                if (showStartMessage)
                {
                    Console.WriteLine(
                        "Lets play \"Minesweeper\"! Try to find all cells without mines."
                        + " Command 'top' shows ranking, 'restart' starts new game, 'exit' exits from the game.");
                    DrawField(playField);
                    showStartMessage = false;
                }

                Console.Write("Enter row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= playField.GetLength(0) && column <= playField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Ranking(champions);
                        break;
                    case "restart":
                        playField = CreatePlayField();
                        mines = SetMines();
                        DrawField(playField);
                        explode = false;
                        showStartMessage = false;
                        break;
                    case "exit":
                        Console.WriteLine("bye, bye, bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                OpenNewCell(playField, mines, row, column);
                                counter++;
                            }

                            if (MaxOpenedCells == counter)
                            {
                                openAllCells = true;
                            }
                            else
                            {
                                DrawField(playField);
                            }
                        }
                        else
                        {
                            explode = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command!\n");
                        break;
                }

                if (explode)
                {
                    DrawField(mines);
                    Console.Write("\nBoom! You died with {0} score. " + "Set nickname: ", counter);
                    string nickname = Console.ReadLine();
                    Player current = new Player(nickname, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(current);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Score < current.Score)
                            {
                                champions.Insert(i, current);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Player first, Player second) => second.Name.CompareTo(first.Name));
                    champions.Sort((Player first, Player second) => second.Score.CompareTo(first.Score));
                    Ranking(champions);

                    playField = CreatePlayField();
                    mines = SetMines();
                    counter = 0;
                    explode = false;
                    showStartMessage = true;
                }

                if (openAllCells)
                {
                    Console.WriteLine("\nCongratulations! You found 35 cells");
                    DrawField(mines);
                    Console.WriteLine("Set nickname: ");
                    string nickname = Console.ReadLine();
                    Player score = new Player(nickname, counter);
                    champions.Add(score);
                    Ranking(champions);
                    playField = CreatePlayField();
                    mines = SetMines();
                    counter = 0;
                    openAllCells = false;
                    showStartMessage = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria");
            Console.Read();
        }

        private static void Ranking(List<Player> score)
        {
            Console.WriteLine("\nSCORE:");
            if (score.Count > 0)
            {
                for (int i = 0; i < score.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, score[i].Name, score[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty Ranking!\n");
            }
        }

        private static void OpenNewCell(char[,] field, char[,] mines, int row, int column)
        {
            char minesCount = CountMines(mines, row, column);
            mines[row, column] = minesCount;
            field[row, column] = minesCount;
        }

        private static void DrawField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayField()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] field = new char[fieldRows, fieldColumns];
            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldColumns; j++)
                {
                    field[i, j] = '?';
                }
            }

            return field;
        }

        private static char[,] SetMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] playField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> positions = new List<int>();
            while (positions.Count < 15)
            {
                Random random = new Random();
                int randomPosition = random.Next(50);
                if (!positions.Contains(randomPosition))
                {
                    positions.Add(randomPosition);
                }
            }

            foreach (int position in positions)
            {
                int col = position / cols;
                int row = position % cols;
                if (row == 0 && position != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                playField[col, row - 1] = '*';
            }

            return playField;
        }

        private static char CountMines(char[,] mines, int row, int col)
        {
            int count = 0;
            int rows = mines.GetLength(0);
            int cols = mines.GetLength(1);

            if (row - 1 >= 0)
            {
                if (mines[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (mines[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (mines[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (mines[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (mines[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (mines[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (mines[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (mines[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }

        public class Player
        {
            private string name;
            private int score;

            public Player()
            {
            }

            public Player(string name, int score)
            {
                this.Name = name;
                this.Score = score;
            }

            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Score
            {
                get
                {
                    return this.score;
                }

                set
                {
                    this.score = value;
                }
            }
        }
    }
}