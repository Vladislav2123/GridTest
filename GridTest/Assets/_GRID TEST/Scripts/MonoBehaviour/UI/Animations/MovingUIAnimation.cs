using System.Collections;
using UnityEngine;

public class MovingUIAnimation : UIAnimation
{
    [SerializeField] private Vector2 _moveOffset;

    public override void PlayAnimation()
    {
        TryStopPlayingAnimation();
        PlayingAnimation = StartCoroutine(MoveAnimation());
    }

    private IEnumerator MoveAnimation()
    {
        Vector2 originPosition = transform.position;
        Vector2 targetPosition = originPosition + _moveOffset;
        float t = 0;

        while(t <= 1)
        {
            transform.position = Vector2.Lerp(originPosition, targetPosition, t);

            t += Time.deltaTime / _animationDuration;
            yield return null;
        }

        transform.position = targetPosition;
        TryStopPlayingAnimation();
    }
}
