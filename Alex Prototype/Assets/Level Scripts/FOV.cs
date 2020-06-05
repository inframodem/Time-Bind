using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
[System.Serializable]
public class FOV : MonoBehaviour
{

	public float viewRadius;
	[Range(0, 360)]
	public float viewAngle;

	public LayerMask enemyMask;
	public LayerMask allyMask;
	public LayerMask obstacleMask;

	public bool drawFOV = false;
	public bool autoUpdate = false;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();
	[HideInInspector]
	public List<Transform> enemyTargets = new List<Transform>();
	[HideInInspector]
	public List<Transform> allyTargets = new List<Transform>();

	Vector3 heightOffset;

	public void Start()
	{
		if (GetComponent<BoxCollider2D>())
			heightOffset = new Vector3(0, transform.GetComponent<BoxCollider2D>().bounds.size.y / 2);
		else
			heightOffset = Vector3.zero;
	}

	public void Update()
	{
		if (autoUpdate) FindVisibleTargets();
		if (drawFOV) DrawViewRadius();
	}

	public void FindVisibleTargets()
	{
		visibleTargets.Clear();
		enemyTargets.Clear();
		allyTargets.Clear();

		Vector3 pos = transform.position + heightOffset;
		Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(pos, viewRadius, enemyMask + allyMask);
		for (int i = 0; i < targetsInViewRadius.Length; i++)
		{
			Transform target = targetsInViewRadius[i].transform;
			Vector3 dirToTarget = (target.position - pos).normalized;
			float angle = Vector3.Angle(transform.forward, dirToTarget);
			if (angle < viewAngle / 2)
			{
				float dstToTarget = Vector3.Distance(pos, target.position);
				if (!Physics2D.Raycast(pos, dirToTarget, dstToTarget, obstacleMask))
				{
					visibleTargets.Add(target);
					//if(target.tag == "Mesh Base")
					if (enemyMask == (enemyMask | (1 << target.gameObject.layer)))
						enemyTargets.Add(target);
					if (allyMask == (allyMask | (1 << target.gameObject.layer)))
						allyTargets.Add(target);
				}
			}
		}

	}


	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
	{
		if (!angleIsGlobal)
		{
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}

	public void DrawViewRadius()
	{
		for (int i = 0; i < viewAngle; i += 3)
		{
			Vector3 pos = transform.position + heightOffset;
			Vector3 end = pos;
			float radian = i * Mathf.Deg2Rad;
			end.x = pos.x + (Mathf.Cos(radian) * viewRadius);
			end.y = pos.y + (Mathf.Sin(radian) * viewRadius);
			//print(i + ", " + end.x + ", " + end.y);
			Debug.DrawLine(pos, end, Color.red);
		}
	}
}