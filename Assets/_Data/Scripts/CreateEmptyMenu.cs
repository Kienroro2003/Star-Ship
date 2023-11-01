using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateEmptyMenu : MonoBehaviour
{
    [MenuItem("GameObject/Create Centered Empty #%&n", priority = 0 )]
    public static void CreateEmpty()
    {
        GameObject empty = new GameObject("GameObject");
        Undo.RegisterCreatedObjectUndo( empty, "Create new empty" );
        Selection.objects = new Object[] { empty };
    }
}
