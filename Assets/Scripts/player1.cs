using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Camera mainCamera;
    int puntuacion;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Verificar si hay toques en la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Obtener el primer toque
            Vector2 touchPosition = mainCamera.ScreenToWorldPoint(touch.position); // Convertir a coordenadas del mundo 2D

            // Lanzar un raycast desde la posición del toque
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            // Verificar si el raycast ha tocado algo
            if (hit.collider != null)
            {
                //Debug.Log("Objeto tocado: " + hit.collider.name); // Verificar el nombre del objeto tocado

                //// Comprobar si el objeto tiene la etiqueta "Mole"
                //if (hit.collider.CompareTag("Mole"))
                //{
                //    Debug.Log("¡Tocado un mole!");
                //}
                Debug.Log(puntuacion);
                puntuacion++; 
            }
            else
            {
                Debug.Log("No se ha tocado ningún objeto."); // Mensaje de depuración si no hay contacto
            }
        }
    }
}
