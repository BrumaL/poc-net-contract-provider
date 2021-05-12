using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocContractValidation.Provider.Models
{
    public class OrderLockedEvent
    {
        public Guid orderId { get; set; }
        public string orderNumber { get; set; }
        public DateTime orderLockedDate { get; set; }
        public Payment payment { get; set; }
    }

    public class Payment
    {
        public string currency { get; set; }
        public LabelValue amount { get; set; }
        public PaymentDetails paymentDetails { get; set; }
    }

    public class PaymentDetails
    {
        public LabelValue amountWithoutDeliveryCharge { get; set; }
        public LabelValue deliveryChargePrice { get; set; }
        public LabelValue VAT { get; set; }
        public List<S3Bucket> documents { get; set; }
    }

    public class S3Bucket
    {
        public string bucket { get; set; }
        public string path { get; set; }

    }

    public class LabelValue
    {
        public string label { get; set; }
        public decimal value { get; set; }
    }
}
