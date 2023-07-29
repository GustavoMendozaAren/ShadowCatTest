using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBehaviour : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter levelMusic;

    public float estadoTransform = 0f;
    public int estadoPausa = 0;
    public int estadoJuego; // 0 = en juego, 1 = Victoria, 2 = Derrota

    void Start()
    {
        levelMusic = GetComponent<FMODUnity.StudioEventEmitter>();
    }


    void Update()
    {
        levelMusic.EventInstance.setParameterByName("estadoTransformacion", estadoTransform);
        levelMusic.EventInstance.setParameterByName("enPausa", estadoPausa);
        levelMusic.EventInstance.setParameterByName("nivel", estadoJuego);
    }

    public void MusicStart()
    {
        levelMusic.Play();
    }
    public void MusicStop()
    {
        levelMusic.Stop();
    }

    public void setEstadoJuego(int winMusicEstado)
    {
        estadoJuego = winMusicEstado;
    }
}
