using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Example : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Application.OpenURL("mailto:jorgeluisgarciaorbegoso@gmail.com?subject=Quiero Contratarte");
    }
}
