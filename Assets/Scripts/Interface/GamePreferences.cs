using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePreferences : MonoBehaviour
{
    public static GamePreferences Instance;
    private float Time = 0f;
    private int DummysNumber = 0;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SetTime(float aux)
    {
        Time = aux;
    }

    public float GetTime()
    {
        return Time;
    }

    public void SetDummysNumber(int aux)
    {
        DummysNumber = aux;
    }

    public int GetDummysNumber()
    {
        return DummysNumber;
    }

}
