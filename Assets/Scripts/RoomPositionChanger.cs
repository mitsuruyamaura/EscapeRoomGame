using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// 部屋の位置を変更するクラス。部屋の各オブジェクトから static を解除すること
/// </summary>
public class RoomPositionChanger : MonoBehaviour
{
    [SerializeField]
    private RoomDetail[] originalArray;

    //[SerializeField]
    private RoomDetail[] copyArray;

    //[SerializeField]
    private Vector3[] newPos;

    [SerializeField]
    private int a = 0;

    //[SerializeField]
    private int b = 0;


    private void Start() {

        newPos = new Vector3[originalArray.Length];

        // 位置情報を保持
        for (int i = 0; i < originalArray.Length; i++) {
            newPos[i] = originalArray[i].transform.localPosition;
            //Debug.Log(newPos[i]);
        }
    }

    private void Update() {
        // デバッグ用
        if(Input.GetKeyDown(KeyCode.Space)) ChangeRoomBackToForward();
    }

    /// <summary>
    /// 奥方向へ部屋を動かす
    /// </summary>
    private void ChangeRoomBackToForward() {

        //a = GamaData.instance.currentInRoomNo;

        a++;

        // 0 に戻すか確認
        a = a % originalArray.Length == 0 ? 0 : a;

        // ディープコピーを作成
        copyArray = new RoomDetail[originalArray.Length];

        Array.Copy(originalArray, copyArray, originalArray.Length);

        b = a;

        // 入れ替え用
        for (int i = 0; i < originalArray.Length; i++) {
            //Debug.Log(b);

            copyArray[i] = originalArray[b];
            originalArray[b].transform.localPosition = newPos[i];

            Debug.Log(copyArray[i].transform.localPosition);

            b++;
            b = b % originalArray.Length == 0 ? 0 : b;
        }
    }
}
