using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Player1Cheat : NetworkBehaviour
{
    GameObject[] redObjects;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            redObjects = GameObject.FindGameObjectsWithTag("Red");

            foreach (GameObject ob in redObjects)
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
