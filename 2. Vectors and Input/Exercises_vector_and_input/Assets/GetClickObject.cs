using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClickObject : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask moleLayer;
    private GameMaster _gameMaster;
    private void Awake()
    {
        _gameMaster = FindObjectOfType<GameMaster>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, float.MaxValue, moleLayer, QueryTriggerInteraction.Collide))
            {
                var moleGameObject = hit.transform.gameObject;
                Destroy(moleGameObject);
                _gameMaster.Score++;
                _gameMaster.DecrementTimer();
            }
        }
    }
}
