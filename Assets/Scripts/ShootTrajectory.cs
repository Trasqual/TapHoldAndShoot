using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ShootTrajectory : MonoBehaviour
{
    [SerializeField] int trajectoryDetail = 20;
    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void DrawTrajectory(Vector3 velocity)
    {
        lr.positionCount = trajectoryDetail;
        lr.SetPositions(Points(transform.position, velocity, trajectoryDetail));
    }

    public void ResetTrajectory()
    {
        lr.positionCount = 0;
    }

    Vector3[] Points(Vector3 pos, Vector3 velocity, int numberOfPoints)
    {
        Vector3[] results = new Vector3[numberOfPoints];

        float timeStep = Time.fixedDeltaTime / Physics.defaultSolverVelocityIterations;

        Vector3 gravityAccel = Physics.gravity * timeStep * timeStep;

        Vector3 moveStep = velocity * timeStep;

        for (int i = 0; i < numberOfPoints; i++)
        {
            moveStep += gravityAccel;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }
}
