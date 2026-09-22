

namespace StringCalculator;

public class CalculatorTests
{

    private Calculator calculator = new Calculator();


    [Fact]
    public void EmptyStringReturnsZero()
    {

        var result = calculator.Add("");
        calculator.Add("1,2");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData("", 252)]
    public void EmptyStringWithDefault(string numbers, int def) 
    {

        var result = calculator.Add(numbers, def);

        Assert.Equal(def, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("1008",  1008)]
    public void SingleDigit(string numbers, int expected)
    {
        var answer = calculator.Add(numbers);

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData("1,3", 4)]
    [InlineData("2,5", 7)]
    [InlineData("10,1", 11)]
    [InlineData("108,20", 128)]
    public void TwoDigits(string numbers, int expected)
    {
        var answer = calculator.Add(numbers);

        Assert.Equal(expected, answer);
    }
    [Theory]

    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    public void Arbitrary(string numbers, int expected)
    {
        var answer = calculator.Add(numbers);

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData("1,2\n3", 6)]
    
    public void MixedDelimeters(string numbers, int expected)
    {
        var answer = calculator.Add(numbers);

        Assert.Equal(expected, answer);
    }
}
