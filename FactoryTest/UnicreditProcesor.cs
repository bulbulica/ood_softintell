using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    public class UnicreditProcesor : PaymentProcessor
    {
        public override IPaymentGateway MakePaymentGateway()
        {
            return new UnicreditBank();
        }
    }
}
