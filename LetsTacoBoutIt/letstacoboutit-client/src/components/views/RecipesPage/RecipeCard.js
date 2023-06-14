import { Card, CardImg } from "react-bootstrap";
import CardHeader from "react-bootstrap/esm/CardHeader"
import { Link, useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { CardBody, CardColumns, CardImgOverlay, CardLink, CardText, CardTitle, ListGroup, ListGroupItem, Butt } from "reactstrap";
import Recipes from "./RecipesPage";

function RecipeCard() {
    const [recipe, setRecipe] = useState({
      recipeName: ""
    });

    const currentUser = localStorage.getItem("capstone_user")
    const tacoUserObject = JSON.parse(currentUser)

    const { id } = useParams();

    useEffect(() => {
        const fetchRecipe = async () => {
          try {
            const response = await fetch(`https://localhost:7278/api/Recipe/${id}`);
            const data = await response.json();
            setRecipe(data);
          } catch (error) {
            console.error('Error fetching recipe:', error);
          }
        };
    
        fetchRecipe();
      }, []);
     
      console.log(tacoUserObject)

    return (
      <>
      <div>
        {
          tacoUserObject.isAdmin ?<>
          <Link to={`/editRecipe`} className="edit-recipe">
            <button className="button">Edit Recipe</button>
             </Link>
             </> 
             :<>
             
             </>
        }
      </div>

        <Card>

            <CardHeader><h3>{recipe.recipeName}</h3></CardHeader>
            <CardBody> 
                <CardTitle tag="h5">Recipe Basics:</CardTitle>
                <CardText> 
                  <div>Level: {recipe.level}</div>
                  <div>Prep Time: {recipe.prepTime}</div>
                  <div>Cook Time: {recipe.cookTime}</div>
                  <div>Total Time: {recipe.totalTime}</div>
                  <div>Serving Size: {recipe.servingSize}</div>
                  </CardText>
            </CardBody>
                <ListGroup flush> 
                  <div><CardImg className="card-image" src={recipe.recipeImage} alt="Recipe Image"/></div>
                  <ListGroupItem>Ingredients: {recipe.ingredients}</ListGroupItem>
                  <ListGroupItem>Directions: {recipe.directions}</ListGroupItem>
                </ListGroup>
            <CardBody>
                  <CardLink href="/recipes"> <h5 className="cardLinkText">View All Recipes</h5>  </CardLink>
            </CardBody>
        </Card>

    </>

    )
};

export default RecipeCard; 