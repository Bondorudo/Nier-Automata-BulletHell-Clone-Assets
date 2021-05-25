using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerControllers { TOPDOWN, SIDESCROLLER, FIRSTPERSON}

public class PlayerController : MonoBehaviour
{
    public PlayerControllers state;

    void Start()
    {
        state = PlayerControllers.TOPDOWN;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == PlayerControllers.TOPDOWN)
        {

        }

    }

    private void FixedUpdate()
    {
    }

    
}
    
