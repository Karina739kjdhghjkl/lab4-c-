using System;

namespace ParametricFunctionsApp
{
    public class ExponentialFunction : ParametricFunction
    {
        public ExponentialFunction() : base("e^x") { }

        public override double Calculate(double x)
        {
            return Math.Exp(x);
        }
    }
}
