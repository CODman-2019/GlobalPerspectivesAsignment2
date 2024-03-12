using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactDetails : MonoBehaviour
{
    public string name;
    [TextArea]
    public string details;

    public string GetName() { return name; }
    public string GetDetails() { return details; }
}
