using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Set Final Time")]
    [SerializeField] int timeCount;
    [Header("Set Text to draw")]
    [SerializeField] TMP_Text time;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1 && timeCount >= 0)
        {
            timeCount--;
            time.text = "" + timeCount;
            timer = 0;
        }
        else if (timeCount == 0 || timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}