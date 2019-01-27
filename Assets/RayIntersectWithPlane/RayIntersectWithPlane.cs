using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayIntersectWithPlane : MonoBehaviour
{

    public Transform playerTrans;
    public Transform planeTrans;
    public LineRenderer lineRenderer;
    //player want to detect if an enemy is in front of it
    void Update()
    {
        ////ref http://www.scratchapixel.com/lessons/3d-basic-rendering/minimal-ray-tracer-rendering-simple-shapes/ray-plane-and-ray-disk-intersection

        ////how to define a plane:
        ////p,p0 are two points on plane, n is the normal of plane
        ////(p-p0)*n = 0 (* is dot)

        ////how to define a ray:
        ////l0 is the origin, p is the point intersect with plane, l is the direction of ray, t is the length of ray
        ////l0 + t*l = p

        ////(l0+t*l-p0)*n = 0
        ////t = (p0*n-l0*n)/(l*n)

        Vector3 p0 = planeTrans.position;//any point on plane would work
        Vector3 n = -planeTrans.up;//assume player is above plane

        Vector3 l0 = playerTrans.position;
        Vector3 l = playerTrans.forward;




        ////take care the case when player face direction perpendicular to n, therefore no intersection
        //if(Mathf.Approximately(Vector3.Dot(l, n), 0))
        //{
        //    Debug.Log("no intersection");

        //}
        //else
        //{
        //    float t = (Vector3.Dot(p0, n) - Vector3.Dot(l0, n)) / Vector3.Dot(l, n);
        //    Vector3 p = l0 + t * l;
        //    lineRenderer.SetPosition(0, l0);
        //    lineRenderer.SetPosition(1, p);

        //    //unity version verify
        //    Ray ray = new Ray(l0, l);
        //    Plane plane = new Plane(n, p0);
        //    float distance;
        //    if (plane.Raycast(ray, out distance))
        //    {
        //        Debug.Assert(Mathf.Approximately(distance, t),"distance calculated from Unity "+distance +"does not equal to the one calculated from my math");
        //        //Debug.Log(distance+" "+t);
        //    }
        //}

        Vector3 intersection;
        if (CSMath.IsLineToPlaneIntersect(l0, l, n, p0, out intersection))
        {
            lineRenderer.SetPosition(0, l0);
            lineRenderer.SetPosition(1, intersection);
        }
    }

    float Dot(Vector3 v1,Vector3 v2)
    {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }
}
