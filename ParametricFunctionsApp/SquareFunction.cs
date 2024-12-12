namespace ParametricFunctionsApp
{
    public class SquareFunction : ParametricFunction
    {
        public SquareFunction() : base("x^2") { }

        public override double Calculate(double x)
        {
            return x * x;
        }
    }
}
