using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPointSystem : MonoBehaviour {
  public RawImage points;

  public void UpdatePoints(int point) {
    points.texture = Resources.Load($"winum{point}") as Texture;
  }
}
