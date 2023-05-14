using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private ParticleSystem _keyPs;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("AM").GetComponent<AudioManager>().Play("Key");
            Instantiate(_keyPs, transform.position, Quaternion.identity);
            Destroy(_door);
            Destroy(gameObject);
        }
    }
}
