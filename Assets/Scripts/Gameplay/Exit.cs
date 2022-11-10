using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
	public GameObject reiniciar;
	private void OnTriggerExit()
	{
		reiniciar.SetActive(false);
	}

}