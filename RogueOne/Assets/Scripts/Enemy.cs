﻿using UnityEngine;
using System.Collections;

public class Enemy : MovingObject {
	public int playerDamage;

	private Animator animator;
	private Transform target;
	private bool skipMove;


	// Use this for initialization
	protected override void Start () {
		animator = GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		base.Start ();
	}

	protected override void AttemptMove<T> (int xDir, int yDir)
	{
		if(skipMove) {
			skipMove = false;
			return;
		}

		base.AttemptMove <T> (xDir, yDir);
		skipMove = true;
	}

	public void MoveEnemy() {
		int xDir = 0;
		int yDir = 0;

		// Check if the enemy and the player are on the same row.
		if(Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon) {

			// If they are, then determine if the player is higher or lower.  
			// Move accordingly.
			yDir = target.position.y > transform.position.y ? 1 : -1;
		} else {
			xDir = target.position.x > transform.position.x ? 1 : -1;
		}

		AttemptMove<Player> (xDir, yDir);
	}

	protected override void OnCantMove<T> (T component)
	{
		Player hitPlayer = component as Player;
		hitPlayer.LoseFood (playerDamage);
	}
}
