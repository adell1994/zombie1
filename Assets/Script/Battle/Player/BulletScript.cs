using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	[Tooltip("Furthest distance bullet will look for target")]
	public float maxDistance = 1000000;
	RaycastHit hit;
	[Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]
	public GameObject decalHitWall;
	[Tooltip("Decal will need to be sligtly infront of the wall so it doesnt cause rendeing problems so for best feel put from 0.01-0.1.")]
	public float floatInfrontOfWall;
	[Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]
	public GameObject bloodEffect;
	[Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
	public LayerMask ignoreLayer;
	public int damage;
	public int weakPointDamage;
	AudioSource audioSource;
	private void Start()
    {

	}

    /*
	* Uppon bullet creation with this script attatched,
	* bullet creates a raycast which searches for corresponding tags.
	* If raycast finds somethig it will create a decal of corresponding tag.
	*/
    void Update () {

		if(Physics.Raycast(transform.position, transform.forward,out hit, maxDistance, ~ignoreLayer)){
			//if(decalHitWall){
				if(hit.transform.tag == "LevelPart"){
					Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
				}
				if(hit.transform.tag == "Enemy")
				{
					Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
					ZombieParameter enemy = hit.collider.GetComponent<EnemyPart>().parameter;
					enemy.Damage(damage);
					Destroy(gameObject);
				}
				if (hit.transform.tag == "EnemyWepon")
				{
					Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
					ZombieParameter enemy = hit.collider.GetComponent<EnemyPart>().parameter;
					enemy.Damage(damage);
					Destroy(gameObject);
				}
				if (hit.transform.tag == "EnemyDog")
				{
					Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
				    EnemyDogParametor enemy = hit.collider.GetComponent<EnemyDogPart>().enemyDogParametor;
				    enemy.Damage(damage);
					Destroy(gameObject);
				}
				if (hit.transform.name == "HeadMesh")
				{
					Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
					ZombieParameter enemy = hit.collider.GetComponent<EnemyPart>().parameter;
					enemy.HeadShot();
					Destroy(gameObject);
				}
				if (hit.transform.tag == "BossEnemy")
				{
					Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
					BossParametor enemy = hit.collider.GetComponent<BossEnemyPart>().bossParametor;
					enemy.Damage(damage);
					Destroy(gameObject);
				}
				if (hit.transform.tag == "BossWepon")
				{
					Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
					BossParametor enemy = hit.collider.GetComponent<BossEnemyPart>().bossParametor;
					enemy.Damage(damage);
					Destroy(gameObject);
				}
				if (hit.transform.name == "BossHeadMesh")
				{
					Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
					BossParametor enemy = hit.collider.GetComponent<BossEnemyPart>().bossParametor;
					enemy.WeakPointDamage(weakPointDamage);
					Destroy(gameObject);
				}
			//}		
			Destroy(gameObject);
		}
		Destroy(gameObject, 0.1f);
	}

}
