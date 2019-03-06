using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipes : MonoBehaviour
{
    public GameObject RuinedDish;

    public Dictionary<string, GameObject> oneItemRecipes = new Dictionary<string, GameObject>();
    public Dictionary<(string, string), GameObject> twoItemRecipes = new Dictionary<(string, string), GameObject>();
    public Dictionary<(string, string, string), GameObject> threeItemRecipes = new Dictionary<(string, string, string), GameObject>();

    public Dictionary<string, float> oneItemTimes = new Dictionary<string, float>();
    public Dictionary<(string, string), float> twoItemTimes = new Dictionary<(string, string), float>();
    public Dictionary<(string, string, string), float> threeItemTimes = new Dictionary<(string, string, string), float>();

    /*

    public Dictionary<string, float> oneItemCounts = new Dictionary<string, float>();
    public Dictionary<(string, string), float> twoItemCounts = new Dictionary<(string, string), float>();
    public Dictionary<(string, string, string), float> threeItemCounts = new Dictionary<(string, string, string), float>();

    */

    public string[] oneIngredient;
    public string[] twoIngredient1;
    public string[] twoIngredient2;
    public string[] threeIngredient1;
    public string[] threeIngredient2;
    public string[] threeIngredient3;

    public GameObject[] oneResult;
    public GameObject[] twoResult;
    public GameObject[] threeResult;

    public float[] oneTimer;
    public float[] twoTimer;
    public float[] threeTimer;

    /*

    public float[] oneCount;
    public float[] twoCount;
    public float[] threeCount;

    */

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < oneIngredient.Length; i ++)
        {
            oneItemRecipes.Add(oneIngredient[i], oneResult[i]);
            oneItemTimes.Add(oneIngredient[i], oneTimer[i]);
            //oneItemCounts.Add(oneIngredient[i], oneCount[i]);
        }

        for (int i = 0; i < twoIngredient1.Length; i++)
        {
            twoItemRecipes.Add((twoIngredient1[i], twoIngredient2[i]), twoResult[i]);
            twoItemTimes.Add((twoIngredient1[i], twoIngredient2[i]), twoTimer[i]);
            //twoItemCounts.Add((twoIngredient1[i], twoIngredient2[i]), twoCount[i]);
        }

        for (int i = 0; i < threeIngredient1.Length; i++)
        {
            threeItemRecipes.Add((threeIngredient1[i], threeIngredient2[i], threeIngredient3[i]), threeResult[i]);
            threeItemTimes.Add((threeIngredient1[i], threeIngredient2[i], threeIngredient3[i]), threeTimer[i]);
            //threeItemCounts.Add((threeIngredient1[i], threeIngredient2[i], threeIngredient3[i]), threeCount[i]);
        }
    }

    public float calcTime(List<Collider> ingredients)
    {
        if (ingredients.Count == 1)
        {
            return findOneItemTime(ingredients[0].tag);
        }
        else if (ingredients.Count == 2)
        {
            return findTwoItemTime(ingredients[0].tag, ingredients[1].tag);
        }
        else if (ingredients.Count == 3)
        {
            return findThreeItemTime(ingredients[0].tag, ingredients[1].tag, ingredients[2].tag);
        }
        else
        {
            return 30;
        }
    }

    public GameObject getResult(List<Collider> ingredients)
    {
        if (ingredients.Count == 1)
        {
            return findOneItemRecipe(ingredients[0].tag);
        }
        else if (ingredients.Count == 2)
        {
            return findTwoItemRecipe(ingredients[0].tag, ingredients[1].tag);
        }
        else if (ingredients.Count == 3)
        {
            return findThreeItemRecipe(ingredients[0].tag, ingredients[1].tag, ingredients[2].tag);
        }
        else
        {
            return RuinedDish;
        }
    }

    /*

    public float GetCount(List<Collider> ingredients)
    {
        if (ingredients.Count == 1)
        {
            return findOneItemCount(ingredients[0].tag);
        }
        else if (ingredients.Count == 2)
        {
            return findTwoItemCount(ingredients[0].tag, ingredients[1].tag);
        }
        else if (ingredients.Count == 3)
        {
            return findThreeItemCount(ingredients[0].tag, ingredients[1].tag, ingredients[2].tag);
        }
        else
        {
            return 1;
        }
    }

    */

    private GameObject findOneItemRecipe(string ingredient1)
    {
        if (oneItemRecipes.ContainsKey(ingredient1))
        {
            return oneItemRecipes[ingredient1];
        }

        return RuinedDish;
    }

    private GameObject findTwoItemRecipe(string ingredient1, string ingredient2)
    {
        if (twoItemRecipes.ContainsKey((ingredient1, ingredient2)))
        {
            return twoItemRecipes[(ingredient1, ingredient2)];
        }
        else if (twoItemRecipes.ContainsKey((ingredient2, ingredient1)))
        {
            return twoItemRecipes[(ingredient2, ingredient1)];
        }

        return RuinedDish;
    }

    private GameObject findThreeItemRecipe(string ingredient1, string ingredient2, string ingredient3)
    {
        if (threeItemRecipes.ContainsKey((ingredient1, ingredient2, ingredient3)))
        {
            return threeItemRecipes[(ingredient1, ingredient2, ingredient3)];
        }
        else if (threeItemRecipes.ContainsKey((ingredient1, ingredient3, ingredient2)))
        {
            return threeItemRecipes[(ingredient1, ingredient3, ingredient2)];
        }
        else if (threeItemRecipes.ContainsKey((ingredient2, ingredient1, ingredient3)))
        {
            return threeItemRecipes[(ingredient2, ingredient1, ingredient3)];
        }
        else if (threeItemRecipes.ContainsKey((ingredient2, ingredient3, ingredient1)))
        {
            return threeItemRecipes[(ingredient2, ingredient3, ingredient1)];
        }
        else if (threeItemRecipes.ContainsKey((ingredient3, ingredient1, ingredient2)))
        {
            return threeItemRecipes[(ingredient3, ingredient1, ingredient2)];
        }
        else if (threeItemRecipes.ContainsKey((ingredient3, ingredient2, ingredient1)))
        {
            return threeItemRecipes[(ingredient3, ingredient2, ingredient1)];
        }

        return RuinedDish;
    }

    private float findOneItemTime(string ingredient1)
    {
        if (oneItemTimes.ContainsKey(ingredient1))
        {
            return oneItemTimes[ingredient1];
        }

        return 30;
    }

    private float findTwoItemTime(string ingredient1, string ingredient2)
    {
        if (twoItemTimes.ContainsKey((ingredient1, ingredient2)))
        {
            return twoItemTimes[(ingredient1, ingredient2)];
        }
        else if (twoItemTimes.ContainsKey((ingredient2, ingredient1)))
        {
            return twoItemTimes[(ingredient2, ingredient1)];
        }

        return 30;
    }

    private float findThreeItemTime(string ingredient1, string ingredient2, string ingredient3)
    {
        if (threeItemTimes.ContainsKey((ingredient1, ingredient2, ingredient3)))
        {
            return threeItemTimes[(ingredient1, ingredient2, ingredient3)];
        }
        else if (threeItemTimes.ContainsKey((ingredient1, ingredient3, ingredient2)))
        {
            return threeItemTimes[(ingredient1, ingredient3, ingredient2)];
        }
        else if (threeItemTimes.ContainsKey((ingredient2, ingredient1, ingredient3)))
        {
            return threeItemTimes[(ingredient2, ingredient1, ingredient3)];
        }
        else if (threeItemTimes.ContainsKey((ingredient2, ingredient3, ingredient1)))
        {
            return threeItemTimes[(ingredient2, ingredient3, ingredient1)];
        }
        else if (threeItemTimes.ContainsKey((ingredient3, ingredient1, ingredient2)))
        {
            return threeItemTimes[(ingredient3, ingredient1, ingredient2)];
        }
        else if (threeItemTimes.ContainsKey((ingredient3, ingredient2, ingredient1)))
        {
            return threeItemTimes[(ingredient3, ingredient2, ingredient1)];
        }

        return 30;
    }

    /*

    private float findOneItemCount(string ingredient1)
    {
        if (oneItemCounts.ContainsKey(ingredient1))
        {
            return oneItemCounts[ingredient1];
        }

        return 30;
    }

    private float findTwoItemCount(string ingredient1, string ingredient2)
    {
        if (twoItemCounts.ContainsKey((ingredient1, ingredient2)))
        {
            return twoItemCounts[(ingredient1, ingredient2)];
        }
        else if (twoItemCounts.ContainsKey((ingredient2, ingredient1)))
        {
            return twoItemCounts[(ingredient2, ingredient1)];
        }

        return 30;
    }

    private float findThreeItemCount(string ingredient1, string ingredient2, string ingredient3)
    {
        if (threeItemCounts.ContainsKey((ingredient1, ingredient2, ingredient3)))
        {
            return threeItemCounts[(ingredient1, ingredient2, ingredient3)];
        }
        else if (threeItemCounts.ContainsKey((ingredient1, ingredient3, ingredient2)))
        {
            return threeItemCounts[(ingredient1, ingredient3, ingredient2)];
        }
        else if (threeItemCounts.ContainsKey((ingredient2, ingredient1, ingredient3)))
        {
            return threeItemCounts[(ingredient2, ingredient1, ingredient3)];
        }
        else if (threeItemCounts.ContainsKey((ingredient2, ingredient3, ingredient1)))
        {
            return threeItemCounts[(ingredient2, ingredient3, ingredient1)];
        }
        else if (threeItemCounts.ContainsKey((ingredient3, ingredient1, ingredient2)))
        {
            return threeItemCounts[(ingredient3, ingredient1, ingredient2)];
        }
        else if (threeItemCounts.ContainsKey((ingredient3, ingredient2, ingredient1)))
        {
            return threeItemCounts[(ingredient3, ingredient2, ingredient1)];
        }

        return 30;
    }

    */
}
