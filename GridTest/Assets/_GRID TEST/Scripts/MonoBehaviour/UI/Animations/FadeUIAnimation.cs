using UnityEngine;
using System.Collections;

public class FadeUIAnimation : UIAnimation
{
    [SerializeField] private CanvasGroup _animatingGroup;
    [SerializeField] [Range (0, 1)] private float _targetFade;

    public override void PlayAnimation()
    {
        TryStopPlayingAnimation();
        PlayingAnimation = StartCoroutine(DisapearAnimation());
    }

    private IEnumerator DisapearAnimation()
    {
        float originAlpha = _animatingGroup.alpha;
        float t = 0;

        while(t <= 1)
        {
            _animatingGroup.alpha = Mathf.Lerp(originAlpha, _targetFade, t);

            t += Time.deltaTime / _animationDuration;
            yield return null;
        }

        _animatingGroup.alpha = _targetFade;
        TryStopPlayingAnimation();
    }
}
