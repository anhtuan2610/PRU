using UnityEngine;

public class Projecttile : MonoBehaviour
{
    [SerializeField] private float kameSpeed = 10f;
    [SerializeField] private float kameDamage = 1f;
    private float direction;
    private bool hit;
    public MPBar mpBar;
    public Health health;
    private BoxCollider2D boxCollider;
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        mpBar = GetComponent<MPBar>();
        health = GetComponent<Health>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(hit)
        {
            return;
        }
        float movementSpeed = kameSpeed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
            collision.GetComponent<Health>().TakeDamage(kameDamage);
        }
    }
    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
    
        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
