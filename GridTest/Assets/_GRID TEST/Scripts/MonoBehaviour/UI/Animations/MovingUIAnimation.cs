using UnityEngine;
using DG.Tweening;

public class MovingUIAnimation : UIAnimation
{
    [SerializeField] private Vector2 _moveOffset;

    public override void PlayAnimation()
    {
        TryKillAndCreateNewSequence();
        _playingSequence.Append(transform.DOMove(transform.position + (Vector3)_moveOffset, _duration).SetEase(_ease));
    }
}
