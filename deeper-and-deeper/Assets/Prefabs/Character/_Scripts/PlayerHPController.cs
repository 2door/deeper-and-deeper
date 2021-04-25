using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHPController : MonoBehaviour {
    
    public int maxHealth;
    public GameEvent damageDealtEvent;
    public GameEvent gameOverEvent;
    public Image[] containers;
    public Sprite fullContainer;
    public Sprite emptyContainer;
    public Animator playerAnimator;
    public float invulnerableDuration;
    
    private GameEventListener damageDealtListener;
    private int hp;
    private bool isInvulnerable;
    private AudioSource hitAudio;

    void Start() {
        hp = maxHealth;
        isInvulnerable = false;
        hitAudio = transform.GetComponent<AudioSource>();
        damageDealtListener = (GameEventListener) ScriptableObject.CreateInstance("GameEventListener");
        damageDealtListener.SetupListener(damageDealtEvent, TakeDamage);
    }

    private void TakeDamage() {
        if(!isInvulnerable) {
            hp -= 1;
            hitAudio.Play();
            UpdateHPHUD();
            if (hp <= 0) {
                gameOverEvent.Raise();
            } else {
                StartCoroutine(StayInvulnerable());
            }
        }
    }

    private void UpdateHPHUD() {
        for(int i = 0; i < maxHealth && i < containers.Length; i ++) {
            if(i <= hp - 1) {
                containers[i].sprite = fullContainer;
            } else {
                containers[i].sprite = emptyContainer;
            }
        }
    }

    private IEnumerator StayInvulnerable() {
        playerAnimator.SetBool("IsDamaged", true);
        isInvulnerable = true;
        print(invulnerableDuration);
        yield return new WaitForSeconds(invulnerableDuration);
        isInvulnerable = false;
        playerAnimator.SetBool("IsDamaged", false);
    }
}
