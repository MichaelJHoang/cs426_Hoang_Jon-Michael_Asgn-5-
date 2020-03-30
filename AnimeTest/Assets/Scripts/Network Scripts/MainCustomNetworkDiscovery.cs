using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


    public class MainCustomNetworkDiscovery : NetworkDiscovery // No longer needed. Doing a direct connect to the Host with network manager
    {

        //private static MainCustomNetworkDiscovery networkDiscoveryInstance;

        //public static MainCustomNetworkDiscovery NetworkDiscoveryInstance
        //{
        //    get
        //    {
        //        if (networkDiscoveryInstance == null)
        //        {
        //            networkDiscoveryInstance = FindObjectOfType<MainCustomNetworkDiscovery>();
        //        }

        //        return networkDiscoveryInstance;
        //    }
        //}

        //// Caching a reference to the singleton accessor
        //private MainCustomNetworkManager customNetworkManager;

        //// Initializes the network discovery
        //void Start()
        //{
        //    customNetworkManager = MainCustomNetworkManager.NetworkInstance;

        //    // Consume the data from the Network Manager
        //    broadcastData = MainCustomNetworkManager.NetworkInstance.GenerateNetworkBroadcastData();

        //    Initialize(); // inherited from Network Discovery
        //}

        //// Checks to see if we receive a broadcast
        //// Tests the connection
        //public override void OnReceivedBroadcast(string fromAddress, string data)
        //{
        //    //Debug.LogError("Network is working, woo! Received broadcast from adress: " + fromAddress + ", data: " + data);

        //    string[] parseMessage = data.Split(MainCustomNetworkManager.BroadcastMsgDelim);
        //    if (parseMessage.Length == 2 && parseMessage[0] == MainCustomNetworkManager.BroadcastMsgPrefix)
        //    { // Checks if the message is correctly receieved

        //        if (customNetworkManager != null && customNetworkManager.client == null) // Checks to see if the instances wasn't already created
        //        {
        //            //Debug.LogError("Connecting to: " + fromAddress);
        //            //customNetworkManager.networkAddress = fromAddress;
        //            //customNetworkManager.networkPort = int.Parse(parseMessage[1]);           
        //            customNetworkManager.StartClient();
        //            customNetworkManager.clientPlayer(); // Always gets player two model
        //        }


        //    }
        //}


    }

