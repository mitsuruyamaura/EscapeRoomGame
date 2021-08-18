using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("所持しているアイテム")]
    public bool[] haveItems;

    [SerializeField]
    private ClearChecker clearChecker;

    [SerializeField]
    private ItemIconDetail itemIconDetailPrefab;

    [SerializeField]
    private List<ItemIconDetail> itemIconDetailsList = new List<ItemIconDetail>();

    [SerializeField]
    private Transform itemIconDetailTran;

    [SerializeField, Header("配置アイテムのリスト")]
    private List<ItemDetail> itemsList = new List<ItemDetail>();

    // TODO アイテムのプレファブのアサイン


    void Start() {
        SetUpItemManager();

        // クリア条件の設定
        clearChecker.SetUpClearChecker();

        CreateItemIconDetails();

        // TODO アイテムの配置

        // アイテムの情報設定
        SetItemDetails();
    }

    /// <summary>
    /// 初期設定
    /// </summary>
    /// <param name="itemCount"></param>
    public void SetUpItemManager(int itemCount = 0) {
        if (itemCount == 0) {
            haveItems = new bool[(int)ItemType.Count];
        } else {
            haveItems = new bool[itemCount];
        }
    }

    /// <summary>
    /// UI にアイテムアイコンの作成
    /// </summary>
    private void CreateItemIconDetails() {

        for (int i = 0; i < clearChecker.GetNeedClearItemCount(); i++) {
            ItemIconDetail itemIconDetail = Instantiate(itemIconDetailPrefab, itemIconDetailTran, false);
            itemIconDetail.SetUpItemIconDetail(clearChecker.GetClearItemTypeNo(i));
            itemIconDetailsList.Add(itemIconDetail);
        }
    }

    /// <summary>
    /// 所持しているアイテム情報の更新
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="isSwitch"></param>
    public void UpdateHaveItem(ItemType itemType, bool isSwitch = true) {
        haveItems[(int)itemType] = isSwitch;

        if (isSwitch) {
            Debug.Log("アイテム取得 : " + itemType.ToString());

            // 獲得したアイテムのアイコンを表示
            //itemIconDetailsList.Find(x => x.ItemNo == (int)itemType).SwitchDisplayItemIcon(true);

            // 獲得したアイテムのアイコンの透明度を戻す
            itemIconDetailsList.Find(x => x.ItemNo == (int)itemType).TransparentDisplayItemIcon(1.0f);

        } else {
            Debug.Log("アイテム喪失 : " + itemType.ToString());
        }
    }

    // TODO クリアアイテムの生成

    /// <summary>
    /// 各アイテムのアイテムの種類の情報の設定
    /// </summary>
    private void SetItemDetails() {
        for (int i = 0; i < clearChecker.GetNeedClearItemCount(); i++) {
            itemsList[i].SetItemType(clearChecker.GetClearItemType(i));
        }
    }
}
