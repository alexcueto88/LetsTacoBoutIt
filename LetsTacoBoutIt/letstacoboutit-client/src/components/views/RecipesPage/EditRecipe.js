import React, { useState, useEffect } from "react";
import { Form, FormGroup, Label, Input, Button, Col } from "reactstrap";
import { useParams, useNavigate } from "react-router-dom";

export const EditRecipe = () => {
    const { id } = useParams();
    const navigate = useNavigate(); 
    const [recipe, setRecipe] = useState({
        id: "",
        userId: "",
        recipeName: "",
        level: "",
        prepTime: "",
        cookTime: "",
        totalTime: "",
        servingSize: "",
        ingredients: "",
        directions:"",
        recipeImage: "",
        createdBy: "",
        proteinTypeId: "",

    });

    // THIS USEEFFECT IS TO GET ONE RECIPE BY ONE ID  
      useEffect(() => {
        const fetchRecipeDetails = async () => {
            try{
                const response = await fetch(`https://localhost:7278/api/Recipe/${id}`);
                const recipeData = await response.json();
                setRecipe(recipeData);
        } catch (error) {
            console.error("Error fetching recipe details:", error);
        }
        
    };

       fetchRecipeDetails();
      }, [id]);


    const handleInputChange = (e) => {
          const { name, value } = e.target;
          setRecipe((prevRecipe) => ({
              ...prevRecipe,
              [name]: value,
            }));
        };
        
    const handleSaveButtonClick = (e) => {
        e.preventDefault();
      
        const recipeToSendToAPI = {
            id: recipe.id,
            userId: recipe.userId,
            recipeName: recipe.recipeName,
            level: recipe.level,
            prepTime: recipe.prepTime,
            cookTime: recipe.cookTime,
            totalTime: recipe.totalTime,
            servingSize: recipe.servingSize,
            recipeImage: recipe.recipeImage,
            ingredients: recipe.ingredients,
            directions: recipe.directions,
            createdBy: recipe.createdBy,
            proteinTypeId: recipe.proteinTypeId,

        };
            
    fetch(`https://localhost:7278/api/Recipe/${id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(recipeToSendToAPI),
    })
      .then((response) => {
      if (response.ok){
        return response.json();
      } else{
        throw new Error("Error updating recipe");
      }
    })
      .then(() => {
        navigate(`/Recipes`, { replace: true });
        });
  };

  return (
    <>
{/* **RECIPE NAME** */}
        <Form>
    <div><h1 className="page-header">EDIT RECIPE</h1></div>
    <FormGroup>
        <Label for="recipeName">Recipe Name</Label>
        <Input
          id="recipeName"
          name="recipeName"
          type="text"
          value={recipe.recipeName}
          onChange={handleInputChange}
        />
    </FormGroup>

    <FormGroup>
        <Label for="level">Difficulty Level</Label>
        <Input
          id="level"
          name="level"
          type="text"
          value={recipe.level}
          onChange={handleInputChange}
        />
    </FormGroup>

{/* **DIFFICULTY LEVEL -- alt option 1**  */}
      {/* <FormGroup>
        <Label for="level">Difficulty Level</Label>
        <Input 
        id="level" 
        name="level" 
        type="select"
        value={recipe.level}
        onChange={handleInputChange}
        >
          <option value="Easy">Easy</option>
          <option value="Moderate">Moderate</option>
          <option value="Hard">Hard</option>
        </Input>
      </FormGroup> */}


{/* *** difficulty level -- OPTION 2 ***
<Form>
  <FormGroup
    row
    tag="fieldset"
  >
    <legend className="col-form-label col-sm-2">
      Difficulty Level
    </legend>
    <Col sm={15}>
      <FormGroup check>
        <Input
          name="level"
          type="radio"
        />
        {' '}
        <Label check>
          Easy
        </Label>
      </FormGroup>
      <FormGroup check>
        <Input
          name="level"
          type="radio"
        />
        {' '}
        <Label check>
          Intermediate
        </Label>
      </FormGroup>
      <FormGroup
        check
        disabled
      >
        <Input
        //   disabled
          name="level"
          type="radio"
        />
        {' '}
        <Label check>
          Hard
        </Label>
      </FormGroup>
    </Col>
  </FormGroup>
 </Form> */}


{/* *** PREP TIME *** */}
    <FormGroup>
        <Label for="prepTime">Prep Time</Label>
        <Input
          id="prepTime"
          name="prepTime"
          type="text"
          value={recipe.prepTime}
          onChange={handleInputChange}
        />
    </FormGroup>

<Form>
<FormGroup><Label for="cookTime">Cook Time</Label>
        <Input
          id="cookTime"
          name="cookTime"
          type="text"
          value={recipe.cookTime}
          onChange={handleInputChange}
        />
    </FormGroup>
</Form>

<Form>
<FormGroup><Label for="totalTime">Total Time</Label>
        <Input
          id="totalTime"
          name="totalTime"
          type="text"
          value={recipe.totalTime}
          onChange={handleInputChange}
        />
    </FormGroup>
</Form>

<Form>
<FormGroup><Label for="servingSize">Serving Size</Label>
        <Input
          id="servingSize"
          name="servingSize"
          type="text"
          value={recipe.servingSize}
          onChange={handleInputChange}
        />
    </FormGroup>
</Form>

{/* ****************************************** SERVING SIZE -- alt option *****************************
     <Form>
  <FormGroup>
    <Label for="servingSize">Serving Size</Label>
  </FormGroup>
  <FormGroup check inline>
    <Input
      type="radio"
      name="servingSize"
      value="2-4"
      checked={recipe.servingSize}
      onChange={handleInputChange}
    />
    <Label check>2-4</Label>
  </FormGroup>
  <FormGroup check inline>
    <Input
      type="radio"
      name="servingSize"
      value="4-6"
      checked={recipe.servingSize}
      onChange={handleInputChange}
    />
    <Label check>4-6</Label>
  </FormGroup>
  <FormGroup check inline>
    <Input
      type="radio"
      name="servingSize"
      value="6-8"
      checked={recipe.servingSize}
      onChange={handleInputChange}
    />
    <Label check>6-8</Label>
  </FormGroup>
</Form> */}


{/* *** RECIPE IMAGE *** */}
    <FormGroup>
        <Label for="recipeImage">Recipe Image</Label>
        <Input
          id="recipeUrl"
          name="recipeImage"
          type="text"
          value={recipe.recipeImage}
          onChange={handleInputChange}
        />
    </FormGroup>

    {/* *** RECIPE INGREDIENTS *** */}
    <FormGroup>
        <Label for="recipeIngredients">Ingredients:</Label>
        <Input
          id="ingredients"
          name="ingredients"
          type="text"
          value={recipe.ingredients}
          onChange={handleInputChange}
        />
    </FormGroup>

    {/* *** RECIPE DIRECTIONS *** */}
    <FormGroup>
        <Label for="recipeDirections">Directions:</Label>
        <Input
          id="directions"
          name="directions"
          type="text"
          value={recipe.directions}
          onChange={handleInputChange}
        />
    </FormGroup>
   



      <Button type="submit" onClick={handleSaveButtonClick}>
        Submit
      </Button>
    </Form>
    </>
  );
};
