using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaData : MonoBehaviour
{
    public static GamaData instance;

    [Header("�������Ă���A�C�e���� List")]
    public List<ItemData> itemDatasList = new List<ItemData>();

    public int controllRoomNo;

    [Header("���݃v���C���[�̂��镔���̔ԍ�")]
    public int currentInRoomNo;


    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �A�C�e���p List �ɃA�C�e����ǉ�
    /// </summary>
    /// <param name="itemData"></param>
    public void AddItemDatasList(ItemData itemData) {

        // �������Ă���A�C�e�����m�F����
        if (itemDatasList.Exists(x => x.itemType == itemData.itemType)) {
            return;
        }

        // �������Ă��Ȃ��A�C�e���̂ݒǉ�
        itemDatasList.Add(itemData);
    }

    /// <summary>
    /// �A�C�e���p List ����A�C�e�����폜
    /// </summary>
    /// <param name="itemData"></param>
    /// <returns></returns>
    public void RemoveItemDatasList(ItemData itemData) {
        itemDatasList.Remove(itemData);
    }

    /// <summary>
    /// ���݂��镔���̏���ݒ�
    /// </summary>
    /// <param name="roomNo"></param>
    public void SetRoomInfo(int roomNo) {�@�@�@//�@���𑝂₵�����ꍇ�ɂ́A�����𑝂₷
        currentInRoomNo = roomNo;
    }
}
