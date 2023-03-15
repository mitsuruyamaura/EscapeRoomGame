using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ClearChecker : MonoBehaviour
{
    [SerializeField, Header("クリアに必要なアイテムの名前")]
    private ItemType[] needClearItemTypes;

    [SerializeField, Header("クリアアイテムのランダム設定有無")]
    private bool isRandomClearItemSet;

    [SerializeField, Header("デバッグ用")]
    private ItemType[] allItems;

    [SerializeField, Header("デバッグ用")]
    private ItemType[] shuffleItems;

    [SerializeField, Header("最小クリアアイテム数")]
    private int minItemCount;

    [SerializeField]
    private UIManager uiManager;

    private bool isGameUp;


    public void SetUpClearChecker() {
        // ランダム設定する場合
        if (isRandomClearItemSet) {
            RandomSetClearItems();
        }
    }

    /// <summary>
    /// クリアに必要なアイテムをランダムで設定
    /// </summary>
    public void RandomSetClearItems() {
        // クリアに必要なアイテムの数のランダム設定
        needClearItemTypes = new ItemType[UnityEngine.Random.Range(minItemCount, (int)ItemType.Count)];

        // すべてのアイテムの情報を持つ配列を作る
        ItemType[] allItems = new ItemType[(int)ItemType.Count];

        // 要素設定
        for (int i = 0; i < allItems.Length; i++) {
            allItems[i] = (ItemType)i;
        }

        // すべてのアイテムの要素をシャッフル
        ItemType[] shuffleItems = allItems.OrderBy(x => Guid.NewGuid()).ToArray();

        // シャッフルした要素をクリアのアイテムに設定
        for (int i = 0; i < needClearItemTypes.Length; i++) {
            needClearItemTypes[i] = shuffleItems[i];
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (isGameUp) {
            return;
        }

        if (other.gameObject.TryGetComponent(out PlayerController player)) {

            // ゲームクリア判定の方法の分岐
            if (needClearItemTypes.Length > 0) {
                JudgeGameClearItemTypes(player.itemManager);
            } else {
                JudgeGameClearAllItems(player.itemManager);
            }
        }
    }

    /// <summary>
    /// すべての所持アイテムの確認をしてゲームクリアの判定
    /// </summary>
    public void JudgeGameClearAllItems(ItemManager itemManager) {

        //for (int i = 0; i < itemManager.haveItems.Length; i++) {
        //    if (itemManager.haveItems[i]) {
        //        continue;
        //    } else {
        //        Debug.Log("アイテムが足りない");
        //        return;
        //    }
        //}

        // これでも OK
        if (itemManager.haveItems.All(x => x != true)) {
            Debug.Log("アイテムが足りない");
            return;
        }

        isGameUp = true;
        Debug.Log("ゲームクリア");

        // ゲームクリア表示
        uiManager.PlayGameClear();
    }

    /// <summary>
    /// クリアに必要なアイテムのみを確認してゲームクリアの判定
    /// </summary>
    /// <param name="itemManager"></param>
    public void JudgeGameClearItemTypes(ItemManager itemManager) {
        foreach (ItemType itemType in needClearItemTypes) {
            for (int i = 0; i < itemManager.haveItems.Length; i++) {
                if (itemManager.haveItems[(int)itemType]) {
                    continue;
                } else {
                    Debug.Log("アイテムが足りない");
                    return;
                }
            }
        }
        isGameUp = true;
        Debug.Log("ゲームクリア");

        // ゲームクリア表示
        uiManager.PlayGameClear();
    }

    public int GetNeedClearItemCount() {
        return needClearItemTypes.Length;
    }

    public int GetClearItemTypeNo(int no) {
        return (int)needClearItemTypes[no];
    }

    public ItemType GetClearItemType(int no) {
        return needClearItemTypes[no];
    }
}
