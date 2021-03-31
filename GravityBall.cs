using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBall : MonoBehaviour
{
    [SerializeField]
    GameObject fireball;

    [SerializeField]
    float attack_force;

    bool attract;
    // Start is called before the first frame update
    void Start()
    {
        attract = false;
    }

    private void FixedUpdate()
    {
        if(attract)
        {
            Attract();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            attract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            attract = false;
        }
    }

    void Attract()
    {
        Vector3 dir = transform.position - fireball.transform.position;
        float dis = dir.magnitude;
        float forcemag = 1f / dis * dis;
        Vector3 force = dir.normalized * forcemag * attack_force;
        fireball.GetComponent<Rigidbody2D>().AddForce(force);
    }
}
