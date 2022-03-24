using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _step;

    private AudioSource _source;
    private float _maximumValue = 1f;
    private float _minimumValue = 0f;
    private float _startVolume = 0f;
    private float _stepChangeTime;
    private float _percentOfStep = 1000f;
    private float _stepChange;
    private WaitForSeconds _waitSeconds;
    private Coroutine _coroutine;

    private void Awake()
    {
        _stepChange = -_step;
        _source = GetComponent<AudioSource>();
        _source.Play();
        _source.volume = _startVolume;
        _stepChangeTime = _step / _percentOfStep;
        _waitSeconds = new WaitForSeconds(_stepChangeTime);
    }

    public void StartChangeSmoothVolume()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeSmoothVolume());
    }

    private IEnumerator ChangeSmoothVolume()
    {
        _startVolume = _source.volume;
        _stepChange = -_stepChange;

        while (_startVolume <= _maximumValue && _startVolume >= _minimumValue)
        {
            _source.volume = Mathf.MoveTowards(_minimumValue, _maximumValue, _startVolume += _stepChange * Time.deltaTime);
            yield return _waitSeconds;
        }
    }
}
