using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaData : MonoBehaviour
{
    public static GamaData instance;

    [Header("所持しているアイテムの List")]
    public List<ItemData> itemDatasList = new List<ItemData>();

    public int controllRoomNo;

    [Header("現在プレイヤーのいる部屋の番号")]
    public int currentInRoomNo;


    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// アイテム用 List にアイテムを追加
    /// </summary>
    /// <param name="itemData"></param>
    public void AddItemDatasList(ItemData itemData) {

        // 所持しているアイテムか確認する
        if (itemDatasList.Exists(x => x.itemType == itemData.itemType)) {
            return;
        }

        // 所持していないアイテムのみ追加
        itemDatasList.Add(itemData);
    }

    /// <summary>
    /// アイテム用 List からアイテムを削除
    /// </summary>
    /// <param name="itemData"></param>
    /// <returns></returns>
    public void RemoveItemDatasList(ItemData itemData) {
        itemDatasList.Remove(itemData);
    }

    /// <summary>
    /// 現在いる部屋の情報を設定
    /// </summary>
    /// <param name="roomNo"></param>
    public void SetRoomInfo(int roomNo) {　　　//　情報を増やしたい場合には、引数を増やす
        currentInRoomNo = roomNo;
    }
}
