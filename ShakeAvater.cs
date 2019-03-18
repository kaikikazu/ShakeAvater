using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShakeAvater{
	public enum ShakeMode
	{
		Y,
		X
	}

	public class ShakeAvater : MonoBehaviour {
		
		public Transform Target;
		public ShakeMode shakeMode;
		public float MoveRange = 0.01f;

		public float Speed = 1f;
		private Vector3 startpos;

		void Start(){
			startpos = Target.position;
		}

		void Update () {
			var sin = Mathf.Sin(2 * Mathf.PI * Speed * Time.time) * MoveRange;
			if(Input.GetKeyDown(KeyCode.Space)){
				if(shakeMode == ShakeMode.Y){
					Target.position = startpos;
					shakeMode = ShakeMode.X;
				}else{
					Target.position = startpos;
					shakeMode = ShakeMode.Y;
				}
			}
			if(shakeMode == ShakeMode.Y){
				Target.position = new Vector3(startpos.x,startpos.y+sin,startpos.z);
			}else{
				Target.position = new Vector3(startpos.x+sin,startpos.y,startpos.z);
			}
		}

		private void OnValidate(){
			Target.position = startpos;
		}
	}
}