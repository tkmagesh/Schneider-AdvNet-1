using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProductsManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var prod = new Product() {Id = 108, Name = "Pen", Cost = 221, Units = 12};
            Console.WriteLine(prod.Format("\t"));
            //MyUtilities.Format(prod);

            Console.WriteLine();
            Console.WriteLine((new Employee{Id = 200, FirstName = "Magesh", LastName = "K", Salary = 10000}).Format());
            Console.WriteLine();

            Console.ReadLine();
            var products = new MyCollection<Product>();
            products.Add(new Product() { Id = 108, Name = "Pen", Cost = 221, Units = 12 });
            products.Add(new Product() { Id = 102, Name = "Hen", Cost = 218, Units = 62 });
            products.Add(new Product() { Id = 106, Name = "Ken", Cost = 217, Units = 92 });
            products.Add(new Product() { Id = 101, Name = "Ten", Cost = 245, Units = 27 });
            products.Add(new Product() { Id = 109, Name = "Den", Cost = 223, Units = 23 });
            products.Add(new Product() { Id = 105, Name = "Len", Cost = 210, Units = 24 });

            MyCollectionUtils.Search(products, p => p.Units > 20);

            Console.WriteLine("Initial List");
            Console.WriteLine("Total Productsa = {0}", products.Count());
            Console.WriteLine("=========================================");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            /*var enumerator = (IEnumerator) products;
          while (enumerator.MoveNext())
          {
              var current = (Product) enumerator.Current;
              Console.WriteLine(current);
          }*/

            /*for(var i=0;i<products.Count;i++)
                Console.WriteLine(products[i]);
            */
            Console.WriteLine("=========================================");
            Console.WriteLine("Products sorted by default order");
            Console.WriteLine("=========================================");
            products.Sort();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("=========================================");
            Console.WriteLine("Products sorted by Cost");
            Console.WriteLine("=========================================");
            products.Sort(new ProductComparerByCost());
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("=========================================");

            Console.WriteLine("Products sorted by Units");
            Console.WriteLine("=========================================");
            products.Sort(new ProductComparerByUnits());
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("=========================================");
            Console.WriteLine("Products sorted by Cost [using Delegates]");
            Console.WriteLine("=========================================");
            //Using explicit methods
            //products.Sort(Program.CompareProductByCost);

            //Using Anonymous Methods
            /*products.Sort(delegate (Product left, Product right)
            {
                if (left.Cost > right.Cost) return 1;
                if (left.Cost < right.Cost) return -1;
                return 0;
            });*/
            
            //Lambda Expressions
            //Step - 1
            /*products.Sort((left, right) =>
            {
                if (left.Cost > right.Cost) return 1;
                if (left.Cost < right.Cost) return -1;
                return 0;
            });*/
            //Step-2
            /*products.Sort((left, right) =>
                {
                    return Math.Sign(left.Cost - right.Cost);
                });*/

            //Step-3
            products.Sort((left, right) => Math.Sign(left.Cost - right.Cost));

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("=========================================");

            Console.WriteLine("Products sorted by Id [using Delegates]");
            Console.WriteLine("=========================================");
            products.Sort((left, right) => Math.Sign(left.Id - right.Id));

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("=========================================");
            
            
            
            Console.WriteLine("Costly Products - cost > 220");
            Console.WriteLine("=========================================");
            var costlyProductsCriteria = new CostlyProductSearchCriteria(220);
            var costlyProducts = products.Search(costlyProductsCriteria);
            foreach (var product in costlyProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("=========================================");
            Console.WriteLine("Cheap Products - cost <= 220");
            Console.WriteLine("=========================================");
            var cheapProductsCriteria = new InverseCriteria<Product>(costlyProductsCriteria);
            var cheapProducts = products.Search(cheapProductsCriteria);
            foreach (var product in cheapProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("=========================================");
            Console.WriteLine("Fast moving poducts - [Search using delegates where Units < 50]");
            Console.WriteLine("================================================================");
            var fastMovingProducts = products.Search(p => p.Units < 50);
            foreach (var product in fastMovingProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("=========================================");
            Console.WriteLine("Mininum Units in Products");
            Console.WriteLine("=========================================");
            Console.WriteLine(products.Min(p => p.Units));
            Console.WriteLine("Mininum Cost in Products");
            Console.WriteLine("=========================================");
            Console.WriteLine(products.Min(p => p.Cost));
            Console.WriteLine("Number of products with Units > 50");
            Console.WriteLine("=========================================");
            Console.WriteLine(products.Count(p => p.Units > 50));
            Console.WriteLine("=========================================");
            Console.WriteLine("Products transformed to ProductViewModels");
            Console.WriteLine("=========================================");
            products.Transform(p => new ProductViewModel() {Id = p.Id, Name = p.Name})
                .ForEach(pvm => Console.WriteLine(pvm.Format()));
            Console.ReadLine();
        }

        public static int CompareProductByCost(Product left, Product right)
        {
            if (left.Cost > right.Cost) return 1;
            if (left.Cost < right.Cost) return -1;
            return 0;
        }
    }
}
