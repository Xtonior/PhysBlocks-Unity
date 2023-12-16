using UnityEngine;

public class RotatingScript : MonoBehaviour
{
    [Header("Rotation Effect")]
    [SerializeField] private float speed;

    [Space]

    [Header("Bouncing Effect")]
    [SerializeField] private float bounceCoeff;
    [SerializeField] private float bounceRange;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime, Space.Self);
        transform.position = _startPosition + new Vector3(0, Mathf.Sin(Time.time * bounceCoeff) * bounceRange, 0);
    }
}
