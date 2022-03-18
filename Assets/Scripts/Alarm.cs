using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _stepVolumeUp;

    private AudioSource _source;
    private float _startVolume = 0f;
    private float _percentOfStep = 100f;
    private float _startPointSound = 0f;
    private float _endPointSound = 1f;
    private WaitForSeconds _waitSeconds;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.volume = 0f;
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

        while (_startVolume <= 1)
        {
            _source.volume = Mathf.MoveTowards(_startPointSound, _endPointSound, _startVolume += _stepVolumeUp);
            yield return _waitSeconds;
        }
    }

    private IEnumerator TurnDownVolume()
    {
        while (_startVolume >= 0)
        {
            _source.volume = Mathf.MoveTowards(_startPointSound, _endPointSound, _startVolume -= _stepVolumeUp);
            yield return _waitSeconds;
        }

        _source.Stop();
    }
}
