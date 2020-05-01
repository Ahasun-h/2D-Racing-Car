using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseResumeBTN : MonoBehaviour
{

    public Sprite pauseSprite;
    public Sprite playSprite;

    public void PauseResumeToggle()
    {

        if(Time.timeScale != 0)
        {
            GetComponent<Image>().sprite = playSprite;
            Time.timeScale = 0;
            return;
        }
        if(Time.timeScale == 0)
        {
            GetComponent<Image>().sprite = pauseSprite;
            Time.timeScale = 1;
            return;
        }

        
    }

}
