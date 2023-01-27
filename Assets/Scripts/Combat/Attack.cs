using UnityEngine;

public class Attack : MonoBehaviour
{
	public int damage;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.GetComponent<IDamgeable>()?.Damage(damage);
	}
	public void DestroySelf()
	{
		Destroy(gameObject);
	}
}
