using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TwoNextLevelto : MonoBehaviour {

	public void OnClick()
	{
		SceneManager.LoadScene("Level2", LoadSceneMode.Single);
	}
}
