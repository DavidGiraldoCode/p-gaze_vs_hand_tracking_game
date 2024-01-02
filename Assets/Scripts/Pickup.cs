using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum ItemType
    {
        Hazard,
        Diamond,
        Heart,
        Lava,
    }
    public ItemType type;

    public enum DamageDirection
    {
        All,
        Up,
        Down,
        Left,
        Right,
        None
    }
    public DamageDirection intendedDirection;

    public float threshold = 0.5f; // 碰撞的阈值

    private void OnItemPickup(GameObject player)
    {
        PointsController pointsController = player.GetComponent<PointsController>();
        if (pointsController != null)
        {
            switch (type)
            {
                case ItemType.Diamond:
                    pointsController.AddPoints(1);
                    break;
                case ItemType.Hazard:
                    break;
                case ItemType.Heart:
                    pointsController.AddLives(1);
                    break;
            }
            // print(pointsController.Points);

            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemPickup(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 确认碰撞的是玩家
        if (collision.gameObject.CompareTag("Player"))
        {
            PointsController pointsController = collision.gameObject.GetComponent<PointsController>();
            if (pointsController != null)
            {
                switch (type)
                {
                    case ItemType.Diamond:
                        break;
                    case ItemType.Hazard:
                        // 这里调用了GetDamageDirection，传入了接触点的法线
                        // DamageDirection contactDirection = GetDamageDirection(collision.contacts[0].normal);
                        // 如果碰撞方向与预期的伤害方向匹配，才对玩家造成伤害
                        // print(contactDirection);

                        pointsController.AddPoints(-1);
                        break;
                    case ItemType.Heart:
                        break;
                }
            }

            // 销毁该物体
            // Destroy(gameObject);
        }
    }



    // 根据碰撞法线确定伤害方向
    private DamageDirection GetDamageDirection(Vector2 contactNormal)
    {
        if (Mathf.Abs(contactNormal.y) > threshold)
        {
            // 垂直方向
            return (contactNormal.y > 0) ? DamageDirection.Up : DamageDirection.Down;
        }
        else if (Mathf.Abs(contactNormal.x) > threshold)
        {
            // 水平方向
            return (contactNormal.x > 0) ? DamageDirection.Right : DamageDirection.Left;
        }

        return DamageDirection.None; // 如果没有明显的垂直或水平方向，返回None
    }
}
