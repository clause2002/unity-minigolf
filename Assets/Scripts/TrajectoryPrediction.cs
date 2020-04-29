using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class TrajectoryPrediction : MonoBehaviour
{
    [SerializeField]
    private Vector2Variable hitValue;

    [SerializeField]
    private float predictionTime = 2.0f;

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private Transform target;
    private Rigidbody2D targetRb2D;

    private List<Vector3> trajectoryPoints = new List<Vector3>();



    private void Start()
    {
        targetRb2D = target.GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        
    }

    private void DisplayTrajectory()
    {
        int maxIterations = Mathf.RoundToInt(predictionTime / Time.fixedDeltaTime);
            Vector2 pos = Vector2.zero;
        Vector2 vel = targetRb2D.velocity + hitValue.Value / targetRb2D.mass;

        float drag = targetRb2D.drag;

        trajectoryPoints.Add(pos);

        for (int i=0; i < maxIterations; i++)
        {
            vel += Physics2D.gravity * Time.fixedDeltaTime;
            vel *= Mathf.Clamp01(1.0f - (drag * Time.fixedDeltaTime));
        }
    }    
}
