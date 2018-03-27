using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    public class BRDProcesor : PaymentProcessor
    {
        public override IPaymentGateway MakePaymentGateway()
        {
            return new BRDBank();
        }
    }
}
