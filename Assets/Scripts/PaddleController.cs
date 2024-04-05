using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float batasKiri;
    public float batasKanan;
    public float kecepatan;
    public string axis;

    void Update()
    {
        float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
        float nextPos = transform.position.x + gerak;
        if (nextPos > batasKanan)
        {
            gerak = 0;
        }
        if (nextPos < batasKiri)
        {
            gerak = 0;
        }
        transform.Translate(gerak, 0, 0);
    }
}
