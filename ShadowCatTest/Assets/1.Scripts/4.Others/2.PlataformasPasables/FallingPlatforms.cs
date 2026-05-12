using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FallingPlatforms : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private GameObject colliderParent;
    [SerializeField] private Light2D lightPlatform;

    private SwitchLite switchLite;
    private float fadeOut = 1f;
    private float timeToDesapear = 2f;
    private bool isDesappearing = false;
    private bool isReapearing = false;

    private void Start()
    {
        switchLite = FindFirstObjectByType<SwitchLite>();
    }

    private void Update()
    {
        if (isReapearing)
        {
            ReapearingPlatform();
        }

        if (isDesappearing)
        {
            if (fadeOut > 0)
            {
                fadeOut = fadeOut - Time.deltaTime * 1f;
                lightPlatform.intensity = lightPlatform.intensity - ((Time.deltaTime * 1f) * 3f);
                spriteRenderer.color = new Color(0, 0, 0, fadeOut);
            }
            else
            {
                lightPlatform.intensity = 0;
                fadeOut = 0;
                
                colliderParent.SetActive(false);
                isDesappearing = false;

                Invoke(nameof(SetReapearing), timeToDesapear);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && switchLite.IsOnGround)
        {
            isDesappearing = true;
        }
    }

    private void SetReapearing()
    {
        isReapearing = true;
    }

    private void ReapearingPlatform()
    {
        if (fadeOut < 1f)
        {
            fadeOut = fadeOut + Time.deltaTime * 1f;
            lightPlatform.intensity = lightPlatform.intensity + (Time.deltaTime * 3f);
            spriteRenderer.color = new Color(0, 0, 0, fadeOut);
        }
        else
        {
            lightPlatform.intensity = 3f;
            fadeOut = 1f;
            colliderParent.SetActive(true);
            isReapearing = false;
        } 
    }
}
