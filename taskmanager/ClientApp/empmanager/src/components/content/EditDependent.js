import * as React from "react";
import { styled } from "@mui/material/styles";
import Box from "@mui/material/Box";
import { DataGrid } from "@mui/x-data-grid";

const StyledBox = styled(Box)(({ theme }) => ({
  height: 300,
  width: "100%",
  "& .MuiDataGrid-cell--editing": {
    backgroundColor: "rgb(255,215,115, 0.19)",
    color: "#1a3e72",
    "& .MuiInputBase-root": {
      height: "100%",
    },
  },
  "& .Mui-error": {
    backgroundColor: `rgb(126,10,15, ${
      theme.palette.mode === "dark" ? 0 : 0.1
    })`,
    color: theme.palette.error.main,
  },
}));

export const EditDependent = (props) => {
  const rows = props;

  const columns = [
    { field: "name", headerName: "Name", width: 160, editable: true },

    {
      field: "type",
      headerName: "Type",
      type: "singleSelect",
      valueOptions: ["Spouse", "Child"],
      width: 160,
      editable: true,
      preProcessEditCellProps: (params) => {
        const isPaidProps = params.otherFieldsProps.isPaid;
        const hasError = isPaidProps.value && !params.props.value;
        return { ...params.props, error: hasError };
      },
    },
  ];

  return (
    <StyledBox>
      <DataGrid
        rows={rows}
        columns={columns}
        editMode="row"
        experimentalFeatures={{ newEditingApi: true }}
      />
    </StyledBox>
  );
};
