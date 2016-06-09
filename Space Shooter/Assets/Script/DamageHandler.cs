using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public int vida = 1;
    public GameObject explosion;
    public GameObject playerExplosion;

	public float periodoInvulnerabilidad = 0;
	float relojInvulnerabilidad = 0;
	int LayerCorrecto;

	SpriteRenderer spriteRenderer;

	void Start() {
        LayerCorrecto = gameObject.layer;

		spriteRenderer = GetComponent<SpriteRenderer>();

		if(spriteRenderer == null) {
            spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();

			
		}
	}

	void OnTriggerEnter2D() {
		vida--;
        //BarraVida.Damage(health);

		if(periodoInvulnerabilidad > 0) {
            relojInvulnerabilidad = periodoInvulnerabilidad;
			gameObject.layer = 10;
		}
	}

	void Update() {

		if(relojInvulnerabilidad > 0) {
            relojInvulnerabilidad -= Time.deltaTime;

			if(relojInvulnerabilidad <= 0) {
				gameObject.layer = LayerCorrecto;
				if(spriteRenderer != null) {
                    spriteRenderer.enabled = true;
				}
			}
			else {
				if(spriteRenderer != null) {
                    spriteRenderer.enabled = !spriteRenderer.enabled;
				}
			}
		}

		if(vida <= 0) {
			Die();

		}
	}

	void Die() {
        
        /*Instantiate(explosion, transform.position, transform.rotation);
        if(tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
        }*/
		Destroy(gameObject);
	}

}
