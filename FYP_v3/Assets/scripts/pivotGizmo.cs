using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivotGizmo : MonoBehaviour {

	public  float gizmosSize = 0.75f;
	public Color gizmosColor =Color.yellow;

	void OnDrawGizmos()
	{
		Gizmos.color = gizmosColor;
		Gizmos.DrawWireSphere (transform.position, gizmosSize);
			}
}
