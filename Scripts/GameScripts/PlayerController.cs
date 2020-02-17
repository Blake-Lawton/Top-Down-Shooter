using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody myRigidbody;
    public GameObject player;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController gun;

    public bool useController;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        //Mouse Play
      if(!useController)
      {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
          Vector3 pointToLook = cameraRay.GetPoint(rayLength);
          Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

          transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if(Input.GetMouseButtonDown(0))
        {
            gun.isFiring = true;
        }

        if(Input.GetMouseButtonUp(0))
        {
            gun.isFiring = false;
        }

        
      }
      //Controller PlayGame
      if(useController)
      {
        Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
        if(playerDirection.sqrMagnitude > 0.0f)
        {
          transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
          gun.isFiring = true;
        }
        else
        {
          gun.isFiring = false;
        }

      }
    }

    void FixedUpdate()
    {
      myRigidbody.velocity = moveVelocity;
    }
}
