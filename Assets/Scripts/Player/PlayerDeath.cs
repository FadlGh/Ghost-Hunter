using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem _playerDiePs;
    private GameObject _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Respawn(Component sender, object data)
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {

        _player.GetComponent<Animator>().SetBool("isDead", true);
        Instantiate(_playerDiePs, _player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        _player.GetComponent<Animator>().SetBool("isDead", false);
        Vector3 _checkPoint = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>()._checkPointPos;
        if (_checkPoint != null)
            transform.position = _checkPoint;
    }
}
