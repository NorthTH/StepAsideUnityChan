using UnityEngine;
using System.Collections;

//不要になったアイテムを順次破棄課題
public class DestroyItself : MonoBehaviour {

	//Unityちゃんのオブジェクト
	private GameObject unitychan;

	//不要になったアイテムを破棄する距離
	private int DelDistance = -15;

	// Use this for initialization
	void Start () {
		//Unityちゃんのオブジェクトを取得
		this.unitychan = GameObject.Find ("unitychan");
	}
	
	// Update is called once per frame
	void Update () {
		
		//アイテムの位置はUnityちゃんよりDelDistance低ければ、アイテムを破棄する
		if ((this.transform.position.z - unitychan.transform.position.z) < DelDistance) {
			Destroy (this.gameObject);
		}
	}
}
