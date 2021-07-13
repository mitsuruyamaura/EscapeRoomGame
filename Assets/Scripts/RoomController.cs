using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RoomController : MonoBehaviour
{
    [SerializeField]
    private RoomDetail[] orijinalArray;

    //[SerializeField]
    private RoomDetail[] copyArray;

    //[SerializeField]
    private Vector3[] newPos;

    [SerializeField]
    private int a = 0;

    //[SerializeField]
    private int b = 0;


    private void Start() {

        newPos = new Vector3[orijinalArray.Length];

        // 位置情報を保持
        for (int i = 0; i < orijinalArray.Length; i++) {
            newPos[i] = orijinalArray[i].transform.localPosition;
            Debug.Log(newPos[i]);
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

        //a = GamaData.instance.currentRoomNo;

        a++;

        // 0 に戻すか確認
        a = a % orijinalArray.Length == 0 ? 0 : a;

        // ディープコピーを作成
        copyArray = new RoomDetail[orijinalArray.Length];

        Array.Copy(orijinalArray, copyArray, orijinalArray.Length);

        b = a;

        // 入れ替え用
        for (int i = 0; i < orijinalArray.Length; i++) {
            //Debug.Log(b);

            copyArray[i] = orijinalArray[b];
            orijinalArray[b].transform.localPosition = newPos[i];

            Debug.Log(copyArray[i].transform.localPosition);

            b++;
            b = b % orijinalArray.Length == 0 ? 0 : b;
        }
    }
}
