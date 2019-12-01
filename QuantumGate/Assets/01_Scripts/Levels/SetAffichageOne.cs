using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class SetAffichageOne : MonoBehaviour {

	public GameObject bon;
	public GameObject mauvais;
	public GameObject resultPanel;
	public GameObject result;
	public GameObject levelSuiv;

	void Update () {

		if (resultPanel.activeSelf) {
			
			if (result.GetComponent<TextMeshProUGUI>().text.Equals("1,00.|<sprite=0>>  ")) {
				bon.SetActive (true);
				mauvais.SetActive (false);
				levelSuiv.SetActive (true);

			} else {
				bon.SetActive (false);
				mauvais.SetActive(true);

			}

		} else {
			
			bon.SetActive (false);
			mauvais.SetActive (false);
			levelSuiv.SetActive(false);
		}
	}
}
