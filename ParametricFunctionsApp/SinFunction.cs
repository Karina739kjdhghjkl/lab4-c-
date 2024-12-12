using System;

namespace ParametricFunctionsApp
{
    public class SinFunction : ParametricFunction
    {
        public SinFunction() : base("Sin(x)") { }

        public override double Calculate(double x)
        {
            return Math.Sin(x);
        }
    }
}
