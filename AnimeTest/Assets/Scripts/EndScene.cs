using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EndScene : NetworkBehaviour

{
    public GameObject EndCanvas;
    public GameObject Door;
    public MeshRenderer DoorDisplay;

    [SyncVar]
    private bool isPlayerOneNear = false;

    [SyncVar]
    private bool isPlayerTwoNear = false;

    [SyncVar]
    private bool bothPlayerNear = false;

    //[SyncVar] -- Can't Sync Statics
    public static bool R_Bird1 = false;
    public static bool R_Bird2 = false;
    public static bool R_Bird3 = false;
    public static bool P_Bird1 = false;
    public static bool P_Bird2 = false;
    public static bool P_Bird3 = false;

    public bool R1 = R_Bird1;
    public bool R2 = R_Bird2;
    public bool R3 = R_Bird3;

    public bool P1 = P_Bird1;
    public bool P2 = P_Bird2;
    public bool P3 = P_Bird3;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


    // Start is called before the first frame update
    void Start()
    {
        EndCanvas.gameObject.SetActive(false);
        CmdSetDoorState(false);
        DoorDisplay = Door.GetComponent<MeshRenderer>();
        
    }


    // Update is called once per frame
    void Update()
    {


         R1 = R_Bird1;
         R2 = R_Bird2;
         R3 = R_Bird3;

         P1 = P_Bird1;
         P2 = P_Bird2;
         P3 = P_Bird3;
        if (
            R_Bird1 == true &&
            R_Bird2 == false &&
            R_Bird3 == true &&
            P_Bird1 == true &&
            P_Bird2 == true &&
            P_Bird3 == true
            )
        {
            Debug.Log("End Door Activated!");
            bothPlayerNear = true;
            CmdSetDoorState(true);

            if(isPlayerOneNear == true && isPlayerTwoNear == true) { CmdTriggerEndScreen(bothPlayerNear); }
            
        }

    }

    [Command]
    void CmdSetDoorState(bool puzzleDone)
    {
        RpcSetDoorState(puzzleDone);
    }

    [ClientRpc]
    void RpcSetDoorState(bool puzzleDone)
    {
        DoorDisplay.enabled = puzzleDone;
    }




    [Command]
    void CmdTriggerEndScreen(bool bothPlayersNear)
    {
        RpcTriggerEndScreen(bothPlayersNear);
    }

    [ClientRpc]
    void RpcTriggerEndScreen(bool bothPlayersNear)
    {
        EndCanvas.gameObject.SetActive(bothPlayerNear);
        Time.timeScale = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Player that is colliding with object
        {
            Debug.Log("Player One Activated Trigger");
            isPlayerOneNear = true;
        }

        if (other.gameObject.CompareTag("PlayerTwo")) // Player that is colliding with object
        {
            Debug.Log("Player Two Activated Trigger");
            isPlayerTwoNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Player that is colliding with object
        {
            isPlayerOneNear = false;
        }

        if (other.gameObject.CompareTag("PlayerTwo")) // Player that is colliding with object
        {
            isPlayerTwoNear = false;
        }
    }

}
