using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour {
	
	public float hdg = 0;
	public float pitch = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(pitch, hdg, 0);
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			hdg += Time.deltaTime * 30;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			hdg -= Time.deltaTime * 30;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			pitch += Time.deltaTime * 30;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			pitch -= Time.deltaTime * 30;
		}
	}
}
