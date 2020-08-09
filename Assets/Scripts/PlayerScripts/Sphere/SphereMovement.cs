using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : ObjectMovement
{

    public SphereMovement() : base(formInUse: Form.SPHERE) { }
    public override void MoveTo(Vector3 direction)
    {
        RB.AddForce(direction.normalized * speed * Time.deltaTime);
    }

}
