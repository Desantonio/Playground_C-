// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Matrix Addition Calculator");

        // Get input matrices
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrixA = MatrixAddition.GetMatrixInput("Matrix A", rows, cols);
        int[,] matrixB = MatrixAddition.GetMatrixInput("Matrix B", rows, cols);

        // Perform matrix addition
        int[,] resultMatrix = MatrixAddition.AddMatrices(matrixA, matrixB);

        // Display matrices and result
        Console.WriteLine("\nMatrix A:");
        MatrixAddition.PrintMatrix(matrixA);

        Console.WriteLine("\nMatrix B:");
        MatrixAddition.PrintMatrix(matrixB);

        Console.WriteLine("\nResultant Matrix:");
        MatrixAddition.PrintMatrix(resultMatrix);


        // Example usage
        double spotPrice = 100.0;
        double strikePrice = 100.0;
        double volatility = 0.2;
        double riskFreeRate = 0.05;
        int timeSteps = 100;
        double timeToMaturity = 1.0;
        bool isCallOption = true;

        double optionPrice = BinomialOptionsPricing.CalculateOptionPrice(
            spotPrice, strikePrice, volatility, riskFreeRate, timeSteps, timeToMaturity, isCallOption
        );

        Console.WriteLine("Option Price: " + optionPrice);

    }
}
