using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Fishing2D
{
    public class ContinueButton : BaseButton
    {
        protected override void OnClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}
