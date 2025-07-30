using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class RotateOnDrag : MonoBehaviour
{
    private Vector3 lastMousePosition;
    public float rotationSpeed = 100f;
    public string rawImageName = "RawImage"; // Ganti sesuai nama GameObject RawImage kamu

    void Update()
    {
        // Cek apakah sedang klik dan kursor berada di RawImage
        if (Input.GetMouseButtonDown(0) && IsPointerOverRawImage())
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0) && IsPointerOverRawImage())
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;

            // Rotasi horizontal (sumbu Y) dan vertikal (sumbu X)
            transform.Rotate(Vector3.up, -delta.x * rotationSpeed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.right, delta.y * rotationSpeed * Time.deltaTime, Space.World);

            lastMousePosition = Input.mousePosition;
        }
    }

    bool IsPointerOverRawImage()
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        foreach (var result in raycastResults)
        {
            if (result.gameObject.name == rawImageName)
                return true;
        }

        return false;
    }
}
