import { Routes, Route, Outlet, useNavigate } from "react-router-dom";
import { logout } from "../helpers/logout";
import { PhotoUpload } from "../photoStorage/PhotoUpload";
import { Home } from "./HomePage/Home";
import { Locations } from "./Locations/Locations";
import { Merchandise } from "./MerchandisePage/MerchPage";
import { Recipes } from "./RecipesPage/RecipesPage";
import RecipeCard from "./RecipesPage/RecipeCard";
import { EditRecipe } from "./RecipesPage/EditRecipe";
import { AddRecipe } from "./RecipesPage/AddRecipe";


export const ApplicationViews = () => {
  let navigate = useNavigate();

  
  return (
    
    <Routes>
      <Route
        path="/"
        element={
          <>
            <Outlet />
          </>
        }
      >
        <Route path="/" element={<Home />} /> 
        <Route path="Recipes" element={<Recipes />} />
        <Route path="Merchandise" element={<Merchandise/>} /> 
        <Route path="Locations" element={<Locations />} /> 
        <Route path="Recipe/:id" element={<RecipeCard />} /> 
        <Route path="EditRecipe/:id" element={<EditRecipe/>} /> 
        <Route path="AddRecipe" element={<AddRecipe/>}/>




      </Route>
    </Routes>


    // <>
    //   <h1>A Blank Page!!</h1>
    //   {/* logout button */}
    //   <button type="submit" onClick={onLogout}>
    //     Logout
    //   </button>
    //   {/* move this component to where you want your PhotoUpload */}
    //   <PhotoUpload />
    // </>
  );
};