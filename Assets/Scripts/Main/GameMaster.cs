using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public Vector3 _checkPointPos;

    private static GameMaster instance;

    void Awake()
    {
        _checkPointPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
