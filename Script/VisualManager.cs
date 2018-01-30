using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualManager : MonoBehaviour {

	LineRenderer magneticRenderer;

	// Use this for initialization
	void Start () {
		magneticRenderer = gameObject.AddComponent<LineRenderer>();
		magneticRenderer.widthCurve = new AnimationCurve(
			new Keyframe(0, 0.1f),
			new Keyframe(0.9f, 0.1f),
			new Keyframe(0.9001f, 0.5f),
			new Keyframe(1f, 0f)
		);
		magneticRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
		magneticRenderer.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		magneticRenderer.numPositions = 4;
		magneticRenderer.SetPosition(0, transform.position);
		magneticRenderer.SetPosition(1, transform.position + 0.9f * MagneticFieldManager.GetField());
		magneticRenderer.SetPosition(2, transform.position + 0.9001f * MagneticFieldManager.GetField());
		magneticRenderer.SetPosition(3, transform.position + MagneticFieldManager.GetField());
	}
}
