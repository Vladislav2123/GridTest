using UnityEngine;
using DG.Tweening;

public class SlotItemMovingAnimation : SlotItemTransitionAnimation
{
    public override void PlayAnimation()
    {
        TryKillAndCreateNewSequence();
        _playingSequence.Append(transform.DOLocalMove(Vector3.zero, _duration)).SetEase(_ease);
    }
}
