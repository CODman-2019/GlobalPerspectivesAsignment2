using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMechanic : MonoBehaviour
{
    public Vector3 lookpoint;
    public float distance;
    public LayerMask layer;
    RaycastHit hit;
    Camera cam;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, layer))
        {
            target = hit.transform;
            ArtifactDetails piece = hit.transform.GetComponent<ArtifactDetails>();
            if (UIManager.ui.ui_Recticle.sprite != UIManager.ui.ui_Available)
                UIManager.ui.ChangeToAvailbleRectilce();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("present facts");
                UIManager.ui.LeanIn(piece.GetName(), piece.GetDetails());
            }

        }
        else
        {
            target = null;
            if(UIManager.ui.ui_Recticle.sprite != UIManager.ui.ui_Normal)
            {
                UIManager.ui.ChangeToNormalRectilce();
                UIManager.ui.LeanOut();
            }

        }

    }
}
