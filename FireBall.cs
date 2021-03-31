using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{ 
    [SerializeField]
    float force;

    [SerializeField]
    ParticleSystem boom;

    [SerializeField]
    manager man;

    Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

   

    public void fire_now()
    {
        if (rig == null) rig = GetComponent<Rigidbody2D>();
        rig.AddForce(transform.right * force , ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "bouncer")
        {
            boom.GetComponent<AudioSource>().Play();
            boom.gameObject.transform.position = transform.position;
            boom.Play();
            if (collision.gameObject.tag != "finish") man.failed();
            gameObject.SetActive(false);
        }
    }
}
