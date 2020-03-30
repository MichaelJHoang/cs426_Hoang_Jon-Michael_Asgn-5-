using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SpawnParts : NetworkBehaviour
{
    public GameObject[] ObjectsToSpawn;

    public override void OnStartServer()
    {
        spawnPartsMethod();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


    private void spawnPartsMethod()
    {
        for (int i = 0; i < ObjectsToSpawn.Length; i++)
        {
            GameObject part = Instantiate(ObjectsToSpawn[i]);
     //       part.GetComponent<UpdateText>().actionText = GameObject.Find("PlayerUI").GetComponent<UIText>();
            NetworkServer.Spawn(part);
        }
    }
}
   
