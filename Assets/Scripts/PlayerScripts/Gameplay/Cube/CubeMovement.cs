using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CubeMovement : ObjectMovement
{
    public CubeMovement() : base(formInUse: Form.CUBE) { }

    public float torqueForce = 5f;
    public override void MoveTo(Vector3 direction)
    {
        RB.AddForce(direction.normalized * speed * Time.deltaTime);
        RB.AddTorque(new Vector3(direction.z, 0, direction.x*-1) * torqueForce);
    }

}
