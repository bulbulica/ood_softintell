using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            product.Name = "Adidasi";
            product.Description = "catifea";
            product.Price = 62;

            PaymentApp app = new PaymentApp(product);
            app.Run();
        }
    }
}
