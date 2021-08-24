using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Coffee.UIExtensions;

public class UIManager : MonoBehaviour
{
    // InfoSet
    [SerializeField]
    private Text txtMessage;

    [SerializeField]
    private Button btnBackgroundFilter;

    [SerializeField]
    private CanvasGroup canvasGroupInfo;

    [SerializeField]
    private Image imgItem;

    // OpeningSet
    [SerializeField]
    private CanvasGroup canvasGroupOpening;

    [SerializeField]
    private Transform needItemTran;


    // GameClearSet
    [SerializeField]
    private RectTransform imgFrameRectTran;

    [SerializeField]
    private ShinyEffectForUGUI shinyEffect;

    [SerializeField]
    private Image imgGameClearLogo;

    [SerializeField]
    private Button btnRestart;

    [SerializeField]
    private CanvasGroup canvasGroupRestartText;

    Tween tween;


    void Start() {
        btnBackgroundFilter.onClick.AddListener(CloseGetInfo);

        btnBackgroundFilter.interactable = false;
        canvasGroupInfo.alpha = 0;

        canvasGroupInfo.blocksRaycasts = false;

        // �Q�[���N���A�\���̏������B���S�ƃt���[���������Ȃ���Ԃɂ���
        imgGameClearLogo.fillAmount = 0;
        imgFrameRectTran.sizeDelta = new Vector2(0, imgFrameRectTran.sizeDelta.y);
        btnRestart.interactable = false;
        canvasGroupRestartText.alpha = 0;
        btnRestart.onClick.AddListener(OnClickRestart);
    }

    /// <summary>
    /// �C���t�H�\�������
    /// </summary>
    private void CloseGetInfo() {
        canvasGroupInfo.DOFade(0f, 0.5f);

        btnBackgroundFilter.interactable = false;
        canvasGroupInfo.blocksRaycasts = false;
        canvasGroupInfo.DOFade(0, 0.5f);
    }

    /// <summary>
    /// ���肵���A�C�e���̃C���t�H�\��
    /// </summary>
    /// <param name="itemData"></param>
    public void DisplayGetInfo(ItemData itemData) {
        txtMessage.text = itemData.itemType.ToString();
        imgItem.sprite = itemData.itemSprite;

        canvasGroupInfo.DOFade(1.0f, 0.5f);

        canvasGroupInfo.blocksRaycasts = true;
        btnBackgroundFilter.interactable = true;
    }

    /// <summary>
    /// �I�[�v�j���O���o�̍Đ�
    /// </summary>
    /// <returns></returns>
    public IEnumerator PlayOpening(List<ItemIconDetail> itemIconDetailsList) {

        canvasGroupOpening.alpha = 0;

        for (int i = 0; i < itemIconDetailsList.Count; i++) {
            Instantiate(itemIconDetailsList[i], needItemTran).TransparentDisplayItemIcon(1.0f);
        }

        canvasGroupOpening.DOFade(1.0f, 1.0f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(2.5f);

        canvasGroupOpening.DOFade(0f, 1.0f).SetEase(Ease.Linear)
            .OnComplete(() => { canvasGroupOpening.blocksRaycasts = false; });    
    }

    /// <summary>
    /// �Q�[���N���A���o�̍Đ�
    /// </summary>
    public void PlayGameClear() {

        // �t���[���A���S�̏��ɃA�j�������āA���̌�A�{�^����L��������
        Sequence sequence = DOTween.Sequence();
        sequence.Append(imgFrameRectTran.DOSizeDelta(new Vector2(3000, imgFrameRectTran.sizeDelta.y), 1.5f).SetEase(Ease.Linear));
        sequence.Append(imgGameClearLogo.DOFillAmount(1.0f, 1.0f).SetEase(Ease.OutQuart))
            .OnComplete(() => 
            {
                shinyEffect.Play(1.0f);
                DisplayRestart();
                btnRestart.interactable = true;
            });
    }

    /// <summary>
    /// Restart �̕����̓_��
    /// </summary>
    private void DisplayRestart() {
        // �����_�ł����[�v�\��
        tween = canvasGroupRestartText.DOFade(1.0f, 1.0f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    /// <summary>
    /// �Q�[���N���A�\�����ɉ�ʂ��N���b�N�����ۂ̏���
    /// </summary>
    private void OnClickRestart() {

        // TODO �g�����W�V��������


        // �����_�ł̃��[�v����������
        tween.Kill();

        // TODO �V�[���̍ēǂݍ���
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
