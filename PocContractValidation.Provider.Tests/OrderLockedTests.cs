using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using PocContractValidation.Provider.Models;
using PocContractValidation.Provider.Services;
using System;
using System.IO;
using System.Text.Json;
using Xunit;

namespace PocContractValidation.Provider.Tests
{
    public class OrderLockedTests
    {
        // Test and validate our order locked event payload to the contracts definition of an order locked event
        [Fact]
        public void CreateOrderLockedEvent()
        {
            var realisticPayloadService = new RealisticPayloadService();
            var orderLockedEvent = realisticPayloadService.BuildOrderLockedEvent();

            var orderLockedJsonContract = File.ReadAllText($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}contract-validation/myorder2/order_locked/order_locked.contract.json");
            var jSchema = JSchema.Parse(orderLockedJsonContract);

            var orderLockedEventAsJson = JsonSerializer.Serialize(orderLockedEvent);
            var orderLockedEventAsJObject = JObject.Parse(orderLockedEventAsJson);

            Assert.True(orderLockedEventAsJObject.IsValid(jSchema));
        }
    }
}
