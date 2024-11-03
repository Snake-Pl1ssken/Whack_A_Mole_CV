using UnityEngine;
using TMPro;

public class player2 : MonoBehaviour
{
    [Header("Texto de puntuacion jugador 2")]
    [SerializeField] TextMeshProUGUI puntuacion_2;

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

            if (hit.collider != null && hit.collider.CompareTag("Mole2"))
            {
                puntuacion++;
                puntuacion_2.text = "" + puntuacion;
            }
        }
    }
}
