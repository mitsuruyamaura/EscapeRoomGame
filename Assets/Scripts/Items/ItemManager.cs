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

    [SerializeField, Header("�z�u�A�C�e���̃��X�g")]
    private List<ItemDetail> itemsList = new List<ItemDetail>();

    // TODO �A�C�e���̃v���t�@�u�̃A�T�C��


    void Start() {
        SetUpItemManager();

        // �N���A�����̐ݒ�
        clearChecker.SetUpClearChecker();

        CreateItemIconDetails();

        // TODO �A�C�e���̔z�u

        // �A�C�e���̏��ݒ�
        SetItemDetails();
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
    /// UI �ɃA�C�e���A�C�R���̍쐬
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
            //itemIconDetailsList.Find(x => x.ItemNo == (int)itemType).SwitchDisplayItemIcon(true);

            // �l�������A�C�e���̃A�C�R���̓����x��߂�
            itemIconDetailsList.Find(x => x.ItemNo == (int)itemType).TransparentDisplayItemIcon(1.0f);

        } else {
            Debug.Log("�A�C�e���r�� : " + itemType.ToString());
        }
    }

    // TODO �N���A�A�C�e���̐���

    /// <summary>
    /// �e�A�C�e���̃A�C�e���̎�ނ̏��̐ݒ�
    /// </summary>
    private void SetItemDetails() {
        for (int i = 0; i < clearChecker.GetNeedClearItemCount(); i++) {
            itemsList[i].SetItemType(clearChecker.GetClearItemType(i));
        }
    }
}
