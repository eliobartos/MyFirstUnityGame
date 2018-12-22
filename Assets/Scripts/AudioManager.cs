using UnityEngine.Audio;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    bool play_fall_sound = true;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("BackgroundMusic");
    }

    public void Play (string name, float pitchVariation = 0)
   {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Check for existance of sound
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        // Vary the parameters
        float old_pitch = s.source.pitch;

        s.source.pitch = Random.Range(s.source.pitch - s.source.pitch * pitchVariation,
                                      s.source.pitch + s.source.pitch * pitchVariation);
        
        // Play Sound
        s.source.Play();

        // Return old parameters
        s.source.pitch = old_pitch;

   }
}
