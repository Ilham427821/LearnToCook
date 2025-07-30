using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTutor : MonoBehaviour
{
    public float speed = 5f;
    public Transform cam; // Drag kamera utama ke sini
    public bool canMove = true; // Tambahan: untuk aktif/tidaknya pergerakan

    private Rigidbody rb;
    private Vector3 moveDir;
    private AnimationController animationController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animationController = GetComponent<AnimationController>();

        if (rb == null)
            Debug.LogError("Rigidbody tidak ditemukan!");
        if (animationController == null)
            Debug.LogWarning("AnimationController tidak ditemukan! Pastikan script ada di GameObject ini.");
    }

    void Update()
    {
        if (!canMove) return; // Tambahan: blokir pergerakan kalau tutorial masih aktif

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (cam != null && direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDirRaw = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir = moveDirRaw.normalized;

            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        if (!canMove) return; // Tambahan: blokir pergerakan fisik

        rb.velocity = moveDir * speed + new Vector3(0, rb.velocity.y, 0);

        if (animationController != null)
        {
            if (moveDir.magnitude > 0)
                animationController.Run();
            else
                animationController.Idle();
        }
    }
}
