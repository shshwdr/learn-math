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

        Vector3 linePerpen32 = Vector3.Cross(line2Dir,line3);
        //linePerpen12 parallel to linePerpen32
        float area12MArea32 = Vector3.Dot(linePerpen12, linePerpen32);
        float area12Sqrt = linePerpen12.sqrMagnitude;
        //s = ratio of height of triangle l2 and p in triangle l2l1
        //namely the area of these two triangle
        //this is the same as |linePerpen32| / |linePerpen12|
        float s = area12MArea32/ area12Sqrt;

        intersection = line1Start + line1Dir * s;
        return true;
    }
}
