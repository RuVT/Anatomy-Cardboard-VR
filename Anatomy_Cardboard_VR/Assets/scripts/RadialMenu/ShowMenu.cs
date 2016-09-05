using UnityEngine;
using System.Collections;

public enum ShowStatus {SHOW_ALL, SHOW_SELECTED, HIDE_ALL, HIDE_SELECTED};

public class ShowMenu : RadialMenu {
	public static ShowStatus showStatus;
	protected override void Awake()
	{
		base.Awake ();
		menus.Add("ShowMenu", this);
		showStatus = ShowStatus.SHOW_ALL;
	}

	public void ShowSelected()
	{
		foreach (Transform item in BrainController.instance.transform) {
			bool selected = BrainController.itemsSelected.Contains (item.gameObject);
			item.gameObject.SetActive (selected);
		}
		showStatus = ShowStatus.SHOW_SELECTED;
	}

	public void HideSelected()
	{
		foreach (Transform item in BrainController.instance.transform) {
			bool selected = BrainController.itemsSelected.Contains (item.gameObject);
			item.gameObject.SetActive (!selected);
		}
		showStatus = ShowStatus.HIDE_SELECTED;
	}

	public void ShowAll()
	{
		foreach (Transform item in BrainController.instance.transform) {
			item.gameObject.SetActive (true);
		}
		showStatus = ShowStatus.SHOW_ALL;
	}

	public void HideAll()
	{
		foreach (Transform item in BrainController.instance.transform) {
			item.gameObject.SetActive (false);
		}
		showStatus = ShowStatus.HIDE_ALL;
	}
}
