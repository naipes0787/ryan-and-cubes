using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void loadLevel(string level){
		SceneManager.LoadScene(level);
	}

	public void quitGame(){
		Application.Quit();
	}

}
