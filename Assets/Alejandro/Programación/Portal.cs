using UnityEngine;

public class Portal : MonoBehaviour
{
    // Referencia al trigger para reutilizar los objetos
    public GameObject TriggerObstaclesEntrada;
    public Transform TriggerObstaclesSalida;
    // Referencia al objeto, en este caso los enemigos (obstaculos)
    public GameObject[] Enemy;

    // Hacer que cuando se toque el limite, el objeto vuelva al principio de su posicion
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.LogError("entra " + other.gameObject.tag);
            other.gameObject.transform.position = TriggerObstaclesSalida.position;
        }
    }
    
}
