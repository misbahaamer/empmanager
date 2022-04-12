import logo from "./logo.svg";
import "./App.css";
import MainPage from "./components/nav/MainPage";
import MainContent from "./components/content/MainContent";
import Box from "@mui/material/Box";
import { Switch, Toolbar } from "@mui/material";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { Admin } from "./components/content/Admin";
import { Benefits } from "./components/content/Benefits";
import { History } from "./components/content/History";
import { Employees } from "./components/content/Employees";
import { Dependents } from "./components/content/Dependents";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Router>
          <MainPage />
          <Routes>
            <Route path="/Admin" element={<Admin />}></Route>
            <Route path="/Benefits" element={<Benefits />}></Route>
            <Route path="/History" element={<History />}></Route>
            <Route path="/Employees" element={<Employees />}></Route>
            <Route path="/Dependents" element={<Dependents />}></Route>
          </Routes>
        </Router>
      </header>
    </div>
  );
}

export default App;
