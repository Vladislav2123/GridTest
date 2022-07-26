using UnityEngine;
using DG.Tweening;

public class FadeUIAnimation : UIAnimation
{
    [SerializeField] private CanvasGroup _animatingGroup;
    [SerializeField] [Range (0, 1)] private float _targetFade;

    public override void PlayAnimation()
    {
        TryKillAndCreateNewSequence();
        _playingSequence.Append(_animatingGroup.DOFade(_targetFade, _duration)).SetEase(_ease);
    }
}
