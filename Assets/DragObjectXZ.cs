using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private void Update()
    {
        float planeY = 20;
        Transform draggingObject = transform;

        Plane plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance; // the distance from the ray origin to the ray intersection of the plane

        float minX = -30f; // bounding box
        float maxX = 30f;
        float minZ = -15f;
        float maxZ = 15f;

        if (plane.Raycast(ray, out distance))
        {
            draggingObject.position = new Vector3(
                Mathf.Clamp(ray.GetPoint(distance).x, minX, maxX),
                ray.GetPoint(distance).y,
                Mathf.Clamp(ray.GetPoint(distance).z, minZ, maxZ)
            ); // distance along the ray
        }
    }
}
