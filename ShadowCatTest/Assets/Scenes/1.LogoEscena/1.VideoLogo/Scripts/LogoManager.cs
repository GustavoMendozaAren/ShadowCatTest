using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour
{
    public GameObject panelFadeOut;

    void Start()
    {
        StartCoroutine(SiguienteEScena());
    }

    private IEnumerator SiguienteEScena()
    {
        yield return new WaitForSeconds(3.7f);
        panelFadeOut.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
