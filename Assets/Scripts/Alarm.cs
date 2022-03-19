using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _stepVolumeUp;

    private AudioSource _source;
    private float _maximumValue = 1f;
    private float _minimumValue = 0f;
    private float _startVolume = 0f;
    private float _percentOfStep = 100f;
    private WaitForSeconds _waitSeconds;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.volume = _startVolume;
        _stepVolumeUp /= _percentOfStep;
        _waitSeconds = new WaitForSeconds(_stepVolumeUp);
    }

    public void StartTurnUpVolume()
    {
        StartCoroutine(TurnUpVolume());
    }

    public void StartTurnDownVolume()
    {
        StartCoroutine(TurnDownVolume());
    }

    private IEnumerator TurnUpVolume()
    {
        _source.Play();

        while (_startVolume <= _maximumValue)
        {
            _source.volume = Mathf.MoveTowards(_minimumValue, _maximumValue, _startVolume += _stepVolumeUp);
            yield return _waitSeconds;
        }
    }

    private IEnumerator TurnDownVolume()
    {
        while (_startVolume >= _minimumValue)
        {
            _source.volume = Mathf.MoveTowards(_minimumValue, _maximumValue, _startVolume -= _stepVolumeUp);
            yield return _waitSeconds;
        }

        _source.Stop();
    }
}
