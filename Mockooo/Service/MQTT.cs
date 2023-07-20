using MQTTnet;
using MQTTnet.Client;

namespace Mockooo.Service
{
    public class MQTT
    {

        public async Task ConnectToClient(string ServerInfo, string TopicToPublish, string str)
        {
            try
            {
                var factory = new MqttFactory();
                var client = factory.CreateMqttClient();
                var options = new MqttClientOptionsBuilder().WithTcpServer(ServerInfo, 1883).WithClientId("mqtt_consumer")
                    .Build();
                await client.ConnectAsync(options, CancellationToken.None);
                if (client.IsConnected)
                {
                    client.PublishStringAsync(TopicToPublish, str);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }
		
    }
}
