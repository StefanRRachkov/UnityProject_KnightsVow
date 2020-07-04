using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : MenuController
{
    
    
    public void ReturnToMenu()
    {
        LoadGame(-SceneManager.GetActiveScene().buildIndex);
    }
}
