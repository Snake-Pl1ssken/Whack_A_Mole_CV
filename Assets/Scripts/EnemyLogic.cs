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

        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            golpeable = true;
            anim.SetBool("taFuera", true);
            elapsed += Time.deltaTime;
        }
        yield return new WaitForSeconds(elapsed);

        elapsed = 0f;
        while (elapsed < showDuration)
        {
            anim.SetBool("taFuera", false);
            golpeable = false;
            elapsed += Time.deltaTime;
        }
        isActive = false;
    }

    private void OnMouseDown()
    {
        if (golpeable)
        {
            anim.SetBool("toyGolpeado", true);
            fueGolpeado = true;
            golpeable = false;
        }
    }
}
