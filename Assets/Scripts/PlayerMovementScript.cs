using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private GameObject[] Obstacles;
    private GameObject[] ObjToPush;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        ObjToPush = GameObject.FindGameObjectsWithTag("ObjToPush");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Move(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();
        
        if(Blocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }

    public bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newpos = new Vector2(position.x, position.y) + direction;

        foreach (var obj in Obstacles)
        {
            if (obj.transform.position.x == newpos.x && obj.transform.position.y == newpos.y)
            {
                return true;
            }
        }

        foreach (var obj in ObjToPush)
        {
            if (ObjToPush.transform.position.x == newpos.x && objToPush.transform.position.y == newpos.y)
            {
                Push objpush = ObjToPush.getcomponent<Push>();
                if (objpush && objpush.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
}
