using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class MakeBirdGlow_Puzzle1 : NetworkBehaviour
{
    public GameObject PuzzleParent_p1;
    public GameObject PinkPedestal_p1;
    public GameObject BluePedestal_p1;

    public Text PinkText_p1;
    public Text BlueText_p1;

    public GameObject Light_p1;

    public GameObject PinkBird_p1;
    public GameObject BlueBird_p1;


    private Light birdLight_p1;

    bool lightOn_p1 = false;

    [SyncVar]
    bool isOn_p1 = true;

    [SyncVar]
    private bool _pinkBirdVisible_p1 = true;

    [SyncVar]
    private bool _blueBirdVisible_p1 = true;

    [SyncVar]
    private bool PickUpActiveBlue_p1 = false;

    [SyncVar]
    private bool PickUpActivePink_p1 = false;


    [SyncVar]
    private bool _playerOneNear_p1 = false;

    [SyncVar]
    private bool _playerTwoNear_p1 = false;

    [SyncVar]
    private bool PinkState_p1 = true;

    [SyncVar]
    private bool BlueState_p1 = true;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


    private void Start()
    {
        birdLight_p1 = Light_p1.gameObject.GetComponent<Light>();
        PinkText_p1.text = "1";
        BlueText_p1.text = "1";
    }


    [Command]
    public void CmdPickUpBird_p1(int playerNear)
    {
        RpcPickUpBird_p1(playerNear);
    }

    [ClientRpc]
    void RpcPickUpBird_p1(int playerNear)
    {

        if (playerNear == 1)
        {
            if (_pinkBirdVisible_p1 == true)
            {
                PinkBird_p1.gameObject.SetActive(false);
                PinkText_p1.text = "0";
                PinkState_p1 = false;
                _pinkBirdVisible_p1 = false;
            }
            else
            {
                PinkBird_p1.gameObject.SetActive(true);
                PinkText_p1.text = "1";
                PinkState_p1 = true;
                _pinkBirdVisible_p1 = true;
            }
        }

        if (playerNear == 2)
        {
            if (_blueBirdVisible_p1 == true)
            {
                BlueBird_p1.gameObject.SetActive(false);
                BlueText_p1.text = "0";
                BlueState_p1 = false;
                _blueBirdVisible_p1 = false;
            }
            else
            {
                BlueBird_p1.gameObject.SetActive(true);
                BlueText_p1.text = "1";
                BlueState_p1 = true;
                _blueBirdVisible_p1 = true;
            }
        }

    }

    private void Update()
    {
        if (PickUpActivePink_p1 == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && _playerOneNear_p1)
            {
                CmdPickUpBird_p1(1);
            }

        }

        if (PickUpActiveBlue_p1 == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && _playerTwoNear_p1)
            {
                CmdPickUpBird_p1(2);
            }

        }

        lightOn_p1 = CheckPedestalState_p1(isOn_p1);
        CmdTurnOffLight_p1(lightOn_p1);

    }


    bool CheckPedestalState_p1(bool isOn)
    {
        if (BlueState_p1 == true && PinkState_p1 == true)
        {
            return isOn;
        }
        else
        {
            return !isOn;
        }
    }


    [Command]
    void CmdTurnOffLight_p1(bool isOn)
    {
        RpcTurnOffLight_p1(isOn);
    }

    [ClientRpc]
    void RpcTurnOffLight_p1(bool isOn)
    {
        birdLight_p1.enabled = isOn;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player")) // Player that is colliding with object
        {
            //gameObject.gameObject.GetComponent<NetworkIdentity>().AssignClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            GetComponent<NetworkIdentity>().AssignClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);

            PickUpActivePink_p1 = true;
            _playerOneNear_p1 = true;
        }

        if (other.gameObject.CompareTag("PlayerTwo")) // Player that is colliding with object
        {
            //gameObject.GetComponent<NetworkIdentity>().AssignClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            GetComponent<NetworkIdentity>().AssignClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            PickUpActiveBlue_p1 = true;
            _playerTwoNear_p1 = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player")) // Player that is colliding with object
        {
            //GetComponent<NetworkIdentity>().RemoveClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            PickUpActivePink_p1 = false;
            _playerOneNear_p1 = false;
        }

        if (other.gameObject.CompareTag("PlayerTwo")) // Player that is colliding with object
        {
            //GetComponent<NetworkIdentity>().RemoveClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            PickUpActiveBlue_p1 = false;
            _playerTwoNear_p1 = false;
        }
    }




}
