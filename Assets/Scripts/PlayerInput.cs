using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] float autoShootTimer = 2f;

    Shooter[] shooters;

    private void Start()
    {
        shooters = GetComponentsInChildren<Shooter>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            foreach(Shooter shooter in shooters)
            {
                shooter.Aim();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            foreach (Shooter shooter in shooters)
            {
                shooter.Shoot();
            }
        }
    }
}
