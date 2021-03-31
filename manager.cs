using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    [SerializeField]
    GameObject failed_menu, success_menu;

   // [SerializeField]
   // AudioClip fa, sa;

   // AudioSource audio;

    int c_id;
    private void Start()
    {
        failed_menu.SetActive(false);
        success_menu.SetActive(false);
        c_id = SceneManager.GetActiveScene().buildIndex - 1;
        //audio = GetComponent<AudioSource>();
    }
    public void success()
    {
        //audio.PlayOneShot(sa);
         
        
        StartCoroutine(s_now());
        //Debug.Log(c_id);
    }

    IEnumerator s_now()
    {
        yield return new WaitForSeconds(1f);
        success_menu.SetActive(true);
    }

    IEnumerator f_now()
    {
        yield return new WaitForSeconds(1f);
        failed_menu.SetActive(true);
    }

    public void failed()
    {
        StartCoroutine(f_now());
        //audio.PlayOneShot(fa);
        
    }

    public void restart()
    {
        SceneManager.LoadScene(c_id + 1);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void next_level()
    {
        int id = PlayerPrefs.GetInt("id");
        if (c_id + 1 > id) id = c_id + 1;
        PlayerPrefs.SetInt("id", id);
        SceneManager.LoadScene(c_id + 2);
    }
}
