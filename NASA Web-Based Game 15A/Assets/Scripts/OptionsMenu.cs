using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    private int soundListSize = 0;
    // Start is called before the first frame update
    private void Start()
    {
        if(GameObject.Find("SoundManager").GetComponent<SoundManager>().soundlist != null)
            soundListSize = GameObject.Find("SoundManager").GetComponent<SoundManager>().soundlist.Length;
    }

    // Used to change volume of in-game background music
    public void AdjustBackgroundVolume(float newVolume)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().soundlist[0].source.volume = newVolume;
        
    }
    
    // Used to change volume of sound effects
    public void AdjustEffectVolume(float newVolume)
    {
        for(var clip = 1; clip < soundListSize; clip++)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().soundlist[clip].source.volume = newVolume;
        }
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("PowerUp");
    }
    
    // Alters fullscreen
    public void ToggleFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
