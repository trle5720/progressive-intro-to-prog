public class Calculator
{
    public int Add(string numbers)
    {
        if (numbers == "") return 0;

        string[] numbersArray = numbers.Split(',');
        int sum = 0;

        foreach (string num in numbersArray)
        {
            if (!int.TryParse(num, out int x))
            {
                throw new ArgumentException($"Invalid number: {num}");
            }
            sum += x;
        }

        return sum;
    }
}
