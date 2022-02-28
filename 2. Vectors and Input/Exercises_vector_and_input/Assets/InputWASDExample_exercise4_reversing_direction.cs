using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputWASDExample_exercise4_reversing_direction : MonoBehaviour
{
    [SerializeField] private bool reverse;

    void Update()
    {
        reverse = Input.GetAxis("Reverse") > 0f;
        Debug.Log(reverse);
        UseIJKL();
        UseWASD();
    }


    private void UseWASD()
    {
        var vAxis = Input.GetAxis("Vertical");
        float vertical = !reverse ? vAxis : -vAxis;
        if (vertical != 0f)
        {
            transform.Translate(Vector3.forward * (vertical * 5f * Time.deltaTime));
        }

        var hAxis = Input.GetAxis("Horizontal");
        float horizontal = !reverse ? hAxis : -hAxis;
        if (horizontal != 0f)
        {
            transform.Rotate(Vector3.up, 50f * Time.deltaTime * horizontal);
        }

        if (Input.GetButtonDown("Jump"))
        {
            // teleport
            transform.Translate(Vector3.forward * 3f);
        }
    }

    private void UseIJKL()
    {
        var vAxis = Input.GetAxis("MyVertical");
        float vertical = !reverse ? vAxis : -vAxis;
        if (vertical != 0f)
        {
            transform.Translate(Vector3.forward * (vertical * 5f * Time.deltaTime));
        }

        var hAxis = Input.GetAxis("MyHorizontal");
        float horizontal = !reverse ? hAxis : -hAxis;
        if (horizontal != 0f)
        {
            transform.Rotate(Vector3.up, 50f * Time.deltaTime * horizontal);
        }

        if (Input.GetButtonDown("Jump"))
        {
            // teleport
            transform.Translate(Vector3.forward * 3f);
        }
    }
}