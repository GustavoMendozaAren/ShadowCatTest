using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class VolumeController : MonoBehaviour
{
    VCA masterVCA;
    VCA musicVCA;
    VCA sfxVCA;    
    VCA ambientVCA;
    VCA cinematicVCA;


    [Range(0f, 1f)] public static float masterVolume = 0.75f;
    [Range(0f, 1f)] public static float musicVolume = 0.75f;
    [Range(0f, 1f)] public static float sfxVolume = 0.75f;
    [Range(0f, 1f)] public static float ambientVolume = 0.75f;
    [Range(0f, 1f)] public static float cinematicVolume = 0.75f;

    private void Awake()
    {
        masterVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Master");
        musicVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Music");
        sfxVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Sfx");        
        ambientVCA = FMODUnity.RuntimeManager.GetVCA("vca:/AmbientSounds");
        cinematicVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Cinematic");
        
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        masterVCA.setVolume(masterVolume);
        musicVCA.setVolume(musicVolume);
        sfxVCA.setVolume(sfxVolume);
        ambientVCA.setVolume(ambientVolume);
        cinematicVCA.setVolume(cinematicVolume);
    }
}
