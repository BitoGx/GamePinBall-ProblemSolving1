using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Controller : MonoBehaviour
{
    private SpawnTrap Spawner;
    private Ball_Controller ballController;

    // Start is called before the first frame update
    void Start()
    {
        Spawner = FindObjectOfType<SpawnTrap>();
        ballController = FindObjectOfType<Ball_Controller>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            Spawner.TrapDespawned();
            Destroy(gameObject);
            ballController.ResetBall();
        }
    }

}
