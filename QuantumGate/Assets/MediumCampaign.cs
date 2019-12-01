using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MediumCampaign : MonoBehaviour {


	public void OnClick()
	{
		List<QCS.Circuit> circuits = new List<QCS.Circuit>
		{
			new QCS.Circuit(5, 2)
		};

		GameMode.nameGame = "";
		GameMode.circuits = circuits;
		GameMode.gates = new List<QCS.Gate>() { QCS.Gate.SWAP, QCS.Gate.CNOT};
		GameMode.customGates = new List<QCS.Gate>();

		SceneManager.LoadScene("SandBox 2", LoadSceneMode.Single);
	}
}
