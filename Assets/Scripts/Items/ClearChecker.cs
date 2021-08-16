using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearChecker : MonoBehaviour
{
    [SerializeField, Header("クリアに必要なアイテムの名前")]
    private ItemType[] needClearItemTypes;


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out PlayerController player)) {

            // ゲームクリア判定の方法の分岐
            if (needClearItemTypes.Length > 0) {
                JudgeGameClearItemTypes(player.itemManager);
            } else {
                JudgeGameClearAllItems(player.itemManager);
            }            
        }
    }

    /// <summary>
    /// すべての所持アイテムの確認をしてゲームクリアの判定
    /// </summary>
    public void JudgeGameClearAllItems(ItemManager itemManager) {

        for (int i = 0; i < itemManager.haveItems.Length; i++) {
            if (itemManager.haveItems[i]) {
                continue;
            } else {
                Debug.Log("アイテムが足りない");
                return;
            }
        }

        Debug.Log("ゲームクリア");
    }

    /// <summary>
    /// クリアに必要なアイテムのみを確認してゲームクリアの判定
    /// </summary>
    /// <param name="itemManager"></param>
    public void JudgeGameClearItemTypes(ItemManager itemManager) {
        foreach (ItemType itemType in needClearItemTypes) {
            for (int i = 0; i < itemManager.haveItems.Length; i++) {
                if (itemManager.haveItems[(int)itemType]) {
                    continue;
                } else {
                    Debug.Log("アイテムが足りない");
                    return;
                }
            }
        }

        Debug.Log("ゲームクリア");
    }
}
