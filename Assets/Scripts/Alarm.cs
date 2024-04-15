using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _step = 0.4f;

    private float _mute = 0f;
    private float _maxVolume = 1f;
    private float _setVolume;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Mover>()) 
        {
            _alarm.Play();
            _setVolume = _maxVolume;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Mover>())
        {
            _setVolume = _mute;
        }
    }

    void Update()
    {
         _alarm.volume = Mathf.MoveTowards(_alarm.volume, _setVolume, _step * Time.deltaTime);

        if (_alarm.volume == _setVolume )
        {
            _alarm.Stop();
        }
    }
}