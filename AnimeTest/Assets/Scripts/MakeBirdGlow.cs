using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class MakeBirdGlow : NetworkBehaviour
{
    public GameObject PuzzleParent;
    public GameObject PinkPedestal;
    public GameObject BluePedestal;

    public Text PinkText;
    public Text BlueText;

    public GameObject Light;

    public GameObject PinkBird;
    public GameObject BlueBird;

 
    private Light birdLight;

    bool lightOn = false;

    [SyncVar]
    bool isOn = true;

    [SyncVar]
    private bool _pinkBirdVisible = true;

    [SyncVar]
    private bool _blueBirdVisible = true;

    [SyncVar]
    private bool PickUpActiveBlue = false;

    [SyncVar]
    private bool PickUpActivePink = false;


    [SyncVar]
    private bool _playerOneNear = false;

    [SyncVar]
    private bool _playerTwoNear = false;

    [SyncVar]
    private bool PinkState = true;

    [SyncVar]
    private bool BlueState = true;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


    private void Start()
    {
        birdLight = Light.gameObject.GetComponent<Light>();
        PinkText.text = "1";
        BlueText.text = "1";
    }


    [Command]
    public void CmdPickUpBird(int playerNear)
    {
        RpcPickUpBird(playerNear);
    }

    [ClientRpc]
    void RpcPickUpBird(int playerNear)
    {

        if( playerNear == 1)
        {
            if (_pinkBirdVisible == true)
            {
                PinkBird.gameObject.SetActive(false);
                PinkText.text = "0";
                PinkState = false;
                _pinkBirdVisible = false;
            }
            else
            {
                PinkBird.gameObject.SetActive(true);
                PinkText.text = "1";
                PinkState = true;
                _pinkBirdVisible = true;
            }
        }

        if (playerNear == 2)
        {
            if (_blueBirdVisible == true)
            {
                BlueBird.gameObject.SetActive(false);
                BlueText.text = "0";
                BlueState = false;
                _blueBirdVisible = false;
            }
            else
            {
                BlueBird.gameObject.SetActive(true);
                BlueText.text = "1";
                BlueState = true;
                _blueBirdVisible = true;
            }
        }

    }

    private void Update()
    {
        if (PickUpActivePink == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && _playerOneNear)
            {
                CmdPickUpBird(1);
            }

        }

        if (PickUpActiveBlue == true) {
            if (Input.GetKeyDown(KeyCode.E) && _playerTwoNear)
            {
                CmdPickUpBird(2);
            }

        }

        lightOn = CheckPedestalState(isOn);
        CmdTurnOffLight(lightOn);

    }


    bool CheckPedestalState(bool isOn)
    {
        if (BlueState == false && PinkState == false)
        {      
            return !isOn;
        }
        else
        {
            return isOn;
        }
    }


    [Command]
    void CmdTurnOffLight(bool isOn)
    {
        RpcTurnOffLight(isOn);
    }

    [ClientRpc]
    void RpcTurnOffLight(bool isOn)
    {
        birdLight.enabled = isOn;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player")) // Player that is colliding with object
        {
            //gameObject.gameObject.GetComponent<NetworkIdentity>().AssignClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            GetComponent<NetworkIdentity>().AssignClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);

            PickUpActivePink = true;
            _playerOneNear = true;
        }

        if (other.gameObject.CompareTag("PlayerTwo")) // Player that is colliding with object
        {
            //gameObject.GetComponent<NetworkIdentity>().AssignClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            GetComponent<NetworkIdentity>().AssignClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            PickUpActiveBlue = true;
            _playerTwoNear = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player")) // Player that is colliding with object
        {
            GetComponent<NetworkIdentity>().RemoveClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            PickUpActivePink = false;
            _playerOneNear = false;
        }
        
        if (other.gameObject.CompareTag("PlayerTwo")) // Player that is colliding with object
        {
            GetComponent<NetworkIdentity>().RemoveClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            PickUpActiveBlue = false;
            _playerTwoNear = false;
        }
    }




}
