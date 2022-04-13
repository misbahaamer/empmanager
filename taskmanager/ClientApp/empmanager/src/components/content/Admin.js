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
import { gridTopLevelRowCountSelector } from "@mui/x-data-grid";
import AddIcon from "@mui/icons-material/Add";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { CalendarPickerSkeleton } from "@mui/x-date-pickers/CalendarPickerSkeleton";
import { PickersDay } from "@mui/x-date-pickers/PickersDay/PickersDay";
import { EditDependent } from "./EditDependent";

export function Admin(params) {
  const props = params.props;
  const initialValue = new Date();

  const requestAbortController = React.useRef(null);
  const [isLoading, setIsLoading] = React.useState(false);
  const [highlightedDays, setHighlightedDays] = React.useState([1, 2, 15]);
  const [selectedDate, setSelectedDate] = React.useState(initialValue);
  const [open, setOpen] = useState(false);
  const [options, setOptions] = useState([]);
  const [dateValue, setDateValue] = useState([]);
  const [dependents, setDependents] = useState([
    { id: Number, name: String, type: String, cost: String },
  ]);

  const [form, setFrom] = useState({
    id: Number,
    name: String,
    type: String,
    empKey: Number,
    date: Date,
  });
  const [ebReqRes, setEbReqRes] = useState({
    id: Number,
    employeeKey: Number,
    benefitKey: Number,
    employeeCost: String,
    dependentCost: String,
    totalCost: String,
  });

  const loading = open && options.length === 0;

  const handleMonthChange = (date) => {
    if (requestAbortController.current) {
      // make sure that you are aborting useless requests
      // because it is possible to switch between months pretty quickly
      requestAbortController.current.abort();
    }

    setIsLoading(true);
    setHighlightedDays([]);
  };

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

  const displayDependentData = (e, v) => {
    setDependents([]);
    setFrom({});

    const emps = populateDependentData();
    const deps = emps.filter((x) => x.empName === v);
    const depstypes = deps.map((e) => {
      return { id: e.depId, name: e.depName, type: e.type };
    });
    setDependents(depstypes);
    let empid = deps.find((e) => true).empid;
    setFrom({ id: empid, empKey: empid });
    return depstypes;
  };

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

  const disableWeekends = (date) => {
    let date1 = new Date("01/01/2022");
    var date2 = date;
    const diffTime = Math.abs(date2 - date1);
    const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
    return diffDays % 14;
  };

  const handleCreatePayrollClick = () => {
    let obj = { ...form, date: dateValue };
  };

  return (
    <Paper elevation={3} style={{ width: "1100px" }}>
      <Container maxWidth="xl">
        <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
          <Typography variant="h4" gutterBottom component="div">
            Create Payroll for an Employee
          </Typography>
          <form>
            <div style={{ display: "flex" }}>
              <Autocomplete
                id="employees"
                sx={{ width: 300, marginRight: "10px" }}
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
                renderInput={(params) => (
                  <TextField
                    {...params}
                    label="Select Employee"
                    InputProps={{
                      ...params.InputProps,
                      endAdornment: (
                        <React.Fragment>
                          {true ? (
                            <CircularProgress color="inherit" size={20} />
                          ) : null}
                          {params.InputProps.endAdornment}
                        </React.Fragment>
                      ),
                    }}
                  />
                )}
              />
              <LocalizationProvider dateAdapter={AdapterDateFns}>
                <DatePicker
                  value={dateValue}
                  //loading={isLoading}
                  onChange={(newValue) => {
                    setDateValue(newValue);
                  }}
                  minDate={new Date("01/01/2022")}
                  maxDate={new Date("12/01/2022")}
                  shouldDisableDate={disableWeekends}
                  onMonthChange={handleMonthChange}
                  renderInput={(params) => <TextField {...params} />}
                  // renderLoading={() => <CalendarPickerSkeleton />}
                  renderDay={(day, _value, DayComponentProps) => {
                    const isSelected =
                      !DayComponentProps.outsideCurrentMonth &&
                      highlightedDays.indexOf(day.getDate()) > 0;

                    return <PickersDay {...DayComponentProps} />;
                  }}
                />
              </LocalizationProvider>
            </div>

            <br />
            <div style={{ textAlign: "left" }}>
              <Button
                variant="contained"
                endIcon={<AddIcon />}
                style={{ backgroundColor: "#162244", margin: "10px" }}
                onClick={handleCreatePayrollClick}
              >
                Calculate Payroll
              </Button>
            </div>
          </form>
        </Box>
      </Container>
      <EditDependent props={dependents} />
    </Paper>
  );
}
