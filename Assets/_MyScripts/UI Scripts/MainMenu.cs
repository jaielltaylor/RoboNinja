using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        this.GetComponent<Button>().onClick.AddListener(enableScene);
    }
    void enableScene()
    {
        SceneManager.LoadScene(0);
        GameControl.control.missionComplete = false;
        GameControl.control.score = 0;
        GameControl.control.patrollersDestroyed = 0;
    }
}
