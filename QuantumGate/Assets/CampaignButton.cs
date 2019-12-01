using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CampaignButton : MonoBehaviour {

	public void OnClick()
	{
		SceneManager.LoadScene("SelectLevels", LoadSceneMode.Single);
	}
}
