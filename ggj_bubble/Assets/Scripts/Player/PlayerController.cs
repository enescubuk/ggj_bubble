using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;

    private Camera playerCamera;
    private float verticalRotation = 0f;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked; // Fareyi kilitle
    }

    void Update()
    {
        // Hareket
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        if(moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + playerCamera.transform.eulerAngles.y;
            float moveX = Mathf.Cos(targetAngle * Mathf.Deg2Rad) * moveSpeed * Time.deltaTime;
            float moveZ = Mathf.Sin(targetAngle * Mathf.Deg2Rad) * moveSpeed * Time.deltaTime;

            transform.position += new Vector3(moveX, 0, moveZ);
        }

        // Kamera Döndürme
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f); // Dikey döngü sınırı

        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}