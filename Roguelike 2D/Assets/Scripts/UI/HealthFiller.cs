using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFiller : MonoBehaviour
{

    [SerializeField] private Transform healthMain;
    
    private float targetScale = 1.0f;

    public float TargetScale
    {
        get => targetScale;
        set
        {
            Debug.Log(targetScale);
            targetScale = Mathf.Clamp01(value);
            healthMain.localScale = new Vector3(targetScale, 1, 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
