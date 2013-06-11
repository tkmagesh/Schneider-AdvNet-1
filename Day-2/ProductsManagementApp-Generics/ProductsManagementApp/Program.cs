using System;
using System.Collections;
using System.Text;

namespace ProductsManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var categories = new MyCollection<Category>
                {
                    new Category() {Id = 1, CategoryName = "Stationary"},
                    new Category() {Id = 2, CategoryName = "Electronics"}
                };
            var firstProduct = new Product() {Id = 108, Name = "Pen", Cost = 221, Units = 12, CategoryId = 2};
            var products = new MyCollection<Product>();
            products.Add(firstProduct);
            products.Add(new Product() { Id = 102, Name = "Hen", Cost = 218, Units = 62, CategoryId = 1});
            products.Add(new Product() { Id = 106, Name = "Ken", Cost = 217, Units = 92, CategoryId = 1 });
            products.Add(new Product() { Id = 101, Name = "Ten", Cost = 245, Units = 27, CategoryId = 2 });
            products.Add(new Product() { Id = 109, Name = "Den", Cost = 223, Units = 23, CategoryId = 1 });
            products.Add(new Product() { Id = 105, Name = "Len", Cost = 210, Units = 24, CategoryId = 2 });

            MyCollectionUtils.Search(products, p => p.Units > 20);

            Console.WriteLine("Initial List");
            Console.WriteLine("Total Productsa = {0}", products.Count());
            Console.WriteLine("=========================================");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            
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
            Console.WriteLine();
            Console.WriteLine("Is Products containing first product?");
            Console.WriteLine("=========================================");
            Console.WriteLine(products.Contains(firstProduct));
            Console.WriteLine();
            Console.WriteLine("Is Products containing product with 1001");
            Console.WriteLine("=========================================");
            Console.WriteLine(products.Contains(new Product(){Id = 1001},new IdEqualityComparer<Product>()));
            Console.WriteLine();
            Console.WriteLine("Products grouped by Category");
            Console.WriteLine("=========================================");
            var productsByCategory = products.GroupBy(p => p.CategoryId);
            foreach (var productByCategory in productsByCategory)
            {
                Console.WriteLine("Category = {0}", productByCategory.Key);
                foreach (var product in productByCategory.Value)
                {
                    Console.WriteLine("\t{0}", product.Format("\t"));
                }
            }
            Console.WriteLine();
            Console.WriteLine("Products with Category");
            Console.WriteLine("=========================================");
            var productsWithCategory = products.Join(categories, p => p.CategoryId, c => c.Id,
                                                     (p, c) =>
                                                     new ProductCategoryViewModel()
                                                         {
                                                             Id = p.Id,
                                                             ProductName = p.Name,
                                                             Cost = p.Cost,
                                                             Units = p.Units,
                                                             CategoryName = c.CategoryName
                                                         });
            productsWithCategory.ForEach(pc => Console.WriteLine(pc.Format("\t")));
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
