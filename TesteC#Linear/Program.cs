namespace Program
{
    public static class Context
    {
        static void Main()
        {
            //do Nothing
        }

        public static string[,] ChangeRepeatingValuesOnXOrYByRespectiveCharacter(string[,] numberArray)
        {
            ChangeValuesHorizontal(numberArray);
            ChangeValuesVertical(numberArray);

            return numberArray;
        }

        public static void SweepMatrix(string[,] matrix)
        {
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);
                        
            for (int i = numRows - 1; i >= 0; i--)
            {
                for (int j = 0; j < numCols; j++)
                {
                    string currentItem = matrix[i, j];
                    if (currentItem == "*" || currentItem == ">" || currentItem == "!")
                    {
                        matrix[i, j] = "0";
                    }
                    else
                    {
                        /*
                            For all numbers in j, 
                            If the number in i is not an ocurrence of an special character move it down 
                            if the item directly below is zero
                        */
                        int nextRow = i;
                        while (nextRow < numRows - 1 && matrix[nextRow + 1, j] == "0")
                        {
                            matrix[nextRow + 1, j] = currentItem;
                            matrix[nextRow, j] = "0";
                            nextRow++;
                        }
                    }
                }
            }
        }

        static void ChangeValuesHorizontal(string[,] numberArray)
        {
            for (int i = 0; i < numberArray.GetLength(0); i++)
            {
                //accounts for the first repeated number;
                int repetitions = 1;
                for (int j = 1; j < numberArray.GetLength(1); j++)
                {
                    string currentChar = numberArray[i, j];
                    string lastChar = numberArray[i, j - 1];
                    if (currentChar == lastChar)
                    {
                        repetitions++;
                    }
                    else
                    {
                        if (repetitions > 2)
                        {
                            handleRepetitions(numberArray, i, repetitions, j, "x");
                        }
                        repetitions = 1;
                    }
                    if(j+1 == numberArray.GetLength(1))
                    {
                        handleRepetitions(numberArray, i, repetitions, j, "x", true);
                    }
                }
            }
        }
        static void ChangeValuesVertical(string[,] numberArray)
        {
            for (int j = 1; j < numberArray.GetLength(1); j++)
            {
                int repetitions = 1;
                for (int i = 1; i < numberArray.GetLength(0); i++)
                {
                    string currentChar = numberArray[i, j];
                    string lastChar = numberArray[i-1, j];

                    if (numberArray[i,j] == numberArray[i-1, j])
                        repetitions++;
                    else
                    {
                        if (repetitions > 2)
                        {
                            handleRepetitions(numberArray, i, repetitions, j, "y");
                        }
                        repetitions = 1;
                    }
                    if (i + 1 == numberArray.GetLength(0))
                    {
                        if (repetitions > 2)
                        {
                            handleRepetitions(numberArray, i, repetitions, j, "y", true);
                        }
                    }
                }
            }
        }
        static void handleRepetitions(string[,] numberArray, int i, int repetitions, int j, string direction, bool isLastItem = false)
        {
            if (repetitions >= 5)
            {
                changeArrayToChar(numberArray, i, repetitions, j, "*", direction, isLastItem);
            }
            else if (repetitions == 4)
            {
                changeArrayToChar(numberArray, i, repetitions, j, "!", direction, isLastItem);
            }
            else if (repetitions == 3)
            {
                changeArrayToChar(numberArray, i, repetitions, j, ">", direction, isLastItem);
            }


            static void changeArrayToChar(string[,] numberArray, int i, int repetitions, int j, string character, string direction, bool isLastItem)
            {
                int increment = isLastItem ? 1 : 0;
                int decrement = isLastItem ? 0 : 1;
                int pos = (direction == "x" ? j : i) - repetitions + increment;

                //Loops through repetitions and changes the values in the array
                if (direction == "x")
                {
                    for (; pos <= j - decrement; pos++)
                    {
                        numberArray[i, pos] = character;
                    }
                }
                else
                {
                    for (; pos <= i - decrement; pos++)
                    {
                        numberArray[pos, j] = character;
                    }
                }
            }
        }
    }
}