using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

    public class MenuManager : MonoBehaviour
    {

        public GameObject UIParent;

        private MainCustomNetworkManager networkManager;

        //private MainCustomNetworkDiscovery networkDiscovery; // No longer needed

        public InputField IP_Field;
        public InputField Port_Field;

        void Awake()
        {
            //DontDestroyOnLoad(this);
        }


        void Start()
        {
            networkManager = MainCustomNetworkManager.NetworkInstance;
            //networkDiscovery = MainCustomNetworkDiscovery.NetworkDiscoveryInstance;
        }


        // Server + Client
        // Broadcasting signal
        public void StartHost()
        {
            string PortHolder = Port_Field.text;
            int PortHolderConverToInt = int.Parse(PortHolder);

            networkManager.networkPort = PortHolderConverToInt;
            networkManager.StartHost(); // Client will act as the host
            networkManager.hostPlayer(); // Host/Client always gets Player One
            networkManager.ServerChangeScene("MainGameScene");
            ButtonDisable();
        }


        // Client
        public void StartClient()
        {
            string PlaceHolder = Port_Field.text;
            int PlaceHolderInt = int.Parse(PlaceHolder);

            networkManager.networkAddress = IP_Field.text;
            networkManager.networkPort = PlaceHolderInt;
            
            networkManager.StartClient();
            networkManager.clientPlayer();
            ButtonDisable();
        }



        void ButtonDisable()
        {
            UIParent.SetActive(false);
        }



    }
