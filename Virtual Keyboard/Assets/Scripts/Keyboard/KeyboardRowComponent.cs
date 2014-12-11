using UnityEngine;
using System.Collections.Generic;
using System;

public class KeyboardRowComponent : MonoBehaviour {
	
	private float rowHeight;
	private float rowSpaceHeight;
	
	private float totalRowWidth;
	private IList<String> keys = new List<String>();
	private int keyCount = 0;

	private GameObject go;
	
	public KeyboardRowComponent(){
		this.rowHeight = 10;
		this.rowSpaceHeight = 0;
		this.totalRowWidth = 0;
	}
	
	public KeyboardRowComponent(float rowHeight, float rowSpaceHeight){
		this.rowHeight = rowHeight;
		this.rowSpaceHeight = rowSpaceHeight;
		this.totalRowWidth = 0;
	}
	
	public void setKeys(String[] keySet) {
		keys = keySet;

		int offset = 0;
		foreach (string s in keys){
			// new Key(this.go, s, offset);
			Key newKey = this.go.AddComponent<Key>();
			newKey.initialize(this.go, s, offset);
			offset += 1;
		}
	}

	public void setGameObject(GameObject gameObject){
		this.go = gameObject; 
	}
	
	public IList<String> getKeys() {
		return keys;
	}
	
	//		public void addNewKey(GameObject parent, string id){
	//			keyCount++;
	//			Key newKey = new Key(parent, id, keyCount);
	//			keys.Add (newKey);
	//			totalRowWidth = totalRowWidth + newKey.getKeyWidth() + newKey.getKeySpaceWidth();
	//		}
}

