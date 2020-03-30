using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnPedestal : NetworkBehaviour
{
    public GameObject[] pedestals;

    public override void OnStartServer()
    {
        SpawnPedestalMethod();
    }


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


    void SpawnPedestalMethod()
    {

        for(int i = 0; i < pedestals.Length; i++)
        {
            GameObject ob = Instantiate(pedestals[i]);
            NetworkServer.Spawn(ob);
        }
    }

}
