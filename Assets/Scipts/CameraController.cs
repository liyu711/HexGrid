using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float fastSpeed;
    public float normalSpeed;
    public float rotationSpeed;
    public float moveSpeed;
    public float moveTime;
    public Transform cameraTransform;

    public Vector3 newPosition;
    public Vector3 zoomAmount;
    public Vector3 newZoom;

    public Vector3 dragStartPos;
    public Vector3 dragEndPos;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newZoom = cameraTransform.localPosition;
    }



    // Update is called once per frame
    void Update()
    {
        HandleMouseInput();
        HandleMovementInput();
    }

    void HandleMouseInput()
    {

        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += (Input.mouseScrollDelta.y * zoomAmount);
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Plane plane = new Plane(Vector3.up, Vector3.zero);
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    float entry;

        //    if (plane.Raycast(ray, out entry))
        //    {
        //        dragStartPos = ray.GetPoint(entry);
        //    }
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Plane plane = new Plane(Vector3.up, Vector3.zero);
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    float entry;

        //    if (plane.Raycast(ray, out entry))
        //    {
        //        dragEndPos = ray.GetPoint(entry);
        //        newPosition = transform.position + dragStartPos - dragEndPos;
        //    }
        //}
    }


    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = fastSpeed;
        }
        else
        {
            moveSpeed = normalSpeed;
        }
        float rotationInput = Input.GetAxis("CameraRotation");
        gameObject.transform.Rotate(Vector3.up, -rotationInput * rotationSpeed * Time.deltaTime);

        float horizontalInput = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
        float verticalInput = Input.GetAxis("Vertical");
        gameObject.transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);


        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }

        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * moveTime);
    }
}
