using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    public class PaymentGatewayFactory
    {
        public virtual IPaymentGateway CreatePaymentGateway(PaymentMethod method, Product product)
        {
            IPaymentGateway gateway = null;

            switch (method)
            {
                case PaymentMethod.PAYPAL_BANK:
                    gateway = new PayPalBank();
                    break;
                case PaymentMethod.UNICREDIT_BANK:
                    gateway = new UnicreditBank();
                    break;
                case PaymentMethod.TRANSILVANIA_BANK:
                    gateway = new TransilvaniaBank();
                    break;
                case PaymentMethod.BRD_BANK:
                    gateway = new BRDBank();
                    break;
                case PaymentMethod.BEST_FOR_ME:
                    if (product.Price < 50)
                    {
                        gateway = new UnicreditBank();
                    }
                    else if (product.Price < 60)
                    {
                        gateway = new BRDBank();
                    }
                    else if (product.Price < 70)
                    {
                        gateway = new TransilvaniaBank();
                    }
                    else
                    {
                        gateway = new PayPalBank();
                    }
                    break;
            }

            return gateway;
        }
    }
}
