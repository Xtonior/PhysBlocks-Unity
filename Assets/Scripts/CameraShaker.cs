using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private float duration;

    [SerializeField] private float shakeAmount = 0.7f;
    [SerializeField] private float decreaseFactor = 1.0f;

    private Vector3 _startPosition;

    private float _time;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (_time > 0)
        {
            transform.localPosition = _startPosition + Random.insideUnitSphere * shakeAmount;

            _time -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            _time = duration;
            transform.localPosition = Vector3.Lerp(transform.position, _startPosition, Time.deltaTime * decreaseFactor);
        }
    }

    public void Shake(float time)
    {
        _time = time;
    }
}
