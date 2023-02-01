using ConsoleApp;

//Console.WriteLine("Hello, World!");

//SessionOne();

//DayThree.ProgramOne();
//DayThree.ProgramTwo();
//DayThree.ProgramThree();
//DayThree.ProgramFour();
//DayThree.ProgramFive();
//DayThree.ProgramSix();
//DayThree.ProgramSeven();
LINQprac.FirstNameQuery();

static void SessionOne()
{
    DayOne obj1 = new();

    Console.Write("Enter First Number: ");
    int firstNumber = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter Second Number: ");
    int secondNumber = Convert.ToInt32(Console.ReadLine());

    var result = obj1.Sum(firstNumber, secondNumber);

    Console.WriteLine($"{firstNumber} + {secondNumber} = {result}");

    Console.WriteLine();

    Console.WriteLine($"{obj1.MinutesToSeconds(10)}");

    var myValues = new int[] { 1, 2, 3, 4, 5 };
    Console.WriteLine($"Input Array = [{string.Join(", ", myValues)}]");

    var addedTwoToMyValues = obj1.AddTwoToAllElementsOfAnArray(myValues);
    Console.WriteLine($"Adding 2 to every element of the Array = [{string.Join(", ", addedTwoToMyValues)}]");

    #region Alternative of string.Join

    //Console.Write("[");
    //for (int i = 0; i < myValues.Length; i++)
    //{
    //    if(i == 0)
    //    {
    //        Console.Write(myValues[i]);
    //    }
    //    else
    //        Console.Write($", {myValues[i]}");
    //}
    //Console.Write("]"); 

    #endregion
}


Console.ReadKey();