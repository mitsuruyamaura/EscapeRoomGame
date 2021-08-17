using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("�������Ă���A�C�e��")]
    public bool[] haveItems;

    [SerializeField]
    private ClearChecker clearChecker;

    [SerializeField]
    private ItemIconDetail itemIconDetailPrefab;

    [SerializeField]
    private List<ItemIconDetail> itemIconDetailsList = new List<ItemIconDetail>();

    [SerializeField]
    private Transform itemIconDetailTran;


    void Start() {
        SetUpItemManager();

        // �N���A�����̐ݒ�
        clearChecker.SetUpClearChecker();

        CreateItemIconDetails();
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
    /// �A�C�e���A�C�R���̍쐬
    /// </summary>
    private void CreateItemIconDetails() {

        for (int i = 0; i < clearChecker.GetNeedClearItemCount(); i++) {
            ItemIconDetail itemIconDetail = Instantiate(itemIconDetailPrefab, itemIconDetailTran, false);
            itemIconDetail.SetUpItemIconDetail(clearChecker.GetClearItemTypeNo(i));
            itemIconDetailsList.Add(itemIconDetail);
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

            // �l�������A�C�e���̃A�C�R����\��
            itemIconDetailsList.Find(x => x.ItemNo == (int)itemType).SwitchDisplayItemIcon(true);

        } else {
            Debug.Log("�A�C�e���r�� : " + itemType.ToString());
        }
    }
}
