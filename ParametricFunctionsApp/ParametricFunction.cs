using System;

namespace ParametricFunctionsApp
{
    public abstract class ParametricFunction
    {
        public abstract double Calculate(double x); // Абстрактний метод для обчислення
        public string Name { get; set; }           // Назва функції

        public ParametricFunction(string name)
        {
            Name = name;
        }
    }
}
