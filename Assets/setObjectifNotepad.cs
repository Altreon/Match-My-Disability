using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setObjectifNotepad : MonoBehaviour
{
    public void setObjNote()
    {
        ObjectifManager.Instance.setObjectif("note");
    }
}
