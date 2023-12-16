using UnityEngine;

public class CubeDissolver : MonoBehaviour
{
    private RaycastHit _hit;

    public void DissolveCube(GameObject cube)
    {
        cube.SetActive(false);
    }
}
