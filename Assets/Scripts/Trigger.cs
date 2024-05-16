using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Mover mover))
        {
            _alarm.StartAlarm();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Mover mover))
        {
            _alarm.StopAlarm();
        }
    }
}