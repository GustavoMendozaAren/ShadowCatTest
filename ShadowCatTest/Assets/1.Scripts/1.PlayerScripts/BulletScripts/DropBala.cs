using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropBala : MonoBehaviour
{
    [SerializeField] private GameObject balaSpriteObj;
    [SerializeField] private GameObject balaOulineSpriteObj;
    [SerializeField] private Image bulletCountdownImg;
    private Collider2D balaCollider;

    private float timer = 6f; 
    private float timer2 = 0f; 
    private bool isCounting = false;

    float contador = 0, y = 0;
    bool suma;

    private void Awake()
    {
        balaCollider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        bulletCountdownImg.fillAmount = 0;
        balaCollider.enabled = true;
    }

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
        bulletCountdownImg.enabled = true;
        balaSpriteObj.SetActive(false);
        balaOulineSpriteObj.SetActive(true);
        isCounting = true;
        balaCollider.enabled = false;
    }

    private void BalaContador()
    {
        if (isCounting)
        {
            timer -= Time.deltaTime;
            timer2 += Time.deltaTime;
            bulletCountdownImg.fillAmount = timer2 / 5f;
            if (timer < 1f)
            {
                isCounting = false;
                timer = 6f;
                OnTimerComplete();
                balaCollider.enabled = true;
            }
            if (timer2 > 5f)
            {
                isCounting = false;
                timer2 = 0f;
                OnTimerComplete();
            }
        }
    }

    private void OnTimerComplete()
    {
        balaSpriteObj.SetActive(true);
        balaOulineSpriteObj.SetActive(false);
        bulletCountdownImg.enabled = false;
    }
}
