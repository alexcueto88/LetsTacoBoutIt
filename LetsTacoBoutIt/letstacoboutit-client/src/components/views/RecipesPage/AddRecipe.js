import React, { useState, useEffect} from "react";
import { useNavigate } from "react-router-dom";
import { Form, FormGroup, Label, Input, Button, Col } from "reactstrap";


export const AddRecipe = () => {
    const [newRecipe, setNewRecipe] = useState({
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

    const navigate = useNavigate();

    const localProjectUser = localStorage.getItem("capstone_user");
    const projectUserObject = JSON.parse(localProjectUser);
    const [proteinTypes, setProteinTypes] = useState([]);
    console.log(projectUserObject)

    console.log(proteinTypes)

    useEffect (() => {
        fetch (`https://localhost:7278/api/Protein`)
        .then((response) => response.json())
        .then((proteinTypes) => {
            setProteinTypes(proteinTypes);
        });
    }, []);

    const handleSaveButtonClick = (e) => {
        e.preventDefault();

        const recipeToSendToAPI = {
            recipeName: newRecipe.recipeName,
            level: newRecipe.level,
            prepTime: newRecipe.prepTime,
            cookTime: newRecipe.cookTime,
            totalTime: newRecipe.totalTime,
            servingSize: newRecipe.servingSize,
            recipeImage: newRecipe.recipeImage,
            ingredients: newRecipe.ingredients,
            directions: newRecipe.directions,
            createdBy: newRecipe.createdBy,
            proteinTypeId: newRecipe.proteinTypeId,
            userId: projectUserObject.id,
        };



        return fetch(`https://localhost:7278/api/Recipe`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(recipeToSendToAPI),
        })
        .then((response) => response.json())
        .then(() => {
            navigate(`/Recipes`);
        });
        
        
    };

    console.warn("after POST", newRecipe);

    return(
<>
        <Form>
    <div><h1 className="page-header">ADD RECIPE</h1></div>
    <FormGroup>
        <Label for="recipeName">Recipe Name</Label>
        <Input
          id="recipeName"
          name="recipeName"
          type="text"
          value={newRecipe.recipeName}
          onChange={(e) => {
            const copy = { ...newRecipe };
            copy.recipeName = e.target.value;
            setNewRecipe(copy)
          }}
        />
    </FormGroup>

    <FormGroup>
  <Label for="protein-type">Protein Type</Label>
  <Input 
    id="protein-type" 
    name="protein-type" 
    type="select"
    defaultValue={newRecipe.proteinTypeId}
    onChange={(e) => {
      const copy = { ...newRecipe };
      copy.proteinTypeId = e.target.value;
      setNewRecipe(copy)
    }}
  >
    <option value={newRecipe.proteinTypeId} disabled selected>-- Protein Type Selection --</option>
    {proteinTypes.map((proteinType) => (
      <option key={proteinType.id} value={proteinType.id}>
        {proteinType.protein}
      </option>
    ))}
  </Input>
</FormGroup>



    <FormGroup>
        <Label for="level">Difficulty Level</Label>
        <Input
          id="level"
          name="level"
          type="text"
          value={newRecipe.level}
          onChange={(e) => {
            const copy = { ...newRecipe };
            copy.level = e.target.value;
            setNewRecipe(copy)
          }}
        />
    </FormGroup>

    <FormGroup>
        <Label for="prepTime">Prep Time</Label>
        <Input
          id="prepTime"
          name="prepTime"
          type="text"
          value={newRecipe.prepTime}
          onChange={(e) => {
            const copy = { ...newRecipe };
            copy.prepTime = e.target.value;
            setNewRecipe(copy)
          }}
        />
    </FormGroup>

<Form>
<FormGroup><Label for="cookTime">Cook Time</Label>
        <Input
          id="cookTime"
          name="cookTime"
          type="text"
          value={newRecipe.cookTime}
          onChange={(e) => {
            const copy = { ...newRecipe };
            copy.cookTime = e.target.value;
            setNewRecipe(copy)
          }}
        />
    </FormGroup>
</Form>

<Form>
<FormGroup><Label for="totalTime">Total Time</Label>
        <Input
          id="totalTime"
          name="totalTime"
          type="text"
          value={newRecipe.totalTime}
          onChange={(e) => {
            const copy = { ...newRecipe };
            copy.totalTime = e.target.value;
            setNewRecipe(copy)
          }}
        />
    </FormGroup>
</Form>

<Form>
<FormGroup><Label for="servingSize">Serving Size</Label>
        <Input
          id="servingSize"
          name="servingSize"
          type="text"
          value={newRecipe.servingSize}
          onChange={(e) => {
            const copy = { ...newRecipe };
            copy.servingSize = e.target.value;
            setNewRecipe(copy)
          }}
        />
    </FormGroup>
</Form>

    <FormGroup>
        <Label for="recipeImage">Recipe Image</Label>
        <Input
          id="recipeUrl"
          name="recipeImage"
          type="text"
          value={newRecipe.recipeImage}
          onChange={(e) => {
            const copy = { ...newRecipe };
            copy.recipeImage = e.target.value;
            setNewRecipe(copy)
          }}
        />
    </FormGroup>

    <FormGroup>
        <Label for="recipeIngredients">Ingredients:</Label>
        <Input
          id="ingredients"
          name="ingredients"
          type="text"
          value={newRecipe.ingredients}
          onChange={(e) => {
            const copy = { ...newRecipe };
            copy.ingredients = e.target.value;
            setNewRecipe(copy)
          }}
        />
    </FormGroup>

    <FormGroup>
        <Label for="recipeDirections">Directions:</Label>
        <Input
          id="directions"
          name="directions"
          type="text"
          value={newRecipe.directions}
          onChange={(e) => {
            const copy = { ...newRecipe };
            copy.directions = e.target.value;
            setNewRecipe(copy)
          }}
        />
    </FormGroup> 



      <Button type="submit" onClick={handleSaveButtonClick}>
        Submit
      </Button>
    </Form>
    </>



    );

};