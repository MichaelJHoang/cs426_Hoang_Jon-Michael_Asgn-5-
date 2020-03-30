using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;




    // Implementing the singleton pattern for our custom NetworkManager
    public class MainCustomNetworkManager : NetworkManager
    {

        public Events.EventLocalPlayerJoined localPlayerJoinedEvent;

        //public const string BroadcastMsgPrefix = "ConnBroadcastMsg";

        //public const char BroadcastMsgDelim = ':';

        private static MainCustomNetworkManager networkInstance;
        
        public int PlayerGiven = 0;
        public short PlayerID = 0;

        public class NetworkMessage : MessageBase
        {
            public int CharIndx = 0;
        }

        // Singleton Pattern
        public static MainCustomNetworkManager NetworkInstance
        {
            get
            {
                if (networkInstance == null)
                {       
                networkInstance = FindObjectOfType<MainCustomNetworkManager>();
                }

                return networkInstance;
            }
        }

      

        // Server setups and spawns a player
        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
        {

            NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
            int playerSelect = message.CharIndx;

            if (playerSelect == 0)
            {
                GameObject player = Instantiate(Resources.Load("PlayerOne", typeof(GameObject))) as GameObject;
                NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
            }

            if (playerSelect == 1)
            {
                GameObject player = Instantiate(Resources.Load("PlayerTwo", typeof(GameObject))) as GameObject;
                NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
            }


        }

        public override void OnServerSceneChanged(string sceneName)
        {
            base.OnServerSceneChanged(sceneName);
            GameManager.Instance.UpdateLevel(sceneName);
           
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            NetworkMessage test = new NetworkMessage();
            test.CharIndx = PlayerGiven;
            
            ClientScene.AddPlayer(conn, PlayerID, test);
        }


    //public override void OnClientSceneChanged(NetworkConnection conn)
    //    {
    //        if (!conn.isReady)
    //        {
    //            base.OnClientSceneChanged(conn);
    //        }

    //        if (networkSceneName.Equals("MainGameScene")) // To prevent having this being invoked in the boot scene or any other scene that is not the MainGameScene
    //        {
    //            localPlayerJoinedEvent.Invoke(MainPlayerNetworkState.LocalPlayer);
    //        }

    //        GameManager.Instance.UpdateLevel(networkSceneName);
    //    }




        // Works with the Network Discovery
        //public string GenerateNetworkBroadcastData()
        //{
        //    // Sending the network port to the clients
        //    return BroadcastMsgPrefix + BroadcastMsgDelim + networkPort;
        //}

        public void hostPlayer()
        {
            PlayerGiven = 0;
            PlayerID = 0;
        }

        public void clientPlayer()
        {
            PlayerGiven = 1;
            PlayerID = 1;
        }


    }

