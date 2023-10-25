using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite redEye;
    public Sprite greenEye;
    public Sprite blueEye;
    public Sprite yellowEye;



    void Start()
    {
       /* redEye = Resources.Load<Sprite>("Assets\\Materials\\UI\\Eyes\\EyeRed.png");
        greenEye = Resources.Load<Sprite>("Assets\\Materials\\UI\\Eyes\\EyeGreen.png");
        blueEye = Resources.Load<Sprite>("Assets\\Materials\\UI\\Eyes\\EyeBlue.png");
        yellowEye = Resources.Load<Sprite>("Materials/UI/Eyes/EyeYellow.png");*/
    }

    // Update is called once per frame
    public void ChangeToRed()
    {
        gameObject.GetComponent<Image>().sprite = redEye;
    }

    public void ChangeToGreen()
    {
        gameObject.GetComponent<Image>().sprite = greenEye;
    }

    public void ChangeToBlue() {
        gameObject.GetComponent<Image>().sprite = blueEye;
    }

    public void ChangeToYellow() {
        gameObject.GetComponent<Image>().sprite = yellowEye;
    }

}
