using UnityEngine;

public class MovementThief : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;

    private void Update()
    {
        if (transform.position != _endPoint.position)
            transform.position = Vector2.MoveTowards(transform.position, _endPoint.position, _speed * Time.deltaTime);
    }
}
