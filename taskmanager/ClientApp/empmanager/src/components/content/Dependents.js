import {
  Autocomplete,
  Box,
  Button,
  CircularProgress,
  Container,
  Divider,
  Paper,
  TextField,
  Toolbar,
  Typography,
} from "@mui/material";
import React from "react";
import { useEffect, useState } from "react";
import { EditDependent } from "./EditDependent";
import SendIcon from "@mui/icons-material/Send";
import AddIcon from "@mui/icons-material/Add";
import { gridNumberComparator } from "@mui/x-data-grid";

export const Dependents = (params) => {
  const [open, setOpen] = useState(false);
  const [options, setOptions] = useState([]);
  const loading = open && options.length === 0;
  const types = ["Spouse", "Child"];
  const [value, setValue] = React.useState(types[0]);
  const [inputValue, setInputValue] = useState("");
  const [name, setName] = useState("");
  const [form, setFrom] = useState({
    id: Number,
    name: String,
    type: String,
    empkey: Number,
  });
  const [dependents, setDependents] = useState([
    { id: Number, name: String, type: String },
  ]);

  useEffect(() => {
    let active = true;

    if (!loading) {
      return undefined;
    }

    (async () => {
      let data = populateDependentData();
      let arr = [...data];
      let options = arr.map((e) => {
        return e.empName;
      });
      let names = options.filter((v, i) => options.indexOf(v) === i);
      if (active) {
        setOptions(names);
      }
    })();

    return () => {
      active = false;
    };
  }, [loading]);

  useEffect(() => {
    if (!open) {
      setOptions([]);
    }
  }, [open]);

  useEffect(() => {
    populateDependentData();
  }, []);

  const populateDependentData = () => {
    const emps = params.props;
    let deps = [];
    for (let i = 0; i < emps.length; i++) {
      let obj = {
        empid: Number,
        empName: String,
        depId: Number,
        empKey: Number,
        depName: String,
        type: String,
      };
      const e = emps[i];
      if (emps[i].dependents.length !== 0) {
        for (let j = 0; j < emps[j].dependents.length; j++) {
          const k = emps[i].dependents[j];
          obj.empid = e.id;
          obj.empName = e.name;
          obj.empKey = e.id;
          obj.depId = k.id;
          obj.depName = k.name;
          obj.type = k.type;
          deps.push(obj);
          obj = {};
        }
      } else {
        obj.empid = e.id;
        obj.empName = e.name;
        obj.empKey = e.id;
        deps.push(obj);
        obj = {};
      }
    }

    return deps;
  };

  const displayDependentData = (e, v) => {
    setDependents([]);

    const emps = populateDependentData();
    const deps = emps.filter((x) => x.empName === v);
    const depstypes = deps.map((e) => {
      return { id: e.depId, name: e.depName, type: e.type };
    });
    setDependents(depstypes);
    let empid = deps.find((e) => true).empid;
    setFrom({ empKey: empid });
    return depstypes;
  };
  const handleOnAddClick = () => {
    let obj = { ...form, name: name, type: inputValue };
    let newt = {
      id: obj.empKey,
      name: obj.name,
      type: inputValue,
    };
    setDependents([...dependents, newt]);
  };

  return (
    <Paper elevation={3} style={{ width: "800px" }}>
      <Container maxWidth="xl">
        <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
          <Typography variant="h4" gutterBottom component="div">
            Add Dependents for an Employee
          </Typography>
          <form>
            <Autocomplete
              id="employees"
              sx={{ width: 300 }}
              open={open}
              onOpen={() => {
                setOpen(true);
              }}
              onClose={() => {
                setOpen(false);
              }}
              onChange={(e, v) => displayDependentData(e, v)}
              isOptionEqualToValue={(option, value) =>
                option.title === value.title
              }
              getOptionLabel={(option) => option}
              options={options}
              loading={loading}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label="Select Employee"
                  InputProps={{
                    ...params.InputProps,
                    endAdornment: (
                      <React.Fragment>
                        {loading ? (
                          <CircularProgress color="inherit" size={20} />
                        ) : null}
                        {params.InputProps.endAdornment}
                      </React.Fragment>
                    ),
                  }}
                />
              )}
            />
            <br />

            <Autocomplete
              value={value}
              onChange={(e, v) => {
                setInputValue(v);
              }}
              inputValue={inputValue}
              id="controllable-states-demo"
              options={types}
              sx={{ width: 300 }}
              renderInput={(params) => (
                <TextField {...params} label="Dependent Type" />
              )}
            />

            <br />
            <div style={{ textAlign: "left" }}>
              <TextField
                id="name"
                label="Name"
                variant="outlined"
                sx={{ width: 300 }}
                value={name}
                onChange={(e, v) => {
                  setName(e.target.value);
                }}
              />

              <Button
                variant="contained"
                endIcon={<AddIcon />}
                style={{ backgroundColor: "#162244", margin: "10px" }}
                onClick={handleOnAddClick}
              >
                Add
              </Button>
            </div>
          </form>
        </Box>
      </Container>
      <EditDependent props={dependents} />
    </Paper>
  );
};
