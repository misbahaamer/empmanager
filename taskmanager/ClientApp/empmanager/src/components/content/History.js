import * as React from "react";
import PropTypes from "prop-types";
import Box from "@mui/material/Box";
import Collapse from "@mui/material/Collapse";
import IconButton from "@mui/material/IconButton";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Typography from "@mui/material/Typography";
import Paper from "@mui/material/Paper";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import KeyboardArrowUpIcon from "@mui/icons-material/KeyboardArrowUp";
import Toolbar from "@mui/material/Toolbar";
import { useEffect, useState } from "react";
import { Breakdown } from "./Breakdown";

const payrollApi = "https://localhost:3867/api/v1/Employee/GetPayrolls";

export function History() {
  const [rows, setRows] = useState([
    {
      id: Number,
      employeeName: String,
      salary: Number,
      payDate: Date,
      takeHome: Number,
      breakDowns: [
        {
          date: Date,
          type: "string",
          count: Number,
          deduction: Number,
        },
      ],
    },
  ]);

  useEffect(() => {
    createData();
    //Row(rows);
  }, []);

  const createData = async () => {
    const data = await fetch(payrollApi);
    const res = await data.json();
    setRows(res);
    return res;
  };

  return (
    <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
      <Toolbar />
      <TableContainer component={Paper}>
        <Table aria-label="collapsible table">
          <TableHead>
            <TableRow>
              <TableCell />
              <TableCell>Employee Id</TableCell>
              <TableCell align="right">Name</TableCell>
              <TableCell align="right">Salary</TableCell>
              <TableCell align="right">Take Home</TableCell>
              <TableCell align="right">Pay Date</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {rows.map((row) => (
              <Breakdown rows={row} />
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
}
