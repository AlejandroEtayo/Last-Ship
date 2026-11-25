
using UnityEngine;


public class SpawnLaser : MonoBehaviour
{
   
    public GameObject LaserGenerado;

    
    public Transform LugarSpawn;

    
    public float tiempoMinimo = 8.0f;
    public float tiempoMaximo = 15.0f;

    
    private float tiempoRestante;

    private void Start()
    {
      
        GenerarLaser();

       
        tiempoRestante = Random.Range(tiempoMinimo, tiempoMaximo);
    }

    private void Update()
    {
      
        tiempoRestante -= Time.deltaTime;

        
        if (tiempoRestante <= 0)
        {
            GenerarLaser();


            tiempoRestante = Random.Range(tiempoMinimo, tiempoMaximo);
        }
    }

    private void GenerarLaser()
    {
        if (LaserGenerado == null)
        {
            Debug.LogWarning("No hay laser que generar");
            return;
        }

        Instantiate(LaserGenerado, LugarSpawn.position, LugarSpawn.rotation);
    }
}
