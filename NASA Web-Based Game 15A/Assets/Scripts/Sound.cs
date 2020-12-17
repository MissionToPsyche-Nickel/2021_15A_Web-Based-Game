using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string clipName;
    // Audio file
    public AudioClip clip;
    public bool loop;
    //Range for volume slider
    [Range(0f, 1f)]
    public float volume;
    
    // Not needed in inspector since the AudioSource is
    // already added
    [HideInInspector] 
    public AudioSource source;
}
