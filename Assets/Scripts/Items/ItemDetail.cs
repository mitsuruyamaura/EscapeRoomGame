using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetail : MonoBehaviour
{
    public ItemType itemType;

    /// <summary>
    /// �A�C�e���̎�ނ��擾
    /// </summary>
    /// <returns></returns>
    public ItemType GetItemType() {
        return itemType;
    }

    /// <summary>
    /// �A�C�e���̎�ނ�ݒ�
    /// </summary>
    /// <param name="itemNo"></param>
    public void SetItemType(ItemType itemType) {
        this.itemType = itemType;
    }
}
