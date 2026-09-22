
namespace StringCalculator;

public class CalculatorInteractionTests
{
    // The calculator logs the result before returning.

    [Theory]
    [InlineData("1,2", "3")]
    [InlineData("4,5", "9")]
    public void ResultsAreWrittenToTheLogger(string numbers, string logged)
    {
        // given
        var mockedLogger = Substitute.For<ILogCalculationResults>();
        var mockedNotifier = Substitute.For<INotifyTechSupportOfLoggingFailures>();
        var calculator = new Calculator(mockedLogger, mockedNotifier);
        // when
        calculator.Add(numbers);
        // then

        // Assert on?
        // Did "3" get written to the logger?
        mockedLogger.Received().Write(logged);
        mockedNotifier.DidNotReceive().Notify(Arg.Any<string>());
    }

    [Theory]
    [InlineData("3", "Failed to log 3")]
    [InlineData("99", "Failed to log 99")]

    public void WhenLoggerFailsWebServiceIsCalled(string nums, string loggerMessage)
    {
        var stubbedLogger = Substitute.For<ILogCalculationResults>();
        var mockedNotifier = Substitute.For<INotifyTechSupportOfLoggingFailures>();
        var calculator = new Calculator(stubbedLogger, mockedNotifier);
        stubbedLogger.When(l => l.Write(Arg.Any<string>())).Throw<LoggingException>();
        // when
        calculator.Add(nums);

        // then 

        mockedNotifier.Received(1).Notify(loggerMessage);
    }
}
