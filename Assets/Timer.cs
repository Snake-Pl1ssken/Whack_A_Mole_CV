using UnityEngine;
using TMPro;
using UnityEditor;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    float timer;
    int timeCount;

    [SerializeField] TMP_Text time;

    // Start is called before the first frame update
    void Start()
    {
        //time.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timeCount = (int)timer;
        Debug.Log(timeCount);
       // Debug.Log(timer);
        if (timer <= 60)
        {
            time.text = "" + timeCount;
        }
        else if(timer == 60 || timer >= 60)
        {
            EditorApplication.ExitPlaymode();
            Debug.Log("fin del tiempo");
        }
    }

    //public void NotifyLadrilloRoto(int puntos)
    //{
    //    puntuacion += puntos;
    //}
}
