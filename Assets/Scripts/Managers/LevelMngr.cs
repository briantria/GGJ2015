using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelMngr : MonoBehaviour 
{
	private static LevelMngr m_instance;
	public static LevelMngr Instance {get { return m_instance; }}
	
	private LevelInProgress m_lvlInProgress;
	public LevelInProgress LvlInProgress { get; set; }
	
	private List<string> m_listQoutes = new List<string>();
	private int m_currQouteIdx;
	
	private Transform  m_transform;
	private GameObject m_gameObject;
	private GameObject m_currLevel;

	#region MONO FUNCTIONS
	private void Awake ()
	{
		m_instance = this;
		m_gameObject = this.gameObject;
		m_transform = this.transform;
		m_currLevel = null;
		m_currQouteIdx = 0;
		QouteSetup ();
	}

	private void Start () 
	{
		LoadNextLevel (Constants.LVL_THEBUTTON);
	}
	#endregion

	private void QouteSetup ()
	{
		// [0]
		m_listQoutes.Add("This is not the end.\nFear not the UNKNOWN.");
		
		// [1]
		m_listQoutes.Add("Mistakes are inevitable..\nbut learn to LISTEN...");
	}
	
	public void UpdateQoute (int p_idx = -1)
	{
		m_currQouteIdx = p_idx;
		
		if(m_currQouteIdx < 0)
		{
			m_currQouteIdx = 0;
		}
		
		if(m_currQouteIdx >= m_listQoutes.Count)
		{
			m_currQouteIdx = m_listQoutes.Count-1;
		}
	}
	
	public string FetchCurrQoute ()
	{
		return m_listQoutes[m_currQouteIdx];
	}

	public void LoadNextLevel (string p_lvlName)
	{
		// TODO: consider object pooling...
		// TODO: group levels and singit force garbage collection. (see Bibby's architecture)

		if (m_currLevel != null) 
		{
			Destroy (m_currLevel);
		}

		m_currLevel = GameObject.Instantiate(Resources.Load ("Prefabs/Levels/" + p_lvlName)) as GameObject;
		m_currLevel.name = p_lvlName;
		m_currLevel.transform.SetParent (m_transform);
	}
}
