using System;
using System.Collections.Generic;

namespace Problem._07.DistanceInLabyrinth
{
	internal static class DistanceInLabyrinth
	{
		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());

			int startRow = 0;
			int startColumn = 0;
			const int startValue = -2;
			const int blockValue = -1;

			int[,] matrix = new int[size, size];

			for (int i = 0; i < size; i++)
			{
				char[] row = Console.ReadLine().ToCharArray();

				for (int col = 0; col < size; col++)
				{
					if (row[col] == '*')
					{
						startRow = i;
						startColumn = col;
						matrix[i, col] = startValue; //start for matrix !!!
					}
					else
					{
						if (row[col] == 'x')
						{
							matrix[i, col] = blockValue; //ne se obhojda
						}
					}
				}
			}


			Queue<Cell> queue = new Queue<Cell>();

			queue.Enqueue(new Cell(startRow, startColumn));

			matrix[startRow, startColumn] = 0;
			while (queue.Count > 0)
			{
				Cell current = queue.Dequeue();
				//Right
				if (current.Row + 1 < size && matrix[current.Row + 1, current.Column] == 0)
				{
					queue.Enqueue(new Cell(current.Row + 1, current.Column));
					matrix[current.Row + 1, current.Column] += matrix[current.Row, current.Column] + 1;
				}
				//Left
				if (current.Row - 1 >= 0 && matrix[current.Row - 1, current.Column] == 0)
				{
					queue.Enqueue(new Cell(current.Row - 1, current.Column));
					matrix[current.Row - 1, current.Column] += matrix[current.Row, current.Column] + 1;
				}
				//Down
				if (current.Column + 1 < size && matrix[current.Row, current.Column + 1] == 0)
				{
					queue.Enqueue(new Cell(current.Row, current.Column + 1));
					matrix[current.Row, current.Column + 1] += matrix[current.Row, current.Column] + 1;
				}
				//Up
				if (current.Column - 1 >= 0 && matrix[current.Row, current.Column - 1] == 0)
				{
					queue.Enqueue(new Cell(current.Row, current.Column - 1));
					matrix[current.Row, current.Column - 1] += matrix[current.Row, current.Column] + 1;
				}

				//PrintMatrix(size, matrix);
			}

			matrix[startRow, startColumn] = startValue;

			//Print matrix
			PrintMatrix(size, matrix);
		}

		private static void PrintMatrix(int size, int[,] matrix)
		{
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					int value = matrix[i, j];
					switch (value)
					{
						case -1:
							Console.Write('x');
							break;
						case -2:
							Console.Write('*');
							break;
						case 0:
							Console.Write('u');
							break;
						default:
							Console.Write(value);
							break;
					}
				}

				Console.WriteLine();
			}
		}
	}

	class Cell
	{
		public int Row { get; set; }
		public int Column { get; set; }
		public bool Visited { get; set; }

		public Cell(int y, int x, bool visited = false)
		{
			this.Column = x;
			this.Row = y;
			this.Visited = visited;
		}
	}
}
