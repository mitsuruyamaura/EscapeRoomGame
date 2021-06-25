using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBase : MonoBehaviour
{
    [SerializeField, Header("������ɔj�󂷂邩�ǂ����̐ݒ�")]
    protected bool isDestroyOn;

    [SerializeField]
    protected bool isTriggerd;

    [SerializeField]
    protected ItemData itemData;

    [SerializeField]
    protected GimmickData gimmickData;

    [SerializeField, Header("�A�C�e�����̐ݒ�")]
    protected int setItemNo;

    /// <summary>
    /// �M�~�b�N�������̃��\�b�h
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
    /// �A�C�e�����̐ݒ�
    /// </summary>
    public virtual void SetUpItemData() {
        itemData = DataBaseManager.instance.itemDataSO.itemDatasList.Find(x => x.itemNo == setItemNo);
    }

    /// <summary>
    /// ������Ԃ̊m�F
    /// </summary>
    /// <returns></returns>
    public bool CheckTriggerdGimmick() {
        return isTriggerd;
    }
}
