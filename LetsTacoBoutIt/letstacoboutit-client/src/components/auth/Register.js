import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { googleAuth } from "../helpers/googleAuth";
import { emailAuth } from "../helpers/emailAuth";
import "./Login.css";

export const Register = () => {
  const [user, setUser] = useState({
    Name: "",
    LastName: "",
    Email: "",
    Password: "",
    IsAdmin: false,
  });
  let navigate = useNavigate();

  // Register with email and password
  const handleRegister = async (e) => {
    e.preventDefault();
    emailAuth.register(user, navigate);
  };

  const updateUser = (evt) => {
    const copy = { ...user };
    copy[evt.target.id] = evt.target.value;
    setUser(copy);
  };

  // Register with google (same as sign in)
  const onSubmitLogin = async () => {
    googleAuth.signInRegister(navigate);
  };

  return (
    <main style={{ textAlign: "center" }}>
      <form className="form--login" onSubmit={handleRegister}>
        <h1 className="h3 mb-3 font-weight-normal">Please Register</h1>
        <fieldset>
          <label htmlFor="firstName"> First Name </label>
          <input
            onChange={updateUser}
            type="text"
            id="firstName"
            className="form-control"
            placeholder="Enter your First Name"
            required
            autoFocus
          />
        </fieldset>

        <fieldset>
          <label htmlFor="lastName"> Last Name </label>
          <input
            onChange={updateUser}
            type="text"
            id="lastName"
            className="form-control"
            placeholder="Enter your Last Name"
            required
            autoFocus
          />
        </fieldset>

        <fieldset>
          <label htmlFor="email"> Email address </label>
          <input
            onChange={updateUser}
            type="email"
            id="email"
            className="form-control"
            placeholder="Email address"
            required
          />
        </fieldset>
        <fieldset>
          <label htmlFor="password"> Password </label>
          <input
            onChange={updateUser}
            type="text"
            id="password"
            className="form-control"
            placeholder="Must Be 6 Characters"
            required
            autoFocus
          />
        </fieldset>

        <fieldset>
          <input
            onChange={(evt) => {
              const copy = { ...user };
              copy.IsAdmin = evt.target.checked;
              setUser(copy);
            }}
            type="checkbox"
            id="isAdmin"
          />
          <label htmlFor="userType"> Admin </label>
        </fieldset>

        <fieldset>
          <button type="submit"> Register </button>
        </fieldset>
      </form>
      <h2>Register With Google?</h2>
      <button type="submit" onClick={onSubmitLogin}>
        Let's Do It!
      </button>
    </main>
  );
};