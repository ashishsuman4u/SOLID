using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TheProblem
{
    public class Invoice
    {
        public long Amount { get; set; }
        public DateTime InvoiceDate { get; set; }

        public void Add()
        {
            try
            {
                // Code for adding invoice

                // Once Invoice has been added , send mail 
                MailMessage mailMessage = new MailMessage("MailAddressFrom", "MailAddressTo", "MailSubject", "MailBody");
                this.SendEmail(mailMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            }
        }

        public void Delete()
        {
            try
            {
                // Code for Delete invoice
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            }
        }

        public void SendEmail(MailMessage mailMessage)
        {
            try
            {
                // Code for getting Email setting and send invoice mail
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            }
        }

        public double GetDiscount(double amount)
        {
            //No discount
            return 0;
        }
    }
}
