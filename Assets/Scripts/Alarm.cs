using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private float _step = 1f;
    private float _delay = 0.05f;
    private bool _trigger = false;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    public IEnumerator StartAlarm()
    {
        var wait = new WaitForSeconds(_delay);

        _trigger = true;

        if (_alarm.volume == _minVolume)
        {
            _alarm.Play();
            Debug.Log("Start");
        }

        while (_alarm.volume != _maxVolume & _trigger == true)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _maxVolume, _step * Time.deltaTime);

            yield return wait;
        }
    }

    public IEnumerator StopAlarm()
    {
        var wait = new WaitForSeconds(_delay);

        _trigger = false;

        while (_alarm.volume != _minVolume & _trigger == false)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _minVolume, _step * Time.deltaTime);

            yield return wait;
        }

        if (_alarm.volume == _minVolume)
        {
            _alarm.Stop();
            Debug.Log("Stop");
        }
    }
}