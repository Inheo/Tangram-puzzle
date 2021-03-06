using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class FadePanel : MonoBehaviour
{
    [SerializeField] private float _animationDuration = 0.2f;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show(bool isInstantAnimation = false)
    {
        DOTween.KillAll();

        if(isInstantAnimation == true)
        {
            _canvasGroup.alpha = 1;
            Active();
            return;
        }

        _canvasGroup.DOFade(1, _animationDuration)
        .OnComplete(() =>
        {
            Active();
        });
    }

    public void Hide(bool isInstantAnimation = false)
    {
        DOTween.KillAll();

        if(isInstantAnimation == true)
        {
            _canvasGroup.alpha = 0;
            Deactive();
            return;
        }
        _canvasGroup.DOFade(0, _animationDuration)
        .OnStart(() =>
        {
            Deactive();
        });
    }

    private void Active()
    {
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
    private void Deactive()
    {
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void Blink()
    {
        _canvasGroup.DOFade(0, _animationDuration).From(1);
    }
}
