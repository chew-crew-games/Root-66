using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void LoadVehiclesScene()
    {
        SceneManager.LoadScene("Vehicles");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
