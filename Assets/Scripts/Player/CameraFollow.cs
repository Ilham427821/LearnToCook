using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;

    public float mouseSensitivity = 2f;
    public float distance = 3f;
    public float height = 1.5f;

    public float zoomSpeed = 2f;
    public float minDistance = 1f;
    public float maxDistance = 10f;

    public LayerMask obstructionMask; // Layer untuk mendeteksi tembok / objek penghalang

    private float yaw = 180f;
    private float pitch = 20f;

    void Start()
    {
        if (target != null)
        {
            yaw = target.eulerAngles.y;
        }

        Camera cam = Camera.main;
        if (cam != null)
        {
            cam.fieldOfView = 60f;
        }
        else
        {
            Debug.LogWarning("Camera.main not found! Pastikan kamera diberi tag 'MainCamera'.");
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Rotasi hanya saat klik kanan
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, 10f, 80f);
        }

        // Hitung posisi kamera yang diinginkan
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position - rotation * Vector3.forward * distance + Vector3.up * height;

        // Deteksi jika ada penghalang
        RaycastHit hit;
        Vector3 direction = desiredPosition - (target.position + Vector3.up * height);
        float currentDistance = distance;

        if (Physics.Raycast(target.position + Vector3.up * height, direction.normalized, out hit, distance, obstructionMask))
        {
            currentDistance = hit.distance - 0.1f; // Tambahkan sedikit jarak agar tidak "nempel"
        }

        // Recalculate posisi berdasarkan hit distance
        Vector3 adjustedPosition = target.position - rotation * Vector3.forward * currentDistance + Vector3.up * height;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, adjustedPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
