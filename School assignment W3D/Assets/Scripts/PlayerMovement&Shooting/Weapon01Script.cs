using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon01Script : MonoBehaviour
{
    [SerializeField] private Transform shootingStart;
    [SerializeField] PlayerTurn playerTurn;
    [SerializeField] TrajectoryRenderer lineRenderer;

    public TextMeshProUGUI forceAmount;

    public float shootForce = 600.0f;
    public float shootForceMin = 600.0f;
    public float shootForceMax = 1000.0f;
    public Rigidbody projectile;
    public float shootForceIncreaseRate = 80.0f;

   

    private void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        if (!IsPlayerTurn) return;


        Vector3 force = shootingStart.forward * shootForce + transform.up * 100f;

        if (PauseScript.gameIsPaused != true)
        {

            if (Input.GetMouseButton(1))
            {
                lineRenderer.DrawCurvedTrajectory(force);
            }
            else
            {
                lineRenderer.ResetTrailRendered();

            }

            if (Input.GetMouseButtonDown(0))
            {

                Rigidbody instance = Instantiate(projectile, shootingStart.position, Quaternion.identity);
                instance.AddForce(force);
                TurnManager.GetInstance().TriggerChangeTurn();
                shootForce = 600;



            }

            shootForce += Input.GetAxis("power") * shootForceIncreaseRate * Time.deltaTime;
            shootForce = Mathf.Clamp(shootForce, shootForceMin, shootForceMax);
            UpdateForceText();

        }
    }
    private void UpdateForceText()
    {
        forceAmount.text = shootForce.ToString();
    }
}
