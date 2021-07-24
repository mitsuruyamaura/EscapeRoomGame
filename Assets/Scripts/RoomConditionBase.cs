using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConditionBase : MonoBehaviour
{
    [SerializeField]
    protected RoomConditionType roomConditionType;

    [SerializeField, Header("���ʒl")]
    protected float conditionValue;

    protected PlayerController playerController;

    protected bool isSetUp;

    protected RoomConditionDataSO.RoomConditionData roomConditionData; 

    /// <summary>
    /// �O���N���X����R���f�B�V�����̊J�n�����s���郁�\�b�h
    /// </summary>
    public void OnEnterRoomCondition(PlayerController playerController) {
        this.playerController = playerController;

        // �����̃R���f�B�V�����̏����擾
        roomConditionData = DataBaseManager.instance.GetRoomConditionData(roomConditionType);

        // �ݒ�
        conditionValue = roomConditionData.conditionValue;

        StartCoroutine(StartRoomCondition());
    }

    /// <summary>
    /// �R���f�B�V�����̊J�n�̎�����
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator StartRoomCondition() {

        // �q�N���X�Ŏ�������


        yield return null;

        isSetUp = true;
    }

    /// <summary>
    /// �O���N���X����R���f�B�V�����̏I�����s�����߂̃��\�b�h
    /// </summary>
    public void OnExitRoomCondition() {
        StartCoroutine(EndRoomCondition());
    }

    /// <summary>
    /// �R���f�B�V�����̏I���̎�����
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator EndRoomCondition() {
        yield return null;

        Destroy(this);
    }
}
