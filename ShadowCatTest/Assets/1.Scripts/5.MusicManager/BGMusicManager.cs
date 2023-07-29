using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class BGMusicManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;

    private EventInstance level1BGEventInstance;

    private EventInstance charactersEventInstance;
    public static BGMusicManager instance { get; private set; }

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Found more than one BGAudioManager in the scene");
            //Destroy(gameObject);
            //return;
        }

        eventInstances = new List<EventInstance>();
    }

    private void Start()
    {
        //Initializelevel1BG(FMODEvents.instance.level1BG);
        //InitializeCharacters(FMODEvents.instance.characters);
    }

    public void MusicToGo()
    {
        Initializelevel1BG(FMODEvents.instance.level1BG);
        //InitializeCharacters(FMODEvents.instance.characters);
    }
    private void Initializelevel1BG(EventReference level1BGEventreference)
    {
        level1BGEventInstance = CreateEventInstance(level1BGEventreference);
        level1BGEventInstance.start();
    }

    private void InitializeCharacters(EventReference charactersEventReference)
    {
        charactersEventInstance = CreateEventInstance(charactersEventReference);
        charactersEventInstance.start();
    }

    public void SetCharactersMusic(CharactersMusic charact)
    {
        charactersEventInstance.setParameterByName("charact", (float)charact);
    }

    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    private void CleanUo()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy()
    {
        CleanUo();
    }
}
