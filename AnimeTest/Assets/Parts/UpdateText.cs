using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    public Text pickUpOrPlaceText;
    public Text partsStatusText;

    bool cheatCodeAvailible = true;
    private float timeElapsed = 0;
    public float requiredElapsedTime = 2.0f;

    private void Start()
    {
        pickUpOrPlaceText.text = "";
        partsStatusText.text = "Head: 0 Body: 0 Feet: 0 Bird: 0";
    }

    void Update()
    {
        timeElapsed = Time.deltaTime + timeElapsed;

        if (Input.GetKeyDown(KeyCode.L) && cheatCodeAvailible)
        {
            cheatCodeAvailible = false;
            CharacterInfo.getCharInfo().useCheat();
            updatePartsStatus(CharacterInfo.getCharInfo().getNumHead(), CharacterInfo.getCharInfo().getNumBody(), CharacterInfo.getCharInfo().getNumFeet(), CharacterInfo.getCharInfo().getNumBird());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Red") || other.gameObject.CompareTag("Purple"))
        {
            if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Red"))
            {
                pickUpOrPlaceText.text = "Press P To Pick Up Part!";
            }
            else if (gameObject.tag.Equals("PlayerTwo") && other.gameObject.CompareTag("Purple"))
            {
                pickUpOrPlaceText.text = "Press P To Pick Up Part!";
            }
            else
                pickUpOrPlaceText.text = "The Part Color Does Not Match Yours.";
        }
        else if (gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("Pedestal4"))
            {
                PedestalText("Bird4");
            }
            else if (other.gameObject.CompareTag("Pedestal5"))
            {
                PedestalText("Bird5");
            }
            else if (other.gameObject.CompareTag("Pedestal6"))
            {
                PedestalText("Bird6");
            }
            else if (other.gameObject.CompareTag("Pedestal11"))
            {
                //PedestalText("Bird5");
            }
            else if (other.gameObject.CompareTag("Pedestal13"))
            {
                //PedestalText("Bird6");
            }
            else
            {
                pickUpOrPlaceText.text = "This Is Not Your Pedestal!";
            }

        }
        else if (gameObject.CompareTag("PlayerTwo"))
        {
            if (other.gameObject.CompareTag("Pedestal1"))
            {
                PedestalText("Bird1");
            }
            else if (other.gameObject.CompareTag("Pedestal2"))
            {
                PedestalText("Bird2");
            }
            else if (other.gameObject.CompareTag("Pedestal3"))
            {
                PedestalText("Bird3");
            }

            else if (other.gameObject.CompareTag("Pedestal10"))
            {
                //PedestalText("Bird2");
            }
            else if (other.gameObject.CompareTag("Pedestal12"))
            {
                //PedestalText("Bird3");
            }
            else
            {
                pickUpOrPlaceText.text = "This Is Not Your Pedestal!";
            }
        }


    }

    private void OnTriggerStay(Collider other)
    {
        //Press P to pick up item
        if (Input.GetKey(KeyCode.P))
        {
            if (gameObject.tag.Equals("Player") && other.gameObject.CompareTag("Red"))
            {
                pickUpOrPlaceText.text = "";
                updatePartsStatus(CharacterInfo.getCharInfo().getNumHead(), CharacterInfo.getCharInfo().getNumBody(), CharacterInfo.getCharInfo().getNumFeet(), CharacterInfo.getCharInfo().getNumBird());
            }
            else if (gameObject.tag.Equals("PlayerTwo") && other.gameObject.CompareTag("Purple"))
            {
                pickUpOrPlaceText.text = "";
                updatePartsStatus(CharacterInfo.getCharInfo().getNumHead(), CharacterInfo.getCharInfo().getNumBody(), CharacterInfo.getCharInfo().getNumFeet(), CharacterInfo.getCharInfo().getNumBird());
            }
            else
                pickUpOrPlaceText.text = "The Part Color Does Not Match Yours.";
        }
        else if (Input.GetKeyDown(KeyCode.E) && timeElapsed >= requiredElapsedTime)
        {
            timeElapsed = 0;
            if (gameObject.CompareTag("Player"))
            {
                if (other.gameObject.CompareTag("Pedestal4"))
                {
                    pickUpOrPlaceMethod("Bird4");
                }
                else if (other.gameObject.CompareTag("Pedestal5"))
                {
                    pickUpOrPlaceMethod("Bird5");
                }
                else if (other.gameObject.CompareTag("Pedestal6"))
                {
                    pickUpOrPlaceMethod("Bird6");
                }
            }

            else if (gameObject.CompareTag("PlayerTwo"))
            {
                if (other.gameObject.CompareTag("Pedestal1"))
                {
                    pickUpOrPlaceMethod("Bird1");
                }
                else if (other.gameObject.CompareTag("Pedestal2"))
                {
                    pickUpOrPlaceMethod("Bird2");
                }
                else if (other.gameObject.CompareTag("Pedestal3"))
                {
                    pickUpOrPlaceMethod("Bird3");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickUpOrPlaceText.text = "";
    }

    public void updatePartsStatus(double headNum, double bodyNum, double feetNum, int birdNum)
    {
        partsStatusText.text = "Head: " + headNum + " Body: " + bodyNum + " Feet: " + feetNum + " Bird: " + birdNum;
    }

    public void PedestalText(string birdNum)
    {
        if (GameObject.FindGameObjectWithTag(birdNum) == null)
        {
            pickUpOrPlaceText.text = "Press E To Place Bird!";
        }
        else
        {
            pickUpOrPlaceText.text = "Press E To Pick Up Bird!";
        }
    }

    public void pickUpOrPlaceMethod(string birdNum)
    {
        if (GameObject.FindGameObjectWithTag(birdNum) == null)
        {
            if (CharacterInfo.getCharInfo().getNumBird() > 0)
            {
                CharacterInfo.getCharInfo().useBird();
                updatePartsStatus(CharacterInfo.getCharInfo().getNumHead(), CharacterInfo.getCharInfo().getNumBody(), CharacterInfo.getCharInfo().getNumFeet(), CharacterInfo.getCharInfo().getNumBird());
            }
            else
            {
                pickUpOrPlaceText.text = "No Availible Bird!";
            }
        }
        else
        {
            CharacterInfo.getCharInfo().getBird();
            updatePartsStatus(CharacterInfo.getCharInfo().getNumHead(), CharacterInfo.getCharInfo().getNumBody(), CharacterInfo.getCharInfo().getNumFeet(), CharacterInfo.getCharInfo().getNumBird());
        }
    }


}
