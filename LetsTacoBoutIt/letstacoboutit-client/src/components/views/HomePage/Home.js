import React from "react";
import { Link } from "react-router-dom";

export const Home = () => {

    return (
        <>
        <div className="background">
          <h1 className="page-header"> Let's Taco 'Bout It </h1>
          <div>
            <p className="infoParagraph"> 
            <h3 className="paragraph-header"> Welcome to the Taco Lovers Website!!</h3>
              <p>
                Are you tired of the same old American-style tacos with their crunchy shell and yellow cheese? Do you crave the idea of trying out some different types of Mexican tacos?
                Well, you are in good luck! We headed south of the border to learn about as many authentic Mexican tacos as we could eat just so you never have to eat a mediocre taco again. 
              </p>
              <p>
                Now, when you head to Mexico on your next trip, skip the resort buffet or the touristy restaurant and head to the streets to eat as many different types of tacos in Mexico as you can stomach.
              </p>
            </p>

        <div> 
            <h3 className="paragraph-header"> History of the Taco </h3>
              <p>The taco as we know it today is a blend of ancient Mexican recipes and International influences. However, before it was known in America, natives in Mexico were eating a version that looked quite different.</p>
              <p>Where did America’s favorite comfort food originate? Here’s the history of one of the best foods on the planet.</p>  
              <p>Tacos are thought to come from Mexico, long before the Spanish arrived. Ancient Mexicans used freshly made, soft, flat corn tortillas and gave them with fillings like fish and cooked organs. It was a staple meal that provided vital nutrients and energy to those who consumed it.</p>  
              <p>These tacos didn’t contain the cheese, lettuce, sour cream, and tomato that we associate with the meal today. In fact, the taco as we know it is less than 100 years old.</p>  
        </div>
            
        <div className= "CategoryBox">
              <div className="type-Box">FIND TACO RECIPES</div>
              <div className="type-Box">BUY TACO MERCH</div>
              <div className="type-Box">FIND THE BEST TACO LOCATIONS</div>
        </div>
     </div>

  
        </div>


        
      </>


      );

};
