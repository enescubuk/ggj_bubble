using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float lookSpeed = 2f;

    private Camera playerCamera;
    private float verticalRotation = 0f;

    // Crosshair object
    public RectTransform crosshair; // Crosshair referansı

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked; // Fareyi kilitle
    }

    void Update()
    {
        // Kamera Döndürme
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f); // Dikey döngü sınırı

        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        // Raycast işlemini tıklama ile başlat
        if (Input.GetMouseButtonDown(0))
        {
            // Ekranın merkezinde bir noktayı hedef al
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = playerCamera.ScreenPointToRay(screenCenter);
            RaycastHit hit;

            int layerMask = LayerMask.GetMask("Clickable");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                GameObject hittedObject = hit.collider.gameObject;
                if (hittedObject.GetComponent<PaperController>() && hittedObject.GetComponent<PaperController>().currentState == PaperController.State.Printed)
                {
                    hittedObject.GetComponent<PaperController>().MoveToTable();
                }
                else if (hittedObject.GetComponent<TrashController>())
                {
                    hittedObject.GetComponent<TrashController>().MoveToTrash();
                }
                else if (hittedObject.GetComponent<SignatureController>())
                {
                    hittedObject.GetComponent<SignatureController>().Sign();
                }
            }
        }
    }
}