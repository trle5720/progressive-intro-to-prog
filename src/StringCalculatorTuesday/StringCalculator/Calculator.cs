
public class Calculator
{
    public int Add(string numbers)
    {

        if ((numbers != "") && (int.TryParse(numbers, out int x)))
        {
            return x;
        }
        else
        {
            return 0;
        }
    }
}
