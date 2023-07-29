using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public void PlayOneShot2(EventReference sound)
    {
        RuntimeManager.PlayOneShot(sound);
    }
}
