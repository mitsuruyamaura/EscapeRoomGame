using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    private float x;
    private float z;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float searchRange;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Transform searchTran;

    [SerializeField]
    private UIManager uiManager;

    public ItemManager itemManager;

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out anim);
    }


    void Update()
    {
        MoveInput();
        SearchAction();
    }

    /// <summary>
    /// キー入力
    /// </summary>
    private void MoveInput() {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        Move();    
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move() {
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, z * moveSpeed);
    }

    /// <summary>
    /// 探索
    /// </summary>
    private void SearchAction() {
        if (Input.GetButtonDown("Action")) {
            Ray ray = new Ray(searchTran.position, searchTran.forward);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 1.0f);

            if (Physics.Raycast(ray, out RaycastHit hit, searchRange, layerMask)) {

                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider.TryGetComponent(out GimmickBase gimmic)) {

                    // すでに発動済のギミック発動かどうかを確認
                    if (gimmic.CheckTriggerdGimmick()) {
                        return;
                    }

                    // ギミック発動
                    gimmic.TriggerGimmick(uiManager);
                }
            }
        }
    }

    /// <summary>
    /// 部屋のコンディションの情報をプレイヤーに付与
    /// </summary>
    /// <param name="addRoomConditionType"></param>
    public void AddRoomCondition(RoomConditionType addRoomConditionType) {
        var roomCondition = addRoomConditionType switch {
            RoomConditionType.ChangeGravity => gameObject.AddComponent<RoomCondition_ChangeGravity>(),
            _ => null,
        };

        // コンディションの開始
        roomCondition.OnEnterRoomCondition(this);
    }

    /// <summary>
    /// 付与されている部屋のコンディションの情報を削除
    /// </summary>
    public void RemoveCondition() {
        Destroy(GetComponent<RoomConditionBase>());
    }

    public Rigidbody GetRigidbody() {
        return rb;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out ItemDetail itemDetail)) {
            itemManager.UpdateHaveItem(itemDetail.GetItemType());

            Destroy(itemDetail.gameObject);
        }
    }
}
