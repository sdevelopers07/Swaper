using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	public static int xSize = 10, ySize = 14;

	public static int[] blocksPos = new int[ySize]; 	

	int fl = 0;

	void Start() {
		for(int i = 0; i < xSize; i++){
			for(int j = 0; j < ySize; j++){
				GameObject obj = new GameObject();
				obj.name = i + "-" + j;
				//obj.tag = i + "-" + j;
				obj.transform.position = new Vector2 (10 + 30 * i, 10 + 30 * j);
				if(fl < 10){
					blocksPos[fl] = 10 + 30 * i;
					fl++;
				}
				obj.AddComponent<Block>();
				obj.AddComponent<Rigidbody2D>();
				obj.AddComponent<BoxCollider2D>();

				BoxCollider2D coll = obj.GetComponent<BoxCollider2D>();
				coll.offset = new Vector2(15f, 15f);
				coll.size = new Vector2(30f, 30f);
				coll.sharedMaterial = Resources.Load<PhysicsMaterial2D>("Block");

				Rigidbody2D gravity = obj.GetComponent<Rigidbody2D>();
				gravity.gravityScale = 5;
				gravity.mass = 10;
				gravity.angularDrag = 0;
				//gravity.isKinematic = true;
				gravity.collisionDetectionMode = CollisionDetectionMode2D.None;
				gravity.interpolation = RigidbodyInterpolation2D.Interpolate;
				gravity.sleepMode = RigidbodySleepMode2D.StartAsleep;
				gravity.freezeRotation = true;
				gravity.constraints = RigidbodyConstraints2D.FreezeRotation;

				Block block = obj.GetComponent<Block>();
				block.currentPos = obj.transform.position;
				block.color = Random.Range(1,6);
				block.x = i;
				block.y = j;
				obj.AddComponent<SpriteRenderer>();
				obj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/" + obj.GetComponent<Block>().color);
				//Instantiate(obj);
			}
		}
	}
}
