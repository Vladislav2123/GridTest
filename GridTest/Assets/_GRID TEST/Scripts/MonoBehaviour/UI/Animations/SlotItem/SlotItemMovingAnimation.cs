using System.Collections;
using UnityEngine;

public class SlotItemMovingAnimation : SlotItemTransitionAnimation
{
    public override void PlayAnimation()
    {
        TryStopPlayingAnimation();
        PlayingAnimation = StartCoroutine(AnimationRoutine());
    }

    private IEnumerator AnimationRoutine()
    {
        Vector2 originPosition = transform.localPosition;
        float t = 0;

        while(t <= 1)
        {
            transform.localPosition = Vector2.Lerp(originPosition, Vector3.zero, t);

            t += Time.deltaTime / _animationDuration; 
            yield return null;
        }

        transform.localPosition = Vector3.zero;
        TryStopPlayingAnimation();
    }
}
