import * as React from "react";
import Box from "@mui/material/Box";
import Drawer from "@mui/material/Drawer";
import AppBar from "@mui/material/AppBar";
import CssBaseline from "@mui/material/CssBaseline";
import Toolbar from "@mui/material/Toolbar";
import List from "@mui/material/List";
import Typography from "@mui/material/Typography";
import Divider from "@mui/material/Divider";
import ListItem from "@mui/material/ListItem";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import AccountBalanceRoundedIcon from "@mui/icons-material/AccountBalanceRounded";
import AdminPanelSettingsRoundedIcon from "@mui/icons-material/AdminPanelSettingsRounded";
import PeopleAltRoundedIcon from "@mui/icons-material/PeopleAltRounded";
import HistoryRoundedIcon from "@mui/icons-material/HistoryRounded";
import { Admin } from "../content/Admin";
import { History } from "../content/History";
import { Employees } from "../content/Employees";
import { Dependents } from "../content/Dependents";
import { Router, Route, Link } from "react-router-dom";
import { MenuItem, MenuList } from "@mui/material";
import { Benefits } from "../content/Benefits";

const drawerWidth = 240;

export default function MainPage() {
  return (
    <Box sx={{ display: "flex" }}>
      <CssBaseline />
      <AppBar
        style={{ backgroundColor: "#162244" }}
        position="fixed"
        sx={{ zIndex: (theme) => theme.zIndex.drawer + 1 }}
      >
        <Toolbar>
          <Typography variant="h6" noWrap component="div">
            Employee Manager
          </Typography>
        </Toolbar>
      </AppBar>
      <Drawer
        variant="permanent"
        sx={{
          width: drawerWidth,
          flexShrink: 0,
          [`& .MuiDrawer-paper`]: {
            width: drawerWidth,
            boxSizing: "border-box",
          },
        }}
      >
        <Toolbar />
        <Box sx={{ overflow: "auto" }}>
          <MenuList>
            {["Admin", "Benefits", "History"].map((text, index) => (
              <MenuItem key={index} component={Link} to={`/${text}`}>
                {index === 0 ? (
                  <AdminPanelSettingsRoundedIcon />
                ) : index === 1 ? (
                  <AccountBalanceRoundedIcon />
                ) : (
                  <HistoryRoundedIcon />
                )}
                <ListItemText primary={text} />
              </MenuItem>
            ))}
          </MenuList>
          <Divider />
          <MenuList>
            {["Employees", "Dependents"].map((text, index) => (
              <MenuItem key={index} component={Link} to={`/${text}`}>
                {index % 2 === 0 ? (
                  <PeopleAltRoundedIcon />
                ) : (
                  <PeopleAltRoundedIcon />
                )}

                <ListItemText primary={text} />
              </MenuItem>
            ))}
          </MenuList>
        </Box>
      </Drawer>
    </Box>
  );
}
