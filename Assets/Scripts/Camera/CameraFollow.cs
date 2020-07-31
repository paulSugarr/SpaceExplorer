using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [Range(1f, 40f), SerializeField] private float laziness = 10f;
    [SerializeField] private bool lookAtTarget = true;
    [SerializeField] private bool takeOffsetFromInitialPos = true;
    [SerializeField] private Vector3 generalOffset;
    private Vector3 cameraPosition;

    private void Start()
    {
        if (takeOffsetFromInitialPos && target != null) generalOffset = transform.position - target.position;
    }

    void FixedUpdate()
    {

        if (target != null)
        {
            cameraPosition = target.position + generalOffset;
            transform.position = Vector3.Lerp(transform.position, cameraPosition, 1 / laziness);

            if (lookAtTarget) transform.LookAt(target);
        }
    }
}
