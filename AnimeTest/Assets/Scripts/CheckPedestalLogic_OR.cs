using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class CheckPedestalLogic_OR : NetworkBehaviour
{


    public Text _BlueText;
    public Text _PinkText;

    //[ClientRpc]
    void ChangeLight()
    {
        if (_BlueText.Equals("0") && _PinkText.Equals("0"))
        {
        
        }
        else
        {
          
        }
    }


    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        ChangeLight();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

        }

    }






}
