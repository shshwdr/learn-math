using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeftOrRight : MonoBehaviour
{

    public Transform playerTrans;
    public Transform enemyTrans;
    //player want to detect if an enemy is in front of it
    void Update()
    {
        Vector3 playerRight = playerTrans.right;
        Vector3 playerToEnemy = enemyTrans.position - playerTrans.position;
        float dot = Vector3.Dot(playerRight, playerToEnemy);
        //after dot, 1 means two vector point to the same direction
        //0 means they are perpendicular
        //if the right direction is at the same direction, it means I need to turn right
        if (dot > 0)
        {
            Debug.Log("turn right to face enemy");
        }
        else
        {
            Debug.Log("turn left to face enemy");
        }
        float dot2 = Vector3.Dot(playerRight, enemyTrans.forward);
        if (dot2 > 0)
        {
            Debug.Log("turn right to face the same direction as enemy");
        }
        else
        {
            Debug.Log("turn left to face the same direction as enemy");
        }
    }

    float Dot(Vector3 v1,Vector3 v2)
    {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }
}
