using UnityEngine;

public class Filas : MonoBehaviour
{
    public GameObject cochePrefab;
    public float tiempoEntreCoches = 3f;

    void Start()
    {

        InvokeRepeating("CocheFila", 1f, tiempoEntreCoches);
    }

    void CocheFila()
    {

        Instantiate(cochePrefab, transform.position, Quaternion.identity);
    }
}
