using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBBall : MonoBehaviour
{
    public float boardHeight = 20;
    public float boardWidth = 20;
    public float height = 1;
    public float width = 1;
    float[] vertices = { };
    public Vector3 moveDir = new Vector3(0.1f,0.2f,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool CheckBounds()
    {
        if (transform.position.y + boardHeight / 2 - height / 2 <= 0)
        {
            Vector3 pos  = transform.position + new Vector3(0, 0.1f, 0);
            transform.position = pos;
            moveDir = new Vector3(moveDir.x, -moveDir.y, 0);
            return true;
        }
        if (transform.position.y - boardHeight / 2 + height / 2 >= 0)
        {
            Vector3 pos = transform.position - new Vector3(0, 0.1f, 0);
            transform.position = pos;
            moveDir = new Vector3(moveDir.x, -moveDir.y, 0);
            return true;
        }
        if (transform.position.x + boardWidth / 2 - width / 2 <= 0)
        {
            Vector3 pos = transform.position + new Vector3(0.1f, 0,0);
            transform.position = pos;
            moveDir = new Vector3(-moveDir.x, moveDir.y, 0);
            return true;
        }
        if (transform.position.x - boardWidth / 2 + width / 2 >= 0)
        {
            Vector3 pos = transform.position - new Vector3(0.1f, 0, 0);
            transform.position = pos;
            moveDir = new Vector3(-moveDir.x, moveDir.y, 0);
            return true;
        }
        return false;
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
