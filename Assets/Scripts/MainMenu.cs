using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider volSlider;
    [SerializeField] private Button firstBtnSel;

    public void OptionClick()
    {
        volSlider.Select();
    }

    public void ReturnClick()
    {
        firstBtnSel.Select();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


   
}
