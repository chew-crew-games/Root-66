using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blender : MonoBehaviour {
  public GameObject smoothie;
  // public string[] contents = new string[0];
  [SerializeField] List<Ingredient> contents = new List<Ingredient>();
  public bool isBlending = false;
  public Transform ingredientSpawn;
  public string[] contentsRecipe;


  public AudioClip[] sounds;
  public AudioSource source;

  void Start() {
    Debug.Log(ingredientSpawn.localPosition.x);
  }
  // public List<Ingredient> ingredients = new List<Ingredient>();

  // public Dictionary<string, Color> dict = new Dictionary<string, Color>() {
  //   {"Carrot", new Color(1f, 0.7f, 0.3f)},
  //   {"Taro", new Color(.7f,.5f,1f)},
  //   {"Potato", new Color(.5f,.4f,.2f)}
  // };

  public void OnCollisionEnter(Collision col) {
    if (!isBlending && col.gameObject.tag == "Ingredient") {
      contents.Add(col.gameObject.GetComponent<Ingredient>());
      col.gameObject.GetComponent<Draggable>().isDragging = false;
      col.transform.position = ingredientSpawn.position;
      col.transform.rotation = ingredientSpawn.rotation;
      col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
      // contents.Add(col.gameObject.GetComponent < IngredientScriptable)
      // Destroy(col.transform.parent.gameObject);
      contentsRecipe = contents.Select(ingredient => ingredient.name).ToArray();
      transform.gameObject.name = "Blender - " + string.Join(", ", contentsRecipe);
    }
  }

  public void OnMouseDown() {
    if (!isBlending && contents.Count > 0) {
      isBlending = true;
      transform.gameObject.name = "Blender - Blending...";
      // source.clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
      // source.Play();
      StartCoroutine(BlendCoroutine());
    }
  }

  IEnumerator BlendCoroutine() {
    yield return new WaitForSeconds(5);
    GameObject new_smoothie = Instantiate(smoothie, ingredientSpawn.position, Quaternion.identity);
    new_smoothie.transform.parent = transform.parent.parent;
    Smoothie newSmoothieScript = new_smoothie.transform.GetChild(0).GetComponent<Smoothie>();
    newSmoothieScript.GetComponent<SpriteRenderer>().color = AverageColors(contents);
    newSmoothieScript.name = string.Join(" ", contentsRecipe) + " Smoothie";
    newSmoothieScript.contents = new List<Ingredient>(contents);
    contents.Clear();
    isBlending = false;
    transform.gameObject.name = "Blender";
  }

  public Color AverageColors(List<Ingredient> ingredients) {
    float r = 0;
    float g = 0;
    float b = 0;
    foreach (Ingredient ingredient in ingredients) {
      r += ingredient.color.r;
      g += ingredient.color.g;
      b += ingredient.color.b;
    }
    r /= ingredients.Count;
    g /= ingredients.Count;
    b /= ingredients.Count;
    return new Color(r, g, b);
  }
}
