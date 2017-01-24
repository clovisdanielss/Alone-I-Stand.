using System;
using UnityEngine;
namespace AssemblyCSharp
{
	public class BatAnimation:MonoBehaviour
	{
		private GameObject target;
		void Update(){
			if (GetComponent<FliperEnemyController> ().target != null) {
				target = GetComponent<FliperEnemyController> ().target;
			}
			if (target != null) {
				float dist = Vector3.Distance (target.transform.position, transform.position);
				if (dist < 3) {
					GetComponent<Animator> ().SetTrigger ("Attack");

				}
			}

		}
	}
}

