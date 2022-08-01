using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Dilouge : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Dialougees_UI.dialougees_instance.is_dialogue)
        {
            Dialougees_UI.dialougees_instance.enable_Dialogue();

            Destroy(Dialougees_UI.dialougees_instance.Dialougees,7);

            Dialougees_UI.dialougees_instance.is_dialogue=false;
        }
    }
}
