using UnityEngine;

public class DebugScript : MonoBehaviour
{
    RaycastHit rc;
    Vector3 dir;
    Rigidbody rb;
    private float speed;
    private int rotateSpeed;
    private Vector3 _inputs = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        dir = Vector3.forward;
        speed = GameManager._instance.playerSpeed;
        rotateSpeed = GameManager._instance.playerRotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rc, Mathf.Infinity) && rc.collider.gameObject.tag == "UsableObjects")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(rc.collider.gameObject);
            }
        }
    }

    void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * speed) + (transform.right * Input.GetAxis("Horizontal") * speed));
        rb.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 300);
        }
    }
}
