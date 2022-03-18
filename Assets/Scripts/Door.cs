using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief) && TryGetComponent<Alarm>(out Alarm alarm))
            alarm.StartTurnUpVolume();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief) && TryGetComponent<Alarm>(out Alarm alarm))
            alarm.StartTurnDownVolume();
    }
}
