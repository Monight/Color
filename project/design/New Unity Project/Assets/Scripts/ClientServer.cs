using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class ClientServer : MonoBehaviour
{

    /// <summary>
    /// 端口
    /// </summary>
    private static int myPort = 8888;

    // Use this for initialization
    void Start ()
    {
        StartClient();

    }


    void StartClient()
    {
        //IP地址
        IPAddress ip = IPAddress.Parse("122.0.0.1");
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(new IPEndPoint(ip, myPort));
            print("server connection success");
        }
        catch (System.Exception e)
        {
            print("server connection failed");
            return;
        }
    }

}
