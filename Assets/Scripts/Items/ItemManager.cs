using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("�������Ă���A�C�e��")]
    public bool[] haveItems;

    void Start() {
        SetUpItemManager();    
    }

    /// <summary>
    /// �����ݒ�
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
    /// �������Ă���A�C�e�����̍X�V
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="isSwitch"></param>
    public void UpdateHaveItem(ItemType itemType, bool isSwitch = true) {
        haveItems[(int)itemType] = isSwitch;

        if (isSwitch) {
            Debug.Log("�A�C�e���擾 : " + itemType.ToString());
        } else {
            Debug.Log("�A�C�e���r�� : " + itemType.ToString());
        }
    }
}
