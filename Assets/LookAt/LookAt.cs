using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetP= target.transform.position;
        Vector3 position = transform.position;
        Vector3 forward = targetP - position;
        Vector3 up = Vector3.up;
        Vector3 right = Vector3.Cross(forward, up);
        up = Vector3.Cross(right,forward);
        Matrix4x4 t = new Matrix4x4();
        for (int i = 0; i < 3; i++)
        {
            t[i, 0]  = right[i];
            t[i, 1] = up[i];
            t[i, 2] = forward[i];
        }
        transform.rotation = t.rotation;
    }
}
