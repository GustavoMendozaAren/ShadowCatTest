using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropBala : MonoBehaviour
{
    [SerializeField] private GameObject balaOtlineObj;
    [SerializeField] private GameObject balaSpriteObj;
    [SerializeField] private TextMeshProUGUI timerText;

    private float timer = 6f; 
    private bool isCounting = false;

    float contador = 0, y = 0;
    bool suma;
    private void Update()
    {
        BalaMovimiento();
        BalaContador();
    }

    private void BalaMovimiento()
    {
        if (y <= 0)
        {
            suma = true;
            contador = 0;
        }
        else if (y >= .001f)
        {
            suma = false;
            contador = 0;
        }

        if (suma)
        {
            contador += Time.deltaTime * .001f;

            y = 0 + contador;
            transform.position = new Vector3(transform.position.x, transform.position.y + y, transform.position.z);
        }
        else if (!suma)
        {
            contador += Time.deltaTime * .001f;

            y = .001f - contador;
            transform.position = new Vector3(transform.position.x, transform.position.y - y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BalaSpritesCondiciones();
        }
    }

    private void BalaSpritesCondiciones() 
    {
        balaOtlineObj.SetActive(true);
        balaSpriteObj.SetActive(false);
        isCounting = true;
    }

    private void BalaContador()
    {
        if (isCounting)
        {
            timer -= Time.deltaTime;
            if (timer < 1f)
            {
                isCounting = false;
                timer = 6f;
                OnTimerComplete();
            }
            UpdateTimerText();
        }
    }

    private void OnTimerComplete()
    {
        balaOtlineObj.SetActive(false);
        balaSpriteObj.SetActive(true);
    }

    private void UpdateTimerText()
    {
        int timerInt = Mathf.FloorToInt(timer);
        timerText.text = timerInt.ToString();
    }
}
