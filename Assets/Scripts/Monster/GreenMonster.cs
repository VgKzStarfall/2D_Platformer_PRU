using UnityEngine;

public class GreenMonster : MonsterShared
{
    float detectTimer;
    public GameObject enemy;
    Vector2 initPos;
    Rigidbody2D rb;
    bool exhausted;
    bool delayHit;
    float delayHitTimer=0f;
    public int moveTime=0;
    float restTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initPos = transform.position;
        MonsterInitial(50,0,0);
        detectTimer = 0f;
        exhausted= false;
        delayHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        enemy = detectEnemy();
        if (detectTimer == 0f)
        {
            if (enemy != null && moveTime<5)
            {
                flyToEnemy();
                detectTimer = 2f;
            } else 
            {
                flyBack();
            }
        }
        if (detectTimer>0f)
        {
            detectTimer -= Time.deltaTime;
        } else
        {
            detectTimer = 0f;
        }
        if (!delayHit)
        {
            checkDmg();
        }
        else
        {
            if (delayHitTimer>0f)
            {
                delayHitTimer -= Time.deltaTime;
            } else
            {
                delayHitTimer = 0f;
                delayHit = false;
            }
        }
    }

    void checkDmg()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 10f, LayerMask.NameToLayer("Player"));
        if (cols.Length>0)
        {
            foreach (var col in cols)
            {
                if (col.tag == "Player")
                {
                    delayHit = true;
                    delayHitTimer = 1f;
                    col.gameObject.GetComponent<Control>().curhealth -= 10;
                }
            }
        }
    }
    void flyToEnemy()
    {
        try
        {
            flyToPos(enemy.transform.position,false);
            moveTime++;
        } catch (System.Exception ex)
        {
            flyBack();
        }
    }

    void flyToPos(Vector2 pos, bool back)
    {
        Vector2 dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
        if (dir != new Vector2(0,0))
        {
            if (back)
            {
                dir.x = 10 * dir.x / Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
                dir.y = 10 * dir.y / Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
            } else
            {
                if (exhausted)
                {
                    exhausted = false;
                    dir.x = 20 * dir.x / Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
                    dir.y = 20 * dir.y / Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
                }
                if ((dir.x * dir.x + dir.y * dir.y) < 5f && back)
                {
                    dir.x = 0;
                    dir.y = 0;
                    moveTime = 0;
                    exhausted = true;
                }
                if ((dir.x * dir.x + dir.y * dir.y) < 50f && !back)
                {
                    dir.x = Random.Range(50f, 100f) * dir.x / Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
                    dir.y = Random.Range(50f, 100f) * dir.y / Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
                }
                else if ((dir.x * dir.x + dir.y * dir.y) > 100f)
                {
                    exhausted = true;
                }
            }
            rb.velocity = dir / 1.25f;
        }
    }

    void flyBack()
    {
        flyToPos(initPos,true);
    }
}
