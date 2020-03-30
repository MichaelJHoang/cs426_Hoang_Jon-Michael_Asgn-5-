using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPedestalLogic_AND : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PedestalOne;
    [SerializeField] TextMeshProUGUI PedestalTwo;
    [SerializeField] GameObject BirdLight;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(PedestalOne.GetParsedText().Equals("1") && PedestalTwo.GetParsedText().Equals("1"))
        {
            BirdLight.gameObject.SetActive(true);
        }
        else
        {
            BirdLight.gameObject.SetActive(false);
        }

    }
}
