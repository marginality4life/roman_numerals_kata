using roman_numerals_kata;
using Xunit;

namespace kata_test;

public class EvaluateTest
{
    [Fact]
    public void CallEval()
    {
        var eval = new Evaluate();
        eval.EvaluateCustomers();
    }
}