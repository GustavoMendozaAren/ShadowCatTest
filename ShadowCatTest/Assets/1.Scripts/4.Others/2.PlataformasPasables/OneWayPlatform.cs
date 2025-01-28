using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    [SerializeField] private GameObject platformCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(DesactivacionPorSegundos());
        }
    }

    IEnumerator DesactivacionPorSegundos()
    {
        platformCollider.SetActive(false);
        yield return new WaitForSeconds(.7f);
        platformCollider.SetActive(true);
    }

}
