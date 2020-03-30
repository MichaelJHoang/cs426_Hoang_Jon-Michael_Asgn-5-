using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerActions : NetworkBehaviour
{
    private Dictionary<string, int> map = new Dictionary<string, int>();
    private bool pickedUp = false;
    private string partColor;
    private float timeElapsed = 0;
    public float requiredElapsedTime = 2.0f;

    private void Update()
    {
        pickedUp = false;
        timeElapsed = Time.deltaTime + timeElapsed;
    }

    void Start()
    {
        if (gameObject.tag.Equals("Red"))
            partColor = "Red";
        else
            partColor = "Purple";
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (partColor.Equals("Red") && other.gameObject.CompareTag("Player"))
        {
            CmdAssignAuthority(other.gameObject);
        }
        else if (partColor.Equals("Purple") && other.gameObject.CompareTag("PlayerTwo"))
        {
            CmdAssignAuthority(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Press P to pick up item
        if (Input.GetKey(KeyCode.P) && timeElapsed >= requiredElapsedTime)
        {
            timeElapsed = 0;
            if (gameObject.tag.Equals("Red") && other.gameObject.CompareTag("Player"))
            {
                allowPickUpMethod();
                CharacterInfo.getCharInfo().incrementParts(gameObject.name, 1);
                CharacterInfo.getCharInfo().buildBird();
            }
            else if (gameObject.tag.Equals("Purple") && other.gameObject.CompareTag("PlayerTwo"))
            {
                allowPickUpMethod();
                CharacterInfo.getCharInfo().incrementParts(gameObject.name, 1);
                CharacterInfo.getCharInfo().buildBird();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CmdRemoveAuthority(other.gameObject);
    }

    private void allowPickUpMethod()
    {
        if (pickedUp == false)
        {
            pickedUp = true;
            CmdPickUpObjects();
        }
    }

    [Command]
    void CmdPickUpObjects()
    {
        RpcPickUpObjects();
    }

    [ClientRpc]
    void RpcPickUpObjects()
    {
        //Dont Destroy Destroy(gameObject);
        gameObject.SetActive(false);
    }

    [Command]
    void CmdAssignAuthority(GameObject ob)
    {
        gameObject.GetComponent<NetworkIdentity>().AssignClientAuthority(ob.GetComponent<NetworkIdentity>().connectionToClient);
    }

    [Command]
    void CmdRemoveAuthority(GameObject ob)
    {
        gameObject.GetComponent<NetworkIdentity>().RemoveClientAuthority(ob.GetComponent<NetworkIdentity>().connectionToClient);
    }
}
