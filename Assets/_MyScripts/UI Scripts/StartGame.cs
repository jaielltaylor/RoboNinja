using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        this.GetComponent<Button>().onClick.AddListener(enableScene);
    }
    void enableScene()
    {
        SceneManager.LoadScene(1);
    }
}
