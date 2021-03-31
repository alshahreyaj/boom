using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    [SerializeField]
    GameObject fire_ball, pos;

    Animation anim;

    AudioSource audio;

    bool done;

    // Start is called before the first frame update
    void Start()
    {
        done = false;
        fire_ball.SetActive(false);
        anim = GetComponent<Animation>();
        audio = GetComponent<AudioSource>();
    }


    public void fire()
    {
        if (done) return;
        done = true;
        audio.Play();
        anim.Play("fire");
        fire_ball.transform.position = pos.transform.position;
        fire_ball.SetActive(true);
        fire_ball.transform.rotation = transform.rotation;
        fire_ball.GetComponent<FireBall>().fire_now();
    }
}
