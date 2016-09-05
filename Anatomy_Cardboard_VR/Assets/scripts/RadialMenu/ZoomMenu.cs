using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ZoomMenu: RadialMenu
{
	public static ZoomMenu instance;
	protected override void Awake ()
	{
		base.Awake ();
		menus.Add ("ZoomMenu", this);
		instance = this;
	}

	public void ZoomIn()
	{
		BrainController.instance.zoomPercentage = 0.999f;
	}

	public void ZoomOut()
	{
		BrainController.instance.zoomPercentage = 1.001f;
	}

	public void ZoomStop()
	{
		BrainController.instance.zoomPercentage = 1f;
	}
}

