using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private float animSpeed;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(PlayParticleAnimation());
    }

    private IEnumerator PlayParticleAnimation()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            spriteRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(animSpeed);
        }
        Destroy(gameObject);
    }
}
