using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideScrollerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = PlayerMovement();
    }

    public Vector3 PlayerMovement()
    {
        Vector3 moveInput = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        Vector3 moveVelocity = moveInput.normalized * moveSpeed * Time.deltaTime;
        return moveVelocity;
    }
}
