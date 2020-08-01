using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singletone
    private static GameManager _instance;
    public static GameManager GetInstance()
    {
        if (_instance != null)
        {
            return _instance;
        }
        else
        {
            _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            return;
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    [SerializeField] private GameObject _player;
    public static GameObject Player { get => GetInstance()._player; private set => GetInstance()._player = value; }

    public static void RunCoroutine(IEnumerator enumerator)
    {
        GetInstance().StartCoroutine(enumerator);
    }

    public static void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public static bool CheckEnemy(Collider other, out EnemyStats enemy)
    {
        enemy = other.gameObject.GetComponent<EnemyStats>();
        return other.gameObject.GetComponent<EnemyStats>() != null;
    }
}
