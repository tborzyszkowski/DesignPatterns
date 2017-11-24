open System.Collections.Generic
let ingredients = new Dictionary<string, string>()

type Meal(t:string) =
    let mutable mealType = t
    member this.Add key value = 
        ingredients.Add(key,value)
    member this.Show () =
        printf "\n---------------------------"
        printf "\nMeal name: %s" mealType
        printf "\nCuisine: %s" ingredients.["cuisine"]
        printf "\nIngrediens count: %s" ingredients.["ingredientsCount"]
        printf "\nDifficulty: %s" ingredients.["difficulty"]
        printf "\nTime to prepare: %s" ingredients.["timeToPrepare"]
        printf "\nSpiciness level: %s" ingredients.["spicinessLevel"]
        printf "\n---------------------------"
        ingredients.Clear()

[<AbstractClass>]
type MealBuilder(name) =
    member x.Meal = new Meal(name)

    abstract member BuildCuisine: unit -> unit
    abstract member BuildIngredients: unit -> unit
    abstract member BuildDifficulty: unit -> unit
    abstract member BuildTimeToPrepare: unit -> unit
    abstract member BuildSpicinessLevel: unit -> unit

type GreenCurryBuilder(name) = 
    inherit MealBuilder(name)
    override x.BuildCuisine() =  x.Meal.Add "cuisine" "Thai"
    override x.BuildIngredients() = x.Meal.Add "ingredientsCount" "12"
    override x.BuildDifficulty() = x.Meal.Add "difficulty" "Medium"
    override x.BuildTimeToPrepare() = x.Meal.Add "timeToPrepare" "25min"
    override x.BuildSpicinessLevel() = x.Meal.Add "spicinessLevel" "3/6"

type SpaghettiBuilder(name) = 
    inherit MealBuilder(name)
    override x.BuildCuisine() =  x.Meal.Add "cuisine" "Italian"
    override x.BuildIngredients() = x.Meal.Add "ingredientsCount" "4"
    override x.BuildDifficulty() = x.Meal.Add "difficulty" "Very Easy"
    override x.BuildTimeToPrepare() = x.Meal.Add "timeToPrepare" "15min"
    override x.BuildSpicinessLevel() = x.Meal.Add "spicinessLevel" "1/6"

type Shop() =
    member this.Construct (mealBuilder: MealBuilder) =
        mealBuilder.BuildCuisine()
        mealBuilder.BuildIngredients()
        mealBuilder.BuildDifficulty()
        mealBuilder.BuildTimeToPrepare()
        mealBuilder.BuildSpicinessLevel()
let shop = new Shop()
let builder = new GreenCurryBuilder("Green Curry");
shop.Construct(builder)
builder.Meal.Show()
let builder2 = new SpaghettiBuilder("Spaghetti");
shop.Construct(builder)
builder.Meal.Show()