using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContenedoresInteraction : MonoBehaviour
{
    [SerializeField] private GameObject contendorAbierto;
    [SerializeField] private GameObject objetoOculto;

    private SpriteRenderer contendorCerradoSprite;

    private void Start()
    {
        contendorCerradoSprite = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        contendorCerradoSprite.enabled = false;
        contendorAbierto.SetActive(true);
        objetoOculto.SetActive(true);
    }
}
