using UnityEngine;


public class MovimientoLaser : MonoBehaviour
{
   
    public float speed = 10.0f;

  
    public Vector3 direccion = Vector3.right;

    void Update()
    {
       
        transform.Translate(direccion.normalized * speed * Time.deltaTime);

      
        if (transform.position.x >= 18.0f)
        {
            Destroy(gameObject);
        }
    }
}