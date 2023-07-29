using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class VideoMusic : MonoBehaviour
{
    private List<EventInstance> eventInstances;

    private EventInstance mainMenuEventInstance;

    public static VideoMusic instance { get; private set; }

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
        InitializeMainMenu(FMODEvents.instance.video);
    }
    private void InitializeMainMenu(EventReference mainMenuEventreference)
    {
        mainMenuEventInstance = CreateEventInstance(mainMenuEventreference);
        mainMenuEventInstance.start();
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
