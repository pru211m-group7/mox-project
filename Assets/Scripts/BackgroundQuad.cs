using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundQuad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var Hheight = Camera.main.orthographicSize * 2f;
        var Wwidth = Hheight * Screen.width / Screen.height;
        transform.localScale = new Vector3(Wwidth, Hheight, 0f);
    }

    
}
