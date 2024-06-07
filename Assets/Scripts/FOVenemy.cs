using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AlertStage
{
    Peaceful,
    Intrigued,
    Alerted
}
public class FOVenemy : MonoBehaviour
{
    [SerializeField] public float fov;
    [Range(0, 360)] public float fovAngle;
    [SerializeField] public AlertStage alertStage;
    [Range(0, 100)] public float alertLevel;
    [SerializeField] private LayerMask _player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool playerInFOV = false;
        Collider[] targetsInFOV = Physics.OverlapSphere(transform.position, fov, _player);
        foreach (Collider c in targetsInFOV)
        {
            if (c.CompareTag("Player"))
            {
                float signedAngle = Vector3.Angle(transform.forward, c.transform.position - transform.position);
                if (Mathf.Abs(signedAngle) < fovAngle / 2)
                {
                    playerInFOV = true;
                }

                break;
            }
        }

        UpdateAlertState(playerInFOV);
    }
    private void UpdateAlertState(bool playerInFOV)
    {
        switch (alertStage)
        {
            case AlertStage.Peaceful:
                if (playerInFOV)
                {
                    alertStage = AlertStage.Intrigued;
                }
                break;
            case AlertStage.Intrigued:
                if (playerInFOV)
                {
                    alertLevel++;
                    if (alertLevel >= 100)
                    {
                        alertStage = AlertStage.Alerted;
                    }
                }
                else
                {
                    alertLevel--;
                    if (alertLevel <= 0)
                    {
                        alertStage = AlertStage.Peaceful;
                    }
                }
                break;
            case AlertStage.Alerted:
                if (!playerInFOV)
                {
                    alertStage = AlertStage.Intrigued;
                }
                break;
        }
    }

}
