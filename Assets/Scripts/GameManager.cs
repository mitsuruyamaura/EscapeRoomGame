using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GimmickBase> gimmicksList = new List<GimmickBase>();


    void Start()
    {
        SetUpItemDataToGimmicks();
    }

    /// <summary>
    /// 各ギミックのアイテム情報の設定
    /// </summary>
    private void SetUpItemDataToGimmicks() {
        for (int i = 0; i < gimmicksList.Count; i++) {
            gimmicksList[i].SetUpItemData();
        }
    }

    void Update()
    {
        
    }
}
