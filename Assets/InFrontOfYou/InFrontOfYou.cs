using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFrontOfYou : MonoBehaviour
{

    public Transform playerTrans;
    public Transform enemyTrans;
    public float degreeFromForward = 45;
    //player want to detect if an enemy is in front of it
    void Update()
    {
        Vector3 playerForward = playerTrans.forward;
        Vector3 playerToEnemy = enemyTrans.position - playerTrans.position;
        float dot = Vector3.Dot(playerForward, playerToEnemy);
        float dot2 = Dot(playerForward, playerToEnemy);
        Debug.Assert(Mathf.Approximately(dot,dot2), "dot "+dot+" should get the same value as vector3.Dot "+dot2+" in unity");
        //after dot, 1 means two vector point to the same direction
        //0 means they are perpendicular
        if (dot > 0)
        {
            Debug.Log("enemy is in front of me");
        }
        else
        {
            Debug.Log("enemy is NOT in front of me");
        }
        dot2 = Dot(playerForward.normalized, playerToEnemy.normalized);
        float radiance = Mathf.Acos(dot2);
        float degree = Mathf.Rad2Deg*radiance;
        if (degree <degreeFromForward&&degree>0)
        {
            Debug.Log("enemy is in front of me with angle "+degree+" dot "+dot2);
        }
    }

    float Dot(Vector3 v1,Vector3 v2)
    {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }
}
