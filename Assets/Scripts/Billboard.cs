using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Start is called before the first frame update
    //public void RotateUnitSprite()
    // {
    //     Vector3 targetVector = Camera.main.transform.position - transform.position;
    //     float newYAngle = Mathf.Atan2(targetVector.z, targetVector.x) * Mathf.Rad2Deg;
    //     transform.rotation = Quaternion.Euler(0, -1 * newYAngle, 0);

    // }
    [SerializeField] bool ChangeMethod = true;
    private void Update()
    {
        if (ChangeMethod)
        {
            transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }
       
    }
}
