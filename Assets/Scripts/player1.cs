using UnityEngine;
using TMPro;

public class Player1 : MonoBehaviour
{
    [Header("Texto de puntuacion jugador 1")]
    [SerializeField] TextMeshProUGUI puntuacion_1;

    int puntuacion = 0;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPosition;

            if (Input.touchCount > 0)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            }
            else
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Mole"))
            {
                puntuacion++;
                puntuacion_1.text = "" + puntuacion;
            }
        }
    }
}
