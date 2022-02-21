using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class UpwardsMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionPrefab;

    private float speed = 70f; // 70
    [SerializeField] private float countdownExplosion = 2f;

    private Vector2 direction;

    private void Start()
    {
        // create random tilt of the rocket.
        Vector3 angle = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20));
        transform.eulerAngles = angle;
    }

    private void Update()
    {
        if (countdownExplosion > 0)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            countdownExplosion -= Time.deltaTime;
        }
        else
        {
            // explode
            Explode();
        }


    }
    
    
    
    private void Explode()
    {
        var obj = Instantiate(_explosionPrefab, transform.GetChild(0).transform);
        var exp = obj.GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.main.duration);
    }
}
