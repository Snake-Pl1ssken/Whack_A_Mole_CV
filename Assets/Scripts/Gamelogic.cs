using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    private Camera mainCamera;
    private float requiredTouchDuration = 1f;
    private float touchTimer = 0f;
    public GameObject[] cornerCubes; 
    private bool[] isCubeTouched;
    public string SceneToGo;

    void Start()
    {
        mainCamera = Camera.main;

        cornerCubes = GameObject.FindGameObjectsWithTag("CornerCube");
        isCubeTouched = new bool[cornerCubes.Length]; 
    }

    void Update()
    {
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
                requiredTouchDuration = 1f;
                SceneManager.LoadScene(SceneToGo); 
            }
        }
        else
        {
            touchTimer = 0f;
        }
    }
}
