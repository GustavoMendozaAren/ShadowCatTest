using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;
public interface IMusicObserver
{
    void OnPlayerTransformed(bool isCat);
    void OnSlowMotionEnabled(bool isSlowMotionEnabled);
    void OnGamePaused(bool isGamePaused);
    void OnGameStateChanged(int gameState); // 0 = playing, 1 = victory, 2 = defeat
}

public class MusicBehaviour : MonoBehaviour, IMusicObserver
{
    public StudioEventEmitter levelMusic;

    void Awake()
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
        Debug.Log("Notificación de transformación recibida en MusicBehavior.");
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
        }
    }
    public void OnGamePaused(bool isGamePaused)
    {
        if (!isGamePaused)
        {
            Debug.Log("Musica en modo normal.");
            levelMusic.SetParameter("enPausa", 0);
        }
        else
        {
            Debug.Log("Musica en modo pausa.");
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
}
