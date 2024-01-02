using UnityEngine;
using ElRaccoone.WebSockets;
using SimpleJSON;

[System.Serializable]
public class MyCustomObject
{
    public float x;
    public float y;
    // Add other properties matching your JSON structure
}

public class WebSocket : MonoBehaviour
{
    private WSConnection wsConnection = new WSConnection("ws://localhost:8080");
    private void Awake()
    {

        this.wsConnection.OnConnected(() =>
        {
            Debug.Log("WS Connected!");
        });

        this.wsConnection.OnDisconnected(() =>
        {
            Debug.Log("WS Disconnected!");
        });

        this.wsConnection.OnError(error =>
        {
            Debug.Log("WS Error " + error);
        });

        this.wsConnection.OnMessage(message =>
        {
            //Debug.Log("Received message " + message);
            //Debug.Log(message);

            // Deserialize the JSON string into your custom object
            MyCustomObject receivedObject = JsonUtility.FromJson<MyCustomObject>(message);

            // Access and log the properties of the received object
            //Debug.Log("X: " + receivedObject.x);
            //Debug.Log("Y: " + receivedObject.y);
            GameModel.eyeX = receivedObject.x;
            GameModel.eyeY = receivedObject.y;

        });

        this.wsConnection.Connect();

        // Queue sending messages, these will always be send in this order.

    }

    private void Start()
    {
        this.wsConnection.SendMessage("Hello,");
        this.wsConnection.SendMessage("World!");
    }

    private void OnDestroy()
    {
        // A provided editor script closes all connections automatically when you
        // exit play mode. Use this method to close the connection manually.
        this.wsConnection.Disconnect();
    }
}
