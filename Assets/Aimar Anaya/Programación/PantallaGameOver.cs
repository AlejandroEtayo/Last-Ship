using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaGameOver : MonoBehaviour
{
    public void LateUpdate()
    {
        Vector3 posicionPantalla = Camera.main.WorldToViewportPoint(transform.position);

        if (posicionPantalla.x < -0.01f || posicionPantalla.x > 1.05f ||
            posicionPantalla.y < -0.01f || posicionPantalla.y > 1.05f)
        {
            Time.timeScale = 0f;

            SceneManager.LoadScene("Menu Muerte", LoadSceneMode.Additive);

            enabled = false;
        }
    }
}
