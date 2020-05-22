using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPointSystem : MonoBehaviour {
  public RawImage points;
  public GameObject pointsHolder;

  public void UpdatePoints(int point) {
    GameObject full = pointsHolder.transform.Find("Full").gameObject;
    GameObject left = pointsHolder.transform.Find("Left").gameObject;
    GameObject zero = pointsHolder.transform.Find("Zero").gameObject;

    if (point > 0 && point < 100) {
      full.SetActive(false);
      left.SetActive(true);
      zero.SetActive(false);

      int num = point / 10;

      points.texture = Resources.Load($"winum{num}") as Texture;
    } else {
      left.SetActive(false);
      zero.SetActive(true);
    }
  }

  public void UpdateFrag(int point) {
    Debug.Log(point);
    points.texture = Resources.Load($"winum{point}") as Texture;
  }
}
