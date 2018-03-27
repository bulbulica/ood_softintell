using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    public class TransilvaniaProcesor : PaymentProcessor
    {
        public override IPaymentGateway MakePaymentGateway()
        {
            return new TransilvaniaBank();
        }
    }
}
