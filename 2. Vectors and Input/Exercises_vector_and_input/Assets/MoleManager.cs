using System;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    private GameMaster _gameMaster;
    public float maxHeight = 0.7f;
    public float speed = 0.1f;
    public float showTime = 1f;

    [SerializeField] private bool haveBeenUp = false;

    private void Awake()
    {
        _gameMaster = FindObjectOfType<GameMaster>();
    }

    private void Update()
    {
        if (transform.position.y <= maxHeight && !haveBeenUp)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * speed));
        }
        else
        {
            haveBeenUp = true;
            if (showTime > 0f)
            {
                showTime -= Time.deltaTime;
            }
            else
            {
                transform.Translate(Vector3.down * (Time.deltaTime * speed));
            }
        }

        if (haveBeenUp && transform.position.y <= 0f)
        {
            Destroy(this);
            _gameMaster.missedMoles++;
        }
    }
}
