﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    public interface IPaymentGateway
    {
        void MakePayment(Product product);
    }
}
