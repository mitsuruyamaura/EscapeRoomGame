using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetail : MonoBehaviour
{
    public int roomNo;

    public Vector2Int roomPos;

    public bool inRoom;�@�@�@// �����Ǘ�

    public PlayerController playerController;

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
        }
    }

    private void OnTriggerExit(Collider other) {
        if (playerController) {
            // ��������ގ�
            inRoom = false;
            SwitchPlayerParent(false);
            playerController = null;
        }
    }
}
