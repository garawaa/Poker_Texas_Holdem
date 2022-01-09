using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour
{
    public Vector3 dir;
    private void Update()
        {
        transform.Rotate(dir * Time.deltaTime   );
        }
    }

