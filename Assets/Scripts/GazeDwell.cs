using UnityEngine;
using UnityEngine.Events;

public class GazeDwell : MonoBehaviour
{
    public float dwellTime = 1.5f;
    public UnityEvent onDwellComplete;
    float timer = 0f;
    Camera cam;

    void Start() { cam = Camera.main; }

    void Update()
    {
        if (cam == null) return;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider != null && hit.collider.transform == transform)
            {
                timer += Time.deltaTime;
                if (timer >= dwellTime)
                {
                    onDwellComplete?.Invoke();
                    timer = 0f;
                }
            }
            else timer = 0f;
        }
        else timer = 0f;
    }
}
