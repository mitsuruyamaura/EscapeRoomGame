using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemManager : MonoBehaviour
{
    [Header("�������Ă���A�C�e��")]
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

    [SerializeField, Header("�z�u�A�C�e���̃��X�g")]
    private List<ItemDetail> itemsList = new List<ItemDetail>();

    [SerializeField]
    private ItemDetail itemDetailPrefab;

    [SerializeField]
    private ClearChecker clearChecker;

    private float maxDistance = 3.0f;    // ���_(�A�C�e���̈ʒu)����� NavMesh �̍ő�T���v�����O�l


    [SerializeField]
    private UIManager uiManagaer;


    void Start() {
        SetUpItemManager();

        // �N���A�����̐ݒ�
        clearChecker.SetUpClearChecker();

        CreateItemIconDetails();

        // TODO �A�C�e���̔z�u
        CreateItems();

        // �A�C�e���̏��ݒ�
        SetItemDetails();

        StartCoroutine(uiManagaer.PlayOpening(itemIconDetailsList));
    }

    /// <summary>
    /// �����ݒ�
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
    /// UI �ɃA�C�e���A�C�R���̍쐬
    /// </summary>
    private void CreateItemIconDetails() {

        for (int i = 0; i < clearChecker.GetNeedClearItemCount(); i++) {
            ItemIconDetail itemIconDetail = Instantiate(itemIconDetailPrefab, itemIconDetailTran, false);
            itemIconDetail.SetUpItemIconDetail(clearChecker.GetClearItemTypeNo(i));
            itemIconDetailsList.Add(itemIconDetail);
        }
    }

    /// <summary>
    /// �������Ă���A�C�e�����̍X�V
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="isSwitch"></param>
    public void UpdateHaveItem(ItemType itemType, bool isSwitch = true) {
        haveItems[(int)itemType] = isSwitch;

        if (isSwitch) {
            Debug.Log("�A�C�e���擾 : " + itemType.ToString());

            // �l�������A�C�e���̃A�C�R����\��
            //itemIconDetailsList.Find(x => x.ItemNo == (int)itemType).SwitchDisplayItemIcon(true);

            // �l�������A�C�e���̃A�C�R���̓����x��߂�
            itemIconDetailsList.Find(x => x.ItemNo == (int)itemType).TransparentDisplayItemIcon(1.0f);

        } else {
            Debug.Log("�A�C�e���r�� : " + itemType.ToString());
        }
    }

    /// <summary>
    /// �A�C�e���̐���
    /// </summary>
    private void CreateItems() {
        for (int i = 0; i < clearChecker.GetNeedClearItemCount(); i++) {

            // �w�肵���͈͓��Ń����_���Ȉʒu�̐ݒ�
            Vector3 randomPos = new Vector3(
                Random.Range(leftBottomTran.position.x, rightTopTran.position.x), 
                leftBottomTran.position.y,
                Random.Range(leftBottomTran.position.z, rightTopTran.position.z)
                );

            // �����_���Ȉʒu�ɃA�C�e������
            ItemDetail item = Instantiate(itemDetailPrefab, randomPos, itemDetailPrefab.transform.rotation);

            // �����_���ɔz�u�����A�C�e�����ǂȂǂɖ�����Ă��܂�Ȃ��悤�ɁA�A�C�e�����猩�� NavMesh ��̍ł��߂��ʒu��������B��������� hit �ɑ�������
            if (NavMesh.SamplePosition(item.transform.position, out NavMeshHit hit, maxDistance, NavMesh.AllAreas)) {

                // �A�C�e���� NavMesh ��ɔz�u���ĕK���v���C���[������ʒu�ɂ���
                item.transform.position = hit.position;
            }

            // ���X�g�ɒǉ�
            itemsList.Add(item);
        }
    }

    /// <summary>
    /// �e�A�C�e���̃A�C�e���̎�ނ̏��̐ݒ�
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

        // �f�o�b�O�p�B�A�C�e���Ĕz�u
        if (Input.GetKeyDown(KeyCode.B)) {
            DestroyAllItems();
            CreateItems();
        }    
    }
}
