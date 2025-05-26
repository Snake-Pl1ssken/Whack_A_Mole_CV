using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoleLogic : MonoBehaviour
{
    public float cuentaAtrasParaFin = 60;
    public TextMeshProUGUI textoDeCuentaAtras, marcadorPlayerB, marcadorPlayerA, cartelVictoria;
    int puntosPlayer1, puntosPlayer2 = 0;
    public GameObject particulasPlayer1, particulasPlayer2;
    public GameObject[] Jugador1Enemies, Jugador2Enemies;

    void Start()
    {
        StartCoroutine(SpawnEnemiesPlayer1());
        StartCoroutine(SpawnEnemiesPlayer2());
        cartelVictoria.text = "";
    }


    void Update()
    {
        int tiempoEnSegundos;

        cuentaAtrasParaFin -= Time.deltaTime;

        tiempoEnSegundos = (int)cuentaAtrasParaFin;

        textoDeCuentaAtras.text = tiempoEnSegundos.ToString();

        if (cuentaAtrasParaFin <= 0.0f)
        {
            cuentaAtrasParaFin = 0;

            if (puntosPlayer1 > puntosPlayer2)
            {
                cartelVictoria.enabled = true;
                cartelVictoria.text = "PLAYER 1 WINS";
                particulasPlayer1.SetActive(true);
            }
            else if (puntosPlayer2 > puntosPlayer1)
            {
                cartelVictoria.enabled = true;
                cartelVictoria.text = "PLAYER 2 WINS";
                particulasPlayer2.SetActive(true);
            }
            else if (puntosPlayer1 == puntosPlayer2)
            {
                cartelVictoria.enabled = true;
                cartelVictoria.text = "EMPATE :(";
            }

            StartCoroutine(RestartLevel());
        }


        foreach (GameObject gameObject in Jugador1Enemies)
        {
            EnemyLogic enemy = gameObject.GetComponent<EnemyLogic>();
            if (enemy.fueGolpeado)
            {
                enemy.fueGolpeado = false;

                puntosPlayer1 += 1;
                marcadorPlayerA.text = puntosPlayer1.ToString();
            }
            else if (cuentaAtrasParaFin <= 60 && cuentaAtrasParaFin >= 50)
            {
                enemy.showDuration = 3f;
                enemy.duration = 3f;
            }
            else if (cuentaAtrasParaFin <= 50 && cuentaAtrasParaFin >= 40)
            {
                enemy.showDuration = 3f;
                enemy.duration = 2f;
            }
            else if (cuentaAtrasParaFin <= 40 && cuentaAtrasParaFin >= 30)
            {
                enemy.showDuration = 2f;
                enemy.duration = 1f;
            }
            else if (cuentaAtrasParaFin <= 30 && cuentaAtrasParaFin >= 20)
            {
                enemy.showDuration = 2f;
                enemy.duration = 0.5f;
            }
            else if (cuentaAtrasParaFin <= 20 && cuentaAtrasParaFin >= 10)
            {
                enemy.showDuration = 1f;
                enemy.duration = 0.25f;
            }
            else if (cuentaAtrasParaFin <= 10 && cuentaAtrasParaFin >= 0)
            {
                enemy.showDuration = 0.5f;
                enemy.duration = 0.15f;
            }
        }

        foreach (GameObject gameObject in Jugador2Enemies)
        {
            EnemyLogic enemy = gameObject.GetComponent<EnemyLogic>();
            if (enemy.fueGolpeado)
            {
                enemy.fueGolpeado = false;

                puntosPlayer2 += 1;
                marcadorPlayerB.text = puntosPlayer2.ToString();
            }
            else if (cuentaAtrasParaFin <= 60 && cuentaAtrasParaFin >= 50)
            {
                enemy.showDuration = 3f;
                enemy.duration = 3f;
            }
            else if (cuentaAtrasParaFin <= 50 && cuentaAtrasParaFin >= 40)
            {
                enemy.showDuration = 3f;
                enemy.duration = 2f;
            }
            else if (cuentaAtrasParaFin <= 40 && cuentaAtrasParaFin >= 30)
            {
                enemy.showDuration = 2f;
                enemy.duration = 1f;
            }
            else if (cuentaAtrasParaFin <= 30 && cuentaAtrasParaFin >= 20)
            {
                enemy.showDuration = 2f;
                enemy.duration = 0.5f;
            }
            else if (cuentaAtrasParaFin <= 20 && cuentaAtrasParaFin >= 10)
            {
                enemy.showDuration = 1f;
                enemy.duration = 0.25f;
            }
            else if (cuentaAtrasParaFin <= 10 && cuentaAtrasParaFin >= 0)
            {
                enemy.showDuration = 0.5f;
                enemy.duration = 0.15f;
            }
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MoleScene");
    }

    private IEnumerator SpawnEnemiesPlayer1()
    {
        while (cuentaAtrasParaFin > 0)
        {
            bool enemyFound = false;
            EnemyLogic enemyScript = null;

            while (!enemyFound)
            {
                int randomMoleIndex = Random.Range(0, Jugador1Enemies.Length);
                GameObject EnemisInPlayer1side = Jugador1Enemies[randomMoleIndex];

                enemyScript = EnemisInPlayer1side.GetComponent<EnemyLogic>();

                if (!enemyScript.isActive)
                {
                    enemyFound = true;
                }
            }

            StartCoroutine(enemyScript.ShowHide());
            yield return new WaitForSeconds(enemyScript.duration);
        }
    }
    private IEnumerator SpawnEnemiesPlayer2()
    {
        while (cuentaAtrasParaFin > 0)
        {
            bool enemyFound = false;
            EnemyLogic enemyScript = null;

            while (!enemyFound)
            {
                int randomMoleIndex = Random.Range(0, Jugador1Enemies.Length);
                GameObject EnemisInPlayer2side = Jugador2Enemies[randomMoleIndex];

                enemyScript = EnemisInPlayer2side.GetComponent<EnemyLogic>();

                if (!enemyScript.isActive)
                {
                    enemyFound = true;
                }
            }

            StartCoroutine(enemyScript.ShowHide());
            yield return new WaitForSeconds(enemyScript.duration);

        }
    }
}
