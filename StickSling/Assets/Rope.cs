using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Transform Hand;
    public Transform Hook;

    Vector3[] positions = new Vector3[2];

    private GrapplingHook grapplingHook;

    // Start is called before the first frame update
    void Start()
    {
        grapplingHook = GetComponent<GrapplingHook>();
        lineRenderer = GetComponent<LineRenderer>();
    }




    // Update is called once per frame
    void LateUpdate()
    {
        
        if (grapplingHook.isShooting)
        {
            if (!lineRenderer.enabled) lineRenderer.enabled = true;

            positions[0] = Hand.position;
            positions[1] = Hook.position;
            lineRenderer.SetPositions(positions);
        }
    }

    public void ResetRope()
    {
        lineRenderer.enabled = false;
    }

}
