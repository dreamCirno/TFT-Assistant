using Greet;
using Grpc.Core;
using UnityEngine;

public class AppEntry : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("App Started.");

        try
        {
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new Greeter.GreeterClient(channel);
            string user = "world";

            var reply = client.SayHello(new HelloRequest() {Name = user});
            Debug.Log("Greeting: " + reply.Message);

            channel.ShutdownAsync().Wait();
        }
        catch (RpcException e)
        {
            Debug.LogError($"连接失败：{e}");
        }
    }
}