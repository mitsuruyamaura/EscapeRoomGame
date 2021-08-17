using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconDetail : MonoBehaviour
{
    [SerializeField]
    private Image imgItemIcon;

    /// <summary>
    /// 設定
    /// </summary>
    /// <param name="itemNo"></param>
    public void SetUpItemIconDetail(int itemNo) {
        imgItemIcon.sprite = Resources.Load<Sprite>("ItemIcon_" + itemNo);

        // アイコンを非表示
        SwitchDisplayItemIcon(false);        
    }

    /// <summary>
    /// アイテムアイコンの表示切り替え
    /// </summary>
    /// <param name="isSwitch"></param>
    public void SwitchDisplayItemIcon(bool isSwitch) {
        imgItemIcon.enabled = isSwitch;
    }
}
