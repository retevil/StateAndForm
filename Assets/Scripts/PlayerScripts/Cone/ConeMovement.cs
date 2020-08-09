using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeMovement : ObjectMovement
{
    public float torqueForce = 1.5f;

    public ConeMovement() : base(formInUse:Form.CONE){}

    public override void MoveTo(Vector3 direction)
    {
       
        RB.AddForce(direction.normalized * speed * Time.deltaTime);
        RB.AddTorque(new Vector3(direction.z, 0, direction.x * -1) * torqueForce);
    }
}
