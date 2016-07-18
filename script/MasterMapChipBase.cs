using UnityEngine;
using System.Collections;

[System.Serializable]
public class MasterMapChipBaseParam : MasterItemParamBase{
	public MasterMapChipBaseParam(){
	}

	public int m_width;
	public int m_height;
	public int m_capacity;

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

public class MasterMapChipBase<T> : CsvData<T> where T : MasterMapChipBaseParam , new(){
	

}



