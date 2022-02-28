using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireworksManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _rocketPrefab;

    [SerializeField] private bool _fireworksEnabled;
    [SerializeField] private bool canFireRocket = true;
    [Range(1, 100)] [SerializeField] private int _rocketsPerBurst = 10;
    [SerializeField] private int waitSecondsBeforeEachBurst = 3;

    private void Update()
    {
        if (_fireworksEnabled)
        {
            if (canFireRocket)
            {

                if (Input.GetButton("Fire1"))
                {
                    StartCoroutine(FireRocket());
                }
                // StartCoroutine(FireRockets());
            }
        }
        else
        {
            
        }
    }

    private IEnumerator FireRocket()
    {
        canFireRocket = false;
        Instantiate(_rocketPrefab);
        yield return new WaitForSeconds(0.01f);
        canFireRocket = true;
    }

    private IEnumerator FireRockets()
    {
        canFireRocket = false;
        
        for (int i = 0; i < _rocketsPerBurst; i++)
        {
            Instantiate(_rocketPrefab);
            yield return new WaitForSeconds(Random.Range(0.01f, 0.5f));
        }

        yield return new WaitForSeconds(waitSecondsBeforeEachBurst);
        canFireRocket = true;
    }
}
