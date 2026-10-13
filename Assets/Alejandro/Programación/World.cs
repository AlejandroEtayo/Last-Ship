using UnityEngine;

public class World : MonoBehaviour
{
    public int carril = 0;
    public GameObject[] suelo;

    public void CrearSuelo()
    {
        Instantiate(suelo[Random.Range(0, suelo.Length)], Vector3.forward* carril, Quaternion.identity);
    }
}
