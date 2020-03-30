using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnUI : NetworkBehaviour
{
    public GameObject UI;

    public override void OnStartServer()
    {
        SpawnUIMethod();
    }


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


    void SpawnUIMethod()
    {
        GameObject ob = Instantiate(UI);

        NetworkServer.Spawn(UI);
    }
}
