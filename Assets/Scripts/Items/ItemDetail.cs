using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetail : MonoBehaviour
{
    public ItemType itemType;

    /// <summary>
    /// アイテムの種類を取得
    /// </summary>
    /// <returns></returns>
    public ItemType GetItemType() {
        return itemType;
    }

    /// <summary>
    /// アイテムの種類を設定
    /// </summary>
    /// <param name="itemNo"></param>
    public void SetItemType(ItemType itemType) {
        this.itemType = itemType;
    }
}
