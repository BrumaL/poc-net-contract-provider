using PocContractValidation.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocContractValidation.Provider.Services
{
    // This is a service that builds realistic payload data that we can validate against a contract.
    public class RealisticPayloadService
    {
        // create an order locked event with our payload
        public OrderLockedEvent BuildOrderLockedEvent()
        {
            var orderLockedEvent = new OrderLockedEvent
            {
                orderId = Guid.NewGuid(),
                orderNumber = "12345",
                orderLockedDate = DateTime.Now,
                payment = new Payment 
                {
                    currency = "SEK",
                    amount = new LabelValue
                    {
                        label = "Amount",
                        value = 199
                    },
                    paymentDetails = new PaymentDetails
                    {
                        amountWithoutDeliveryCharge = new LabelValue
                        {
                            label = "Amount without delivery charge",
                            value = 100
                        },
                        deliveryChargePrice = new LabelValue
                        {
                            label = "delivery charge price",
                            value = 99
                        },
                        VAT = new LabelValue
                        {
                            label = "VAT",
                            value = 50.99M
                        },
                        documents = new List<S3Bucket>
                        {
                            new S3Bucket { bucket = "bucket1", path = "path/to/bucket1" },
                            new S3Bucket { bucket = "bucket2", path = "path/to/bucket2" }
                        }
                        
                    }
                }
            };

            return orderLockedEvent;
        }
    }
}
