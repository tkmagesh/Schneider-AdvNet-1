using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SchneiderServices.Contracts;

namespace SchneiderServicesClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ChannelFactory<ICalculator>(new BasicHttpBinding(),
                                                          "http://localhost:9090/SchneiderServices/CalculatorService");
            var serviceChannel = factory.CreateChannel();
            Console.WriteLine("Adding 10 and 20 yields {0}", serviceChannel.Add(10,20));
            Console.WriteLine("Subtracting 20 from 10 yields {0}", serviceChannel.Subtract(10, 20));
            Console.WriteLine("Multiplying 10 and 20 yields {0}", serviceChannel.Multiply(10, 20));
            Console.WriteLine("Diving 20 by 10 yields {0}", serviceChannel.Divide(20, 10));
            Console.ReadLine();
        }
    }
}
