using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] GameObject cameraHolder;
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
    float verticalLookRotation;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;
    [SerializeField]Rigidbody rb;
    [SerializeField] GameObject enemy;
    [SerializeField] int deathDepth;

    private void Start()
    {
        enemy.SetActive(false);
    }

    void Update()
    {  
        if(Input.GetKeyDown(KeyCode.P))
        {
            UIManager.instance.infoText.SetActive(false);
            enemy.SetActive(true); 
        }

        Look();
        Move();
        Jump();

        if (transform.position.y < deathDepth)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    void Move()
    {
        Vector3 movDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, movDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        UIManager.instance.gameOverPanel.SetActive(true);
        Debug.Log("Player died");
    } 
}
