using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D rb;
    public float movementSpeed = 1.0f;
    public float missilePower = 2000.0f;
    public GameObject missilePrefab;
    public bool InCooldown = false;
    public float CooldownTime = 0.2f;
    public int missileCount = 10;
    public float CooldownSec1 = 0.5f;
    public float reloadCD = 0.2f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton("Jump") && missileCount > 0 && !InCooldown)
        {
            Debug.Log("Firing");
            GameObject missile = Instantiate(missilePrefab);
            missile.transform.position = transform.position;
            Rigidbody2D rbMissile = missile.GetComponent<Rigidbody2D>();
            InCooldown = true;
            StartCoroutine(refreshCooldown());

            missileCount--;
            if (missileCount == 0)
            {
                StartCoroutine(reloadCooldown());
            }
            else
            {
                StartCoroutine(refreshCooldown());
            }
        }
    }

    IEnumerator refreshCooldown()
    {
        yield return new WaitForSeconds(CooldownSec1);
        InCooldown = false;
    }

    IEnumerator reloadCooldown()
    {
        yield return new WaitForSeconds(reloadCD);
        InCooldown = false;
        missileCount = 10;
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
    }
}
