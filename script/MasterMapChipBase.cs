using UnityEngine;
using System.Collections;

[System.Serializable]
public class MasterMapchipBaseParam : MasterItemParam{
	public MasterMapchipBaseParam(){
	}

	protected int m_width;
	protected int m_height;
	protected int m_capacity;

	public int width { get{ return m_width;} set{m_width = value; } }
	public int height { get{ return m_height;} set{m_height = value; } }
	public int capacity { get{ return m_capacity;} set{m_capacity= value; } }

	new public void SetParam(int _item_id){
		base.SetParam (_item_id);
		width = 1;
		height = 1;
		capacity = 0;

	}
}

public class MasterMapchipBase<T> : CsvData<T> where T : MasterMapchipBaseParam , new(){
	

}



