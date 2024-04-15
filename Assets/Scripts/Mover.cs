using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField, Range(-10f, 0f)] private float Slider = -10f;

    private void Update()
    {
        transform.position = new Vector3(0f, 2f, Slider);
    }
}
