using System.Collections;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Bird _bird; 

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        _bird = FindObjectOfType<Bird>();

        Vector3 lineZeroPos = new Vector3(
            _bird.transform.position.x, 
            _bird.transform.position.y, 
            -0.1f);

        lineRenderer.SetPosition(0, lineZeroPos);
    }

    
    void Update()
    { 
        if (_bird.IsDragging)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, _bird.transform.position);
        }
        else
        {
            lineRenderer.enabled = false;
        }
        
    }
}
