using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconDetail : MonoBehaviour
{
    [SerializeField]
    private Image imgItemIcon;

    /// <summary>
    /// �ݒ�
    /// </summary>
    /// <param name="itemNo"></param>
    public void SetUpItemIconDetail(int itemNo) {
        imgItemIcon.sprite = Resources.Load<Sprite>("ItemIcon_" + itemNo);

        // �A�C�R�����\��
        SwitchDisplayItemIcon(false);        
    }

    /// <summary>
    /// �A�C�e���A�C�R���̕\���؂�ւ�
    /// </summary>
    /// <param name="isSwitch"></param>
    public void SwitchDisplayItemIcon(bool isSwitch) {
        imgItemIcon.enabled = isSwitch;
    }
}
