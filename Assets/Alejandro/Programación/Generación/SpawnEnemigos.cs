using System.Collections.Generic;
using UnityEngine;

//Función para generar enemigos en el juego
public class SpawnEnemigos : MonoBehaviour
{
    //Variable para la lista de objetos a generar
    public GameObject[] objetos;

    public Transform LugarSpawn;
    // Punto donde aparecerá el objeto

    private GameObject AsteroideGenerado;

    private void Start()
    {
        GenerarAsteroide();
    }
    public void GenerarAsteroide()
    {
        // Eliminar el asteroide anterior
        if (AsteroideGenerado != null)
        {
            Destroy(AsteroideGenerado);
            AsteroideGenerado = null;
        }

        if (objetos == null || objetos.Length == 0)
        {
            Debug.LogWarning("No hay objetos para generar.");
            return;
        }

        if (LugarSpawn == null)
        {
            Debug.LogWarning("Falta asignar LugarSpawn en " + gameObject.name);
            return;
        }



        int array = Random.Range(0, objetos.Length);
        AsteroideGenerado = Instantiate(objetos[array], LugarSpawn.position, LugarSpawn.rotation);
        
        AsteroideGenerado.transform.SetParent(transform, true);
    }

 }
    