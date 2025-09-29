using UnityEngine;
public class FloatingBillboard : MonoBehaviour
{
    public Transform targetCamera;
    public bool faceOnlyY = true;

    void Start()
    {
        if (targetCamera == null && Camera.main != null) targetCamera = Camera.main.transform;
    }

    void LateUpdate()
    {
        if (targetCamera == null) return;
        if (faceOnlyY)
        {
            Vector3 dir = targetCamera.position - transform.position;
            dir.y = 0;
            if (dir.sqrMagnitude > 0.001f) transform.rotation = Quaternion.LookRotation(dir);
        }
        else transform.LookAt(targetCamera);
    }
}
