using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraConfiner : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    void Update()
    {

        if (virtualCamera == null)
        {
            Debug.LogError("Virtual Camera not assigned.");
            return;
        }

        var confiner = virtualCamera.GetComponent<CinemachineConfiner>();
        if (confiner == null)
        {
            Debug.LogError("No CinemachineConfiner2D found on the virtual camera.");
            return;
        }

        var boundsObj = GameObject.FindWithTag("Camerabounds");
        if (boundsObj == null)
        {
            Debug.LogError("CameraBounds GameObject not found. Make sure it's tagged correctly.");
            return;
        }

        var collider = boundsObj.GetComponent<PolygonCollider2D>();
        if (collider == null)
        {
            Debug.LogError("CameraBounds GameObject does not have a PolygonCollider2D.");
            return;
        }
        confiner.m_ConfineMode = CinemachineConfiner.Mode.Confine2D;
        confiner.m_BoundingShape2D = collider;
        //confiner.InvalidateCache(); // Recalculate the boundaries
    }
}
