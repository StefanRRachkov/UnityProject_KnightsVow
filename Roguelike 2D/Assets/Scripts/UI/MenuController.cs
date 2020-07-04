using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [SerializeField] private GameObject transition;
    [SerializeField] private float transitionTime = 1.0f;

    private Animator anim;

    private void Start()
    {
        if (transition)
        {
            anim = transition.GetComponent<Animator>();
        }
    }

    public void PlayGame()
    {
        LoadGame(1);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void LoadGame(int whichLevel)
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + whichLevel));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
