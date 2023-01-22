using UnityEngine;

public class Attack : MonoBehaviour
{
	public int damage;
	public float destroyTime = 0.1f;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.GetComponent<IDamgeable>()?.Damage(damage);
	}

	private void Awake()
	{
		Destroy(gameObject, destroyTime);
	}
}
