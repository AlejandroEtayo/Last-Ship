using UnityEngine;

public class World : MonoBehaviour
{
    public int carril = 0;
    public GameObject[] suelo;

    //Cantidad de carriles que se generan al inicio del juego
    public int SueloSpawn; 

    //Nada más empezar el juego se generan 10 carriles de suelo para que el jugador pueda avanzar
    private void Start()
    {
        for(int i = 0; i < SueloSpawn; i++)
        {
            CrearSuelo();
        }
    }

    //El suelo se genera aleatoriamente entre todos los prefabs de tipos de carriles que se añadan en lista. estos se añaden dependiendo de el avance del jugador (1 paso arriba, un nuevo carril)
    public void CrearSuelo()
    {
        Instantiate(suelo[Random.Range(0, suelo.Length)], Vector3.forward* carril, Quaternion.identity);
        carril++;
    }
}
