using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _thiefAppeared;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief))
            _thiefAppeared?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief))
            _thiefAppeared?.Invoke();
    }
}
