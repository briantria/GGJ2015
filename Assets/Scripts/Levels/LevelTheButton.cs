using UnityEngine;
using System.Collections;

public class LevelTheButton : MonoBehaviour 
{
	public void OnClick ()
	{
		LevelMngr.Instance.LoadNextLevel (Constants.LVL_CURSORTIMEOUT);
	}
}
