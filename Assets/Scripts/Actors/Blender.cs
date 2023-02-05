using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Blender : MonoBehaviour {
  public GameObject smoothie;
  public string[] contents = new string[0];
  public bool isBlending = false;

  public Dictionary<string, Color> dict = new Dictionary<string, Color>() {
        {"Carrot", new Color(1f, 0.7f, 0.3f)},
        {"Taro", new Color(.7f,.5f,1f)},
        {"Potato", new Color(.5f,.4f,.2f)}
    };

  public void OnCollisionEnter(Collision col) {
    if (!isBlending && col.gameObject.tag == "Ingredient") {
        Array.Resize(ref contents, contents.Length + 1);
        contents[contents.GetUpperBound(0)] = col.gameObject.name;
        Destroy(col.transform.parent.gameObject);
        transform.gameObject.name = "Blender - " + string.Join(", ", contents);
    }
  }

  public void OnMouseDown() {
    if (!isBlending && contents.Length > 0) {
      isBlending = true;
      transform.gameObject.name = "Blender - Blending...";
      StartCoroutine(BlendCoroutine());
    }
  }

  IEnumerator BlendCoroutine() {
    yield return new WaitForSeconds(5);
    GameObject new_smoothie = Instantiate(smoothie, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    new_smoothie.transform.parent = transform.parent;
    new_smoothie.transform.Find("Smoothie").GetComponent<SpriteRenderer>().color = AverageColors();
    new_smoothie.transform.Find("Smoothie").name = "Smoothie - " + string.Join(", ", contents);
    new_smoothie.transform.Find("Smoothie").GetComponent<Smoothie>().contents = new string[contents.Length];
    contents.CopyTo(new_smoothie.transform.Find("Smoothie").GetComponent<Smoothie>().contents, 0);
    contents = new string[0];
    isBlending = false;
    transform.gameObject.name = "Blender";
  }

  public Color AverageColors() {
    float r = 0;
    float g = 0;
    float b = 0;
    for (int i = 0; i < contents.Length; i++) {
      r += dict[contents[i]].r;
      g += dict[contents[i]].g;
      b += dict[contents[i]].b;
    }
    r /= contents.Length;
    g /= contents.Length;
    b /= contents.Length;
    return new Color(r, g, b);
  }
}
