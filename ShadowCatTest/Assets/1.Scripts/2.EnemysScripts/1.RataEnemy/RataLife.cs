using System.Collections;
using UnityEngine;

public class RataLife : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rataSprite;

    private int rataLife = 2;
    private Coroutine damageCoroutine;

    public bool IsDead = false;

    private void QuitarVidaRata()
    {
        rataLife -= 1;

        if (rataLife <= 0)
        {
            IsDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TriggerFlash();
            QuitarVidaRata();
        }
    }

    private void TriggerFlash()
    {
        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            rataSprite.color = new Color(1f, 1f, 1f, 1f);
        }

        damageCoroutine = StartCoroutine(DamageColor());
    }

    IEnumerator DamageColor()
    {
        for (int i = 0; i < 2; i++)
        {
            rataSprite.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(.1f);
            rataSprite.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(.1f);
        }

        damageCoroutine = null;
    }
}
