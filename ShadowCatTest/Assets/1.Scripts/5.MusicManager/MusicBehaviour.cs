using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;
using System.Data;
interface IMusicObserved // Esta interfaz será dada a toda clase que quiera interactuar con MusicBehaviour.
{
    public MusicBehaviour MusicBehaviourInstance { get; set; }
    public IMusicObserver MusicObserverInstance { get; set; }

    public void MusicNotificarTransformGato(bool isCat)
    {
        MusicObserverInstance.OnPlayerTransformed(isCat);
    }
    public void MusicNotificarRalentizado(bool estaRalentizando)
    {
        MusicObserverInstance.OnSlowMotionEnabled(estaRalentizando);
    }
    public void MusicNotificarPausa(bool estaPausado)
    {
        MusicObserverInstance.OnGamePaused(estaPausado);
    }
    public void MusicNotificarFinJuego(int estadoJuego)
    {
        MusicObserverInstance.OnGameStateChanged(estadoJuego); // 0 = en juego, 1 = Victoria, 2 = Derrota. 
    }
    void Start()
    {
        GameObject instanciaMusic = GameObject.Find("Music");
        MusicBehaviourInstance = instanciaMusic.GetComponent<MusicBehaviour>();
        MusicObserverInstance = MusicBehaviourInstance;
    }
}
public interface IMusicObserver // Está inferfaz será dada a MusicBehaviour o cualquier clase similar o que herede de ella.
{    
    void OnPlayerTransformed(bool isCat);
    void OnSlowMotionEnabled(bool isSlowMotionEnabled);
    void OnGamePaused(bool isGamePaused);
    void OnGameStateChanged(int gameState); // 0 = playing, 1 = victory, 2 = defeat
}

[RequireComponent(typeof(StudioEventEmitter))]
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
    public void OnGamePaused(bool isGamePaused)
    {
        if (!isGamePaused)
        {
            //Debug.Log("Musica en modo normal.");
            levelMusic.SetParameter("enPausa", 0);
        }
        else
        {
            //Debug.Log("Musica en modo pausa.");
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

