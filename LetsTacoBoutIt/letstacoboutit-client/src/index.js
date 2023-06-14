import { LetsTacoBoutIt } from "./components/LetsTacoBoutIt";
import { createRoot } from "react-dom/client";
import "./index.css";
import { BrowserRouter } from "react-router-dom";
import firebase from "firebase/compat/app"; // Import Firebase!!
import { firebaseConfig } from "./apiKeys"; // Import Your Config!!
import "bootstrap/dist/css/bootstrap.min.css";



firebase.initializeApp(firebaseConfig);

const container = document.getElementById("root");
const root = createRoot(container);
root.render(
  <BrowserRouter>
    <LetsTacoBoutIt />
  </BrowserRouter>
);