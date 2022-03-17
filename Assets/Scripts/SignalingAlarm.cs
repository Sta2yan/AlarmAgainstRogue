using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalingAlarm : MonoBehaviour
{
    [SerializeField] private float _stepVolumeUp;

    private AudioSource _alarmSource;
    private bool _isActive;
    private float _startVolume = 0;

    private void Awake()
    {
        _alarmSource = GetComponent<AudioSource>();
        _alarmSource.volume = 0f;
        _isActive = false;
    }

    private void Update()
    {
        if (_isActive)
        {
            if(_startVolume <= 1f)
                _alarmSource.volume = Mathf.MoveTowards(0f, 1f, _startVolume += _stepVolumeUp / 100);
        }
        else
        {
            if(_startVolume >= 0f)
                _alarmSource.volume = Mathf.MoveTowards(0f, 1f, _startVolume -= _stepVolumeUp / 100);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief))
            _isActive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MovementThief>(out MovementThief thief))
            _isActive = false;
    }
}
