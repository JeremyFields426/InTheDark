using UnityEngine;
using UnityEngine.Audio;
using System.Linq;
using System.Collections.Generic;

public class SoundSystem : MonoBehaviour
{
    private Queue<AudioSource> sourcePool = new Queue<AudioSource>();

    [SerializeField] private int poolSize = 8;
    [SerializeField] private AudioMixer mainMixer = null;


    private void Awake()
    {
        PopulatePool();
        RegisterPreExistingCallbacks();
    }

    private void OnEnable()
    {
        ObjectPooler.ObjectCreatedCallback += OnObjectCreated;
    }

    private void OnDisable()
    {
        ObjectPooler.ObjectCreatedCallback -= OnObjectCreated;
    }

    private void PopulatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;

            sourcePool.Enqueue(source);
        }
    }

    private void RegisterPreExistingCallbacks()
    {
        // TODO: This will not work for GameObjects that are inactive.
        foreach (IPlaySound soundComp in FindObjectsOfType<MonoBehaviour>().OfType<IPlaySound>())
        {
            soundComp.PlaySoundCallback += PlaySound;
        }
    }

    private void OnObjectCreated(GameObject obj)
    {
        foreach (IPlaySound soundComp in obj.GetComponentsInChildren<IPlaySound>(true))
        {
            soundComp.PlaySoundCallback += PlaySound;
        }
    }

    private void PlaySound(Sound sound)
    {
        if (sound == null || sound.Clip == null) { return; }

        AudioSource source = (sourcePool.Count > 0) ? sourcePool.Dequeue() : gameObject.AddComponent<AudioSource>();

        if (!source.isActiveAndEnabled) { return; }
 
        mainMixer.GetFloat("MasterVolume", out float masterVolume);

        source.clip = sound.Clip;
        source.volume = sound.Volume * (masterVolume / -80f);
        source.pitch = sound.Pitch;
        source.Play();

        sourcePool.Enqueue(source);
    }
}
