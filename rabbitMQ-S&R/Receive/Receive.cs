using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using resposbalitityPattrn;
using startingTestconsoleApp;
using startingTestconsoleApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Receive
{
    class Receive
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: true,
                                        arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    if(processFood(message) != string.Empty){
                        Console.WriteLine(" [x] Message Processed");
                    }
                };
                channel.BasicConsume(queue: "hello",
                                        autoAck: true,
                                        consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        public static string processFood(string message) 
        {
            if(!string.Empty.Equals(message))
            {
                try 
	            {	        
		            animalList = JsonConvert.DeserializeObject<List<Animal>>(message);
                    AnimalClient client = new AnimalClient();
                    return client.Processor(animalList?? new List<Animal>());
	            }
	            catch (Exception)
	            {
                    return string.Empty;
		            throw;
                    
	            } 
            }
             return string.Empty;
        }
    }
}
