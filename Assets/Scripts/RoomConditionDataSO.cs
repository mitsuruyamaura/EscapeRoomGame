using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 部屋のコンディションの情報のマスターデータのデータベース
/// </summary>
[CreateAssetMenu(fileName = "RoomConditionDataSO", menuName = "Create RoomConditionSO")]
public class RoomConditionDataSO : ScriptableObject
{
    [System.Serializable]
    public class RoomConditionData {
        public RoomConditionType roomConditionType;
        public float conditionValue;
    }

    public List<RoomConditionData> roomConditionDatasList = new List<RoomConditionData>();
}
