
using Confluent.Kafka;
using N5.Management.Commons.Dtos;
using Newtonsoft.Json;
using Serilog;

namespace N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer
{

    public class KafkaProducerService
    {
        private readonly string _bootstrapServers;
        private readonly string _topic;

        public KafkaProducerService(string bootstrapServers, string topic)
        {
            _bootstrapServers = bootstrapServers;
            _topic = topic;
        }

        public async Task ProduceAsync(OperationMessageDto message)
        {
            var config = new ProducerConfig { BootstrapServers = _bootstrapServers };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var kafkaMessage = new Message<Null, string>
                    {
                        Value = JsonConvert.SerializeObject(message)
                    };

                    var deliveryResult = await producer.ProduceAsync(_topic, kafkaMessage);
                         //Log.Information("Delivered: {@kafkaMessage}", JsonConvert.SerializeObject(deliveryResult));
                    Log.Information($"Delivered: '{message.Id} - ' '{deliveryResult.Value}' to '{deliveryResult.TopicPartitionOffset}' ' Date: {DateTime.Now.Date}' ");
                }
                catch (ProduceException<Null, string> e)
                {
                    Log.Error($"Delivery failed: {e.Error.Reason}");
                }
            }
        }
    }
}
