using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCondition_IncreaseGravity : RoomConditionBase
{
    private Vector3 gravityScale;

    protected override IEnumerator StartRoomCondition() {

        // プレイヤーにかける重力を設定
        gravityScale = new Vector3(0, conditionValue, 0);
        
        // 設定完了にする
        return base.StartRoomCondition();
    }

    private void FixedUpdate() {

        // コンディションの設定が終了したら
        if (isSetUp) {
            // プレイヤーに重力をかける
            SetPlayerGravity();
        }
    }

    /// <summary>
    /// プレイヤーに重力をかける
    /// </summary>
    private void SetPlayerGravity() {
        playerController.GetRigidbody().AddForce(gravityScale);   // , ForceMode.Acceleration
    }
}
