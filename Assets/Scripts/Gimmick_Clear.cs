using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Clear : GimmickBase
{
    public ItemData[] clearItems;

    public override void TriggerGimmick(UIManager uiManager) {
        //base.TriggerGimmick(uiManager);

        isTriggerd = true;

        CheckClear();
    }

    /// <summary>
    /// クリアに必要なアイテムをすべて所持しているか確認
    /// </summary>
    private void CheckClear() {

        // クリアに必要なアイテムを順番に確認する
        for (int i = 0; i < clearItems.Length; i++) {
            if (!GamaData.instance.itemDatasList.Exists(x => x.itemNo == clearItems[i].itemNo)) {
                isTriggerd = false;
                Debug.Log("必要なアイテムを所持していない");
                return;
            }
        }

        Debug.Log("Game Clear");
    }
}
