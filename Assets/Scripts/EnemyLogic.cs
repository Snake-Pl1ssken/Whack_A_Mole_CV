using System.Collections;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public bool golpeable, fueGolpeado;
    public bool isActive = false;
    public float showDuration,duration;
    Animator anim;
    public void Init()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public IEnumerator ShowHide()
    {
        fueGolpeado = false;
        isActive = true;

        golpeable = true;
        anim.SetTrigger("Salete");
        anim.ResetTrigger("Vuelve");
        anim.ResetTrigger("golpeTrigger");

        yield return new WaitForSeconds(showDuration);

        golpeable = false;
        anim.SetTrigger("Vuelve");

        isActive = false;
    }

    private void OnMouseDown()
    {
        if (golpeable)
        {
            anim.SetTrigger("golpeTrigger");
            fueGolpeado = true;
            golpeable = false;
        }
    }
}
