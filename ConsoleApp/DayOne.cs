namespace ConsoleApp;

public class DayOne
{
    /// <summary>
    /// Create a function that takes two numbers as arguments and returns their sum.
    /// </summary>
    /// <param name="firstNumber"></param>
    /// <param name="secondNumber"></param>
    /// <returns>Sum of two numbers</returns>
    public int Sum(int firstNumber, int secondNumber)
    {
        return firstNumber + secondNumber;
    }

    /// <summary>
    /// Write a function that takes an integer minutes and converts it to seconds.
    /// </summary>
    /// <param name="minutes"></param>
    /// <returns></returns>
    public int MinutesToSeconds(int minutes)
    {
        return minutes * 60;
    }

    public int[] AddTwoToAllElementsOfAnArray(int[] input)
    {
        int[] ints= new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            ints[i] = input[i] + 2;
        }

        return ints;
    }
}
