using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public long Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        private readonly FileLogger _fileLogger;
        private readonly MailerService _mailerService;
        public InvoiceType InvoiceType { get; set; }

        public Invoice()
        {
            _fileLogger = new FileLogger();
            _mailerService = new MailerService();
        }
        public void Add()
        {
            try
            {
                _fileLogger.Info("Add method Start");
                // Code for adding invoice
                // Once Invoice has been added , send mail 
                _mailerService.From = "MailAddressFrom";
                _mailerService.To = "MailAddressTo";
                _mailerService.Subject = "MailSubject";
                _mailerService.Body = "MailBody";
                _mailerService.SendEmail();
            }
            catch (Exception ex)
            {
                _fileLogger.Error("Error while Adding Invoice", ex);
            }
        }

        public void Delete()
        {
            try
            {
                _fileLogger.Info("Add Delete Start");
                // Code for Delete invoice
            }
            catch (Exception ex)
            {
                _fileLogger.Error("Error while Deleting Invoice", ex);
            }
        }

        //This is what we do when we come across new requirements.
        public double GetDiscount(double amount, InvoiceType invoiceType)
        {
            double finalAmount = 0;
            if (invoiceType == InvoiceType.Final)
            {
                finalAmount = amount - 100;
            }
            else if (invoiceType == InvoiceType.Proposed)
            {
                finalAmount = amount - 50;
            }
            return finalAmount;
        }

        public double GetDiscount(double amount)
        {
            //No discount
            return 0;
        }
        public string GetErrorFileName(int id)
        {
            var fileName = _fileLogger.GetErrorFilePath(id);
            DirectoryInfo directoryInfo = new DirectoryInfo(fileName);
            if (directoryInfo.Exists)
            {
                return fileName;
            }
            return string.Empty;
        }

    }
}
