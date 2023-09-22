using Program;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WillChangeRepeatingValuesOnXOrYByRespectiveCharacter()
        {
            string[,] actual =
            {
                { "1", "5", "3", "2", "1", "3", "1"},
                { "2", "2", "3", "5", "6", "1", "4"},
                { "3", "4", "1", "1", "1", "1", "1"},
                { "6", "5", "4", "3", "1", "4", "2"},
                { "5", "5", "1", "5", "7", "4", "1"},
                { "4", "5", "5", "6", "4", "4", "2"},
                { "2", "1", "3", "3", "3", "4", "5"},
            };
            Context.ChangeRepeatingValuesOnXOrYByRespectiveCharacter(actual);

            string[,] expected =
            {
                { "1", "5", "3", "2", "1", "3", "1"},
                { "2", "2", "3", "5", "6", "1", "4"},
                { "3", "4", "*", "*", "*", "*", "*"},
                { "6", ">", "4", "3", "1", "!", "2"},
                { "5", ">", "1", "5", "7", "!", "1"},
                { "4", ">", "5", "6", "4", "!", "2"},
                { "2", "1", ">", ">", ">", "!", "5"},
            };
            for (int i = 0; i < actual.GetLength(0); i++)
            {
                for (int j = 0; j < actual.GetLength(1); j++)
                {
                    Console.Write(actual[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Assert.IsTrue(CompareArrays(expected, actual), "Numbers not changed correctly");
        }

        [TestMethod]
        public void WillPerformLineSweepOperation()
        {
            string[,] actual =
            {
                { "1", "5", "3", "2", "1", "3", "1"},
                { "2", "2", "3", "5", "6", "1", "4"},
                { "3", "4", "*", "*", "*", "*", "*"},
                { "6", ">", "4", "3", "1", "!", "2"},
                { "5", ">", "1", "5", "7", "!", "1"},
                { "4", ">", "5", "6", "4", "!", "2"},
                { "2", "1", ">", ">", ">", "!", "5"},
            };
            Context.SweepMatrix(actual);

            string[,] expected =
            {
                { "1", "0", "0", "0", "0", "0", "0"},
                { "2", "0", "0", "0", "0", "0", "1"},
                { "3", "0", "3", "2", "1", "0", "4"},
                { "6", "5", "3", "5", "6", "0", "2"},
                { "5", "2", "4", "3", "1", "0", "1"},
                { "4", "4", "1", "5", "7", "3", "2"},
                { "2", "1", "5", "6", "4", "1", "5"},
            };
            for (int i = 0; i < actual.GetLength(0); i++)
            {
                for (int j = 0; j < actual.GetLength(1); j++)
                {
                    Console.Write(actual[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Assert.IsTrue(CompareArrays(expected, actual), "Numbers not changed correctly");
        }

        static bool CompareArrays(string[,] array1, string[,] array2)
        {
            if (array1.GetLength(0) != array2.GetLength(0) || array1.GetLength(1) != array2.GetLength(1))
            {
                return false; // Arrays have different dimensions, so they are not equal.
            }

            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    if (array1[i, j] != array2[i, j])
                    {
                        return false; // Elements at position (i, j) are not equal.
                    }
                }
            }

            return true; // All elements are equal.
        }
    }
}