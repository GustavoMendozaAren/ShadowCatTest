using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteTextDialogoUI : MonoBehaviour
{
    TMP_Text _tmpProText;
    string writer;

    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;

    [SerializeField] private bool tieneTextoAlFinal;
    [SerializeField] private GameObject sigueinteTexto;

    [SerializeField] private bool esTextoFinal;
    [SerializeField] private DialogosUIManager dialogoManager;

    // Use this for initialization
    void Start()
    {
        _tmpProText = GetComponent<TMP_Text>()!;

        if (_tmpProText != null)
        {
            writer = _tmpProText.text;
            _tmpProText.text = "";

            StartCoroutine("TypeWriterTMP");
        }
    }

    IEnumerator TypeWriterTMP()
    {
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            if (_tmpProText.text.Length > 0)
            {
                _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
            }
            if (c != ' ')
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.typeWriter, this.transform.position);
            }

            _tmpProText.text += c;
            _tmpProText.text += leadingChar;

            yield return new WaitForSeconds(timeBtwChars);

        }

        if (leadingChar != "")
        {
            _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
        }

        if(tieneTextoAlFinal)
            sigueinteTexto.SetActive(true);

        if (esTextoFinal)
            Invoke(nameof(DesactivarDialogoAnims), 1f);

        Invoke(nameof(DeactiveText), 1f);
    }

    private void DesactivarDialogoAnims()
    {
        dialogoManager.DesactivarDialogosAniamciones();
    }

    private void DeactiveText()
    {
        _tmpProText.enabled = false;
    }
}
