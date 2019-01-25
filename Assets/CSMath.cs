using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSMath : MonoBehaviour
{
    public static bool IsLineToLineIntersect(Vector3 line1Start,Vector3 line1End, Vector3 line2Start,Vector3 line2End,out Vector3 intersection)
    {
        Vector3 line1Dir = line1End - line1Start;
        Vector3 line2Dir = line2End - line2Start;
        Vector3 line3 = line1Start - line2Start;//any two position on 1 and 2 would work

        Vector3 linePerpen12 = Vector3.Cross(line1Dir, line2Dir);
        //if l1 and l2 parallel, area should be 0
        bool isParallel = Mathf.Approximately(linePerpen12.sqrMagnitude, 0);
        if (isParallel)
        {
            if (line1Start == line2Start)
            {
                Debug.Log("two lines are overlap");

                intersection = Vector3.zero;
                return false;
            }
            Debug.Log("two lines parallel to each other");
            intersection = Vector3.zero;
            return false;
        }
        //find the line4 perpendicular to l1 and l2
        //if l4 also perpendicular to l3, then l1 and l2 on the same plane
        float line3DotLinePerpen12 = Vector3.Dot(line3, linePerpen12);
        bool isCorplaner = Mathf.Approximately(line3DotLinePerpen12,0);
        if (!isCorplaner)
        {
            Debug.Log("two lines are not on the same plane");
            intersection = Vector3.zero;
            return false;
        }
        Debug.Log("two lines intersect");
        intersection = Vector3.zero;
        return true;
    }
}
