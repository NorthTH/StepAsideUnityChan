using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour {

	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	public GameObject conePrefab;
	//スタート地点
	private int startPos = -160;
	//ゴール地点
	private int goalPos = 120;
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;

	//Unityちゃんのオブジェクト
	private GameObject unitychan;
	////アイテムを生成する位置取得する
	private int pos;
	//Unityちゃんの前アイテム生先する必要な距離
	private int CreDistance = 45;

	// Use this for initialization
	void Start () {

		//Unityちゃんのオブジェクトを取得
		this.unitychan = GameObject.Find ("unitychan");

		//アイテムを生成する位置を初期化
		pos = startPos;

		/*ユニティちゃんの位置に応じてアイテムを動的に生成の不要な部分
		//一定の距離ごとにアイテムを生成
		for (int i = startPos; i < goalPos; i+=15) {
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range (0, 10);
			if (num <= 1) {
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
					GameObject cone = Instantiate (conePrefab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
				}
			} else {

				//レーンごとにアイテムを生成
				for (int j = -1; j < 2; j++) {
					//アイテムの種類を決める
					int item = Random.Range (1, 11);
					//アイテムを置くZ座標のオフセットをランダムに設定
					int offsetZ = Random.Range(-5, 6);
					//50%コイン配置:30%車配置:10%何もなし
					if (1 <= item && item <= 6) {
						//コインを生成
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
					} else if (7 <= item && item <= 9) {
						//車を生成
						GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
					}
				}
			}
		}*/
	}

	// Update is called once per frame
	void Update () {
		
		//startPosとgoalPosの間にアイテムを生成する
		if (unitychan.transform.position.z + CreDistance >= pos && pos < goalPos) {
			itemGen (pos);
			pos += 15;
		}
	}

	//ユニティちゃんの位置に応じてアイテムを動的に生成課題
	//pos位置(z)にアイテムを生成する
	void itemGen(int pos){
		//どのアイテムを出すのかをランダムに設定
		int num = Random.Range (0, 10);
		if (num <= 1) {
			//コーンをx軸方向に一直線に生成
			for (float j = -1; j <= 1; j += 0.4f) {
				GameObject cone = Instantiate (conePrefab) as GameObject;
				cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, pos);
			}
		} else {

			//レーンごとにアイテムを生成
			for (int j = -1; j < 2; j++) {
				//アイテムの種類を決める
				int item = Random.Range (1, 11);
				//アイテムを置くZ座標のオフセットをランダムに設定
				int offsetZ = Random.Range(-5, 6);
				//50%コイン配置:30%車配置:10%何もなし
				if (1 <= item && item <= 6) {
					//コインを生成
					GameObject coin = Instantiate (coinPrefab) as GameObject;
					coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, pos + offsetZ);
				} else if (7 <= item && item <= 9) {
					//車を生成
					GameObject car = Instantiate (carPrefab) as GameObject;
					car.transform.position = new Vector3 (posRange * j, car.transform.position.y, pos + offsetZ);
				}
			}
		}
	}
}
