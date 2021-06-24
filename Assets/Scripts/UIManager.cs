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


}
