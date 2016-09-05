using UnityEngine;
using System.Collections;

public class SelectionMenu : RadialMenu {

	protected override void Awake()
	{
		base.Awake ();
		menus.Add("SelectionMenu", this);
	}

	public void AddBrainItemToSelected()
	{
		if(!BrainController.itemsSelected.Contains(BrainController.lastSelection))
			BrainController.itemsSelected.Add (BrainController.lastSelection);
	}

	public void RemoveBrainItemToSelected()
	{
		if(BrainController.itemsSelected.Contains(BrainController.lastSelection))
			BrainController.itemsSelected.Remove (BrainController.lastSelection);
	}
}
