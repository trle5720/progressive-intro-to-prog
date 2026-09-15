

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 3)]
    [InlineData("4", 4)]
    public void SingleDigit(string numbers, int expected)
    {
        var calculator = new Calculator();
        var answer = calculator.Add(numbers);

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,3", 5)]
    [InlineData("3,4", 7)]
    public void TwoIntegers(string numbers, int expected)
    {
        var calculator = new Calculator();
        var answer = calculator.Add(numbers);
        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("2,3,4,5", 14)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    
    public void MultipleIntegers(string numbers, int expected)
    {
        var calculator = new Calculator();
        var answer = calculator.Add(numbers);
        Assert.Equal(expected, answer);
    }


    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("1\n2,3", 6)]
    [InlineData("1,2\n3,4", 10)]
    public void MixedDelimiters(string numbers, int expected)
    {
        var calculator = new Calculator();
        var answer = calculator.Add(numbers);
        Assert.Equal(expected, answer);
    }

}
