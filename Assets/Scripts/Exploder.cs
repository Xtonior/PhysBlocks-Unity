using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [Header("Explosion Prefab")]
    [SerializeField] private ParticleSystem explosionEffect;

    [Header("Explosion Settings")]
    [SerializeField] private float cooldown;

    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForce;

    [Header("Camera")]
    [SerializeField] private CameraShaker cameraShaker;
    [SerializeField] private float shakeTime;

    private float _time;

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (_time >= 0)
        {
            _time -= Time.deltaTime;
            return;
        }
    }

    public void Explode(Vector3 position)
    {
        explosionEffect.transform.position = position;
        explosionEffect.Play();

        Collider[] colliders = Physics.OverlapSphere(position, explosionRadius);

        foreach (var collider in colliders)
        {
            Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddForce((rb.transform.position - position) * explosionForce);

                cameraShaker.Shake(shakeTime);
            }
        }

        _time = cooldown;
    }
}
