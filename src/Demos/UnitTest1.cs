using Demos.Tools;

namespace Demos;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var myPay = 12.23M;
        var paul = new Student("Paul", 3.23M);
       

        var paul2 = new Student("Paul", 3.23M);

        Assert.Equal("bozo", paul2.ToString());

        Assert.Equal(paul, paul2);
        var sue = new Student("Susan",4.25M)
        {
         
            NickName = "Susie"
        };
        
            
     

        Assert.Equal(3.23M, paul.Gpa);
    }

    [Fact]
    public void AccidentalCohesion()
    {
        int someNumber = 21;

        var s = 3.DaysFromToday();

        if (someNumber.IsEven())
        {
            // do something
        }
        else
        {
            // do something else.
        }
    }


}


// record means you get some cool free stuff from the compiler,
// but you need to make it mean something "real" - an immutable record of something in your system.
public record Student(string Name, decimal Gpa)
{
    

    //public required string Name { get; init; } = string.Empty;
    //public required decimal Gpa { get; init; }
    public  string NickName { get; init; } = string.Empty;

    
}