using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public Vector2 newPos;
	public Vector2 currentPos;
	public int color;
	public int angelGravity = 270;
	public bool moveable = true;
	public int x;
	public int y;
	public bool flag = false;

	void Update(){
		//this.gameObject.transform.rotation = new Quaternion ();
		this.gameObject.transform.position = new Vector2 (10 + 30 * x, this.gameObject.transform.position.y);

		/*float fY = Mathf.Round(this.gameObject.transform.position.y);
		if ((fY % 10) == 0) {
			flag = true;
		}*/

		/*for(int i = 0; i < StartGame.blocksPos.Length; i++){
			if(this.gameObject.transform.position.x == StartGame.blocksPos[i]){
				flag = true;
				break;
			}
		}*/

		if(flag){
			Vector2 vec = new Vector2(this.gameObject.transform.position.x + 15, this.gameObject.transform.position.y - 0.1f);
			//Collider2D[] hitColliders = Physics2D.OverlapPointAll(vec, 1);
			Collider2D col = Physics2D.OverlapPoint(vec, 1);
			//if (hitColliders.Length > 0) {
			if (col != null) {
				//this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
				this.gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
				float newY = Mathf.Round(this.gameObject.transform.position.y);
				this.gameObject.transform.position = new Vector2 (this.gameObject.transform.position.x, newY);
			//} else if(hitColliders.Length == 0){
			} else {
				//this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
				this.gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			}
			flag = false;
		}
	}

	void OnMouseDown(){

		ArrayList blocks = getBlocks(this.gameObject);

		if(blocks.Count >= 4){
			for(int i = 0; i < blocks.Count; i++){
				if((GameObject)blocks[i] != null){
					Destroy((GameObject)blocks[i]);
				}
			}
		}
	}

	public ArrayList getBlocks(GameObject block){
		ArrayList objs = new ArrayList();

		Block comp = block.GetComponent<Block>();
		int blockX = comp.x;
		int blockY = comp.y;

		if(blockX == 0){
			for(int i = 0; i < StartGame.xSize; i++){
				GameObject obj = GameObject.Find(i + "-" + blockY);
				if(obj != null){
					if(obj.GetComponent<Block>().color == color){
						objs.Add(obj);
					} else {
						break;
					}
				}
			}
		} else {
			for(int i = blockX; i < StartGame.xSize; i++){
				GameObject obj = GameObject.Find(i + "-" + blockY);
				if(obj != null){
					if(obj.GetComponent<Block>().color == color){
						objs.Add(obj);
					} else {
						break;
					}
				}
			}
			
			for(int i = blockX; i >= 0; i--){
				GameObject obj = GameObject.Find(i + "-" + blockY);
				if(obj != null){
					if(obj.GetComponent<Block>().color == color){
						objs.Add(obj);
					} else {
						break;
					}
				}
			}
		}
		
		if (blockY == 0) {
			for (int i = 0; i < StartGame.ySize; i++) {
				GameObject obj = GameObject.Find (blockX + "-" + i);
				if(obj != null){
					if(obj.GetComponent<Block>().color == color){
						objs.Add(obj);
					} else {
						break;
					}
				}
			}
		} else {
			for(int i = blockY; i < StartGame.ySize; i++){
				GameObject obj = GameObject.Find(blockX + "-" + i);
				if(obj != null){
					if(obj.GetComponent<Block>().color == color){
						objs.Add(obj);
					} else {
						break;
					}
				}
			}
			
			for(int i = blockY; i >= 0; i--){
				GameObject obj = GameObject.Find(blockX + "-" + i);
				if(obj != null){
					if(obj.GetComponent<Block>().color == color){
						objs.Add(obj);
					} else {
						break;
					}
				}
			}
		}

		/*for(int i = 0; i < objs.Count; i++){
			if((GameObject)objs[i] != null){
				ArrayList temp = getBlocks((GameObject)objs[i]);
				for(int j = 0; j < temp.Count; j++){
					objs.Add((GameObject)temp[j]);
				}

			}
		}*/

		return objs;
	}
}
