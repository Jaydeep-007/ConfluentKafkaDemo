using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;

namespace KafkaFunctionApp
{
    public class KafkaReciever
    {
        // KafkaTrigger sample 
        // Consume the message from "topic" on the LocalBroker.
        // Add `BrokerList` and `KafkaPassword` to the local.settings.json
        // For EventHubs
        // "BrokerList": "{EVENT_HUBS_NAMESPACE}.servicebus.windows.net:9093"
        // "KafkaPassword":"{EVENT_HUBS_CONNECTION_STRING}
        [FunctionName("Function1")]
        public void Run(
            [KafkaTrigger("pkc-7prvp.centralindia.azure.confluent.cloud:9092",
                          "topic_1",
                          Username = "4RMQDOR5YTCZXODV",
                          Password = "7nSvqYEi9hmPWZlrQiomktpNjZX3M9yXU+ZEc0eXPx07Aw3ZgYMdeoGTgKDeQrOf",
                          Protocol = BrokerProtocol.SaslSsl,
                          AuthenticationMode = BrokerAuthenticationMode.Plain,
                          ConsumerGroup = "$Default")] KafkaEventData<string>[] events,
            ILogger log)
        {
            foreach (KafkaEventData<string> eventData in events)
            {
                log.LogInformation($"C# Kafka trigger function processed a message: {eventData.Value}");
            }
        }
    }
}
