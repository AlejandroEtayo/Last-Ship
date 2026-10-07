using UnityEngine;


public class Springs : MonoBehaviour
{
    public GameObject Player;
    public Movimiento Movimiento;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Movimiento player = other.GetComponent<Movimiento>();
            if (player != null)
            {
                player.Curar();
            }
        }
    }
}
