using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace kafkaproducer
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.Write("Address of the Kafka server: ");
            string server = Console.ReadLine();

            Console.Write("Topic name: ");
            string topic = Console.ReadLine();            

            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers", server }
            };

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {     
                while(true)
                {
                    var dr = producer.ProduceAsync(topic, null, $"New message at {DateTime.Now}").Result;
                    Thread.Sleep(1000);
                    Console.WriteLine($"Delivered '{dr.Value}' to: {dr.TopicPartitionOffset}");
                }                
            }
        }

        private static IConfigurationRoot StartConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            return configuration;
        }
    }
}
