
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel4 : MonoBehaviour {


	public void OnClick()
	{
		List<QCS.Circuit> circuits = new List<QCS.Circuit>
		{
			new QCS.Circuit(10, 2)
		};

		GameMode.nameGame = "";
		GameMode.circuits = circuits;
		GameMode.gates = new List<QCS.Gate>() { QCS.Gate.NOT, QCS.Gate.CONTROL, QCS.Gate.HADAMARD, QCS.Gate.SWAP, QCS.Gate.CNOT};
		GameMode.customGates = new List<QCS.Gate>();

		SceneManager.LoadScene("Level4", LoadSceneMode.Single);
	}
}
