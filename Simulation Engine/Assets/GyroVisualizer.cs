using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SatProt;
using System.Threading;

public class GyroVisualizer : MonoBehaviour {

	Vector3 desiredAngles = Vector3.zero;
	Server server;

	// Use this for initialization

	Thread t;

	void Start () 
	{
		server = new Server(14944);
		server.MessageHandler = OnServerMessage;
		server.OnClientConnected = OnClientConnected;
		t = new Thread(() => 
		{
			server.Start();
		});
		t.IsBackground = true;
		t.Start();
	}

	public static void _Debug(string x)
	{
		UnityEngine.Debug.Log(x);
	}

	void OnApplicationQuit()
	{
		Debug.Log("Exit");
		server.Stop();
		t.Abort();
	}
	
	void OnServerMessage(InMsg msg) 
	{
		float x = msg.NextFloat();
		float y = msg.NextFloat();
		float z = msg.NextFloat();

		Debug.Log("Message " + x + ", " + y + ", " + z);

		desiredAngles = new Vector3(x, y, z);
	}

	void OnClientConnected(System.Net.Sockets.TcpClient c)
	{
		Debug.Log("Client Connected");
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = desiredAngles;
	}
}
