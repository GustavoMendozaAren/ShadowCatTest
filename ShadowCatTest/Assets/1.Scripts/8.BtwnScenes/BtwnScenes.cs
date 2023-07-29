using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtwnScenes : MonoBehaviour
{
    public static BtwnScenes instance;

    [HideInInspector]
    public int CoinsCollected;

    [HideInInspector]
    public bool testKey = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }


    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            testKey = true;
            print("TestKeyActivate");
        }
    }*/
}
