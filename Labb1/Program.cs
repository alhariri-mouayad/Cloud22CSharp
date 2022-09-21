Lab1();

void Lab1()
{
    string welcomeText = "mata in en textsträng:";
    string resultText1 = "\nSträngar med samma start och slutsiffra:";
    string resultText2 = "\nSumman av de färgmarkerade strängarna: ";
    ConsoleColor highlightColor = ConsoleColor.Blue;

    string userInput = PromptUserAndGetString(welcomeText);
    string[] stringsWithSameStartAndEndNumber = FindStringsWithSameStartAndEndNumber(userInput);
    string[] stringsWithSameStartAndEndNumberAndNoLetters = FindStringsWithNoLetters(stringsWithSameStartAndEndNumber);

    Console.WriteLine(resultText1);
    PrintAllStringsInStringWithColor
        (
            userInput,
            stringsWithSameStartAndEndNumberAndNoLetters,
            highlightColor
        );

    PrintSum(FindStringsWithNoLetters(stringsWithSameStartAndEndNumber), resultText2);
}

void PrintSum(string[] userInput, string outputTextBeforeTheSum)
{
    try
    {
        decimal[] numbers = Array.ConvertAll(FindStringsWithNoLetters(userInput), decimal.Parse);
        decimal sum = 0;
        foreach (decimal number in numbers)
        {
            sum += number;
        }
        Console.WriteLine(outputTextBeforeTheSum + sum);
    }
    catch (OverflowException)
    {
        Console.WriteLine(outputTextBeforeTheSum + "Kunde inte beräkna summan");
    }
}

void PrintAllStringsInStringWithColor(string userInput, string[] partStrings, ConsoleColor partStringcolor)
{
    int LastStartIndexFontColored = 0;
    int startIndexFontColored;
    int endIndexFontColored;
    for (int i = 0; i < partStrings.Length; i++)
    {
        startIndexFontColored = userInput.IndexOf(partStrings[i], LastStartIndexFontColored);
        LastStartIndexFontColored = startIndexFontColored + 1;
        endIndexFontColored = startIndexFontColored + partStrings[i].Length - 1;
        for (int j = 0; j < userInput.Length; j++)
        {
            if (j >= startIndexFontColored && j <= endIndexFontColored)
                Console.ForegroundColor = partStringcolor;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{userInput[j]}");
        }
        Console.WriteLine("\r");
    }
    Console.ForegroundColor = ConsoleColor.Green;
}

string[] FindStringsWithNoLetters(string[] userInputs)
{
    List<string> output = new();
    bool number = true;
    foreach (string userInput in userInputs)
    {
        for (int i = 0; i < userInput.Length; i++)
        {
            if (!char.IsDigit(userInput[i]))
            {
                number = false;
                break;
            }
        }
        if (number)
            output.Add(userInput);
        else
            number = true;
    }
    return output.ToArray();
}

string[] FindStringsWithSameStartAndEndNumber(string userInput)
{
    List<string> output = new();
    for (int i = 0; i < userInput.Length; i++)
    {
        if (!int.TryParse(userInput[i].ToString(), out int number))
            continue;
        int endIndex = userInput.IndexOf(number.ToString(), i + 1);
        if (endIndex == -1)
            continue;
        output.Add(userInput.Substring(i, endIndex - i + 1));
    }
    return output.ToArray();
}

string PromptUserAndGetString(string textPresentedToUser)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{textPresentedToUser}");
    string output = Console.ReadLine()!;
    while (string.IsNullOrWhiteSpace(output))
    {
        Console.WriteLine($"fel inmatning. {textPresentedToUser}");
        output = Console.ReadLine()!;
    }
    return output;
}
