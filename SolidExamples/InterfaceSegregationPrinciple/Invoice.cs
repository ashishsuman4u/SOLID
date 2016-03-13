using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
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

        protected virtual ILogger Logger { get { return _fileLogger; } }
        protected virtual IFileLocator FileLocator { get { return _fileLocator; } }
        protected virtual IMailerService MailerService { get { return _mailerService; } }

        public Invoice()
        {
            _fileLogger = new FileLogger();
            _fileLocator = new FileLocator();
            _mailerService = new GmailMailerService();
        }

        public virtual void Add()
        {
            try
            {
                Logger.Info("Add method Start");
                // Code for adding invoice
                // Once Invoice has been added , send mail 
                MailerService.From = "MailAddressFrom";
                MailerService.To = "MailAddressTo";
                MailerService.Subject = "MailSubject";
                MailerService.Body = "MailBody";
                MailerService.SendEmail();
            }
            catch (Exception ex)
            {
                Logger.Error("Error while Adding Invoice", ex);
            }
        }

        public virtual void Delete()
        {
            try
            {
                Logger.Info("Add Delete Start");
                // Code for Delete invoice
            }
            catch (Exception ex)
            {
                Logger.Error("Error while Deleting Invoice", ex);
            }
        }

        public virtual double GetDiscount(double amount)
        {
            //No discount
            return 0;
        }
        public string GetErrorFileName(int id)
        {
            return FileLocator.GetErrorFile(id);
        }
    }
}
