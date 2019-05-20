using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int pointsToAdd = 10;
    public float playerSpeed;
    public float walkSpeed = 2f;
    public float sprintSpeed = 10f;
    public float mouseSensitivity = 2f;
    public float jumpHeight = 8f;
    public float reach = 10f;
    public float power = 100f;
    public Camera cam;
    public GameObject UI;


    private float yRot;
    private float xRot;
    private Rigidbody rigidBody;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = walkSpeed;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // -------------------- Movement --------------------
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
        //transform.Rotate(-Input.GetAxis("Mouse Y") * mouseSensitivity, 0, 0);

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
            Vector3 target = cam.transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime;
            target.y = 0;
            transform.Translate(target, Space.World);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
            Vector3 target = cam.transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime;
            target.y = 0;
            transform.Translate(target, Space.World);
        }

        // -------------------- Jump --------------------
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rigidBody.velocity += (transform.up * jumpHeight);
            isGrounded = false;
        }

        // -------------------- Sprint --------------------
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            playerSpeed = sprintSpeed;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            playerSpeed = walkSpeed;
        }

        // -------------------- Push --------------------
        if (Input.GetMouseButtonDown(0)) {
            Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit);
            Debug.Log(hit.transform.gameObject.name);
            if(hit.distance <= reach && hit.transform.gameObject.GetComponent<Destructible>() != null) {
                hit.transform.gameObject.transform.GetComponent<Destructible>().Kill();
                UI.GetComponent<Scoring>().addScore(pointsToAdd);
            }
        }

    }

    void OnCollisionEnter(Collision collision) {
        isGrounded = true;
    }
}
