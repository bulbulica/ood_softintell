﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    public class BRDBank : IPaymentGateway
    {
        public void MakePayment(Product product)
        {
            // The bank specific API call to make the payment
            Console.WriteLine("Using BRDBank to pay for {0}, amount {1}", product.Name, product.Price);
            Console.ReadKey();
        }
    }
}
