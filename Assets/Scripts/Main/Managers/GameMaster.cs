using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public Vector3 _checkPointPos;
    private static GameMaster instance;

    void Start()
    {
        _checkPointPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
