using UnityEngine;
using UnityEngine.UI;

public class SmallPanelsStore : MonoBehaviour
{
    [SerializeField] private Sprite escopetaColorImg;
    [SerializeField] private Sprite escopetaNegraImg;
    [SerializeField] private Sprite[] smallBtnSprite;
    [SerializeField] private Image[] escopetaImg;
    [SerializeField] private Image smallBtnImg;

    private void Start()
    {
        SmallButtonImageChange(2);
        SmallButtonImageChange(4);
    }

    public void EscopetaComprada()
    {
        if (StateGameController.isShotgunUnlock)
        {
            for (int i = 0; i < escopetaImg.Length; i++)
            {
                escopetaImg[i].sprite = escopetaColorImg;
            }
        }
        else
        {
            for (int i = 0; i < escopetaImg.Length; i++)
            {
                escopetaImg[i].sprite = escopetaNegraImg;
            }
        }
    }

    public void SmallButtonImageChange(int index)
    {
        if (!StateGameController.isShotgunUnlock)
        {
            smallBtnImg.sprite = smallBtnSprite[index];
        }
        else
        {
            smallBtnImg.sprite = smallBtnSprite[index + 1];
        }

        
    }
}
