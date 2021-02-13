using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClickGO : MonoBehaviour {

	public void LoadScene(int level){
		SceneManager.LoadScene (level);
	}
}
