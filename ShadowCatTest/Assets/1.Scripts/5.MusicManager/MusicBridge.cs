using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MusicBridge : MonoBehaviour // MusicBridge conecta los distintos scripts del juego con MusicBehaviour.
{
    public MusicBehaviour musicBehaviourInstance;

    void Start()
    {
        musicBehaviourInstance = GetComponent<MusicBehaviour>();
    }

    public void NotificarCambioMusica(string evento, bool valor)
    {
        switch (evento)
        {
            case "EsGato":
                MusicNotificarTransformGato(valor);
                break;
            case "RalentizarEnUso":
                MusicNotificarRalentizado(valor);
                break;
            case "Pausa":
                MusicNotificarPausa(valor);
                break;
            case "BajoEnVida":
                throw new NotImplementedException();
            default:
                throw new ArgumentException("ERROR.Parámetro no válido.");
        }
    }
    public void NotificarCambioMusica(string evento)
    {
        switch (evento)
        {
            case "JuegoEnCurso":
                MusicNotificarFinJuego(0);
                break;
            case "Ganar":
                MusicNotificarFinJuego(1);
                break;
            case "Perder":
                MusicNotificarFinJuego(2);
                break;
            case "Acorde":
                MusicNotificarAcorde();
                break;
            case "NoDestruir":
                musicBehaviourInstance.DontDestroyMusic();
                break;
            default:
                throw new ArgumentException("ERROR.Parámetro no válido.");
        }
    }

    public void DestroyMusic()
    {
        musicBehaviourInstance.DestroyMusic();
    }

    private void MusicNotificarTransformGato(bool isCat)
    {
        musicBehaviourInstance.OnPlayerTransformed(isCat);
    }
    private void MusicNotificarRalentizado(bool estaRalentizando)
    {
        musicBehaviourInstance.OnSlowMotionEnabled(estaRalentizando);
    }
    private void MusicNotificarPausa(bool estaPausado)
    {
        musicBehaviourInstance.OnGamePaused(estaPausado);
    }
    private void MusicNotificarFinJuego(int estadoJuego)
    {
        musicBehaviourInstance.OnGameStateChanged(estadoJuego); // 0 = en juego, 1 = Victoria, 2 = Derrota. 
    }
    private void MusicNotificarAcorde()
    {
        musicBehaviourInstance.OnItemPickedUp();       
    }
} 

