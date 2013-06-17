using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using CalculatorWsdlClient.ServiceProxies;

namespace CalculatorWsdlClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var advancedCalculatorClient = new AdvancedCalculatorClient();
                var result = advancedCalculatorClient.Calculate(new CalculatorInput()
                    {
                        Number1 = 100,
                        Number2 = 10,
                        Operation = "Divide",
                    });
                Console.WriteLine(result);
            }
            catch (FaultException<DivideOperationFailure> e)
            {
                Console.WriteLine(e.Detail.Message);
            }
            catch (FaultException<DivideByEvenNumberFailure> e)
            {
                Console.WriteLine(e.Detail.Message);
            }
            Console.ReadLine();
            /*var advancedCalculatorProcessorClient = new AdvancedCalculatorProcessorClient();
            for (var i = 1; i <= 20;i++ )
                advancedCalculatorProcessorClient.Process(new CalculatorInput()
                    {
                        Number1 = 100 + i,
                        Number2 = 100 - i * 2,
                        Operation = "Add"
                    });
            Console.WriteLine("Done");
            Console.ReadLine();*/
        }
    }

    
}

namespace CalculatorWsdlClient.ServiceProxies
{
    public partial class CalculatorResult
    {
        public override string ToString()
        {
            return string.Format("Number 1={0},Number 2={1},Operation={2},Result={3}", this.Number1, this.Number2,
                                 this.Operation, this.Result);
        }
    }

}
