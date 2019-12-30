using System;
using RabbitMQ.Client;
using System.Text;
using resposbalitityPattrn;
using startingTestconsoleApp;
using startingTestconsoleApp.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Send
{
    class Send
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                     channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: true,
                                 arguments: null);

                        string message = "Hello World!";
                        message = JsonConvert.SerializeObject(new object());
                        var body = Encoding.UTF8.GetBytes(message.ToString());

                        channel.BasicPublish(exchange: "",
                                             routingKey: "hello",
                                             basicProperties: null,
                                             body: body);
                        Console.WriteLine(" [x] Sent {0}", message);
                }
            }

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
        }


        public static List<Animal> GetAnimals()
        {
            //It's possible define any quatity of animals in the chain. 
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal { food = "Nut", specie = "Squirrel" });
            animals.Add(new Animal { food = "Banana", specie = "Monkey" });
            animals.Add(new Animal { food = "Milk", specie = "Cat" });
            
            return animals;
        }

         
}
}
