using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBBall : MonoBehaviour
{
    public float boardHeight = 20;
    public float boardWidth = 20;
    public float height = 1;
    public float width = 1;
    public List<Transform> colliders;
    public Vector3 moveDir = new Vector3(0.1f,0.2f,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool CheckBounds()
    {
        if (transform.position.y + boardHeight / 2 - height / 2 <= 0)
        {
            Vector3 pos  = transform.position;

            pos.y = -(boardHeight / 2 - height / 2 - 0.1f);
            transform.position = pos;
            moveDir = new Vector3(moveDir.x, -moveDir.y, 0);
            return true;
        }
        if (transform.position.y - boardHeight / 2 + height / 2 >= 0)
        {
            Vector3 pos = transform.position;

            pos.y = (boardHeight / 2 - height / 2 - 0.1f);
            transform.position = pos;
            moveDir = new Vector3(moveDir.x, -moveDir.y, 0);
            return true;
        }
        if (transform.position.x + boardWidth / 2 - width / 2 <= 0)
        {
            Vector3 pos = transform.position;
            pos.x = -(boardWidth / 2 - width / 2 - 0.1f);
            transform.position = pos;
            moveDir = new Vector3(-moveDir.x, moveDir.y, 0);
            return true;
        }
        if (transform.position.x - boardWidth / 2 + width / 2 >= 0)
        {
            Vector3 pos = transform.position;
            pos.x = boardWidth / 2 - width / 2 - 0.1f;
            transform.position = pos;
            moveDir = new Vector3(-moveDir.x, moveDir.y, 0);
            return true;
        }
        bool found = false;
        foreach(Transform t in colliders)
        {
            Vector3 p1 = t.position;
            Vector3 p2 = transform.position;
            float dx = (p1 - p2).x;
            float dy = (p1 - p2).y;
            float absdx = Mathf.Abs(dx);
            float absdy = Mathf.Abs(dy);
            if (absdx <= width && absdy <= height)
            {
                if (absdx > absdy)
                {

                    Vector3 pos;
                    if (dx > 0)
                    {
                        pos = p1 - new Vector3(width + 0.1f,0, 0);
                    }
                    else
                    {
                        pos = p1 + new Vector3( width + 0.1f,0, 0);
                    }
                    pos.y = transform.position.y;
                    transform.position = pos;
                    moveDir = new Vector3(-moveDir.x, moveDir.y, 0);
                }
                else
                {
                    Vector3 pos;
                    if (dy > 0)
                    {
                        pos = p1 - new Vector3(0, height+0.1f, 0);
                    }
                    else
                    {
                        pos = p1 + new Vector3(0, height + 0.1f, 0);
                    }
                        
                    pos.x = transform.position.x;
                    transform.position = pos;
                    moveDir = new Vector3(moveDir.x, -moveDir.y, 0);
                }
                found = true;
            }
        }
        return found;
    }
    // Update is called once per frame
    void Update()
    {
        if (!CheckBounds())
        {
            transform.position += moveDir;
        }
    }
}
