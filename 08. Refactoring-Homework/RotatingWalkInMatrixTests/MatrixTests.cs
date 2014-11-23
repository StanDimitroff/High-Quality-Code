using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MatrixTests
{
    [TestMethod]
    public void TestMatrixSize1()
    {
        int n = 1;
        int[,] expectedMatrix =
            {
                { 1 }
            };
        int[,] createdMatrix = WalkInMatrix.CreateMatrix(n);
        CollectionAssert.AreEqual(expectedMatrix, createdMatrix, "This matrix is not expected.");
    }

    [TestMethod]
    public void TestMatrixSize2()
    {
        int n = 2;
        int[,] expectedMatrix =
            {
                { 1, 4 },
                { 3, 2 }
            };
        int[,] createdMatrix = WalkInMatrix.CreateMatrix(n);
        CollectionAssert.AreEqual(expectedMatrix, createdMatrix, "This matrix is not expected.");
    }

    [TestMethod]
    public void TestMatrixSize3()
    {
        int n = 3;
        int[,] expectedMatrix =
            {
                { 1, 7, 8 },
                { 6, 2, 9 },
                { 5, 4, 3 }
            };
        int[,] createdMatrix = WalkInMatrix.CreateMatrix(n);
        CollectionAssert.AreEqual(expectedMatrix, createdMatrix, "This matrix is not expected.");
    }

    [TestMethod]
    public void TestMatrixSize6()
    {
        int n = 6;
        int[,] expectedMatrix =
            {
                { 1, 16, 17, 18, 19, 20 }, { 15, 2, 27, 28, 29, 21 }, { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32, 4, 25, 23 }, { 12, 35, 34, 33, 5, 24 }, { 11, 10, 9, 8, 7, 6 }
            };

        int[,] createdMatrix = WalkInMatrix.CreateMatrix(n);
        CollectionAssert.AreEqual(expectedMatrix, createdMatrix, "This matrix is not expected.");
    }
}