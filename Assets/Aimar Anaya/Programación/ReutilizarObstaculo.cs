using UnityEngine;

public class ReutilizarObstaculo : MonoBehaviour
{
    public float rapidez = 5f;
    public bool derecha = true;

    void Update()
    {
        // Elige hacia donde camina el coche.
        Vector3 lado = derecha ? Vector3.right : Vector3.left;
        transform.Translate(lado * rapidez * Time.deltaTime);

        // Teletransporta al inicio si se sale por la derecha.
        if (derecha && transform.position.x > 20f)
        {
            transform.position = new Vector3(-20f, transform.position.y, transform.position.z);
        }
        // Teletransporta al inicio si se sale por la izquierda.
        else if (!derecha && transform.position.x < -20f)
        {
            transform.position = new Vector3(20f, transform.position.y, transform.position.z);
        }
    }
}
