using UnityEngine;
using Cinemachine;


public interface ObjectMovementInt 
{
    void MoveTo(Vector3 dir);
    void Jump();

    void SetCamera(CinemachineVirtualCamera CV);
}
