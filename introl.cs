using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introl : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }
}
