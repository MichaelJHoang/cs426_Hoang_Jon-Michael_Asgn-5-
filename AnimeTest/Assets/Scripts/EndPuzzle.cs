﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EndPuzzle : NetworkBehaviour
{
    public GameObject PedestalBird;
    public Text PedestalText;
    public int SolutionNumberState;
    public int PedestalID;
    public string SetPedestalToPlayer;

    private bool _PlayerNear = false;
    private bool _PedestalActive = false;
    private bool _BirdVisible = false;
    private float timeElapsed = 0;
    public float requiredElapsedTime = 2.0f;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameObject ob = SpawnPedestal.M_birdmap[SetPedestalNumber];
        PedestalText.text = "0";
        PedestalBird.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.deltaTime + timeElapsed;

        if (_PedestalActive == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && timeElapsed >= requiredElapsedTime)
            {
                timeElapsed = 0;
                if (_BirdVisible == true)
                {
                    CmdPickUpBird_p1(0);
                }
                else if (_BirdVisible == false)
                {
                    if (CharacterInfo.getCharInfo().getPreviousNumBird() > 0)
                    {
                        Debug.Log(CharacterInfo.getCharInfo().getPreviousNumBird());
                        CmdPickUpBird_p1(0);
                    }
                }
            }

        }
    }

    [Command]
    public void CmdPickUpBird_p1(int playerNear)
    {
        RpcPickUpBird_p1(playerNear);
    }

    [ClientRpc]
    void RpcPickUpBird_p1(int playerNear)
    {

        if (_BirdVisible == true)
        {
            PedestalBird.gameObject.SetActive(false);
            PedestalText.text = "0";
            _BirdVisible = false;

            if (PedestalID == 1) { EndScene.R_Bird1 = false; }
            else if (PedestalID == 3) { EndScene.R_Bird2 = true; }
            else if (PedestalID == 5) { EndScene.R_Bird3 = false; }
            else if (PedestalID == 2) { EndScene.P_Bird1 = false; }
            else if (PedestalID == 4) { EndScene.P_Bird2 = false; }
            else if (PedestalID == 6) { EndScene.P_Bird3 = false; }

        }
        else
        {
            PedestalBird.gameObject.SetActive(true);
            PedestalText.text = "1";
            _BirdVisible = true;

            if (PedestalID == 1) { EndScene.R_Bird1 = true; }
            else if (PedestalID == 3) { EndScene.R_Bird2 = false; }
            else if (PedestalID == 5) { EndScene.R_Bird3 = true; }
            else if (PedestalID == 2) { EndScene.P_Bird1 = true; }
            else if (PedestalID == 4) { EndScene.P_Bird2 = true; }
            else if (PedestalID == 6) { EndScene.P_Bird3 = true; }

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(SetPedestalToPlayer)) // Player that is colliding with object
        {
            GetComponent<NetworkIdentity>().AssignClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);

            _PedestalActive = true;
            _PlayerNear = true;
        }

    }


    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag(SetPedestalToPlayer)) // Player that is colliding with object
        {
            GetComponent<NetworkIdentity>().RemoveClientAuthority(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            _PedestalActive = false;
            _PlayerNear = false;
        }

    }

}