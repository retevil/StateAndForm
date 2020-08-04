using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100;

    public float jumpForce = 5;

    private Rigidbody RB;

    private CinemachineVirtualCamera VC;

    private bool IsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponentInChildren<Rigidbody>();
        VC = GetComponentInChildren<CinemachineVirtualCamera>();
        VC.Follow = RB.transform;
    }
   
    public void OnChildCollisionStay(Collision collision)
    {
        this.IsGrounded = true;
    }

    public void OnChildCollisionExit(Collision collision)
    {
        this.IsGrounded = false;
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(GameManager.GM.forward))
        {

            this.MoveTo(new Vector3(0, 0, 1));
        }

        if (Input.GetKey(GameManager.GM.backward))
        {

            this.MoveTo(new Vector3(0, 0, -1));
        }

        if (Input.GetKey(GameManager.GM.left))
        {

            this.MoveTo(new Vector3(-1, 0, 0));
        }

        if (Input.GetKey(GameManager.GM.right))
        {
            this.MoveTo(new Vector3(1, 0, 0));
        }

        if (Input.GetKey(GameManager.GM.jump) && this.IsGrounded == true)
        {
            this.Jump();
        }

    }


    private void MoveTo(Vector3 direction)
    {
        //VER ADDTORQUE
        RB.AddForce(direction.normalized * speed * Time.deltaTime);

    }

    private void Jump()
    {
        RB.AddForce(new Vector3(0, 1f, 0) * jumpForce, ForceMode.Impulse);
        this.IsGrounded = false;
    }
}
