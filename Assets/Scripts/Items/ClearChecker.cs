using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearChecker : MonoBehaviour
{
    [SerializeField, Header("クリアに必要なアイテム")]
    private bool[] needClearItems;

    [SerializeField, Header("クリアに必要なアイテムの名前")]
    private ItemType[] needClearItemNames;


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out PlayerController player)) {
            JudgeGameClearAllItems(player.itemManager);
        }
    }

    /// <summary>
    /// 所持アイテムの確認をしてゲームクリアの判定
    /// </summary>
    public void JudgeGameClearAllItems(ItemManager itemManager) {

        for (int i = 0; i < itemManager.haveItems.Length; i++) {
            if (itemManager.haveItems[i]) {
                continue;
            } else {
                return;
            }
        }

        Debug.Log("ゲームクリア");
    }


}
