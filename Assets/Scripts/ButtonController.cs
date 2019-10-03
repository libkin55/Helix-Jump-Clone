using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Button btnRestart;
    private void Start()
    {
        btnRestart.gameObject.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void Restart(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void UIShow()
    {
        btnRestart.gameObject.SetActive(true);
        //other ui
    }
}
