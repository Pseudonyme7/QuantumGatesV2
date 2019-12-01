
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackMenu : MonoBehaviour {


	public void OnClick()
	{
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}
}
