using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField] private AudioClip clip = null;
    [SerializeField] [Range(0f, 1f)] private float volume = 0.5f;
    [SerializeField] [Range(0f, 3f)] private float pitch = 1f;


    public AudioClip Clip => clip;
    
    public float Volume => volume;

    public float Pitch => pitch;
}
