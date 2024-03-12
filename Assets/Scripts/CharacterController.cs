using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject cam;
    public float speed;
    public float clamp;

    private Rigidbody rb;
    private Vector3 movement, newOrientation;
    private float cameraMove, bodyRot;
    private bool enable;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enable = true;
    }

    // Update is called once per frame
    void Update()
    {
            float playerX = Input.GetAxisRaw("Horizontal") * speed;
            float playerY = Input.GetAxisRaw("Vertical") * speed;

            movement = new Vector3(playerX, 0, playerY);

            bodyRot += Input.GetAxisRaw("Mouse X");
            cameraMove += Input.GetAxisRaw("Mouse Y");
            cameraMove = Mathf.Clamp(cameraMove, -clamp, clamp);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (enable) enable = false;
            else enable = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (enable)
        {
            newOrientation = new Vector3(0, bodyRot, 0);
            //transform.Rotate(0, mousePos.x, 0);
            cam.transform.rotation = Quaternion.Euler(-cameraMove, bodyRot, 0);
        }
        else
        {
            movement = Vector3.zero;
        }

    }


    private void FixedUpdate()
    {

        //rb.MovePosition(rb.transform.position + movement * speed * Time.deltaTime);
        rb.AddRelativeForce(movement);
        rb.MoveRotation(Quaternion.AngleAxis(bodyRot, Vector3.up));
    }

}
