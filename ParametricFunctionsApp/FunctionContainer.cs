using System.Collections.Generic;

namespace ParametricFunctionsApp
{
    public class FunctionContainer
    {
        private List<ParametricFunction> functions = new List<ParametricFunction>();

        public void AddFunction(ParametricFunction function)
        {
            functions.Add(function);
        }

        public void RemoveFunction(ParametricFunction function)
        {
            functions.Remove(function);
        }

        public IEnumerable<ParametricFunction> GetAllFunctions()
        {
            return functions;
        }
    }
}
