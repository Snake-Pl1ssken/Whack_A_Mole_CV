using System.Collections;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public bool golpeable, fueGolpeado;
    public bool isActive = false;
    public float showDuration, duration;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public IEnumerator ShowHide()
    {
        fueGolpeado = false;
        isActive = true;

        //float elapsed = 0f;
        //while (elapsed < showDuration)
        //{
        //    golpeable = true;
        //    anim.SetBool("taFuera", true);
        //    anim.SetTrigger("Salete");
        //    elapsed += Time.deltaTime;
        //}
        //yield return new WaitForSeconds(elapsed);


        //elapsed = 0f;
        //while (elapsed < showDuration)
        //{
        //    anim.SetBool("taFuera", false);
        //    //anim.SetTrigger("taFueraTrigger");
        //    golpeable = false;
        //    elapsed += Time.deltaTime;
        //}
        //isActive = false;

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
            //anim.SetTrigger("taGolpeadoTrigger");
            fueGolpeado = true;
            golpeable = false;
        }
    }
}
