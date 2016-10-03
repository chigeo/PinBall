using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	private GameObject ScoreText;
	private int score = 0;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find ("GameOverText");

		this.ScoreText = GameObject.Find ("ScoreText");
	}

	// Update is called once per frame
	void Update() {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}
	}

	void OnCollisionEnter(Collision other){
		// タグによって得点を変える
		if (other.transform.tag == "SmallStarTag") {
			this.score += 5;
			this.ScoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";
		} else if (other.transform.tag == "LargeStarTag") {
			this.score += 10;
			this.ScoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";
		} else if (other.transform.tag == "SmallCloudTag") {
			this.score += 20;
			this.ScoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";
		} else if (other.transform.tag == "LargeCloudTag") {
			this.score += 30;
			this.ScoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";
		}
	}
}