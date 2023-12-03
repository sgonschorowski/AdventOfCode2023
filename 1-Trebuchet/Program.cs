var file = "Assets/1-Trebuchet-Input.txt";
List<string> linesFromFile = File.ReadAllLines(file).ToList();
var sum = 0;
Dictionary<string, int> numbers = new Dictionary<string, int>()
{
    { "twone", 21 },
    { "threeigth", 38 },
    { "fiveigth", 58 },
    { "eightwo", 82 },
    { "nineigth", 98 },
    { "sevenine", 79 },
    { "oneight", 18 },
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
    { "four", 4 },
    { "five", 5 },
    { "six", 6 },
    { "seven", 7 },
    { "eight", 8 },
    { "nine", 9 }
};
var preparedLines = new List<string>();
var concatedNumbers = new List<string>();

foreach (var lineFromFile in linesFromFile)
{
    var findings = lineFromFile;
    foreach (var item in numbers)
    {
        if (findings.Contains(item.Key))
        {

            findings = findings.Replace(item.Key, item.Value.ToString());
        }
    }
    Console.WriteLine("Prepared line: {0}", findings);
    preparedLines.Add(findings);

}


foreach (var line in preparedLines)
{
    char[] chars = [.. line];
    var firstDigit = 0;
    var lastDigit = -1;
    var isFirstDigit = true;

    for (int i = 0; i < chars.Length; i++)
    {
        var character = chars[i].ToString();

        bool parsed = int.TryParse(character, out var number);

        if (!parsed)
            continue;

        if (isFirstDigit)
        {
            firstDigit = number;
            isFirstDigit = false;
        }
        else if (!isFirstDigit)
        {
            lastDigit = number;
        }
    }

    if (lastDigit is -1)
    {
        lastDigit = firstDigit;
    }

    var concatedNumber = String.Concat(firstDigit, lastDigit);
    concatedNumbers.Add(concatedNumber);

    var b = int.TryParse(concatedNumber, out var numberToAdd);
    if (!b)
    {
        continue;
    }
    sum += numberToAdd;
}

Console.WriteLine("Final result: {0}", sum);