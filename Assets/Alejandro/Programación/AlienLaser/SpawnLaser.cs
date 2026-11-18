using UnityEngine;

public class SpawnLaser : MonoBehaviour
{
    [SerializeField]private float speed = 1.0f;

    [SerializeField] private GameObject LaserGenerado;

    [SerializeField] private float tiempoRestante = 10.0f;

    public Transform LugarSpawn;
    private bool cronometroActivo = true;
    private void Start()
    {
        GenerarLaser();
    }

    private void GenerarLaser()
    {
        if (LaserGenerado == null)
        {
            Debug.LogWarning("No hay laser que generar");
        }

        LaserGenerado = Instantiate(LaserGenerado, LugarSpawn.position, LugarSpawn.rotation);
    }
}
