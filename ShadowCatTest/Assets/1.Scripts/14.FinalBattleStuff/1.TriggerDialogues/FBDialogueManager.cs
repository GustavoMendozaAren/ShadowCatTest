using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FBDialogueManager : MonoBehaviour
{
    [Header("JUGADOR")]
    [SerializeField] private GameObject proteccionControles;
    [SerializeField] private SwitchLite playerMove;
    [SerializeField] private GameObject winPanel;

    [Header("ENEMIGO")]
    [SerializeField] private BartenderThrowAttack bartederThrowSc;
    [SerializeField] private BartenderFly2 bartenderFly;

    [Header("BARRA DE VIDA")]
    [SerializeField] private SpriteRenderer bartenderSprite;
    [SerializeField] private GameObject[] healthBarActive;
    [SerializeField] private HealthBarBartender healthBarBartender;

    [Header ("DIALOGOS")]
    [SerializeField] private DialogueUITriggerFB dialogueUI1;
    [SerializeField] private DialogueUITriggerFB dialogueUI2;
    [SerializeField] private DialogueUITriggerFB dialogueUI3;
    [SerializeField] private DialogueUITriggerFB dialogueUI4;
    [SerializeField] private GameObject dialogueUIFirstFase;
    [SerializeField] private GameObject dialogueUISecondFase;
    [SerializeField] private GameObject dialogueUIThirdFase;

    public MusicBridge levelMusic;
    public PlayerDamage damageInstance;

    private void Start()
    {
        GameObject instanciaMusic = GameObject.Find("Music");
        levelMusic = instanciaMusic.GetComponent<MusicBridge>();

        GameObject playerDamageInstance = GameObject.Find("Player v3 Switcher (1)");
        damageInstance = playerDamageInstance.GetComponent<PlayerDamage>();

        StateGameController.playerCanDie = true;
    }

    private void Update()
    {
        // PRIMERA FASE COMIENZO
        if (dialogueUI1.DialogueAnimDeactive)
        {
            bartenderSprite.color = Color.white;
            dialogueUI1.DialogueAnimDeactive = false;

        }

        if (dialogueUI1.DialogueImgDeactive)
        {
            healthBarActive[0].SetActive(true);
            proteccionControles.SetActive(false);
            dialogueUI1.DialogueImgDeactive = false;
            bartederThrowSc.enabled = true;
        }

        // PRIMERA FASE FINAL
        if (healthBarBartender.FirstFaseEnded)
        {
            playerMove.isInCinematic = true;
            dialogueUIFirstFase.SetActive(true);
            healthBarActive[0].SetActive(false);
            healthBarBartender.FirstFaseEnded = false;
        }

        // SEGUNDA FASE COMIENZO
        if (dialogueUI2.DialogueImgDeactive)
        {
            healthBarActive[1].SetActive(true);
            bartenderFly.enabled = true;
            bartederThrowSc.IsAimingAtPlayer = true;
            bartederThrowSc.throwCooldown = 1f;
            dialogueUI2.DialogueImgDeactive = false;
        }

        // SEGUNDA FASE FINAL
        if (healthBarBartender.SecondFaseEnded)
        {
            playerMove.isInCinematic = true;
            dialogueUISecondFase.SetActive(true);
            healthBarActive[1].SetActive(false);
            healthBarBartender.SecondFaseEnded = false;
        }

        // TERCERA FASE COMIENZO
        if (dialogueUI3.DialogueImgDeactive)
        {
            healthBarActive[2].SetActive(true);
            bartederThrowSc.throwCooldown = 0.75f;
            bartenderFly.moveSpeed = 8f;
            bartenderFly.CanCharge = true;
            dialogueUI3.DialogueImgDeactive = false;
        }

        // TERCERA FASE FINAL
        if (healthBarBartender.ThirdFaseEnded)
        {
            playerMove.isInCinematic = true;
            dialogueUIThirdFase.SetActive(true);
            healthBarActive[2].SetActive(false);
            healthBarBartender.ThirdFaseEnded = false;
        }

        if (dialogueUI4.DialogueImgDeactive)
        {
            winPanel.SetActive(true);
            levelMusic.NotificarCambioMusica("Ganar");
            dialogueUI4.DialogueImgDeactive = false;

            StateGameController.pistaCandado[3] = true;

            StateGameController.playerCanDie = false;
        }
    }
}
