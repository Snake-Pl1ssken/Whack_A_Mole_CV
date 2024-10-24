using UnityEngine;

public class Gamelogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 4)
        {
            Touch touch = Input.GetTouch(0);

            // Update the Text on the screen depending on current position of the touch each frame
            //m_Text.text = "Touch Position : " + touch.position;
        }
        else
        {
            //m_Text.text = "No touch contacts";
        }
    }
}
