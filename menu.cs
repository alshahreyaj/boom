using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField]
    GameObject[] images;

    [SerializeField]
    GameObject pan;

    [SerializeField]
    Text level_text;

    int id, c_id;

    private void Start()
    {
        //PlayerPrefs.SetInt("id", 5);
        StartCoroutine(bot1());
        StartCoroutine(bot2());
        pan.SetActive(false);
        id = PlayerPrefs.GetInt("id");
        c_id = id;
        level_text.text = "Level: " + (c_id + 1).ToString();
    }

    IEnumerator bot1()
    {
        yield return new WaitForSeconds(7f);
        images[0].GetComponent<Animation>().Play();
        StartCoroutine(bot1());
    }

    IEnumerator bot2()
    {
        yield return new WaitForSeconds(10f);
        images[1].GetComponent<Animation>().Play();
        StartCoroutine(bot2());
    }

    public void play()
    {
        pan.SetActive(true);
    }

    public void back()
    {
        pan.SetActive(false);
    }

    public void plus()
    {
        if (c_id < id) c_id++;
        level_text.text = "Level: " + (c_id + 1).ToString();
    }

    public void minus()
    {
        if (c_id > 0) c_id--;
        level_text.text = "Level: " + (c_id + 1).ToString();
    }

    public void quit()
    {
        Application.Quit();
    }

    public void start_now()
    {
        SceneManager.LoadScene(c_id + 1);
    }
}
