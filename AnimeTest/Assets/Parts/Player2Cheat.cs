﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Player2Cheat : NetworkBehaviour
{
    GameObject[] purpleObjects;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            purpleObjects = GameObject.FindGameObjectsWithTag("Purple");

            foreach (GameObject ob in purpleObjects)
            {
                if (ob != null)
                {
                    CmdAssignAuthority(ob);
                    CmdDeleteObjects(ob);
                }
            }
        }
    }

    [Command]
    void CmdDeleteObjects(GameObject ob)
    {
        RpcDeleteObjects(ob);
    }

    [ClientRpc]
    void RpcDeleteObjects(GameObject ob)
    {
        ob.SetActive(false);
    }

    [Command]
    void CmdAssignAuthority(GameObject ob)
    {
        gameObject.GetComponent<NetworkIdentity>().AssignClientAuthority(ob.GetComponent<NetworkIdentity>().connectionToClient);
    }

    [Command]
    void CmdRemoveAuthority(GameObject ob)
    {
        gameObject.GetComponent<NetworkIdentity>().RemoveClientAuthority(ob.GetComponent<NetworkIdentity>().connectionToClient);
    }
}
