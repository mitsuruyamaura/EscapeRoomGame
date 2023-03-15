using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class RoomArray {

    public RoomDetail[] roomY;
}

public class MultiRoomPositionChanger : MonoBehaviour
{
    [SerializeField]
    private RoomArray[] roomX;

    [SerializeField]
    private RoomArray[] copyArrays;

    [SerializeField]
    private Vector3[,] newPos;

    [SerializeField]
    private int a = 0;

    //[SerializeField]
    private int b = 0;


    private void Start() {

        newPos = new Vector3[roomX[0].roomY.Length ,roomX[1].roomY.Length];

        // 複数の部屋の位置情報を保持
        for (int i = 0; i < roomX.Length; i++) {
            for (int j = 0; j < roomX.Length; j++) {
                newPos[i, j] = roomX[i].roomY[j].transform.localPosition;
                //Debug.Log(newPos[i, j]);
            }
        }
    }

    private void Update() {
        // デバッグ用
        if (Input.GetKeyDown(KeyCode.LeftShift)) ChangeRoomRow(0);
        if (Input.GetKeyDown(KeyCode.LeftAlt)) ChangeRoomColumn(0);
    }

    /// <summary>
    /// ゲーム画面を頭上からみて、指定した行を左方向へ１つ部屋を動かす
    /// </summary>
    private void ChangeRoomRow(int rowNo) {

        //a = GamaData.instance.currentInRoomNo;

        a++;

        // 0 に戻すか確認
        a = a % roomX[rowNo].roomY.Length == 0 ? 0 : a;

        // ディープコピーを作成の準備
        copyArrays = new RoomArray[roomX[rowNo].roomY.Length];

        // 多次元配列をコピー
        Array.Copy(roomX, copyArrays, roomX[rowNo].roomY.Length);


        b = a;

        // 入れ替え用
        for (int i = 0; i < roomX[rowNo].roomY.Length; i++) {
            //Debug.Log(b);



            //copyArrays[rowNo].roomY[i] = roomX[rowNo].roomY[b];
            roomX[rowNo].roomY[i].transform.localPosition = newPos[rowNo, b];

            //Debug.Log(copyArrays[columnNo].roomY[i].transform.localPosition);

            b++;
            b = b % roomX[rowNo].roomY.Length == 0 ? 0 : b;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="columnNo"></param>
    private void ChangeRoomColumn(int columnNo) {
        a++;

        // 0 に戻すか確認
        a = a % roomX[columnNo].roomY.Length == 0 ? 0 : a;

        // ディープコピーを作成の準備
        copyArrays = new RoomArray[roomX[columnNo].roomY.Length];

        // 多次元配列をコピー
        Array.Copy(roomX, copyArrays, roomX[0].roomY.Length);


        b = a;

        // 入れ替え用
        for (int i = 0; i < roomX[columnNo].roomY.Length; i++) {
            Debug.Log(b);


            
            //copyArrays[i].roomY[columnNo] = roomX[b].roomY[columnNo];
            roomX[i].roomY[columnNo].transform.localPosition = newPos[b, columnNo];
            Debug.Log(newPos[b, columnNo]);

            //Debug.Log(copyArrays[columnNo].roomY[i].transform.localPosition);

            b++;
            b = b % roomX[columnNo].roomY.Length == 0 ? 0 : b;
        }

        //for (int i = 0; i < roomX[columnNo].roomY.Length; i++) {
        //    for (int j = 0; j < roomX[columnNo].roomY.Length; j++) {
        //        roomX[i].roomY[j] = copyArrays[b].roomY[j];

        //        b++;
        //        b = b % roomX[columnNo].roomY.Length == 0 ? 0 : b;
        //    }
        //}
    }
}
