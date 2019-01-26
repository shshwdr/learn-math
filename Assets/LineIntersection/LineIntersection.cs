using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineIntersection : MonoBehaviour
{

    public LineRenderer line1;
    public LineRenderer line2;
    public GameObject intersectionObject;
    //player want to detect if an enemy is in front of it
    void Update()
    {
        Vector3 intersection;
        if(line1.positionCount==2 && line2.positionCount == 2)
        {

            if(CSMath.IsLineToLineIntersect(line1.GetPosition(0), line1.GetPosition(1), line2.GetPosition(0), line2.GetPosition(1), out intersection))
            {
                intersectionObject.SetActive(true);
                intersectionObject.transform.position = intersection;
            }
            else
            {
                intersectionObject.SetActive(false);
            }
        }
    }
}
