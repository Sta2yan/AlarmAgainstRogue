using UnityEngine;

public class Door : MonoBehaviour
{
    public bool HasEnter { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief))
            HasEnter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief))
            HasEnter = false;
    }
}
