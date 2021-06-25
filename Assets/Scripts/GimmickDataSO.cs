using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GimmickDataSO", menuName = "Create GimmickDataSO")]
public class GimmickDataSO : ScriptableObject
{
    public List<GimmickData> gimmickDatasList = new List<GimmickData>();
    
}
