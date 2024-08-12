using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBullets : MonoBehaviour
{
    [SerializeField] private GameObject[] extraBullets;
    [SerializeField] private GameObject[] extraBulletsDeactive;

    private void Start()
    {
        CheckIfExtraBullets();
    }

    private void CheckIfExtraBullets() 
    {
        if (StateGameController.bulletsInGame >= 8) 
        {
            extraBullets[0].SetActive(true);
            extraBullets[1].SetActive(true);
            extraBulletsDeactive[0].SetActive(true);
            extraBulletsDeactive[1].SetActive(true);
        }
        if (StateGameController.bulletsInGame >= 10) 
        {
            extraBullets[2].SetActive(true);
            extraBullets[3].SetActive(true);
            extraBulletsDeactive[2].SetActive(true);
            extraBulletsDeactive[3].SetActive(true);
        }
        if (StateGameController.bulletsInGame >= 12)
        {
            extraBullets[4].SetActive(true);
            extraBullets[5].SetActive(true);
            extraBulletsDeactive[4].SetActive(true);
            extraBulletsDeactive[5].SetActive(true);
        }
    }
}
