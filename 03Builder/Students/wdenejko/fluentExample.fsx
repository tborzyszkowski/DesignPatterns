// create an underlying type
type FluentShape = {
    label : string; 
    color : string; 
    onClick : FluentShape->FluentShape // a function type
    }

let defaultShape = 
    {label=""; color=""; onClick=fun shape->shape}

let click shape = 
    shape.onClick shape

let display shape = 
    printfn "My label=%s and my color=%s" shape.label shape.color
    shape   //return same shape
let setLabel label shape = 
   {shape with FluentShape.label = label}

let setColor color shape = 
   {shape with FluentShape.color = color}

//add a click action to what is already there
let appendClickAction action shape = 
   {shape with FluentShape.onClick = shape.onClick >> action}

// Compose two "base" functions to make a compound function.
let setRedBox = setColor "red" >> setLabel "box" 

// Create another function by composing with previous function.
// It overrides the color value but leaves the label alone.
let setBlueBox = setRedBox >> setColor "blue"  

// Make a special case of appendClickAction
let changeColorOnClick color = appendClickAction (setColor color)  

//setup some test values
let redBox = defaultShape |> setRedBox
let blueBox = defaultShape |> setBlueBox 

// create a shape that changes color when clicked
redBox 
    |> display
    |> changeColorOnClick "green"
    |> click
    |> display  // new version after the click

// create a shape that changes label and color when clicked
blueBox 
    |> display
    |> appendClickAction (setLabel "box2" >> setColor "green")  
    |> click
    |> display  // new version after the click

let rainbow =
    ["red";"orange";"yellow";"green";"blue";"indigo";"violet"]

let showRainbow = 
    let setColorAndDisplay color = setColor color >> display 
    rainbow 
    |> List.map setColorAndDisplay 
    |> List.reduce (>>)

// test the showRainbow function
defaultShape |> showRainbow 