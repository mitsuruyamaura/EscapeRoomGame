using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearChecker : MonoBehaviour
{
    [SerializeField, Header("�N���A�ɕK�v�ȃA�C�e���̖��O")]
    private ItemType[] needClearItemTypes;


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out PlayerController player)) {

            // �Q�[���N���A����̕��@�̕���
            if (needClearItemTypes.Length > 0) {
                JudgeGameClearItemTypes(player.itemManager);
            } else {
                JudgeGameClearAllItems(player.itemManager);
            }            
        }
    }

    /// <summary>
    /// ���ׂĂ̏����A�C�e���̊m�F�����ăQ�[���N���A�̔���
    /// </summary>
    public void JudgeGameClearAllItems(ItemManager itemManager) {

        for (int i = 0; i < itemManager.haveItems.Length; i++) {
            if (itemManager.haveItems[i]) {
                continue;
            } else {
                Debug.Log("�A�C�e��������Ȃ�");
                return;
            }
        }

        Debug.Log("�Q�[���N���A");
    }

    /// <summary>
    /// �N���A�ɕK�v�ȃA�C�e���݂̂��m�F���ăQ�[���N���A�̔���
    /// </summary>
    /// <param name="itemManager"></param>
    public void JudgeGameClearItemTypes(ItemManager itemManager) {
        foreach (ItemType itemType in needClearItemTypes) {
            for (int i = 0; i < itemManager.haveItems.Length; i++) {
                if (itemManager.haveItems[(int)itemType]) {
                    continue;
                } else {
                    Debug.Log("�A�C�e��������Ȃ�");
                    return;
                }
            }
        }

        Debug.Log("�Q�[���N���A");
    }
}
