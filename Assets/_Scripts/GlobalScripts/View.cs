using UnityEngine;
using System.Collections;

public class View : MonoBehaviour {


	protected float _viewRange = 1;
	protected CapsuleCollider _view;

	void Awake(){
		AddView ();
	}

	void AddView(){
		
		GameObject viewPart = new GameObject ();

		viewPart.AddComponent<ViewCollisionCheck> ();

		viewPart.name = "View";
		
		viewPart.transform.parent = transform;

		viewPart.transform.position = viewPart.transform.parent.position;

		viewPart.layer = 2;
		
		_view = viewPart.AddComponent<CapsuleCollider> ();
		_view.isTrigger = true;
		_view.radius = _viewRange;
	}

	public void ChangeViewRange(float range){
		_viewRange = range;
		_view.radius = _viewRange;
	}
}
