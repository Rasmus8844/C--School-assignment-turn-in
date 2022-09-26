using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    [SerializeField] private GameObject custumizableProjectile;
    [SerializeField] private int stepCount = 10;
    [SerializeField] private LineRenderer lineRenderer;

    public void DrawCurvedTrajectory(Vector3 force)
    {

        float projectileMass = custumizableProjectile.GetComponent<Rigidbody>().mass;
        Vector3 velocity = (force / projectileMass) * Time.fixedDeltaTime;
        float flightDuration = (2 * velocity.y) / -Physics.gravity.y;
        float stepTime = flightDuration / (float) stepCount;

        lineRenderer.positionCount = stepCount;

        for (int i = 0; i < stepCount; i++)
        {
            float timePassed = stepTime * i;
            float height = velocity.y * timePassed - (0.5f * -Physics.gravity.y * timePassed * timePassed);
            Vector3 curvePoint = transform.position + new Vector3(velocity.x * timePassed, height, velocity.z * timePassed);
            lineRenderer.SetPosition(i, curvePoint);

        }

    }

    public void ResetTrailRendered()
    {
        lineRenderer.positionCount = 0;
    }

}
    
