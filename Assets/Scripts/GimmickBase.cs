using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBase : MonoBehaviour
{
    [SerializeField, Header("発動後に破壊するかどうかの設定")]
    protected bool isDestroyOn;

    [SerializeField]
    protected bool isTriggerd;

    [SerializeField]
    protected ItemData itemData;

    [SerializeField]
    protected GimmickData gimmickData;

    [SerializeField, Header("アイテム情報の設定")]
    protected int setItemNo;

    /// <summary>
    /// ギミック発動時のメソッド
    /// </summary>
    /// <param name="uiManager"></param>
    public virtual void TriggerGimmick(UIManager uiManager) {
        isTriggerd = true;

        Debug.Log("Gimmick Triggered : " + isTriggerd);

        uiManager.DisplayGetInfo(itemData);

        GamaData.instance.AddItemDataList(itemData);

        if (isDestroyOn) {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// アイテム情報の設定
    /// </summary>
    public virtual void SetUpItemData() {
        itemData = DataBaseManager.instance.itemDataSO.itemDatasList.Find(x => x.itemNo == setItemNo);
    }

    /// <summary>
    /// 発動状態の確認
    /// </summary>
    /// <returns></returns>
    public bool CheckTriggerdGimmick() {
        return isTriggerd;
    }
}
