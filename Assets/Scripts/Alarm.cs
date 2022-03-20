using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent (typeof(Door))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _soundChangeInSecond;

    private AudioSource _source;
    private Door _door;
    private float _maximumValue = 1f;
    private float _minimumValue = 0f;
    private float _startVolume = 0f;
    private float _stepChangeTime;
    private float _percentOfStep = 100f;
    private WaitForSeconds _waitSeconds;
    private Coroutine _pastCoroutineChangeSmoothVolume;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _door = GetComponent<Door>();
        _source.Play();
        _source.volume = _startVolume;
        _stepChangeTime = _soundChangeInSecond / _percentOfStep;
        _waitSeconds = new WaitForSeconds(_stepChangeTime);
    }

    public void StartChangeSmoothVolume()
    {
        if (_pastCoroutineChangeSmoothVolume != null)
            StopCoroutine(_pastCoroutineChangeSmoothVolume);
        _pastCoroutineChangeSmoothVolume = StartCoroutine(ChangeSmoothVolume());
    }

    private IEnumerator ChangeSmoothVolume()
    {
        if (_door.HasEntered)
        {
            while (_startVolume <= _maximumValue)
            {
                _source.volume = Mathf.MoveTowards(_minimumValue, _maximumValue, _startVolume += _soundChangeInSecond * Time.deltaTime);
                yield return _waitSeconds;
            }
        }
        else
        {
            while (_startVolume >= _minimumValue)
            {
                _source.volume = Mathf.MoveTowards(_minimumValue, _maximumValue, _startVolume -= _soundChangeInSecond * Time.deltaTime);
                yield return _waitSeconds;
            }
        }
    }
}
