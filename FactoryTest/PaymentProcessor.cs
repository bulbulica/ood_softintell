using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    public abstract class PaymentProcessor
    {
        private IPaymentGateway gateway;

        public PaymentProcessor()
        {
        }    

        public void MakePayment(Product product)
        {
            this.gateway = MakePaymentGateway();
            this.gateway.MakePayment(product);
        }

        public abstract IPaymentGateway MakePaymentGateway();
    }
}
