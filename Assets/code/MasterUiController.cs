using UnityEngine;
using System.Collections;

public class MasterUiController : MonoBehaviour
{
    [SerializeField] BaseUiController pauseMenu;

	void FixedUpdate ()
    {
	    if(Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.toggle();
        }
	}
}
