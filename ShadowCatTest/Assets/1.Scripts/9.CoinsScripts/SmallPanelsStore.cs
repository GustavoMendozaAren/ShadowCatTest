using UnityEngine;
using UnityEngine.UI;

public class SmallPanelsStore : MonoBehaviour
{
    [SerializeField] private Sprite escopetaColorImg;
    [SerializeField] private Sprite[] smallBtnSprite;
    [SerializeField] private Image[] escopetaImg;
    [SerializeField] private Image smallBtnImg;

    public void EscopetaComprada()
    {
        for (int i = 0; i < escopetaImg.Length; i++)
        {
            escopetaImg[i].sprite = escopetaColorImg;
        }
    }

    public void SmallButtonImageChange(int index)
    {        
        if (!StateGameController.isShotgunUnlock)
            smallBtnImg.sprite = smallBtnSprite[index];
        else
            smallBtnImg.sprite = smallBtnSprite[index + 1];
    }
}
