using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class TurnOnOffPuzzleLight : NetworkBehaviour
{

    public static bool P1_BluePedestal = true;
    public static bool P1_PinkPedestal = true;

    public static bool P2_BluePedestal = true;
    public static bool P2_PinkPedestal = true;

    //public GameObject PuzzleLight;
    public int PuzzleID;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {

        //CmdChangeLightState(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(PuzzleID == 1) { 

            // If both pedestals have birds on them then turn on the AND gate light
            if (P1_BluePedestal == true && P1_PinkPedestal == true)
            {
                Debug.Log("AND Pedestal is: ON");
                CmdChangeLightState(true);
            }
            else
            {
                Debug.Log("AND Pedestal is: OFF");
                CmdChangeLightState(false);
            }

        }

        if(PuzzleID == 2)
        {
            // If neither pedestals ahve birds on them then turn off the OR gate light
            if (P2_BluePedestal == false && P2_PinkPedestal == false)
            {
                Debug.Log("OR Pedestal is: OFF");
                CmdChangeLightState(false);
            }
            else
            {
                Debug.Log("OR Pedestal is: ON");
                CmdChangeLightState(true);
            }
        }
       
    }

    [Command]
    void CmdChangeLightState(bool LightState)
    {
        RpcChangeLightState(LightState);
    }

    [ClientRpc]
    void RpcChangeLightState(bool LightState)
    {
        GetComponent<Light>().enabled = LightState;
    }









}
