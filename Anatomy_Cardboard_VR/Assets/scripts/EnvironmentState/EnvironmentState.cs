using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class EnvironmentState {
	public List<GameObject> visibleObjects;
	public List<GameObject> invisibleObjects;
	public Vector3 cameraPos;
}
