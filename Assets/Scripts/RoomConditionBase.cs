using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConditionBase : MonoBehaviour
{
    [SerializeField]
    protected RoomConditionType roomConditionType;

    [SerializeField, Header("効果値")]
    protected float conditionValue;

    protected PlayerController playerController;

    protected bool isSetUp;

    protected RoomConditionDataSO.RoomConditionData roomConditionData; 

    /// <summary>
    /// 外部クラスからコンディションの開始を実行するメソッド
    /// </summary>
    public void OnEnterRoomCondition(PlayerController playerController) {
        this.playerController = playerController;

        // 部屋のコンディションの情報を取得
        roomConditionData = DataBaseManager.instance.GetRoomConditionData(roomConditionType);

        // 設定
        conditionValue = roomConditionData.conditionValue;

        StartCoroutine(StartRoomCondition());
    }

    /// <summary>
    /// コンディションの開始の実処理
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator StartRoomCondition() {

        // 子クラスで実装する


        yield return null;

        isSetUp = true;
    }

    /// <summary>
    /// 外部クラスからコンディションの終了を行うためのメソッド
    /// </summary>
    public void OnExitRoomCondition() {
        StartCoroutine(EndRoomCondition());
    }

    /// <summary>
    /// コンディションの終了の実処理
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator EndRoomCondition() {
        yield return null;

        Destroy(this);
    }
}
