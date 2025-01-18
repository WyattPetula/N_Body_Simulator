using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage_UI : MonoBehaviour
{
    public CanvasGroup canvas_group;

	void Update() 
	{
		if (Input.GetKeyUp(KeyCode.U)) 
		{
			canvas_group.blocksRaycasts = !canvas_group.blocksRaycasts;
            canvas_group.interactable = !canvas_group.interactable;
            if(canvas_group.alpha == 0)
                canvas_group.alpha = 1;
            else canvas_group.alpha = 0;
		}
	}
}
