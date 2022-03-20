using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _thiefCame = new UnityEvent();

    public bool HasEntered { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief))
        {
            HasEntered = true;
            _thiefCame.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief))
        {
            HasEntered = false;
            _thiefCame.Invoke();
        }
    }
}
