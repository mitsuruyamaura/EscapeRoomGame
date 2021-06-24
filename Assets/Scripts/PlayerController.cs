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
    /// ÉLÅ[ì¸óÕ
    /// </summary>
    private void MoveInput() {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        Move();    
    }

    /// <summary>
    /// à⁄ìÆ
    /// </summary>
    private void Move() {
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, z * moveSpeed);
    }

    /// <summary>
    /// íTçı
    /// </summary>
    private void SearchAction() {
        if (Input.GetButtonDown("Action")) {
            Ray ray = new Ray(searchTran.position, searchTran.forward);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 1.0f);

            if (Physics.Raycast(ray, out RaycastHit hit, searchRange, layerMask)) {

                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider.TryGetComponent(out GimmickBase gimmic)) {
                    gimmic.TriggerGimmick(uiManager);
                }
            }
        }
    }
}
