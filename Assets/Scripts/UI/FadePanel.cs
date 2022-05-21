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

    public void Show()
    {
        _canvasGroup.DOFade(1, _animationDuration);
    }

    public void Hide()
    {
        _canvasGroup.DOFade(0, _animationDuration);
    }

    public void Blink()
    {
        _canvasGroup.DOFade(0, _animationDuration).From(1);
    }
}
