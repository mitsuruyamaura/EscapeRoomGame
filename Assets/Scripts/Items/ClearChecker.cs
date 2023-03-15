using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ClearChecker : MonoBehaviour
{
    [SerializeField, Header("�N���A�ɕK�v�ȃA�C�e���̖��O")]
    private ItemType[] needClearItemTypes;

    [SerializeField, Header("�N���A�A�C�e���̃����_���ݒ�L��")]
    private bool isRandomClearItemSet;

    [SerializeField, Header("�f�o�b�O�p")]
    private ItemType[] allItems;

    [SerializeField, Header("�f�o�b�O�p")]
    private ItemType[] shuffleItems;

    [SerializeField, Header("�ŏ��N���A�A�C�e����")]
    private int minItemCount;

    [SerializeField]
    private UIManager uiManager;

    private bool isGameUp;


    public void SetUpClearChecker() {
        // �����_���ݒ肷��ꍇ
        if (isRandomClearItemSet) {
            RandomSetClearItems();
        }
    }

    /// <summary>
    /// �N���A�ɕK�v�ȃA�C�e���������_���Őݒ�
    /// </summary>
    public void RandomSetClearItems() {
        // �N���A�ɕK�v�ȃA�C�e���̐��̃����_���ݒ�
        needClearItemTypes = new ItemType[UnityEngine.Random.Range(minItemCount, (int)ItemType.Count)];

        // ���ׂẴA�C�e���̏������z������
        ItemType[] allItems = new ItemType[(int)ItemType.Count];

        // �v�f�ݒ�
        for (int i = 0; i < allItems.Length; i++) {
            allItems[i] = (ItemType)i;
        }

        // ���ׂẴA�C�e���̗v�f���V���b�t��
        ItemType[] shuffleItems = allItems.OrderBy(x => Guid.NewGuid()).ToArray();

        // �V���b�t�������v�f���N���A�̃A�C�e���ɐݒ�
        for (int i = 0; i < needClearItemTypes.Length; i++) {
            needClearItemTypes[i] = shuffleItems[i];
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (isGameUp) {
            return;
        }

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

        //for (int i = 0; i < itemManager.haveItems.Length; i++) {
        //    if (itemManager.haveItems[i]) {
        //        continue;
        //    } else {
        //        Debug.Log("�A�C�e��������Ȃ�");
        //        return;
        //    }
        //}

        // ����ł� OK
        if (itemManager.haveItems.All(x => x != true)) {
            Debug.Log("�A�C�e��������Ȃ�");
            return;
        }

        isGameUp = true;
        Debug.Log("�Q�[���N���A");

        // �Q�[���N���A�\��
        uiManager.PlayGameClear();
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
        isGameUp = true;
        Debug.Log("�Q�[���N���A");

        // �Q�[���N���A�\��
        uiManager.PlayGameClear();
    }

    public int GetNeedClearItemCount() {
        return needClearItemTypes.Length;
    }

    public int GetClearItemTypeNo(int no) {
        return (int)needClearItemTypes[no];
    }

    public ItemType GetClearItemType(int no) {
        return needClearItemTypes[no];
    }
}
