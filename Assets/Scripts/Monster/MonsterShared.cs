using UnityEngine;

public class MonsterShared : MonoBehaviour
{
    public int damage { get; set; }
    public float speed { get; set; }
    public float amounttomovex { get; set; }
    public float currentposx { get; set; }
    public float currentposy { get; set; }
    public int facing { get; set; }
    public void dealDamage(GameObject enemy)
    {
        try
        {
            Control player = enemy.GetComponent<Control>();
            if (!player.immune) player.curhealth -= damage;
        } catch (System.Exception ex)
        {
            Debug.Log("Not player");
        }
    }
    public void Move()
    {
        if (facing == 1 && gameObject.transform.position.x < currentposx - amounttomovex)
        {
            facing = 0;
        }

        if (facing == 0 && gameObject.transform.position.x > currentposx)
        {
            facing = 1;
        }

        if (facing == 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (facing == 1)
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
    }

    public void MonsterInitial(int dmg, float spd, float amounttomovex)
    {
        currentposx = gameObject.transform.position.x;
        facing = 0;
        damage = dmg;
        speed = spd;
        this.amounttomovex = amounttomovex;
    }

    public GameObject detectEnemy()
    {
        GameObject enemy = GameObject.FindObjectOfType<Control>().gameObject;
        float space = (enemy.transform.position.x - transform.position.x) * (enemy.transform.position.x - transform.position.x)
            + (enemy.transform.position.y - transform.position.y) * (enemy.transform.position.y - transform.position.y);
        if (space<500f && !enemy.GetComponent<Control>().immune)
        {
            return enemy;
        } else
        {
            return null;
        }
    }
}
