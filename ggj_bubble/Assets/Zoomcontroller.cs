using UnityEngine;

public class Zoomcontroller : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float targetFOV = 20f;
    private float defaultFOV;

    void Start()
    {
        defaultFOV = Camera.main.fieldOfView;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaultFOV, zoomSpeed * Time.deltaTime);
        }
    }
}
