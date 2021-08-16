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
    /// �L�[����
    /// </summary>
    private void MoveInput() {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        Move();    
    }

    /// <summary>
    /// �ړ�
    /// </summary>
    private void Move() {
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, z * moveSpeed);
    }

    /// <summary>
    /// �T��
    /// </summary>
    private void SearchAction() {
        if (Input.GetButtonDown("Action")) {
            Ray ray = new Ray(searchTran.position, searchTran.forward);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 1.0f);

            if (Physics.Raycast(ray, out RaycastHit hit, searchRange, layerMask)) {

                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider.TryGetComponent(out GimmickBase gimmic)) {

                    // ���łɔ����ς̃M�~�b�N�������ǂ������m�F
                    if (gimmic.CheckTriggerdGimmick()) {
                        return;
                    }

                    // �M�~�b�N����
                    gimmic.TriggerGimmick(uiManager);
                }
            }
        }
    }

    /// <summary>
    /// �����̃R���f�B�V�����̏����v���C���[�ɕt�^
    /// </summary>
    /// <param name="addRoomConditionType"></param>
    public void AddRoomCondition(RoomConditionType addRoomConditionType) {
        var roomCondition = addRoomConditionType switch {
            RoomConditionType.ChangeGravity => gameObject.AddComponent<RoomCondition_ChangeGravity>(),
            _ => null,
        };

        // �R���f�B�V�����̊J�n
        roomCondition.OnEnterRoomCondition(this);
    }

    /// <summary>
    /// �t�^����Ă��镔���̃R���f�B�V�����̏����폜
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
