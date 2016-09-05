using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class RotationMenu: RadialMenu
{
	public static RotationMenu instance;
	protected override void Awake()
	{
		base.Awake ();
		menus.Add ("RotationMenu", this);
		instance = this;
	}

	public void MoveBrainLeft()
	{
		BrainController.instance.addRotation = new Vector3 (0, 1, 0);
	}

	public void MoveBrainRight()
	{
		BrainController.instance.addRotation = new Vector3 (0, -1, 0);
	}

	public void MoveBrainUp()
	{
		BrainController.instance.addRotation = new Vector3 (1, 0, 0);
	}

	public void MoveBrainDown()
	{
		BrainController.instance.addRotation = new Vector3 (-1, 0, 0);
	}

	public void StopMoveBrain()
	{
		BrainController.instance.addRotation = Vector3.zero;
	}
}

