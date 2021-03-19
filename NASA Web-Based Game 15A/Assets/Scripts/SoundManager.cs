using System;
using UnityEngine;
using UnityEngine.Audio;

// I used the Manager from this video https://www.youtube.com/watch?v=6OT43pvUyfY.
// Please change it around if anyone has a better way to manage it
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    //stores all the sound clips
    public Sound[] soundlist;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        /*foreach (Sound item in soundlist)
        {
            item.source.volume = item.volume;
        }*/
    }

    // Awake is called before the game starts
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
         
        DontDestroyOnLoad(gameObject);
        // gives each Sound item an AudioSource, audio file,
        //  and volume slider from Sound class
        foreach (Sound item in soundlist)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;
            item.source.volume = item.volume;
            item.source.loop = item.loop;
        }
    }

    // Plays audio clip when called, used in other scripts when
    // clip is needed
    public void PlaySound(string name)
    {
        Sound s = Array.Find(soundlist, sound => sound.clipName == name);
        if(ReferenceEquals(s, null))
        {
          //Debug.LogWarning(name + " does not exist");
          return;
        }
        s.source.Play();
    }

    // Plays audio clip when called, used in other scripts when
    // clip is needed
    public void StopSound(string name)
    {
        Sound s = Array.Find(soundlist, sound => sound.clipName == name);
        if(ReferenceEquals(s, null))
        {
            return;
        }
        s.source.Stop();
     }
}
