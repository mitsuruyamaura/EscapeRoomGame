using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ɃA�^�b�`����N���X
/// </summary>
public class RoomDetail : MonoBehaviour
{
    public int roomNo;

    public Vector2Int roomPos;

    public bool inRoom;�@�@�@// �����Ǘ�

    public PlayerController playerController;

    public RoomConditionType roomConditionType;


    /// <summary>
    /// �����ƃv���C���[�̐e�q�֌W�̐ݒ�E����
    /// </summary>
    /// <param name="isSetRoomParent"></param>
    public void SwitchPlayerParent(bool isSetRoomParent) {

        if (isSetRoomParent) {
            playerController.transform.SetParent(this.transform);
        } else {
            playerController.transform.SetParent(null);
        }

        Debug.Log(isSetRoomParent ? "�v���C���[�����̕����̎q�ɐݒ�" : "�v���C���[�𕔉��̎q�������");
    }

    private void OnTriggerEnter(Collider other) {
        if (!inRoom && other.TryGetComponent(out playerController)) {
            // �����ɓ���
            inRoom = true;
            SwitchPlayerParent(true);
            GamaData.instance.SetRoomInfo(roomNo);

            // �v���C���[�ɕ����̃R���f�B�V������t�^
            playerController.AddRoomCondition(roomConditionType);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (playerController) {
            // ��������ގ�
            inRoom = false;
            SwitchPlayerParent(false);

            playerController.RemoveCondition();

            playerController = null;
        }
    }
}
