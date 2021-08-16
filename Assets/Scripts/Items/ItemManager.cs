using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("所持しているアイテム")]
    public bool[] haveItems;

    void Start() {
        SetUpItemManager();    
    }

    /// <summary>
    /// 初期設定
    /// </summary>
    /// <param name="itemCount"></param>
    public void SetUpItemManager(int itemCount = 0) {
        if (itemCount == 0) {
            haveItems = new bool[(int)ItemType.Count];
        } else {
            haveItems = new bool[itemCount];
        }
    }

    /// <summary>
    /// 所持しているアイテム情報の更新
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="isSwitch"></param>
    public void UpdateHaveItem(ItemType itemType, bool isSwitch = true) {
        haveItems[(int)itemType] = isSwitch;

        if (isSwitch) {
            Debug.Log("アイテム取得 : " + itemType.ToString());
        } else {
            Debug.Log("アイテム喪失 : " + itemType.ToString());
        }
    }
}
