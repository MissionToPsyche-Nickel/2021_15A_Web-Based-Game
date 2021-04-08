using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private int soundListSize = 0;
    public Slider bgSlider;
    public Slider seSlider;
    // Start is called before the first frame update
    private void Start()
    {
        if(GameObject.Find("SoundManager").GetComponent<SoundManager>().soundlist != null)
            soundListSize = GameObject.Find("SoundManager").GetComponent<SoundManager>().soundlist.Length;
        bgSlider.value = GameObject.Find("SoundManager").GetComponent<SoundManager>().soundlist[0].source.volume;
        seSlider.value = GameObject.Find("SoundManager").GetComponent<SoundManager>().soundlist[1].source.volume;

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
