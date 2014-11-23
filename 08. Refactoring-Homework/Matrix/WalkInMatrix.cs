using System;

public class WalkInMatrix
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var matrix = CreateMatrix(n);

        PrintMatrix(matrix);
    }

    public static int[,] CreateMatrix(int n)
    {
        int[,] matrix = new int[n, n];
        int number = 1;
        int row = 0;
        int col = 0;

        WalkingInMatrix(matrix, row, col, ref number);
        FindNewEmptyCell(matrix, out row, out col);
        number++;
        if (row != 0 && col != 0)
        {
            WalkingInMatrix(matrix, row, col, ref number);
        }

        return matrix; 
    }

    private static void WalkingInMatrix(
        int[,] matrix,
        int row,
        int col,
        ref int number)
    {
        int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int directionX = 1;
        int directionY = 1;

        while (true)
        {
            matrix[row, col] = number;

            if (!IsEmptyCellAvailable(matrix, row, col))
            {
                break;
            }

            while (row + directionX >= matrix.GetLength(0) ||
                row + directionX < 0 || col + directionY >= matrix.GetLength(0) ||
                col + directionY < 0 ||
                matrix[row + directionX, col + directionY] != 0)
            {
                ChangeDirection(directionsX, directionsY, ref directionX, ref directionY);
            }

            row += directionX;
            col += directionY;
            number++;
        }
    }

    static void ChangeDirection(
        int[] directionsX,
        int[] directionsY,
        ref int directionX,
        ref int directionY)
    {
        for (int i = 0; i < directionsX.Length; i++)
        {
            if (directionsX[i] == directionX && directionsY[i] == directionY)
            {
                directionX = directionsX[(i + 1) % directionsX.Length];
                directionY = directionsY[(i + 1) % directionsY.Length];

                return;
            }
        }
    }

    static bool IsEmptyCellAvailable(int[,] matrix, int x, int y)
    {
        int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        for (int i = 0; i < directionsX.Length; i++)
        {
            bool isOutOfRightWall = x + directionsX[i] >= matrix.GetLength(0);
            bool isOutOfLeftWall = x + directionsX[i] < 0;

            if (isOutOfRightWall || isOutOfLeftWall)
            {
                directionsX[i] = 0;
            }

            bool isOutOfDownWall = y + directionsY[i] >= matrix.GetLength(0);
            bool isOutOfUpWall = y + directionsY[i] < 0;

            if (isOutOfDownWall || isOutOfUpWall)
            {
                directionsY[i] = 0;
            }

            if (matrix[x + directionsX[i], y + directionsY[i]] == 0)
            {
                return true;
            }
        }

        return false;
    }

    static void FindNewEmptyCell(int[,] matrix, out int x, out int y)
    {
        x = 0;
        y = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                if (matrix[row, col] == 0)
                {
                    x = row;
                    y = col;
                    return;
                }
            }
        }
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                Console.Write("{0,3}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}