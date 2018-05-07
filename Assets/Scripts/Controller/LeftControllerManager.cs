using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftControllerManager : MonoBehaviour {

	void Update () {

		//左コントローラーメニューボタンでMenuシーンへ
		if (OVRInput.GetDown(OVRInput.RawButton.Start)) {
			SceneManager.LoadScene("Menu");
		}
	}
}
