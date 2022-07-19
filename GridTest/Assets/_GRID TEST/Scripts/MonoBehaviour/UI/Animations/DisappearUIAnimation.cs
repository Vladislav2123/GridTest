using UnityEngine;
using System.Collections;

public class DisappearUIAnimation : UIAnimation
{
    [SerializeField] private CanvasGroup _animatingGroup;
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
            _animatingGroup.alpha = Mathf.Lerp(originAlpha, 0, t);

            t += Time.deltaTime / _animationDuration;
            yield return null;
        }

        _animatingGroup.alpha = 0;
        TryStopPlayingAnimation();
    }
}
