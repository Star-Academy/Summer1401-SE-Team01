using System.Reflection;
using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;
using System;

namespace SimpleCalculatorTest;

public class Test
{
    [Theory]
    [InlineData(2, 3)]
    [InlineData(5, 6)]
    [InlineData(13, 6)]
    public void Calculate_Sum_SumOfTwoNumbers(int firstOperand, int secondOperand)
    {
        int expected = firstOperand + secondOperand;
        Calculator calculator = new Calculator();

        int answer = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.sum);

        Assert.True(expected == answer);
    }
    
    [Theory]
    [InlineData(2, 3)]
    [InlineData(5, 6)]
    [InlineData(13, 6)]
    public void Calculate_Sub_SumOfTwoNumbers(int firstOperand, int secondOperand)
    {
        int expected = firstOperand - secondOperand;
        Calculator calculator = new Calculator();

        int answer = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.sub);

        Assert.True(expected == answer);
    }

    [Theory]
    [InlineData(0, 1000)]
    [InlineData(-100, 1000)]
    [InlineData(2, 3)]
    [InlineData(5, 6)]
    [InlineData(13, 6)]
    public void Calculate_Multiply_MultiplyOfTwoNumbers(int firstOperand, int secondOperand)
    {
        int expected = firstOperand * secondOperand;
        Calculator calculator = new Calculator();

        int answer = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.multiply);

        Assert.True(expected == answer);
    }

    [Theory]
    [InlineData(0, 1000)]
    [InlineData(-100, 1000)]
    [InlineData(2, 3)]
    [InlineData(5, 6)]
    [InlineData(13, 6)]
    public void Calculate_Division_DivisionOfTwoNumbers(int firstOperand, int secondOperand)
    {
        int expected = firstOperand / secondOperand;
        Calculator calculator = new Calculator();

        int answer = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.division);

        Assert.True(expected == answer);
    }

    [Fact]
    public void Calculate_DivisionByZero_Exception() {
        int firstOperand = 12;
        int secondOperand = 0;
        Calculator calculator = new Calculator();

        try
        {
            int answer = calculator.Calculate(firstOperand, secondOperand, OperatorEnum.division);
            Assert.True(false);
        }
        catch
        {
            Assert.True(true);
        }
    }
}