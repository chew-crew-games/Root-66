using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour {
  public GameObject smoothie;
  public List<string> contents;
  public bool isBlending = false;

  public Dictionary<string, Color> dict = new Dictionary<string, Color>() {
        {"Carrot", new Color(1f, 0.7f, 0.3f)},
        {"Taro", new Color(.7f,.5f,1f)},
        {"Potato", new Color(.5f,.4f,.2f)}
    };

  public void OnCollisionEnter(Collision col) {
    if (!isBlending && col.gameObject.tag == "Ingredient") {
      contents.Add(col.gameObject.name);
      Destroy(col.transform.parent.gameObject);
      transform.gameObject.name = "Blender - " + string.Join(", ", contents);
    }
  }

  public void OnMouseDown() {
    if (!isBlending && contents.Count > 0) {
      isBlending = true;
      transform.gameObject.name = "Blender - Blending...";
      StartCoroutine(BlendCoroutine());
    }
  }

  IEnumerator BlendCoroutine() {
    yield return new WaitForSeconds(5);
    GameObject new_smoothie = Instantiate(smoothie, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    new_smoothie.transform.Find("Smoothie").GetComponent<SpriteRenderer>().color = AverageColors();
    new_smoothie.transform.Find("Smoothie").name = "Smoothie - " + string.Join(", ", contents);
    contents = new List<string>();
    isBlending = false;
    transform.gameObject.name = "Blender";
  }

  public Color AverageColors() {
    float r = 0;
    float g = 0;
    float b = 0;
    for (int i = 0; i < contents.Count; i++) {
      r += dict[contents[i]].r;
      g += dict[contents[i]].g;
      b += dict[contents[i]].b;
    }
    r /= contents.Count;
    g /= contents.Count;
    b /= contents.Count;
    return new Color(r, g, b);
  }
}
