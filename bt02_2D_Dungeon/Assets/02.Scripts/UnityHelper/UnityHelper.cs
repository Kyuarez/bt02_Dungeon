using UnityEngine;

public static class UnityHelper
{
    /// <summary>
    /// fromTo와 x축 사이의 각도 구하기
    /// </summary>
    public static float GetAngleFromTo(Vector2 from, Vector2 to, bool isDegree = true)
    {
        Vector2 fromTo = new Vector2(to.x - from.x, to.y - from.y);
        float angle = Mathf.Atan2(fromTo.y, fromTo.x);

        return isDegree == true ? angle * Mathf.Rad2Deg : angle;
    }

    /// <summary>
    /// use Addforce to target
    /// </summary>
    public static Vector2 GetChaseTargetVec(Vector2 from, Vector2 to)
    {
        float radian = GetAngleFromTo(from, to, false);
        float x = Mathf.Cos(radian);
        float y = Mathf.Sin(radian);
        return new Vector2(x, y);
    }
}
