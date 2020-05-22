using UnityEngine;
using static UnityEngine.Mathf;

public class Health : MonoBehaviour {
	[SerializeField]
	private int health = 100;

	private PlayerPointSystem healthPoints;

	public void TakeDamage(GameObject gameObject) {
		Animator animator = gameObject.GetComponent<Animator>();
		int damage = 10;

		health = Max(health - damage, 0);
		animator.SetInteger("Health", health);
		animator.SetTrigger("TookDamage");

		if (gameObject.tag == "Head") {
			healthPoints = GetComponent<PlayerPointSystem>();
			healthPoints.UpdatePoints(health);
		}
	}
}
