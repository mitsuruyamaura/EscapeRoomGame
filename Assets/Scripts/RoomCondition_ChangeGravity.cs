using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCondition_ChangeGravity : RoomConditionBase
{
    private Vector3 gravityScale;

    protected override IEnumerator StartRoomCondition() {

        // プレイヤーにかける重力を設定
        gravityScale = new Vector3(0, conditionValue, 0);

        // ゲーム全体の重力を変更
        //SetWorldGravity();

        // 設定完了にする
        return base.StartRoomCondition();
    }

    private void FixedUpdate() {

        // コンディションの設定が終了したら
        if (isSetUp) {
            // プレイヤーの重力を変更
            SetPlayerGravity();
        }
    }

    /// <summary>
    /// プレイヤーの重力のみ変更
    /// </summary>
    private void SetPlayerGravity() {
        playerController.GetRigidbody().AddForce(gravityScale, ForceMode.Acceleration);
    }

    /// <summary>
    /// ゲーム全体の重力を変更
    /// </summary>
    private void SetWorldGravity() {
        Physics.gravity = gravityScale;
    }
}
