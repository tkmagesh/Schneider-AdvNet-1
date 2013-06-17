using System.ServiceModel;
using SchneiderServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchneiderServices.Implementations
{
    [ServiceBehavior]
    public class CalculatorService : ICalculator, IAdvancedCalculator, IAdvancedCalculatorProcessor
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

        [OperationBehavior]
        public CalculatorResult Calculate(CalculatorInput input)
        {
            int result = 0;
            switch (input.Operation)
            {
                case "Add":
                    result = Add(input.Number1, input.Number2);
                    break;
                case "Subtract" :
                    result = Subtract(input.Number1, input.Number2);
                    break;
                case "Multiply":
                    result = Multiply(input.Number1, input.Number2);
                    break;
                case "Divide":
                    if (input.Number2 == 0)
                        throw new FaultException<DivideOperationFailure>(new DivideOperationFailure()
                        {
                            Number1 = input.Number1,
                            Number2 = input.Number2,
                            Message = "Only a dumbo will try to divide by zero"
                        });
                    if (input.Number2 % 2 == 0)
                        throw new FaultException<DivideByEvenNumberFailure>(new DivideByEvenNumberFailure()
                            {
                                Message = "This is juz for fun"
                            });
                    result = Divide(input.Number1, input.Number2);
                    break;
            }
            return new CalculatorResult()
                {
                    Number1 = input.Number1,
                    Number2 = input.Number2,
                    Operation = input.Operation,
                    Result = result
                };
        }

        [OperationBehavior]
        void IAdvancedCalculatorProcessor.Calculate(CalculatorInput input)
        {
            int result = 0;
            
            switch (input.Operation)
            {
                case "Add":
                    result = Add(input.Number1, input.Number2);
                    break;
                case "Subtract":
                    result = Subtract(input.Number1, input.Number2);
                    break;
                case "Multiply":
                    result = Multiply(input.Number1, input.Number2);
                    break;
                case "Divide":
                    if (input.Number2 == 0)
                        throw new FaultException<DivideOperationFailure>(new DivideOperationFailure()
                            {
                                Number1 = input.Number1,
                                Number2 = input.Number2,
                                Message = "Only a dumbo will try to divide by zero"
                            });
                    result = Divide(input.Number1, input.Number2);
                    break;
            }
            Console.WriteLine(new CalculatorResult()
            {
                Number1 = input.Number1,
                Number2 = input.Number2,
                Operation = input.Operation,
                Result = result
            });
            
        }
    }
}
