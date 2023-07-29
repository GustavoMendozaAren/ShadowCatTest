using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMusicEvent : MonoBehaviour
{
    [Header ("CharactersMusic")]
    [SerializeField] private CharactersMusic charact;

    private void Start()
    {
        BGMusicManager.instance.SetCharactersMusic(charact);
    }
}
