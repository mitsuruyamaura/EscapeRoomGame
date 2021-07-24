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
    /// �N���A�ɕK�v�ȃA�C�e�������ׂď������Ă��邩�m�F
    /// </summary>
    private void CheckClear() {

        // �N���A�ɕK�v�ȃA�C�e�������ԂɊm�F����
        for (int i = 0; i < clearItems.Length; i++) {
            if (!GamaData.instance.itemDatasList.Exists(x => x.itemNo == clearItems[i].itemNo)) {
                isTriggerd = false;
                Debug.Log("�K�v�ȃA�C�e�����������Ă��Ȃ�");
                return;
            }
        }

        Debug.Log("Game Clear");
    }
}
