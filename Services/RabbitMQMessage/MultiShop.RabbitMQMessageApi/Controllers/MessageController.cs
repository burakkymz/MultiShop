using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connetcitonFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connetcitonFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk1", false, false, false, arguments:null);

            var messageContent = "Merhaba bu bir RabbitMQ kuyruk mesajıdır";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            channel.BasicPublish("", "Kuyruk1", null, byteMessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır");
        }

        [HttpGet]
        public IActionResult ReadMessage()
        {
            string message = "";
            var connectionFactory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var result = channel.BasicGet(queue: "Kuyruk1", autoAck: false);

                if (result != null)
                {
                    var byteMessage = result.Body.ToArray();
                    message = Encoding.UTF8.GetString(byteMessage);
                }
                else
                {
                    message = "No messages in the queue";
                }
            }

            return Ok(message);
        }
    }
}
