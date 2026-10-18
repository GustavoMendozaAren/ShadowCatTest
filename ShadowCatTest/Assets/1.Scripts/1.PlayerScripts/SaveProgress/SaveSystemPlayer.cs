using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemPlayer : MonoBehaviour
{
    [SerializeField] private GameObject wantToErasePanel;
    [SerializeField] private StoreEqp1Rev storeEqp1Rev;
    [SerializeField] private StoreEqp2Cat storeEqp2Cat;
    [SerializeField] private SmallPanelsStore smallPanelsStore;
    [SerializeField] private World1 textoMonedasNiveles;

    private void Awake()
    {
        CargarDatos();
    }

    public void BorrarDatosButton()
    {
        wantToErasePanel.SetActive(true);
    }

    public void ConfirmEraseDatosButton()
    {
        wantToErasePanel.SetActive(false);
        BorrarDatos();
    }

    public void CancelEraseDataButton()
    {
        wantToErasePanel.SetActive(false);
    }

    public void BorrarDatos()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        StateGameController.isShotgunUnlock = false;
        StateGameController.coinsTotal = 55;

        StateGameController.barrasPowerIndex = -1;
        StateGameController.revolverPower = 1f;
        StateGameController.currentDamageText = 10;
        StateGameController.nextPowerText = 15;

        StateGameController.barrasAmountIndex = -1;
        StateGameController.bulletsInGame = 6;
        StateGameController.currentAmountTxt = 6;
        StateGameController.nextAmountTxt = 8;

        StateGameController.barrasEscopetaDamageIndex = -1;
        StateGameController.EscopetaDamage = 20;
        StateGameController.currentEscopetaDamageTxt = 20;
        StateGameController.nextEscopetaDamageTxt = 30;

        StateGameController.barrasEscopetaAuraIndex = -1;
        StateGameController.AuraFarming = 1;
        StateGameController.currentEscopetaAuraTxt = 1;
        StateGameController.nextEscopetaAuraTxt = 4;

        StateGameController.barrasSlowIndex = -1;
        StateGameController.slowdownTime = 4f;
        StateGameController.currentSlowText = 4;
        StateGameController.nextSlowText = 6;

        StateGameController.level1Coins = 0;
        StateGameController.level2Coins = 0;
        StateGameController.level3Coins = 0;
        StateGameController.level4Coins = 0;

        storeEqp1Rev.ActulaizarDatosGuardados();
        storeEqp2Cat.ActualizarDatosGuardadosDeGato();
        smallPanelsStore.SmallButtonImageChange(2);
        smallPanelsStore.SmallButtonImageChange(4);
        smallPanelsStore.EscopetaComprada();
        textoMonedasNiveles.ActualizarMonedasEnNiveles();
    }

    //private void BorrarDatosMonedas()
    //{
    //    for (int i = 1; i < 16; i++)
    //    {
    //        PlayerPrefs.SetInt("2N" + i, 0);
    //        PlayerPrefs.SetInt("2C" + i, 0);
    //        PlayerPrefs.SetInt("2H" + i, 0);
    //    }

    //    StateGameController.level2Coins = 0;
    //}

    private void CargarDatos()
    {
        StateGameController.coinsTotal = PlayerPrefs.GetInt("CoinsTotal", 55);

        StateGameController.isShotgunUnlock = PlayerPrefs.GetInt("IsShotgunUnlock", 0) == 1;

        StateGameController.barrasPowerIndex = PlayerPrefs.GetInt("BarrasPowerIndex", -1);
        StateGameController.revolverPower = PlayerPrefs.GetFloat("RevolverPower", 1f);
        StateGameController.currentDamageText = PlayerPrefs.GetInt("CurrentDamageText", 10);
        StateGameController.nextPowerText = PlayerPrefs.GetInt("NextPowerText", 15);

        StateGameController.barrasAmountIndex = PlayerPrefs.GetInt("BarrasAmountIndex", -1);
        StateGameController.bulletsInGame = PlayerPrefs.GetInt("BulletsInGame", 6);
        StateGameController.currentAmountTxt = PlayerPrefs.GetInt("CurrentAmountTxt", 6);
        StateGameController.nextAmountTxt = PlayerPrefs.GetInt("NextAmountTxt", 8);

        StateGameController.barrasEscopetaDamageIndex = PlayerPrefs.GetInt("BarrasEscopetaDamageIndex", -1);
        StateGameController.EscopetaDamage = PlayerPrefs.GetInt("EscopetaDamage", 20);
        StateGameController.currentEscopetaDamageTxt = PlayerPrefs.GetInt("CurrentEscopetaDamageTxt", 20);
        StateGameController.nextEscopetaDamageTxt = PlayerPrefs.GetInt("NextEscopetaDamageTxt", 30);

        StateGameController.barrasEscopetaAuraIndex = PlayerPrefs.GetInt("BarrasEscopetaAuraIndex", -1);
        StateGameController.AuraFarming = PlayerPrefs.GetInt("AuraFarming", 1);
        StateGameController.currentEscopetaAuraTxt = PlayerPrefs.GetInt("CurrentEscopetaAuraTxt", 1);
        StateGameController.nextEscopetaAuraTxt = PlayerPrefs.GetInt("NextEscopetaAuraTxt", 4);

        StateGameController.barrasSlowIndex = PlayerPrefs.GetInt("BarrasSlowIndex", -1);
        StateGameController.slowdownTime = PlayerPrefs.GetFloat("SlowdownTime", 4f);
        StateGameController.currentSlowText = PlayerPrefs.GetInt("CurrentSlowText", 4);
        StateGameController.nextSlowText = PlayerPrefs.GetInt("NextSlowText", 6);

        StateGameController.level1Coins = PlayerPrefs.GetInt("Level1Coins", 0);
        StateGameController.level2Coins = PlayerPrefs.GetInt("Level2Coins", 0);
        StateGameController.level3Coins = PlayerPrefs.GetInt("Level3Coins", 0);
        StateGameController.level4Coins = PlayerPrefs.GetInt("Level4Coins", 0);

        PlayerPrefs.Save();
    }
}
