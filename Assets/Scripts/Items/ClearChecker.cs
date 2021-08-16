using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearChecker : MonoBehaviour
{
    [SerializeField, Header("�N���A�ɕK�v�ȃA�C�e��")]
    private bool[] needClearItems;

    [SerializeField, Header("�N���A�ɕK�v�ȃA�C�e���̖��O")]
    private ItemType[] needClearItemNames;


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out PlayerController player)) {
            JudgeGameClearAllItems(player.itemManager);
        }
    }

    /// <summary>
    /// �����A�C�e���̊m�F�����ăQ�[���N���A�̔���
    /// </summary>
    public void JudgeGameClearAllItems(ItemManager itemManager) {

        for (int i = 0; i < itemManager.haveItems.Length; i++) {
            if (itemManager.haveItems[i]) {
                continue;
            } else {
                return;
            }
        }

        Debug.Log("�Q�[���N���A");
    }


}
