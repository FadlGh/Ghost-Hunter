using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint;
    private GameObject _player;
    private static GameMaster instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Respawn()
    {
        _player.transform.position = _checkPoint.position;
    }
}
