using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using SchneiderServices.Contracts;
using SchneiderServices.Implementations;

namespace SchneiderServices.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof (CalculatorService), new Uri[] {});
            
            host.AddServiceEndpoint(typeof (ICalculator), new BasicHttpBinding(),
                                    "http://localhost:9090/SchneiderServices/CalculatorService");
            host.Open();
            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine("{0}\t{1}\t{2}",endpoint.Contract.Name, endpoint.Address.Uri, endpoint.Binding.Name );
            }
            Console.WriteLine("Hit ENTER to shutdown...");
            Console.ReadLine();
            host.Close();
        }
    }
}
