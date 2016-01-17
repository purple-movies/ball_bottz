using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseUiController : MonoBehaviour
{
    public bool hideOnStart = true;

    Canvas canvas;

	void Start ()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = ! hideOnStart;
        onStart();
	}

    virtual protected void onStart()
    {
    }

    protected void finish()
    {
        hide();
    }

    public bool toggle()
    {
        canvas.enabled = ! canvas.enabled;
        return canvas.enabled;
    }

    public void hide()
    {
        canvas.enabled = false;
    }

    public void show()
    {
        canvas.enabled = true;
    }
}
