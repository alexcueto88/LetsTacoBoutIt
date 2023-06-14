import React from "react";
import { logout } from "../helpers/logout";
import { useNavigate } from "react-router-dom";


export const NavBar = () => {
  
  const navigate = useNavigate();
  const onLogout = () => {
    logout.logout(navigate);
  };


    return(
        <nav class="navbar navbar-expand-lg bg-body-tertiary">
  <div class="container-fluid">
    <a class="navbar-brand" href="/">Let's Taco 'Bout It!</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNavDropdown">
      <ul class="navbar-nav">

{/* *** HOME BUTTON *** */}        
        {/* <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="/home">Home</a>
        </li> */}


{/* *** RECIPE BUTTON *** */}        
<li class="nav-item">
          <a class="nav-link active" aria-current="page" href="/Recipes">Recipes</a>
        </li>


{/* *** HOW CAN WE GET THIS BUTTON TO WORK?? *** */}
        {/* <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
            Recipes
          </a>
          <ul class="dropdown-menu">
            <li><a class="dropdown-item" href="#">Action</a></li>
            <li><a class="dropdown-item" href="#">Another action</a></li>
            <li><a class="dropdown-item" href="#">Something else here</a></li>
          </ul>
        </li> */}
        
{/* *** MERCHANDISE BUTTON *** */}
        <li class="nav-item">
          <a class="nav-link" href="/merchandise">Merchandise</a>
        </li>


{/* *** LOCATIONS BUTTON *** */}
        <li class="nav-item">
          <a class="nav-link" href="/locations">Locations</a>
        </li>

{/* *** LOG OUT BUTTON *** */}        
<li class="nav-item">
          <a onClick={onLogout} class="nav-link" aria-current="page" href="/login">Log Out</a>
        </li>



      </ul>

    </div>
  </div>
</nav>






    )
}