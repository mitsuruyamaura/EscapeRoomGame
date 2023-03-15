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

        // �����̕����̈ʒu����ێ�
        for (int i = 0; i < roomX.Length; i++) {
            for (int j = 0; j < roomX.Length; j++) {
                newPos[i, j] = roomX[i].roomY[j].transform.localPosition;
                //Debug.Log(newPos[i, j]);
            }
        }
    }

    private void Update() {
        // �f�o�b�O�p
        if (Input.GetKeyDown(KeyCode.LeftShift)) ChangeRoomRow(0);
        if (Input.GetKeyDown(KeyCode.LeftAlt)) ChangeRoomColumn(0);
    }

    /// <summary>
    /// �Q�[����ʂ𓪏ォ��݂āA�w�肵���s���������ւP�����𓮂���
    /// </summary>
    private void ChangeRoomRow(int rowNo) {

        //a = GamaData.instance.currentInRoomNo;

        a++;

        // 0 �ɖ߂����m�F
        a = a % roomX[rowNo].roomY.Length == 0 ? 0 : a;

        // �f�B�[�v�R�s�[���쐬�̏���
        copyArrays = new RoomArray[roomX[rowNo].roomY.Length];

        // �������z����R�s�[
        Array.Copy(roomX, copyArrays, roomX[rowNo].roomY.Length);


        b = a;

        // ����ւ��p
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

        // 0 �ɖ߂����m�F
        a = a % roomX[columnNo].roomY.Length == 0 ? 0 : a;

        // �f�B�[�v�R�s�[���쐬�̏���
        copyArrays = new RoomArray[roomX[columnNo].roomY.Length];

        // �������z����R�s�[
        Array.Copy(roomX, copyArrays, roomX[0].roomY.Length);


        b = a;

        // ����ւ��p
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
