import React, { useState, useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import "../RecipesPage/RecipesPage.css";
import { Card, CardGroup, CardLink, Button } from "reactstrap"; 


export const Recipes = () => {
  const [recipes, setRecipes] = useState([]);

// BRINGS ALL RECIPES  
useEffect(() => {
    const fetchRecipes = async () => {
        const response = await fetch(`https://localhost:7278/api/Recipe`);
        const recipes = await response.json();
        setRecipes(recipes);
    };
    fetchRecipes()
}, [])

const editButton = (id) => {
  return (
    <Link to={`/editRecipe/${id}`}>
      <Button className="editButton">Edit Recipe</Button>                                      
    </Link>
  );
};

const deleteButton = (id) => {
   const handleDelete = async () => {
          const options = {
            method: "DELETE"
          };
          await fetch(`https://localhost:7278/api/Recipe/${id}`, options);
          const updatedRecipes = recipes.filter((recipe) => recipe.id !== id);
          setRecipes(updatedRecipes);
        };
return(
  <button onClick={handleDelete} className="recipeDeleteButton"> 
    Delete Recipe
    </button>
    );

};

// SORTS RECIPES ALPHABETICALLY 
    const sortRecipes = () => {
        const sortedRecipes = [...recipes].sort((a, b) =>
        a.recipeName.localeCompare(b.recipeName)
        );
        setRecipes(sortedRecipes);
    };

    const {id} = useParams()

//RETURN = WHAT IS DISPLAYED ON PAGE    
  return (
    <>
     <div>
      <Link to={`/AddRecipe`} className="add-recipe-link"><button> Add New Recipe</button> 
      </Link>
    </div>

      <div className="background">       
        <div >
            <h1 className="page-header">RECIPES</h1>
        </div>

        <div> 
            <div className="proteintype-box">
            <h3 className="section-header">PICK YOUR PROTEIN:</h3>   

                <div className= "CategoryBox">
                    <div className="type-Box">MEAT</div>
                    <div className="type-Box">POULTRY</div>
                    <div className="type-Box">PORK</div>
                    <div className="type-Box">VEGGIE</div>
                </div> 
        </div>

    </div>

          <div className="section-header"><h3>VIEW ALL RECIPES</h3></div>
 {/* ************ BUTTON TO SORT ALPHABETICALLY ******************************/}

      <div className="button-section"><button onClick={sortRecipes}>Sort Alphabetically</button></div>

    <div className="recipe-list">

            <CardGroup>
            {recipes.map((recipe) => (
              <div key={recipe.id}>    
              <Card className="recipe-card">
                  <img src={recipe.recipeImage} alt={recipe.recipeName} />
                  <Link to={`/recipe/${recipe.id}`} className="recipe-name-link"><h3>{recipe.recipeName}</h3></Link>
                  {editButton(recipe.id)}
                  {deleteButton(recipe.id)}
              </Card>
              
               </div>
            ))}
            </CardGroup>
            
          </div>

        </div>
    </>
  );
};

export default Recipes;