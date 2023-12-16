using UnityEngine;

public class MouseInputSolver : MonoBehaviour
{
    [Header("RayCast Settings")]
    [SerializeField] private LayerMask selectableLayerMask;

    [Header("Links")]
    [SerializeField] private CubeDissolver cubeDissolver;
    [SerializeField] private Exploder exploder;

    [SerializeField] private StatsManager statsManager;

    private RaycastHit _hit;

    private void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0) && CalculateRay(selectableLayerMask))
        {
            cubeDissolver.DissolveCube(_hit.transform.gameObject);
        }

        if (Input.GetMouseButtonDown(1) && CalculateRay())
        {
            exploder.Explode(_hit.point);
            statsManager.AddStep();
        }
    }

    public bool CalculateRay(int layerMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hit, Mathf.Infinity, layerMask))
        {
            return true;
        }

        return false;
    }

    private bool CalculateRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hit))
        {
            return true;
        }

        return false;
    }
}
