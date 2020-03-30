using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupPlayer : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] disableComponents;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < disableComponents.Length; i++)
            {
                disableComponents[i].enabled = false;
            }
        }
    }


}
