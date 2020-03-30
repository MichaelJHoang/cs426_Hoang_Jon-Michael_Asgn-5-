using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo
{
    private double numHead = 0;
    private double numBody = 0;
    private double numFeet = 0;
    private int numBird = 0;
    private int previousNumBird = 0;
    private static CharacterInfo characterInfo;

    private CharacterInfo() { }

    public static CharacterInfo getCharInfo()
    {
        if (characterInfo == null)
        {
            characterInfo = new CharacterInfo();
        }
        return characterInfo;
    }

    public void incrementParts(string partName, double increamentAmount)
    {
        if (partName.Contains("redBirdBody") || partName.Contains("PurpleBirdBody"))
            numBody += increamentAmount;
        else if (partName.Contains("redBirdFeet") || partName.Contains("PurpleBirdFeet"))
            numFeet += increamentAmount;
        else if (partName.Contains("redBirdHead") || partName.Contains("PurpleBirdHead"))
            numHead += increamentAmount;
    }

    public void buildBird()
    {
        if (numHead >= 1 && numBody >= 1 && numFeet >= 1)      //Increment bird if enough pieces and subtract other pieces
        {
            numBird++;
            numBody--;
            numHead--;
            numFeet--;
        }
    }

    public void getBird()
    {
        numBird++;
    }

    public int getPreviousNumBird()
    {
        return previousNumBird;
    }

    public void useBird()
    {
        previousNumBird = numBird;
        numBird--;
    }

    public double getNumHead()
    {
        return numHead;         //Get the number of head
    }

    public double getNumBody()
    {
        return numBody;       //Get the number of body
    }

    public double getNumFeet()
    {
        return numFeet;       //Get the number of feet
    }

    public int getNumBird()
    {
        return numBird;
    }

    public void useCheat()
    {
        numHead = 0;
        numBody = 0;
        numFeet = 0;
        numBird = 6;
        previousNumBird = 5;
    }

}
