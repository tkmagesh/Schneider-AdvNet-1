using System.ServiceModel;
using SchneiderServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchneiderServices.Implementations
{
    [ServiceBehavior]
    public class CalculatorService : ICalculator
    {
        [OperationBehavior]
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        [OperationBehavior]
        public int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        [OperationBehavior]
        public int Multiply(int number1, int number2)
        {
            return number1*number2;
        }

        [OperationBehavior]
        public int Divide(int number1, int number2)
        {
            return number1/number2;
        }
    }
}
