using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBase : MonoBehaviour
{
    [SerializeField]
    protected bool isDestroyOn;

    [SerializeField]
    protected ItemData itemData;

    /// <summary>
    /// �M�~�b�N�������̃��\�b�h
    /// </summary>
    /// <param name="uiManager"></param>
    public virtual void TriggerGimmick(UIManager uiManager) {

        Debug.Log("Gimmick Triggered");

        uiManager.DisplayGetInfo(itemData);

        GamaData.instance.AddItemDataList(itemData);

        if (isDestroyOn) {
            Destroy(gameObject);
        }
    }
}
