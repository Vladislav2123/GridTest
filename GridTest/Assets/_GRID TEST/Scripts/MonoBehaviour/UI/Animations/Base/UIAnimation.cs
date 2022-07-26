using UnityEngine;
using DG.Tweening;

public abstract class UIAnimation : MonoBehaviour
{
    [SerializeField] protected float _duration;
    [SerializeField] protected Ease _ease = Ease.Linear;

    protected Sequence _playingSequence;

    public bool IsPlaying => _playingSequence != null && _playingSequence.active == true;

    public abstract void PlayAnimation();

    protected void TryKillAndCreateNewSequence()
    {
        if(_playingSequence != null) _playingSequence.Kill();

        _playingSequence = DOTween.Sequence();
    }
}
