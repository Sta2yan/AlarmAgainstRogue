using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _soundChangeInSecond;

    private AudioSource _source;
    private float _maximumValue = 1f;
    private float _minimumValue = 0f;
    private float _startVolume = 0f;
    private float _stepChangeTime;
    private float _percentOfStep = 1000f;
    private WaitForSeconds _waitSeconds;
    private Coroutine _coroutine;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.Play();
        _source.volume = _startVolume;
        _stepChangeTime = _soundChangeInSecond / _percentOfStep;
        _waitSeconds = new WaitForSeconds(_stepChangeTime);
    }

    public void StartChangeSmoothVolume(int duration)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeSmoothVolume(duration));
    }

    private IEnumerator ChangeSmoothVolume(int duration)
    {
        _startVolume = _source.volume;
        float a = 0;

        while (_startVolume <= _maximumValue && _startVolume >= _minimumValue)
        {
            a += Time.deltaTime;
            _source.volume = Mathf.MoveTowards(_minimumValue, _maximumValue, _startVolume += _soundChangeInSecond * Time.deltaTime * duration);
            Debug.Log(a);
            yield return _waitSeconds;
        }
    }
}
