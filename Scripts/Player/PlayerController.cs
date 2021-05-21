using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private Camera mainCamera;
    [SerializeField] private PlayerBulletController playerBullet;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float coolDownDefault = 0.1f;
    public float bulletSpeed = 25;
    public int damage = 1;
    float coolDown = 0;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        coolDown += Time.deltaTime;

        Movement();
        Rotation();

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    public void Movement()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
    }

    public void Rotation()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.Rotate(0f, 45f, 0f, Space.World);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    public void Shoot()
    {
        if (coolDown > coolDownDefault)
        {
            Instantiate(playerBullet, firePoint.position, firePoint.rotation);
            coolDown = 0;
        }
    }
}
    
