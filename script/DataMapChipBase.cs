using UnityEngine;
using System.Collections;

[System.Serializable]
public class DataMapChipBaseParam : CsvDataParam{
	public DataMapChipBaseParam(){
	}

	public int m_mapchip_serial;
	public int m_item_id;
	public int m_category;
	public int m_x;
	public int m_y;
	public int m_width;
	public int m_height;
	public int m_flip;

	public int mapchip_serial { get{ return m_mapchip_serial;} set{m_mapchip_serial= value; } }
	public int item_id { get{ return m_item_id;} set{m_item_id = value; } }
	public int category { get{ return m_category;} set{m_category = value; } }
	public int x { get{ return m_x;} set{m_x = value; } }
	public int y { get{ return m_y;} set{m_y = value; } }
	public int width { get{ return m_width;} set{m_width = value; } }
	public int height { get{ return m_height;} set{m_height = value; } }
	public int flip { get{ return m_flip;} set{m_flip = value; } }

	public void SetParam(int _item_id, int _x , int _y){
		mapchip_serial = 0;
		item_id = _item_id;
		category = 0;
		x = _x;
		y = _y;
		width = 1;
		height = 1;
		flip = 0;
	}


}


public class DataMapChipBase<T> : CsvData<T> where T : DataMapChipBaseParam , new(){

	public bool GetExist( int _iX , int _iY , out T _param ){
		bool bRet = false;
		_param = new T ();
		foreach (T param in list) {
			if (GridHit (_iX, _iY, param)) {
				_param = param;
				bRet = true;
				break;
			}
		}
		return bRet;
	}



	public bool GridHit( int _iX , int _iY , int _iItemX , int _iItemY , int _iItemWidth , int _iItemHeight , out int _iOffsetX , out int _iOffsetY ){
		_iOffsetX = 0;
		_iOffsetY = 0;
		//Debug.Log ("x:" + _dataItem.x.ToString () + " y:" + _dataItem.y.ToString () + " w:" + _dataItem.width.ToString () + " h:" + _dataItem.height.ToString ());

		bool bHit = false;
		for (int x = _iItemX; x < _iItemX + _iItemWidth; x++) {
			for (int y = _iItemY; y < _iItemY + _iItemHeight; y++) {
				if (_iX == x && _iY == y) {

					_iOffsetX = x - _iItemX;
					_iOffsetY = y - _iItemY;
					bHit = true;
					break;
				}
			}
		}
		return bHit;
	}

	public bool GridHit( int _iX , int _iY , T _param , out int _iOffsetX , out int _iOffsetY ){
		return GridHit (_iX, _iY, _param.x, _param.y, _param.width, _param.height, out _iOffsetX, out _iOffsetY);
	}

	public bool GridHit( int _iX , int _iY , T _param ){
		int iOffsetX = 0;
		int iOffsetY = 0;

		return GridHit (_iX, _iY, _param, out iOffsetX, out iOffsetY);
	}


}



