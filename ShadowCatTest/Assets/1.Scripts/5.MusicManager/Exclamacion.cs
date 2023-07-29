using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclamacion : MonoBehaviour
{
    public void Sonido()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.sorpresaFX, this.transform.position);
    }
}
