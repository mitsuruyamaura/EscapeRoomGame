using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;

    public ItemDataSO itemDataSO;

    public GimmickDataSO gimmickDataSO;

    public RoomConditionDataSO roomConditionDataSO;


    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �����̃R���f�B�V�����̃f�[�^���擾
    /// </summary>
    /// <param name="getRoomConditionType"></param>
    /// <returns></returns>
    public RoomConditionDataSO.RoomConditionData GetRoomConditionData(RoomConditionType getRoomConditionType) {
        return roomConditionDataSO.roomConditionDatasList.Find(x => x.roomConditionType == getRoomConditionType);
    }
}
