using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetail : MonoBehaviour
{
    public int roomNo;

    public Vector2Int roomPos;

    public bool inRoom;　　　// 入室管理

    public PlayerController playerController;

    /// <summary>
    /// 部屋とプレイヤーの親子関係の設定・解除
    /// </summary>
    /// <param name="isSetRoomParent"></param>
    public void SwitchPlayerParent(bool isSetRoomParent) {

        if (isSetRoomParent) {
            playerController.transform.SetParent(this.transform);
        } else {
            playerController.transform.SetParent(null);
        }

        Debug.Log(isSetRoomParent ? "プレイヤーをこの部屋の子に設定" : "プレイヤーを部屋の子から解除");
    }

    private void OnTriggerEnter(Collider other) {
        if (!inRoom && other.TryGetComponent(out playerController)) {
            // 部屋に入室
            inRoom = true;
            SwitchPlayerParent(true);
            GamaData.instance.SetRoomInfo(roomNo);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (playerController) {
            // 部屋から退室
            inRoom = false;
            SwitchPlayerParent(false);
            playerController = null;
        }
    }
}
