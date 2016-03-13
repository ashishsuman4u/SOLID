using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    public class Invoice
    {
        public long Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        private readonly StoreLogger _storeLogger;
        private readonly MailerService _mailerService;
        public InvoiceType InvoiceType { get; set; }

        protected virtual StoreLogger Logger { get { return _storeLogger; } }
        protected virtual MailerService MailerService { get { return _mailerService; } }

        public Invoice()
        {
            _storeLogger = new StoreLogger();
            _mailerService = new MailerService();
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
    }
}
