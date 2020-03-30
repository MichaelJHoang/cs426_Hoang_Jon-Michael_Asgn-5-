using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


    public class MainPlayerNetworkState : NetworkBehaviour
    {
        // There's a player network state object for EVERY local player that is in the game
        public static MainPlayerNetworkState LocalPlayer;

        public override void OnStartLocalPlayer()
        {
            LocalPlayer = this;
        }

    }
