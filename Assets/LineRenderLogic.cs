using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderLogic : MonoBehaviour
{

    public Transform lineStart;
    public Transform lineEnd;
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPositions(new Vector3[]{ lineStart.position,lineEnd.position});
    }
}
