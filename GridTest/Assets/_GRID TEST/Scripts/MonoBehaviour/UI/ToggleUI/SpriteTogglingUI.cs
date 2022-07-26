using UnityEngine;
using UnityEngine.UI;

public class SpriteTogglingUI : Toggling
{
    [SerializeField] private Image _togglingImage;
    [SerializeField] private Sprite _enabledSprite;
    [SerializeField] private Sprite _disabledSprite;

    protected override void OnDisabled()
    {
        _togglingImage.sprite = _disabledSprite;
    }

    protected override void OnEnabled()
    {
        _togglingImage.sprite = _enabledSprite;
    }
}
