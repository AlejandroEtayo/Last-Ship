using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool muerto = false;
    private PlayerMovement movimiento;

    void Start()
    {
        movimiento = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (muerto)
            return;

        if (other.CompareTag("Coche"))
        {
            muerto = true;

            movimiento.Morir();

            Debug.Log("GAME OVER: Has sido atropellado.");
        }
    }
}