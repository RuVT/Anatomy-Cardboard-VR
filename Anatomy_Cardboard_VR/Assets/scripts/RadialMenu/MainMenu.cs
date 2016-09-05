using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class MainMenu: RadialMenu
{
	protected override void Awake()
	{
		base.Awake ();
		menus.Add("MainMenu", this);
	}

	protected void OpenMenu(string name)
	{
		RadialMenu menu = menus[name];
		SetActive (false);
		menu.MoveToCameraCenter ();
		menu.SetActive (true);
	}

	public void OpenRotationMenu()
	{
		OpenMenu("RotationMenu");
	}

	public void OpenZoomMenu()
	{
		OpenMenu("ZoomMenu");
	}

	public void OpenSelectionMenu()
	{
		OpenMenu("SelectionMenu");
	}

	public void OpenShowMenu()
	{
		OpenMenu("ShowMenu");
	}
}

