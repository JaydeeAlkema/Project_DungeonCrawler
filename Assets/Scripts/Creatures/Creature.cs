using NaughtyAttributes;
using UnityEngine;

public class Creature : MonoBehaviour
{
	[BoxGroup("Creature Stats")] public int health;
	[BoxGroup("Creature Stats")] public int damage;
	[BoxGroup("Creature Stats")] public int moveSpeed;
	[Space()]
	[BoxGroup("Creature Components")] public Rigidbody2D rb2d;
}
