using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieManager : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Respawn()
    {
        print("ss");
        _player.transform.position = _checkPoint.position;
    }
}
