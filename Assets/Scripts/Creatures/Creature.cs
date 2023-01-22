using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, IDamgeable
{
	[BoxGroup("Creature Stats")] public int health = 100;
	[BoxGroup("Creature Stats")] public int damage = 10;
	[BoxGroup("Creature Stats")] public int moveSpeed = 5;
	[Space()]
	[BoxGroup("Creature Components")] public Rigidbody2D rb2d = null;
	[Space()]
	[BoxGroup("Combat")] public int currentAttackIndex = 0;
	[BoxGroup("Combat")] public List<GameObject> attacks = new List<GameObject>();

	public virtual void Damage(int value)
	{
		health -= value;
	}
}
