using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public long Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public InvoiceType InvoiceType { get; set; }

        private readonly ILogger _fileLogger;
        private readonly IFileLocator _fileLocator;
        private readonly IMailerService _mailerService;
        

        public Invoice(ILogger logger, IFileLocator fileLocator, IMailerService mailerService)
        {
            _fileLogger = logger;
            _fileLocator = fileLocator;
            _mailerService = mailerService;
        }

        public virtual void Add()
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

        public virtual void Delete()
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

        public virtual double GetDiscount(double amount)
        {
            //No discount
            return 0;
        }
        public string GetErrorFileName(int id)
        {
            return _fileLocator.GetErrorFile(id);
        }
    }
}
