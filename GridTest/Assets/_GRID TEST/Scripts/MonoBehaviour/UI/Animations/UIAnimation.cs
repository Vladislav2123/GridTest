using UnityEngine;

public abstract class UIAnimation : MonoBehaviour
{
    [SerializeField] protected float _animationDuration;

    private Coroutine _playingAnimation;

    protected Coroutine PlayingAnimation
    {
        get => _playingAnimation;
        set
        {
            IsPlaying = value != null;
            _playingAnimation = value;
        }
    }

    public bool IsPlaying {get; private set;}

    public abstract void PlayAnimation();

    protected void TryStopPlayingAnimation()
    {
        if(PlayingAnimation == null) return;

        StopCoroutine(PlayingAnimation);
        PlayingAnimation = null;
    }
}
