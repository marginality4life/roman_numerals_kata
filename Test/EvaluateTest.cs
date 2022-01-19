using roman_numerals_kata;
using Xunit;

namespace kata_test;

public class EvaluateTest
{
    [Fact]
    public void CallEvalPhone()
    {
        var eval = new Evaluate();
        eval.EvaluatePrintOutputPhone();
    }
    
    [Fact]
    public void CallEvalEmail()
    {
        var eval = new Evaluate();
        eval.EvaluatePrintOutputEmail();
    }
    
    [Fact]
    public void CallEvalNames()
    {
        var eval = new Evaluate();
        eval.EvaluatePrintOutputNames();
    }
}