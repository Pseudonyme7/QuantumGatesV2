using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HardCampaign : MonoBehaviour {



	public void OnClick()
	{
		SceneManager.LoadScene("Settings", LoadSceneMode.Single);
	}
}
