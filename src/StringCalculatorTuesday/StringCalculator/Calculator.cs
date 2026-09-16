public class Calculator
{
    public int Add(string numbers)
    {
        if (numbers == "") return 0;
        string[] numbersArray;
        if (numbers.StartsWith("//")){
            var parts = numbers.Split(new[] { "\r\n", "\n" }, 2, StringSplitOptions.None);
            string header = parts[0];
            string rest = parts.Length > 1 ? parts[1] : "";
            string customDelim = header.Length > 2 ? header.Substring(2) : "";
            if (string.IsNullOrEmpty(customDelim))
            {
                numbersArray = rest.Split(',', '\n');
            }
            else
            {
                numbersArray = rest.Split(new[] { ",", "\n", customDelim }, StringSplitOptions.None);
            }

        }
        else
        {
            numbersArray = numbers.Split(',', '\n');
        }

        int sum = 0;

        foreach (string num in numbersArray)
        {
            if (!int.TryParse(num, out int x))
            {
                throw new ArgumentException($"Invalid number: {num}");
            }else if(x < 0)
            {
                throw new ArgumentException($"Negative number: {x}");
            }
            sum += x;
        }

        return sum;
    }
}
