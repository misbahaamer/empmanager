import logo from "./logo.svg";
import "./App.css";
import MainPage from "./components/nav/MainPage";

import Box from "@mui/material/Box";
import { Switch, Toolbar } from "@mui/material";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { Admin } from "./components/content/Admin";
import { Benefits } from "./components/content/Benefits";
import { History } from "./components/content/History";
import { Employees } from "./components/content/Employees";
import { Dependents } from "./components/content/Dependents";
import React, { useEffect, useState } from "react";

function App() {
  const employeesApi = "https://localhost:3867/api/v1/Employee";

  const [employees, setEmployees] = useState([]);
 

  useEffect(() => {
    getEmployees();
  }, []);

  const getEmployees = async () => {
    const data = await fetch(employeesApi);
    const res = await data.json();
    setEmployees(res);
    return res;
  };

  return (
    <div className="App">
      <header className="App-header">
        <Router>
          <MainPage />
          <Routes>
            <Route path="/Admin" element={<Admin props={employees} />}></Route>
            <Route path="/Benefits" element={<Benefits />}></Route>
            <Route path="/History" element={<History />}></Route>
            <Route
              path="/Employees"
              element={<Employees props={employees} />}
            ></Route>
            <Route
              path="/Dependents"
              element={<Dependents props={employees} />}
            ></Route>
          </Routes>
        </Router>
      </header>
    </div>
  );
}

export default App;
