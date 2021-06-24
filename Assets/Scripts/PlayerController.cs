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

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out anim);
    }


    void Update()
    {
        MoveInput();
    }

    private void MoveInput() {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        Move();    
    }

    private void Move() {
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, z * moveSpeed);
    }
}
