using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class UIText : MonoBehaviour
{
    public string pickUpOrPlaceString;      //Text to pickup items on the floor
    public string partsStatusString;        //Shows the status of the parts

    public Text pickUpOrPlaceText;
    public Text partsStatus;

    private static UIText instance;

    private UIText() { }


    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pickUpOrPlaceText.text = "";
        partsStatus.text = "Head: 0 Body: 0 Feet: 0 Bird: 0";
    }

    public void changeText(string text)
    {
        pickUpOrPlaceText.text = text;
    }

    public void updatePartsStatus(double headNum, double bodyNum, double feetNum, int birdNum)
    {
        partsStatus.text = "Head: " + headNum + " Body: " + bodyNum + " Feet: " + feetNum + " Bird: " + birdNum;
    }


    public void showPickUpText()
    {
        pickUpOrPlaceText.text = "Press P To Pick Up Part!";
    }

    public void showPickUpBirdText()
    {
        pickUpOrPlaceText.text = "Press P To Pick Up Bird!";
    }

    public void showPlaceText()
    {
        pickUpOrPlaceText.text = "Press O To Place Bird!";
    }

    public void notEnoughBirds()
    {
        pickUpOrPlaceText.text = "Not Enough Birds!";
    }

    public void deleteText()
    {
        pickUpOrPlaceText.text = "";
    }

    public void notCompatibleText()
    {
        pickUpOrPlaceText.text = "The Part Color Does Not Match Yours.";
    }

}
