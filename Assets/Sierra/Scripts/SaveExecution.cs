using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveExecution : MonoBehaviour
{
    public JugadorInfo so;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SaveManager.Save(so);
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            so = SaveManager.Load();
        }
    }
}
