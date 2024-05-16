using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField, Range(-10f, 0f)] private float Slider = -10f;

    private float _minDistance = 0f;
    private float _maxDistance = 2f;

    private void Update()
    {
        transform.position = new Vector3(_minDistance, _maxDistance, Slider);
    }
}