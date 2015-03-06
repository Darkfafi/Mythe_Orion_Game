using UnityEngine;
using System.Collections;

//Gemaakt Door Ramses

public class Projectile : MonoBehaviour {

	private int _damage;
	private float _speed;

	void Start(){
		Destroy (gameObject, 5f);
	}

	void OnCollisionEnter(Collision other){
		//een handle ofzo checkt zelf dat een arrow hem raakt en het efect. Dat doet de arrow niet
		if (other.gameObject.GetComponent<Creature>() != null && other.gameObject.tag != "Player"){
			other.gameObject.GetComponent<Creature>().GetDamage(_damage);
			Destroy(this.gameObject);
		}
	}
	public void SetStats(int damage,float speed){
		_damage = damage;
		_speed = speed;
	}

	void Update(){
		transform.Translate (Vector3.forward * _speed * Time.deltaTime);
	}
}