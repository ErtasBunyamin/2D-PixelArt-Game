using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeController : MonoBehaviour
{
    private PlayerController player;
    private Tilemap tilemap;
    private SpriteRenderer  spriteRenderer;
    private PolygonCollider2D collider2D;
    private ParticleSystem particle;

    // Start is called before the first frame update
    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<PolygonCollider2D>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            StartCoroutine(destroyTree());
        }
    }



    public IEnumerator destroyTree()
    {
        particle.Play();
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(this);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Trees"))
        {
            //canCut = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
