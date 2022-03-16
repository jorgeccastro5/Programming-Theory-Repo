using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
    
    public void GoToRacingSelector()
    {
        SceneManager.LoadScene("Racing_Type_Selection");
    }
    
    public void StartCarRacing()
    {
        SceneManager.LoadScene("Cart_Racing");
    }

    public void StartSpaceshipRacing()
    {
        SceneManager.LoadScene("Spaceship_Racing");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Exit();
#endif
    }
}
