using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    // InfoSet
    [SerializeField]
    private Text txtMessage;

    [SerializeField]
    private Button btnBackgroundFilter;

    [SerializeField]
    private CanvasGroup canvasGroupInfo;

    [SerializeField]
    private Image imgItem;

    // OpeningSet
    [SerializeField]
    private CanvasGroup canvasGroupOpening;

    [SerializeField]
    private Transform needItemTran;


    void Start() {
        btnBackgroundFilter.onClick.AddListener(CloseGetInfo);

        btnBackgroundFilter.interactable = false;
        canvasGroupInfo.alpha = 0;

        canvasGroupInfo.blocksRaycasts = false;
    }

    /// <summary>
    /// インフォ表示を閉じる
    /// </summary>
    private void CloseGetInfo() {
        canvasGroupInfo.DOFade(0f, 0.5f);

        btnBackgroundFilter.interactable = false;
        canvasGroupInfo.blocksRaycasts = false;
        canvasGroupInfo.DOFade(0, 0.5f);
    }

    /// <summary>
    /// 入手したアイテムのインフォ表示
    /// </summary>
    /// <param name="itemData"></param>
    public void DisplayGetInfo(ItemData itemData) {
        txtMessage.text = itemData.itemType.ToString();
        imgItem.sprite = itemData.itemSprite;

        canvasGroupInfo.DOFade(1.0f, 0.5f);

        canvasGroupInfo.blocksRaycasts = true;
        btnBackgroundFilter.interactable = true;
    }

    /// <summary>
    /// オープニング演出の再生
    /// </summary>
    /// <returns></returns>
    public IEnumerator PlayOpening(List<ItemIconDetail> itemIconDetailsList) {

        canvasGroupOpening.alpha = 0;

        for (int i = 0; i < itemIconDetailsList.Count; i++) {
            Instantiate(itemIconDetailsList[i], needItemTran).TransparentDisplayItemIcon(1.0f);
        }

        canvasGroupOpening.DOFade(1.0f, 1.0f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(2.5f);

        canvasGroupOpening.DOFade(0f, 1.0f).SetEase(Ease.Linear)
            .OnComplete(() => { canvasGroupOpening.blocksRaycasts = false; });    
    }
}
