using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDeath : MonoBehaviour
{
    [SerializeField] private float _knockback;
    private Rigidbody2D _playerRb;

    private void Start()
    {
        _playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || _playerRb.GetComponent<PlayerController>()._isDashing)
        {
            return;
        }
        transform.parent.GetComponent<Animator>().SetTrigger("Die");
        _playerRb.AddForce(Vector2.up * _knockback, ForceMode2D.Impulse);
        Destroy(transform.parent.gameObject, 0.6f);
    }
}
