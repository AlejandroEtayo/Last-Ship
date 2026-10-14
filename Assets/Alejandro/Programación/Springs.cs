using UnityEngine;


public class Springs : MonoBehaviour
{
    public GameObject Player;
    public PlayerMovement Movimiento;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.Curar();
            }
        }
    }
}
