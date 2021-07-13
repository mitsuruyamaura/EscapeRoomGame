using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaData : MonoBehaviour
{
    public static GamaData instance;

    public List<ItemData> itemDatasList = new List<ItemData>();

    public int controllRoomNo;


    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void AddItemDataList(ItemData itemData) {
        if (itemDatasList.Exists(x => x.itemType == itemData.itemType)) {
            return;
        }

        itemDatasList.Add(itemData);
    }
}
