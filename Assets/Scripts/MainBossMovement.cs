using UnityEngine;
using UnityEngine.InputSystem;

public class MainBossMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D myRb;
    private Vector2 moveInput;
    private float moveSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    public float fireRate = 0.2f;

    private Vector2 rawInput;
    private Vector2 finalDirection;
    private bool isMouse;
    private bool isFiring;
    private float nextFireTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRb.linearVelocity = moveInput * moveSpeed;

        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (moveDir != Vector2.zero)
        {
            // Change to transform.right if your sprite faces right by default
            transform.up = moveDir;
        }

        HandleAiming();

        // Check if firing and if cooldown has finished
        if (isFiring && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate; // Reset cooldown
        }
    }

    void HandleAiming()
    {
        if (isMouse)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(rawInput.x, rawInput.y, -Camera.main.transform.position.z));
            finalDirection = ((Vector2)mouseWorldPos - (Vector2)transform.position).normalized;
        }
        else if (rawInput.sqrMagnitude > 0.1f)
        {
            finalDirection = rawInput.normalized;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        rawInput = context.ReadValue<Vector2>();
        Debug.Log("Looking");
        isMouse = context.control.device is Mouse;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        // Read the value directly (Button West is 1.0, Trigger is 0.0 to 1.0)
        float value = context.ReadValue<float>();

        // If the value is high enough, we are firing
        isFiring = value > 0.1f;
    }

    void Fire()
    {
        float angle = Mathf.Atan2(finalDirection.y, finalDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = finalDirection * bulletSpeed;
    }
}
