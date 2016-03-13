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
        public int InvoiceId { get; set; }
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
                string file = GetErrorFile(InvoiceId);
                System.IO.File.WriteAllText(file, ex.ToString());
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
                string file = GetErrorFile(InvoiceId);
                System.IO.File.WriteAllText(file, ex.ToString());
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
                string file = GetErrorFile(InvoiceId);
                System.IO.File.WriteAllText(file, ex.ToString());
            }
        }

        public double GetDiscount(double amount)
        {
            //No discount
            return 0;
        }
        public string GetErrorFile(int id)
        {
            var fileName = string.Format(@"c:\Error\{0}.txt", id);
            DirectoryInfo directoryInfo = new DirectoryInfo(fileName);
            if (directoryInfo.Exists)
            {
                return fileName;
            }
            return string.Empty;
        }
    }
}
