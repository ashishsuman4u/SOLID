using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public class ProposedInvoice : Invoice
    {
        public override double GetDiscount(double amount)
        {
            return base.GetDiscount(amount) - 50;
        }
    }
}
