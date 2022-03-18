using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Door))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _stepVolumeUp;

    private AudioSource _source;
    private Door _door;
    private float _startVolume = 0f;
    private float _percentOfStep = 100f;
    private float _startPointSound = 0f;
    private float _endPointSound = 1f;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _door = GetComponent<Door>();
        _source.volume = 0f;
    }

    private void Update()
    {
        if (_door.HasEnter)
            if(_startVolume <= _endPointSound)
                _source.volume = Mathf.MoveTowards(_startPointSound, _endPointSound, _startVolume += _stepVolumeUp / _percentOfStep);
        else
            if(_startVolume >= _startPointSound)
                _source.volume = Mathf.MoveTowards(_startPointSound, _endPointSound, _startVolume -= _stepVolumeUp / _percentOfStep);
    }
}
