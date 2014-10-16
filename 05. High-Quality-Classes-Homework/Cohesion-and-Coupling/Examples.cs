namespace CohesionAndCoupling
{
    using System;

    public class Examples
    {
        public static void Main()
        {
            Console.WriteLine(FileExtensions.GetFileExtension("example"));
            Console.WriteLine(FileExtensions.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtensions.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
               Calculator.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                Calculator.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Console.WriteLine("Volume = {0:f2}", Calculator.CalcVolume(2, 3, 4));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Calculator.CalcDistance3D(3, 6, 2, 1, 9, 2));
            Console.WriteLine("Diagonal XY = {0:f2}", Calculator.CalcDistance2D(1, 2, 3, 4));
            Console.WriteLine("Diagonal XZ = {0:f2}", Calculator.CalcDistance2D(9, 9, 7, 8));
            Console.WriteLine("Diagonal YZ = {0:f2}", Calculator.CalcDistance2D(2, 1, 1, 2));
        }
    }
}