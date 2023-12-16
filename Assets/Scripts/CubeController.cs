using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private StatsManager statsManager;

    public void OnEnable()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y < -15)
        {
            statsManager.AddPoint(100);
            gameObject.SetActive(false);
        }
    }
}
