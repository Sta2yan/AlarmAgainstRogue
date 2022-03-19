using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _thiefCame = new UnityEvent();
    [SerializeField] private UnityEvent _thiefGone = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief))
            _thiefCame.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief))
            _thiefGone.Invoke();
    }
}
