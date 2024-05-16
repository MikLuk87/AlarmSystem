using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private Coroutine _coroutine;

    private float _setVolume = 0f;
    private float _step = 1f;
    private float _delay = 0.1f;

    private bool _isPlaying = false;
    private bool _isStopping = false;

    public void StartAlarm()
    {
        _setVolume = 1f;

        _isStopping = false;

        if (_isPlaying == false)
        {
            _isPlaying = true;
            Debug.Log("StartAlarm");
            _alarm.Play();
        }

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Smoother());
        }
    }

    public void StopAlarm()
    {
        _setVolume = 0f;

        _isStopping = true;

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Smoother());
        }
    }

    private IEnumerator Smoother()
    {
        var wait = new WaitForSeconds(_delay);

        while (_alarm.volume != _setVolume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _setVolume, _step * Time.deltaTime);

            yield return wait;
        }

        Debug.Log("StopCoroutine");
        StopCoroutine(_coroutine);
        _coroutine = null;

        if (_isStopping)
        {
            _isPlaying = false;
            Debug.Log("StopAlarm");
            _alarm.Stop();
        }
    }
}