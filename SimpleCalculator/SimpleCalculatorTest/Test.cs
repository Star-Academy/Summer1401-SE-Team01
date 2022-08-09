using SimpleCalculator.Business;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;
using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.Enums;
using NSubstitute;

namespace SimpleCalculatorTest;

public class Test
{
    private OperatorProvider _operatorProvider;

    public Test() {
        _operatorProvider = new OperatorProvider();
    }

    [Fact]
    public void GetOperator_DivisionEnum_DivisionOperator() {
        var returnedOperator = _operatorProvider.GetOperator(OperatorEnum.division);

        Assert.IsType<DivisionOperator>(returnedOperator);
    }

    [Fact]
    public void GetOperator_MultiplyEnum_MultiplyOperator() {
        var returnedOperator = _operatorProvider.GetOperator(OperatorEnum.multiply);

        Assert.IsType<MultiplyOperator>(returnedOperator);
    }

    [Fact]
    public void GetOperator_SumEnum_SumOperator() {
        var returnedOperator = _operatorProvider.GetOperator(OperatorEnum.sum);

        Assert.IsType<SumOperator>(returnedOperator);
    }


    [Fact]
    public void GetOperator_SubEnum_SubOperator() {
        var returnedOperator = _operatorProvider.GetOperator(OperatorEnum.sub);

        Assert.IsType<SubOperator>(returnedOperator);
    }

    [Fact]
    public void GetOperator_NullEnum_ThrowsNotSupportedException() {
        Action act = () => _operatorProvider.GetOperator((OperatorEnum)(-1));

        Assert.Throws<NotSupportedException>(act);
    }

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(5, 6, 11)]
    [InlineData(13, 6, 19)]
    public void Calculate_Sum_SumOfTwoNumbers(int firstOperand, int secondOperand, int expected)
    {
        var sumOperator = new SumOperator();

        int answer = sumOperator.Calculate(firstOperand, secondOperand);

        Assert.Equal(expected, answer);
    }
    
    [Theory]
    [InlineData(2, 3, -1)]
    [InlineData(5, 6, -1)]
    [InlineData(13, 6, 7)]
    public void Calculate_Sub_SubOfTwoNumbers(int firstOperand, int secondOperand, int expected)
    {
        var subOperator = new SubOperator();
        
        int answer = subOperator.Calculate(firstOperand, secondOperand);

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData(0, 1000, 0)]
    [InlineData(-100, 1000, -100000)]
    [InlineData(2, 3, 6)]
    [InlineData(5, 6, 30)]
    [InlineData(13, 6, 13*6)]
    public void Calculate_Multiply_MultiplyOfTwoNumbers(int firstOperand, int secondOperand, int expected)
    {
        var multiplyOperator = new MultiplyOperator();
        
        int answer = multiplyOperator.Calculate(firstOperand, secondOperand);

        Assert.Equal(expected, answer);
    }

    [Theory]
    [InlineData(0, 1000, 0)]
    [InlineData(-100, 1000, 0)]
    [InlineData(2, 3, 0)]
    [InlineData(5, 6, 0)]
    [InlineData(13, 6, 2)]
    public void Calculate_Division_DivisionOfTwoNumbers(int firstOperand, int secondOperand, int expected)
    {
        var divisionOperator = new DivisionOperator();
        
        int answer = divisionOperator.Calculate(firstOperand, secondOperand);

        Assert.Equal(expected, answer);
    }

    [Fact]
    public void Calculate_DivisionByZero_Exception() {
        int firstOperand = 12;
        int secondOperand = 0;
        var divisionOperator = new DivisionOperator();

        Action act = () => divisionOperator.Calculate(firstOperand, secondOperand);

        Assert.Throws<DivideByZeroException>(act);
    }

    [Theory]
    [InlineData(2, 5, OperatorEnum.sum, 7)]
    [InlineData(2, 5, OperatorEnum.sub, -3)]
    [InlineData(2, 5, OperatorEnum.division, 0)]
    [InlineData(2, 5, OperatorEnum.multiply, 10)]
    public void Calculator_Calculate_ExpectedCalculatorResult(int firstOperand, int secondOperand, OperatorEnum operatorType, int expected) {
        IOperatorProvider provider = Substitute.For<IOperatorProvider>();
        provider.GetOperator(OperatorEnum.sum).Returns(new SumOperator());
        provider.GetOperator(OperatorEnum.sub).Returns(new SubOperator());
        provider.GetOperator(OperatorEnum.division).Returns(new DivisionOperator());
        provider.GetOperator(OperatorEnum.multiply).Returns(new MultiplyOperator());
        var calculator = new Calculator(provider);

        int answer = calculator.Calculate(firstOperand, secondOperand, operatorType);

        Assert.Equal(answer, expected);
    }
}