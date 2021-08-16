using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// �����̈ʒu��ύX����N���X�B�����̊e�I�u�W�F�N�g���� static ���������邱��
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

        // �ʒu����ێ�
        for (int i = 0; i < originalArray.Length; i++) {
            newPos[i] = originalArray[i].transform.localPosition;
            //Debug.Log(newPos[i]);
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

        //a = GamaData.instance.currentInRoomNo;

        a++;

        // 0 �ɖ߂����m�F
        a = a % originalArray.Length == 0 ? 0 : a;

        // �f�B�[�v�R�s�[���쐬
        copyArray = new RoomDetail[originalArray.Length];

        Array.Copy(originalArray, copyArray, originalArray.Length);

        b = a;

        // ����ւ��p
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
