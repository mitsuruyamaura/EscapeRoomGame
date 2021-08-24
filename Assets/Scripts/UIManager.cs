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

        // ゲームクリア表示の初期化。ロゴとフレームを見えない状態にする
        imgGameClearLogo.fillAmount = 0;
        imgFrameRectTran.sizeDelta = new Vector2(0, imgFrameRectTran.sizeDelta.y);
        btnRestart.interactable = false;
        canvasGroupRestartText.alpha = 0;
        btnRestart.onClick.AddListener(OnClickRestart);
    }

    /// <summary>
    /// インフォ表示を閉じる
    /// </summary>
    private void CloseGetInfo() {
        canvasGroupInfo.DOFade(0f, 0.5f);

        btnBackgroundFilter.interactable = false;
        canvasGroupInfo.blocksRaycasts = false;
        canvasGroupInfo.DOFade(0, 0.5f);
    }

    /// <summary>
    /// 入手したアイテムのインフォ表示
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
    /// オープニング演出の再生
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
    /// ゲームクリア演出の再生
    /// </summary>
    public void PlayGameClear() {

        // フレーム、ロゴの順にアニメさせて、その後、ボタンを有効化する
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
    /// Restart の文字の点滅
    /// </summary>
    private void DisplayRestart() {
        // 文字点滅をループ表示
        tween = canvasGroupRestartText.DOFade(1.0f, 1.0f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    /// <summary>
    /// ゲームクリア表示中に画面をクリックした際の処理
    /// </summary>
    private void OnClickRestart() {

        // TODO トランジション処理


        // 文字点滅のループ処理を解除
        tween.Kill();

        // TODO シーンの再読み込み
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
