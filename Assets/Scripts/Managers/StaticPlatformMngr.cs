using UnityEngine;
using System.Collections.Generic;

public class StaticPlatformMngr : MonoBehaviour 
{
	private static StaticPlatformMngr m_instance;
	public static StaticPlatformMngr Instance {get{return m_instance;}}
	
	private Transform m_transform;
	private int m_childCount;
	
	private List<GameObject> m_listPlatforms = new List<GameObject>();

	private void Awake ()
	{
		m_instance = this;
		m_transform = this.transform;
		
		m_childCount = m_transform.childCount;
		for(int idx = 0; idx < m_childCount; ++idx)
		{
			GameObject go = m_transform.GetChild(idx).gameObject;
			m_listPlatforms.Add(go);
			go.SetActive(false);
		}
	}
	
	public List<GameObject> GetChildrenList ()
	{
		return m_listPlatforms;
	}
	
	public void EnableAllChildren ()
	{
		for(int idx = 0; idx < m_childCount; ++idx)
		{
			m_listPlatforms[idx].SetActive(true);
		}
	}
}
