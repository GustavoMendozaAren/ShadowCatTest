using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;

public class FMODEvents : MonoBehaviour
{
    private float estadoTransform = 0f; // 0 = Detective, 1 = Gato
    private int estadoPausa = 0; // 0 = Juego, 1 = Pausa.
    private int estadoJuego; // 0 = en juego, 1 = Victoria, 2 = Derrota.

    [field: Header("Level 1 music")]

    FMOD.Studio.EventInstance levelMusic;   
    //public StudioEventEmitter levelMusic;
    //[field: SerializeField] public EventReference level1BG { get; private set; }

    /*[field: Header("Characters")]
    [field: SerializeField] public EventReference characters { get; private set; }*/

    [field: Header("MainMenu")]
    [field: SerializeField] public EventReference mainMenu { get; private set; }

    [field: Header("Video")]
    [field: SerializeField] public EventReference video { get; private set; }

    /*[field: Header("CatSong")]
    [field: SerializeField] public EventReference catSong { get; private set; }

    [field: Header("DetectiveSong")]
    [field: SerializeField] public EventReference detectiveSong { get; private set; }*/



    [field: Header("Shoot SFX")]
    [field: SerializeField] public EventReference shoot { get; private set; }

    [field: Header("EmptyGun SFX")]
    [field: SerializeField] public EventReference emptyGun { get; private set; }

    [field: Header("Transform SFX")]
    [field: SerializeField] public EventReference transformFX { get; private set; }

    [field: Header("Sorpresa")]
    [field: SerializeField] public EventReference sorpresaFX { get; private set; }

    [field: Header("CatDeath")]
    [field: SerializeField] public EventReference catDeath { get; private set; }

    [field: Header("TypeWriter")]
    [field: SerializeField] public EventReference typeWriter { get; private set; }

    [field: Header("PestañaUI")]
    [field: SerializeField] public EventReference pestañaUI { get; private set; }
    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //levelMusic = GetComponent<StudioEventEmitter>();
            levelMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Level 1 music");
        }
        
        
        //levelMusic.start();
    }
    public void FixUpdate()
    {
        SetCapaMusica();
        levelMusic.setParameterByName("enPausa", estadoPausa);
        levelMusic.setParameterByName("nivel", estadoJuego);
    }
    public void SetCapaMusica() // 0 = Detective, 1 = Gato
    {
        if (!StateGameController.isCat)
        {
            estadoTransform = 0f;
            Debug.Log("Detective!");
        }        
        else 
        {
            estadoTransform = 1f;
            Debug.Log("Gato!");
        }
        levelMusic.setParameterByName("estadoTransformacion", estadoTransform);
    }
}
