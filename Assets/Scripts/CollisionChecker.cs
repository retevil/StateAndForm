using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    private PlayerController PC;
    // Start is called before the first frame update
    void Start()
    {
        this.PC = GetComponentInParent<PlayerController>();
    }

    private void OnCollisionStay(Collision collision)
    {
        this.PC.OnChildCollisionStay(collision);
    }
    private void OnCollisionExit(Collision collision)
    {
        this.PC.OnChildCollisionExit(collision);
    }
}
