using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ExamplePuzzles : NetworkBehaviour
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
    public float requiredElapsedTime = 5.0f;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        PedestalText.text = "1";
        PedestalBird.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.deltaTime + timeElapsed;

        if (_PedestalActive == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && timeElapsed >= requiredElapsedTime)
            {
                if (_BirdVisible == true)
                {
                    CmdPickUpBird_p1(0);
                }
                else if (_BirdVisible == false)
                {

                    Debug.Log(CharacterInfo.getCharInfo().getPreviousNumBird());
                    CmdPickUpBird_p1(0);
                    
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

            if (PedestalID == 10) { TurnOnOffPuzzleLight.P1_BluePedestal = false; }
            else if (PedestalID == 11) { TurnOnOffPuzzleLight.P1_PinkPedestal = false; }
            else if (PedestalID == 12) { TurnOnOffPuzzleLight.P2_BluePedestal = false; }
            else if (PedestalID == 13) { TurnOnOffPuzzleLight.P2_PinkPedestal = false; }


        }
        else
        {
            PedestalBird.gameObject.SetActive(true);
            PedestalText.text = "1";
            _BirdVisible = true;

            if (PedestalID == 10) { TurnOnOffPuzzleLight.P1_BluePedestal = true; }
            else if (PedestalID == 11) { TurnOnOffPuzzleLight.P1_PinkPedestal = true; }
            else if (PedestalID == 12) { TurnOnOffPuzzleLight.P2_BluePedestal = true; }
            else if (PedestalID == 13) { TurnOnOffPuzzleLight.P2_PinkPedestal = true; }

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
