using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[System.Serializable]
public abstract class ObjectMovement : MonoBehaviour, ObjectMovementInt
{
    
    public float speed = 100;

    public float jumpForce = 5;

    protected Rigidbody RB;

    protected bool IsGrounded;

    private Form formInUse;

    public Form FormInUse { get => formInUse; set => formInUse = value; }

    protected ObjectMovement(Form formInUse)
    {
        FormInUse = formInUse;
    }

    void Start()
    {
        SetRB();
    }

    private void SetRB()
    {
        if (RB == null)
        {
            RB = GetComponent<Rigidbody>();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        IsGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }



    public abstract void MoveTo(Vector3 direction);


    public void Jump()
    {
        if (this.IsGrounded == true)
        {
            RB.AddForce(new Vector3(0, 1f, 0) * jumpForce, ForceMode.Impulse);
            IsGrounded = false;
        }
    }

    public void SetCamera(CinemachineVirtualCamera CV)
    {
        SetRB();
        CV.Follow = RB.transform;
    }

    public void Activate(bool active)
    {
        gameObject.SetActive(active);
    }

   
}
