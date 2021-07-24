using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCondition_IncreaseGravity : RoomConditionBase
{
    private Vector3 gravityScale;

    protected override IEnumerator StartRoomCondition() {

        // �v���C���[�ɂ�����d�͂�ݒ�
        gravityScale = new Vector3(0, conditionValue, 0);
        
        // �ݒ芮���ɂ���
        return base.StartRoomCondition();
    }

    private void FixedUpdate() {

        // �R���f�B�V�����̐ݒ肪�I��������
        if (isSetUp) {
            // �v���C���[�ɏd�͂�������
            SetPlayerGravity();
        }
    }

    /// <summary>
    /// �v���C���[�ɏd�͂�������
    /// </summary>
    private void SetPlayerGravity() {
        playerController.GetRigidbody().AddForce(gravityScale);   // , ForceMode.Acceleration
    }
}
