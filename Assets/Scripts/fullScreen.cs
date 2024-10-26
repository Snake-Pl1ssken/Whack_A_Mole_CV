using UnityEngine;

public class FullscreenToggle : MonoBehaviour
{
    [SerializeField] GameObject fotoAtrue;
    [SerializeField] GameObject panelToHide;
    private bool isFullscreen = false;

    public void ToggleFullscreen()
    {

        if (isFullscreen)
        {
            panelToHide.SetActive(false);
            fotoAtrue.SetActive(true);
        }
        else
        {
            panelToHide.SetActive(true);
            fotoAtrue.SetActive(false);
        }

        isFullscreen = !isFullscreen;
    }
}
