using UnityEngine;

public class Spawn_Obstacles : MonoBehaviour
{
    // Velocidad de movimiento
    public float speed = 5.0f;
    // Referencia al trigger para reutilizar los objetos
    public GameObject TriggerObstaclesE;
    public Transform TriggerObstaclesS;
    // Referencia al objeto, en este caso los enemigos (obstaculos)
    public GameObject Enemy;
    // Dirección del movimiento
    public Vector3 direccion = Vector3.left;
    void Update()
    {
        // Mueve el objeto de forma constante e independiente de los FPS
        transform.Translate(direccion.normalized * speed * Time.deltaTime);
    }
    // Hacer que cuando se toque el limite, el objeto vuelva al principio de su posicion
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == TriggerObstaclesE)
        {
            transform.position = TriggerObstaclesS.position; 
        }
    }
}
