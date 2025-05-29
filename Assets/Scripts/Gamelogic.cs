using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    private Camera mainCamera;
    private float requiredTouchDuration = 1f;
    private float touchTimer = 0f;
    private GameObject[] cornerCubes; 
    private bool[] isCubeTouched;
    public string SceneToGo;
    public GameObject particulasAcierto, particulasNoAcierto;

    void Start()
    {
        mainCamera = Camera.main;

        cornerCubes = GameObject.FindGameObjectsWithTag("CornerCube");
        isCubeTouched = new bool[cornerCubes.Length]; 
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 worldPos = mainCamera.ScreenToWorldPoint(touch.position);

            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Mole") || hit.collider.CompareTag("Mole2"))
                {
                    Instantiate(particulasAcierto, hit.point, Quaternion.identity);
                }
                else
                {
                    Instantiate(particulasNoAcierto, hit.point, Quaternion.identity);
                }
            }
            else
            {
                Instantiate(particulasNoAcierto, worldPos, Quaternion.identity);
            }
        }

        int touchedCount = 0; 

        for (int i = 0; i < isCubeTouched.Length; i++)
        {
            isCubeTouched[i] = false;
            cornerCubes[i].GetComponent<MeshRenderer>().material.color = Color.white;
        }

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

        for (int i = 0; i < isCubeTouched.Length; i++)
        {
            if (isCubeTouched[i])
            {
                touchedCount++;
            }
        }

        if (touchedCount == cornerCubes.Length)
        {
            touchTimer += Time.deltaTime;

            if (touchTimer >= requiredTouchDuration)
            {
                SceneManager.LoadScene(SceneToGo); 
            }
        }
        else
        {
            touchTimer = 0f;
        }
    }
}
