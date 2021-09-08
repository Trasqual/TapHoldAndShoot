using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ShootTrajectory : MonoBehaviour
{
    [SerializeField] int trajectoryLenght = 20;
    [SerializeField] LayerMask groundMask;
    [SerializeField] GameObject groundIndicator;

    LineRenderer lr;

    RaycastHit hit;
    Vector3 finalHitPosition;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        groundIndicator.SetActive(false);
    }

    public void DrawTrajectory(Vector3 velocity)
    {
        lr.positionCount = trajectoryLenght;
        lr.SetPositions(Points(transform.position, velocity, trajectoryLenght));
        groundIndicator.SetActive(true);
        DetectCollision(Points(transform.position, velocity, trajectoryLenght));
    }

    public void ResetTrajectory()
    {
        lr.positionCount = 0;
        groundIndicator.SetActive(false);
        var newIndicator = Instantiate(groundIndicator, finalHitPosition, Quaternion.identity);
        newIndicator.SetActive(true);
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

    private void DetectCollision(Vector3[] points)
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            if(Physics.Linecast(points[i], points[i + 1], out hit,groundMask))
            {
                groundIndicator.transform.position = hit.point;
                if(hit.point != Vector3.zero)
                {
                    finalHitPosition = hit.point;
                }
            }
        }
    }
}
