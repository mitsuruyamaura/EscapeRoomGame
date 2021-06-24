using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBase : MonoBehaviour
{
    [SerializeField]
    private bool isDestroyOn;


    public void TriggerGimmick() {
        Debug.Log("Gimmick Triggered");

        if (isDestroyOn) {
            Destroy(gameObject);
        }
    }
}
