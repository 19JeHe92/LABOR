﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneratoPuzzleLoader : MonoBehaviour {

    public GameObject completeGlas;
    private bool isComplete = false;

	void Update () {
		if( !isComplete && completeGlas == null)
        {
            isComplete = true;
            StartCoroutine(WaitAndLoadScene());
        }
	}

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ChP9-RobotRoom-Control");
    }
}
