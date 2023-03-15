using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemManager : MonoBehaviour
{
    [Header("所持しているアイテム")]
    public bool[] haveItems;

    public ItemDetail[] itemPrefabs;

    [SerializeField]
    private Transform leftBottomTran;

    [SerializeField]
    private Transform rightTopTran;

    [SerializeField]
    private ItemIconDetail itemIconDetailPrefab;

    [SerializeField]
    private List<ItemIconDetail> itemIconDetailsList = new List<ItemIconDetail>();

    [SerializeField]
    private Transform itemIconDetailTran;

    [SerializeField, Header("配置アイテムのリスト")]
    private List<ItemDetail> itemsList = new List<ItemDetail>();

    [SerializeField]
    private ItemDetail itemDetailPrefab;

    [SerializeField]
    private ClearChecker clearChecker;

    private float maxDistance = 3.0f;    // 原点(アイテムの位置)からの NavMesh の最大サンプリング値


    [SerializeField]
    private UIManager uiManagaer;


    void Start() {
        SetUpItemManager();

        // クリア条件の設定
        clearChecker.SetUpClearChecker();

        CreateItemIconDetails();

        // TODO アイテムの配置
        CreateItems();

        // アイテムの情報設定
        SetItemDetails();

        StartCoroutine(uiManagaer.PlayOpening(itemIconDetailsList));
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

    /// <summary>
    /// アイテムの生成
    /// </summary>
    private void CreateItems() {
        for (int i = 0; i < clearChecker.GetNeedClearItemCount(); i++) {

            // 指定した範囲内でランダムな位置の設定
            Vector3 randomPos = new Vector3(
                Random.Range(leftBottomTran.position.x, rightTopTran.position.x), 
                leftBottomTran.position.y,
                Random.Range(leftBottomTran.position.z, rightTopTran.position.z)
                );

            // ランダムな位置にアイテム生成
            ItemDetail item = Instantiate(itemDetailPrefab, randomPos, itemDetailPrefab.transform.rotation);

            // ランダムに配置したアイテムが壁などに埋もれてしまわないように、アイテムから見て NavMesh 上の最も近い位置を見つける。見つけた情報が hit に代入される
            if (NavMesh.SamplePosition(item.transform.position, out NavMeshHit hit, maxDistance, NavMesh.AllAreas)) {

                // アイテムを NavMesh 上に配置して必ずプレイヤーが取れる位置にする
                item.transform.position = hit.position;
            }

            // リストに追加
            itemsList.Add(item);
        }
    }

    /// <summary>
    /// 各アイテムのアイテムの種類の情報の設定
    /// </summary>
    private void SetItemDetails() {
        for (int i = 0; i < clearChecker.GetNeedClearItemCount(); i++) {
            itemsList[i].SetItemType(clearChecker.GetClearItemType(i));
        }
    }

    public void DestroyAllItems() {
        for (int i = 0; i < itemsList.Count; i++) {
            if (itemsList[i]) {
                Destroy(itemsList[i].gameObject);
            }
        }
        itemsList.Clear();
    }

    void Update() {

        // デバッグ用。アイテム再配置
        if (Input.GetKeyDown(KeyCode.B)) {
            DestroyAllItems();
            CreateItems();
        }    
    }
}
