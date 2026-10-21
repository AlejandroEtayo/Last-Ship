using UnityEngine;

public class Enemies : MonoBehaviour
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
                player.Dano();
            }
        }
    }
}
