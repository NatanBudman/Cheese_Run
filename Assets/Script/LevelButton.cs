using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
   public string levelName;
   public void LevelSelected()
   {
      LevelLoad.LevelLoading($"Scenes/{levelName}");
   }
}
