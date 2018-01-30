using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticFieldManager : MonoBehaviour {


	public static MagneticFieldManager instance;

	[SerializeField]
	private Vector3 field;

	public Vector3 Field {
		get {
			return field;
		}
	}

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static Vector3 GetField()
	{
		return instance == null ? Vector3.zero : instance.field;
	}
}
