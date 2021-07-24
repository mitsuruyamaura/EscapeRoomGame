using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCondition_ChangeGravity : RoomConditionBase
{
    private Vector3 gravityScale;

    private Vector3 originGravityScale;

    protected override IEnumerator StartRoomCondition() {

        originGravityScale = Physics.gravity;

        // �v���C���[�ɂ�����d�͂�ݒ�
        gravityScale = new Vector3(0, conditionValue, 0);

        // �Q�[���S�̂̏d�͂�ύX
        //SetWorldGravity();

        // �ݒ芮���ɂ���
        yield return base.StartRoomCondition();

        //yield return new WaitForSeconds(3.0f);

        // �Q�[���S�̂̏d�͂����ɖ߂�
        //ReturnWorldGravity();
    }

    private void FixedUpdate() {

        // �R���f�B�V�����̐ݒ肪�I��������
        if (isSetUp) {
            // �v���C���[�̏d�͂�ύX
            SetPlayerGravity();
        }
    }

    /// <summary>
    /// �v���C���[�̏d�͂̂ݕύX
    /// </summary>
    private void SetPlayerGravity() {
        playerController.GetRigidbody().AddForce(gravityScale, ForceMode.Acceleration);
    }

    /// <summary>
    /// �Q�[���S�̂̏d�͂�ύX
    /// </summary>
    private void SetWorldGravity() {
        Physics.gravity = gravityScale;
    }

    /// <summary>
    /// �Q�[���S�̂̏d�͂����ɖ߂�
    /// </summary>
    private void ReturnWorldGravity() {
        Physics.gravity = originGravityScale;
    }
}
