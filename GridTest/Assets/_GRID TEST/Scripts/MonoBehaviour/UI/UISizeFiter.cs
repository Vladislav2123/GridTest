using UnityEngine;

public class UISizeFiter : MonoBehaviour
{
    private enum FitAxis { X, Y }

    [SerializeField] private FitAxis _fitByAxis;
    [SerializeField] private float _ratio = 1;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {
        Fit();
    }

    private void Fit()
    {
        float targetWidth = _fitByAxis == FitAxis.X ? _rectTransform.sizeDelta.x : _rectTransform.rect.height * _ratio;
        float targetHeight = _fitByAxis == FitAxis.X ? _rectTransform.rect.width * _ratio : _rectTransform.sizeDelta.y;
        Vector2 targetSizeDelta = new Vector2(targetWidth, targetHeight);

        _rectTransform.sizeDelta = targetSizeDelta;
    }
}