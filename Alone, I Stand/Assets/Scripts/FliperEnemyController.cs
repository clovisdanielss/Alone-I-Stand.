using System;
using UnityEngine;
namespace AssemblyCSharp
{
	public class FliperEnemyController:EnemyController
	{
		private bool right = false;
		public FliperEnemyController ()
		{
			
		}

		void Update () {
			if (target != null) {
				Vector3 direction = transform.position - new Vector3 (target.transform.position.x,
					target.transform.position.y, -10);
				Flip (direction.normalized);
				GetComponent<Rigidbody2D> ().angularVelocity = 0;
				GetComponent<Rigidbody2D> ().AddForce (-direction.normalized * speed * force);
			}

		}

		public void Flip(Vector3 d){
			if (d.x < 0 && !right) {
				transform.Rotate (new Vector3 (0, 180, 0));
				right = true;
			}
			if (d.x > 0 && right) {
				transform.Rotate (new Vector3 (0, 180, 0));
				right = false;
			}
		}

	}
}

