using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;
using System.Data;

[RequireComponent(typeof(StudioEventEmitter), typeof(MusicBridge))]
[HelpURL("")]
public class MusicBehaviour : MonoBehaviour
{
    
    public StudioEventEmitter levelMusic;
    public static MusicBehaviour instance { get; private set; }

    private void Awake()
    {
        levelMusic = GetComponent<FMODUnity.StudioEventEmitter>(); 
    }


    #region Métodos para actualizar
    public void OnPlayerTransformed(bool isCat) // 0 = Detective, 1 = Gato
    {
        if (!isCat)
        {
            levelMusic.SetParameter("capaTransformacion", 0f);
        }
        else levelMusic.SetParameter("capaTransformacion", 1f);
    }
    public void OnSlowMotionEnabled(bool isSlowMotionEnabled)
    {
        if (!isSlowMotionEnabled)
        {
            levelMusic.SetParameter("capaRalentizado", 0);
        } 
        else
        {
            levelMusic.EventInstance.setParameterByName("capaRalentizado", 1);
        }
    }
    public void OnGameStateChanged(int gameState)
    {
        switch (gameState)
        {
            case 0: // Normal
                levelMusic.SetParameter("estadoNivel", 0);
                break;
            case 1: // Ganar
                levelMusic.SetParameter("estadoNivel", 1);
                break;
            case 2: // Perder
                levelMusic.SetParameter("estadoNivel", 2);
                break;
            default:
                throw new ArgumentException("ERROR. MusicNotificarFinJuego() solo debe tener como parámetro los valores 0, 1 o 2.");
        }
    }
    public void OnItemPickedUp()
    {
        levelMusic.SetParameter("triggerChord", 1);
        new WaitForSeconds(0.1f); //Hacer con Corrutina
        levelMusic.SetParameter("triggerChord", 0);
    }
    public void OnGamePaused(bool isGamePaused)
    {
        if (!isGamePaused)
        {
            levelMusic.SetParameter("enPausa", 0);
        }
        else
        {
            levelMusic.SetParameter("enPausa", 1);            
        }
    }
    #endregion


    public void MusicStart()
    {
        levelMusic.Play();
    }
    public void MusicStop()
    {
        levelMusic.Stop();
    }
    public void DestroyMusic()
    {
        Destroy(gameObject);
    }
    public void DontDestroyMusic()
    {
        DontDestroyOnLoad(gameObject);
    }
}

