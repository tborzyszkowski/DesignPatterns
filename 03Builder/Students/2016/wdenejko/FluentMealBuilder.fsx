type FluentMeal = {
    cuisine : string; 
    ingredientsCount : string;
    difficulty : string;
    timeToPrepare : string; 
    spicinessLevel : string
    }
let show meal =
        printf "\n---------------------------"
        printf "\nCuisine: %s" meal.cuisine
        printf "\nIngrediens count: %s" meal.ingredientsCount
        printf "\nDifficulty: %s" meal.difficulty
        printf "\nTime to prepare: %s" meal.timeToPrepare
        printf "\nSpiciness level: %s" meal.spicinessLevel
        printf "\n---------------------------"
        meal

let setCuisine cuisine meal =
    {meal with FluentMeal.cuisine = cuisine}
let setIngredientsCount ingredientsCount meal =
    {meal with FluentMeal.ingredientsCount = ingredientsCount}
let setDifficulty difficulty meal =
    {meal with FluentMeal.ingredientsCount = difficulty}
let setTimeToPrepare timeToPrepare meal =
    {meal with FluentMeal.timeToPrepare = timeToPrepare}
let setSpicinessLevel spicinessLevel meal =
    {meal with FluentMeal.spicinessLevel = spicinessLevel}
let defaultMeal =
    {cuisine=""; ingredientsCount=""; difficulty=""; timeToPrepare=""; spicinessLevel=""}

let GreenCurry = defaultMeal 
                |> setCuisine "Thai"
                |> setIngredientsCount "10"
                |> setDifficulty "Medium"
                |> setTimeToPrepare "30min"
                |> setSpicinessLevel "4/6"

GreenCurry |> show

let Spaghetti = defaultMeal
                |> setCuisine "Italian"
                |> setIngredientsCount "4"
                |> setDifficulty "Easy"
                |> setTimeToPrepare "15min"
                |> setSpicinessLevel "1/6"
                |> show
