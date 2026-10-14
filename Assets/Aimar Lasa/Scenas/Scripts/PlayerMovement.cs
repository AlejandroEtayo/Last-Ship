using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 8f;
    public float alturaSalto = 0.3f;
    public int maximoAtras = -4;

    private bool moviendo = false;
    private bool muerto = false;

    private float tamanoCasilla = 1f;
    private float posicionInicialZ;

    void Start()
    {
        posicionInicialZ = transform.position.z;
    }

    void Update()
    {
        if (moviendo || muerto)
            return;

        Vector3 direccion = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.UpArrow))
            direccion = Vector3.forward;
        else if (Input.GetKeyDown(KeyCode.S) ||
                 Input.GetKeyDown(KeyCode.DownArrow))
            direccion = Vector3.back;
        else if (Input.GetKeyDown(KeyCode.A) ||
                 Input.GetKeyDown(KeyCode.LeftArrow))
            direccion = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.D) ||
                 Input.GetKeyDown(KeyCode.RightArrow))
            direccion = Vector3.right;

        if (direccion == Vector3.zero)
            return;

        Vector3 destino =
            transform.position + direccion * tamanoCasilla;

        // Limitar el retroceso a cuatro casillas
        if (direccion == Vector3.back &&
            destino.z < posicionInicialZ -
            maximoAtras * tamanoCasilla - 0.001f)
            return;

        // Comprobar si hay un objeto sólido en el destino
        Vector3 centro = destino + Vector3.up * 0.5f;

        Collider[] objetos = Physics.OverlapBox(
            centro,
            new Vector3(0.35f, 0.45f, 0.35f),
            Quaternion.identity
        );

        foreach (Collider objeto in objetos)
        {
            if (objeto.transform != transform &&
                !objeto.transform.IsChildOf(transform) &&
                !objeto.isTrigger &&
                !objeto.CompareTag("Suelo"))
            {
                return;
            }
        }

        StartCoroutine(MoverCasilla(destino));
    }

    IEnumerator MoverCasilla(Vector3 destino)
    {
        moviendo = true;

        Vector3 inicio = transform.position;
        float duracion = 1f / velocidad;
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;

            float progreso = Mathf.Clamp01(tiempo / duracion);

            Vector3 posicion = Vector3.Lerp(
                inicio, destino, progreso
            );

            posicion.y += Mathf.Sin(progreso * Mathf.PI)
                          * alturaSalto;

            transform.position = posicion;

            yield return null;
        }

        transform.position = destino;
        moviendo = false;
    }

    public void Morir()
    {
        muerto = true;
        StopAllCoroutines();
    }
}