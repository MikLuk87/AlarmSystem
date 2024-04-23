using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Mover mover))
        {
            StartCoroutine(_alarm.StartAlarm());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Mover mover))
        {
            StartCoroutine(_alarm.StopAlarm());
        }
    }
}