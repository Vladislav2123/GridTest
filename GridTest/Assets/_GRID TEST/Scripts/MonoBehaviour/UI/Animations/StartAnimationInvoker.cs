using UnityEngine;

public class StartAnimationInvoker : MonoBehaviour
{
    [SerializeField] private UIAnimation _invokingAnimation;
    [SerializeField] private float _delay;

    private void Start()
    {
        if (_delay == 0)
        {
            _invokingAnimation.PlayAnimation();
            return;
        }

        Invoke(nameof(PlayAnimation), _delay); // Вызвать _invokingAnimation.PlayAnimation на прямю не получается
    }

    private void PlayAnimation() => _invokingAnimation.PlayAnimation();
}
