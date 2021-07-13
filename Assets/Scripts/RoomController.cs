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

        // �ʒu����ێ�
        for (int i = 0; i < orijinalArray.Length; i++) {
            newPos[i] = orijinalArray[i].transform.localPosition;
            Debug.Log(newPos[i]);
        }
    }

    private void Update() {
        // �f�o�b�O�p
        if(Input.GetKeyDown(KeyCode.Space)) ChangeRoomBackToForward();
    }

    /// <summary>
    /// �������֕����𓮂���
    /// </summary>
    private void ChangeRoomBackToForward() {

        //a = GamaData.instance.currentRoomNo;

        a++;

        // 0 �ɖ߂����m�F
        a = a % orijinalArray.Length == 0 ? 0 : a;

        // �f�B�[�v�R�s�[���쐬
        copyArray = new RoomDetail[orijinalArray.Length];

        Array.Copy(orijinalArray, copyArray, orijinalArray.Length);

        b = a;

        // ����ւ��p
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
