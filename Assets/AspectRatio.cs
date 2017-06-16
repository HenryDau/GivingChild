using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatio : MonoBehaviour {

	public float orthoSize = 5;
	public float aspect = 1.33333f;

	void Start () {
		Camera.main.projectionMatrix = Matrix4x4.Ortho (
			-orthoSize * aspect, orthoSize * aspect,
			-orthoSize, orthoSize,
			Camera.main.nearClipPlane, Camera.main.farClipPlane);
	}
	
	
}
