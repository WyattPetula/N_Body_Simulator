using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage_UI : MonoBehaviour
{
    public CanvasGroup canvas_group;
	void Start()
	{
		canvas_group.blocksRaycasts = false;
        canvas_group.interactable = false;
		canvas_group.alpha = 0;
	}

	void Update() 
	{
		// Show / hide config UI.
		if (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.C))  
		{
			canvas_group.blocksRaycasts = !canvas_group.blocksRaycasts;
            canvas_group.interactable = !canvas_group.interactable;
            if(canvas_group.alpha == 0)
                canvas_group.alpha = 1;
            else canvas_group.alpha = 0;
		}
	}
}
