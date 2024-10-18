using UnityEngine;

public class salir : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cerrarApp()
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }
}
