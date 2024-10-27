using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    private Camera mainCamera;
    private float requiredTouchDuration = 1f;
    private float touchTimer = 0f;
    private GameObject[] cornerCubes; // Array para almacenar los cubos de las esquinas
    private bool[] isCubeTouched;     // Array para verificar si cada cubo está tocado

    void Start()
    {
        mainCamera = Camera.main;

        // Encontrar todos los cubos con la etiqueta "CornerCube" y almacenarlos en el array
        cornerCubes = GameObject.FindGameObjectsWithTag("CornerCube");
        isCubeTouched = new bool[cornerCubes.Length]; // Inicializa el array de verificación
    }

    void Update()
    {
        int touchedCount = 0; // Contador para saber cuántos cubos están presionados

        // Resetear el estado de los cubos en cada frame
        for (int i = 0; i < isCubeTouched.Length; i++)
        {
            isCubeTouched[i] = false;
            cornerCubes[i].GetComponent<MeshRenderer>().material.color = Color.white;
        }

        // Detectar toques y actualizar el estado de los cubos tocados
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            Ray ray = mainCamera.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                for (int j = 0; j < cornerCubes.Length; j++)
                {
                    if (hit.transform.gameObject == cornerCubes[j])
                    {
                        isCubeTouched[j] = true;
                        cornerCubes[j].GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                }
            }
        }

        // Contar cuántos cubos están siendo tocados
        for (int i = 0; i < isCubeTouched.Length; i++)
        {
            if (isCubeTouched[i])
            {
                touchedCount++;
            }
        }

        // Verificar si todos los cubos están tocados y empezar a contar
        if (touchedCount == cornerCubes.Length)
        {
            touchTimer += Time.deltaTime;

            // Si han pasado los 3 segundos, cambiar de escena
            if (touchTimer >= requiredTouchDuration)
            {
                SceneManager.LoadScene("MoleScene"); // Cambia "NombreDeTuEscena" por el nombre de la escena
            }
        }
        else
        {
            // Reiniciar el temporizador si no están todos los cubos presionados
            touchTimer = 0f;
        }
    }
}
