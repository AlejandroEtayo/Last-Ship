using System.Collections.Generic;
using UnityEngine;

//Función para generar enemigos en el juego
public class SpawnEnemigos : MonoBehaviour
{
    //Variable para la lista de objetos a generar
    public GameObject[] objetos;

    public Transform LugarSpawn;
    // Punto donde aparecerá el objeto

    private GameObject objetoGenerado;

    private void Start()
    {
        GenerarObjeto();
    }
    public void GenerarObjeto()
    {
        // Eliminar el asteroide anterior
        if (objetoGenerado != null)
        {
            Destroy(objetoGenerado);
            objetoGenerado = null;
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
        objetoGenerado = Instantiate(objetos[array], LugarSpawn.position, LugarSpawn.rotation);
        
        objetoGenerado.transform.SetParent(transform, true);
    }

 }
    