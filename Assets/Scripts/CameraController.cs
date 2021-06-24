using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform targetTran;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - targetTran.position;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetTran.position + offset;
    }
}
