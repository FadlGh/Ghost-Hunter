using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem _playerDiePs;
    [SerializeField] private Light2D _light;
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
        _player.GetComponent<SpriteRenderer>().enabled = false;
        _player.GetComponent<BoxCollider2D>().enabled = false;
        _player.GetComponent<Rigidbody2D>().isKinematic = true;
        _player.GetComponent<Animator>().enabled = false;
        _light.enabled = false;
        Instantiate(_playerDiePs, _player.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(2f);

        _player.GetComponent<Animator>().enabled = true;
        _player.GetComponent<SpriteRenderer>().enabled = true;
        _player.GetComponent<BoxCollider2D>().enabled = true;
        _player.GetComponent<Rigidbody2D>().isKinematic = false;
        _light.enabled = true;

        Vector3 _checkPoint = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>()._checkPointPos;
        if (_checkPoint != null)
            transform.position = _checkPoint;
    }
}
