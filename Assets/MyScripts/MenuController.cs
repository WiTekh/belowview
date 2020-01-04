using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void OnClickCharacterPick(int whichOne)
    {
        if (PlayerInfo.PI != null)
        {
            PlayerInfo.PI.mySelectedCharacter = whichOne;
            PlayerPrefs.SetInt("MyCharacter", whichOne);
        }
    }
}
