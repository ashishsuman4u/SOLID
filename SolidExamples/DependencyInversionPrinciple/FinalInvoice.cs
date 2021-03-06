﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public class FinalInvoice : Invoice
    {
        public FinalInvoice(ILogger logger, IFileLocator fileLocator, IMailerService mailerService) 
            : base(logger, fileLocator, mailerService)
        {
        }

        public override double GetDiscount(double amount)
        {
            return base.GetDiscount(amount) - 100;
        }

    }
}
