using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextScript : EventTextScript
{
    [SerializeField] bool lastText;
    [SerializeField] GameObject nextText;
    public override void Destroy()
    {
        if (!lastText)
            Instantiate(nextText);
        base.Destroy();
    }
}
