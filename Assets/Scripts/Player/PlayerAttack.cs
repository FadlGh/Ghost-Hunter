using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _knockback;
    private Rigidbody2D _playerRb;

    private void Start()
    {
        _playerRb = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Die");
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _playerRb.AddForce(Vector2.up * _knockback, ForceMode2D.Impulse);
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
