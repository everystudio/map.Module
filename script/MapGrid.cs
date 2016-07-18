using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGrid {
	public int x;
	public int y;

	public MapGrid( int _iX , int _iY ){
		x = _iX;
		y = _iY;
		return;
	}
	public MapGrid(){
		x = 0;
		y = 0;
	}

	static  public bool Equals( MapGrid _a , MapGrid _b ){
		return (_a.x == _b.x && _a.y == _b.y);
	}
	public bool Equals( int _x , int _y ){
		if (x == _x && y == _y) {
			return true;
		} else {
			return false;
		}
	}

	static private void setUsingGrid( ref List<MapGrid> _gridList , int _iX , int _iY , int _iWidth , int _iHeight ){
		for (int x = 0; x < _iWidth; x++) {
			for (int y = 0; y < _iHeight; y++) {
				MapGrid grid = new MapGrid ( _iX + x, _iY + y);
				_gridList.Add (grid);
			}
		}
		return;
	}

	static public void SetUsingGrid<U>( ref List<MapGrid> _gridList , U _param ) where U : DataMapchipBaseParam{
		setUsingGrid (ref _gridList, _param.x, _param.y, _param.width, _param.height);
		return;
	}

	static public void SetUsingGrid<U>( ref List<MapGrid> _gridList , List<U> _paramList , List<int> _ignoreSerialList )where U : DataMapchipBaseParam{
		_gridList.Clear ();
		foreach (U param in _paramList) {
			bool bInsert = true;
			foreach (int iIgnoreSerial in _ignoreSerialList) {
				if (param.mapchip_serial == iIgnoreSerial) {
					bInsert = false;
				}
			}
			if (bInsert) {
				List<MapGrid> grid_list = new List<MapGrid> ();
				SetUsingGrid (ref grid_list, param);
				foreach (MapGrid grid in grid_list) {
					_gridList.Add (grid);
				}
			}
		}
		return;
	}

	static public bool AbleSettingItem<U>( U _param , int _iX , int _iY , int _iMaxX , int _iMaxY, List<MapGrid> _gridList )where U : DataMapchipBaseParam{
		bool bRet = true;

		List<MapGrid> useGrid = new List<MapGrid> ();
		setUsingGrid (ref useGrid, _iX, _iY, _param.width, _param.height);

		foreach (MapGrid check_grid in useGrid) {
			if (check_grid.x < 0) {
				bRet = false;
			} else if (check_grid.y < 0) {
				bRet = false;
			} else if (_iMaxX <= check_grid.x) {
				bRet = false;
			} else if (_iMaxY <= check_grid.y) {
				bRet = false;
			} else {
			}
		}
		foreach (MapGrid check_grid in useGrid) {
			foreach (MapGrid field_grid in _gridList) {

				if (MapGrid.Equals (check_grid, field_grid) == true) {
					//Debug.Log ("you cant setting here!");
					return false;
				}
			}
		}
		//Debug.Log ("able set GOOD POSITION");
		return bRet;
	}


}
