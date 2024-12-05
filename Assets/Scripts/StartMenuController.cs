using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour {
	public Button startButton;
    public Button quitButton;

	void Start () {
		Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(StartGame);
            
        Button btn2 = quitButton.GetComponent<Button>();
        btn2.onClick.AddListener(QuitGame);
	}

	void StartGame(){
		SceneManager.LoadScene(1);
    }

    void QuitGame(){
        Application.Quit();
	}
}
