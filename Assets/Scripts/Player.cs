using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{    
    [SerializeField] private ParticleSystem _particleWalk;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private Wallet _wallet;

    private Rigidbody _rigidbody;
    private AudioSource _source;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet.AddMoney(coin.Value);
            Destroy(coin.gameObject);
        }
    }

    private void Update()
    {
        var direction = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y) * _speed;
        _rigidbody.velocity = direction;

        if (_rigidbody.velocity != Vector3.zero && _source.isPlaying == false)
        {
            _source.Play();
            _particleWalk.Play();
        }
        else if (_source.isPlaying && _rigidbody.velocity == Vector3.zero)
        {
            _source.Stop();
            _particleWalk.Stop();
        }
    }
}
