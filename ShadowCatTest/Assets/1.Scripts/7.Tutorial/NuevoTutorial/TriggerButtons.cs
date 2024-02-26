using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButtons : MonoBehaviour
{
    [SerializeField]
    int identificador = 0;

    [SerializeField]
    GameObject buttonAppear;

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttonAppear.SetActive(true);
            gameObject.SetActive(false);
        }
    }


}
