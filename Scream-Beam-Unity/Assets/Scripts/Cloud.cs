using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public IEnumerator Reset () {
		yield return new WaitForSeconds(1.5f);
		gameObject.SetActive(false);
	}
}
