import { Routes, Route, Outlet, useNavigate } from "react-router-dom";
import { logout } from "../helpers/logout";
import { PhotoUpload } from "../photoStorage/PhotoUpload";
import { Home } from "./HomePage/Home";
import { Locations } from "./Locations/Locations";


export const ApplicationViews = () => {
  let navigate = useNavigate();

  // Move this to where ever you end up putting your logout button
  const onLogout = () => {
    logout.logout(navigate);
  };
  
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
        <Route path="Home" element={<Home />} /> 
        <Route path="Locations" element={<Locations />} /> 


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