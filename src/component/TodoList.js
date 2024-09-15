/** @format */

import React, { useState, useEffect } from "react";
import axios from "axios";
import {
 TextField,
 Button,
 Grid,
 Card,
 CardContent,
 Typography,
 IconButton,
 Container,
 Select,
 MenuItem,
 FormControl,
 InputLabel,
} from "@mui/material";
import {
 Delete,
 Edit,
 Add,
 CheckCircle,
 List,
 Save,
} from "@mui/icons-material";

const TodoList = () => {
 const [todos, setTodos] = useState([]);
 const [newTask, setNewTask] = useState("");
 const [newTaskStatus, setNewTaskStatus] = useState("incomplete"); // Status for the new task
 const [editTaskId, setEditTaskId] = useState(null);
 const [editTask, setEditTask] = useState("");
 const [editTaskStatus, setEditTaskStatus] = useState(""); // Task status for editing
 const [filter, setFilter] = useState("all"); // "all", "completed", "incomplete"

 useEffect(() => {
  fetchTodos();
 }, []);

 const fetchTodos = async () => {
  try {
   const response = await axios.get("https://localhost:7128/api/todo", {
    headers: {
     "Content-Type": "application/json",
     Accept: "application/json",
    },
   });

   // Map IsComplete to status for frontend usage
   const mappedTodos = response.data.map((todo) => ({
    ...todo,
    status: todo.isComplete ? "completed" : "incomplete",
   }));

   setTodos(mappedTodos);
  } catch (error) {
   console.error("Error fetching todos:", error);
  }
 };

 const addTask = async () => {
  try {
   console.log("Task:", newTask);
   console.log("Status:", newTaskStatus);

   // Map status to isComplete
   const isComplete = newTaskStatus === "completed";

   await axios.post(
    "https://localhost:7128/api/todo",
    { task: newTask, isComplete },
    {
     headers: {
      "Content-Type": "application/json",
      Accept: "application/json",
     },
    },
   );
   setNewTask("");
   setNewTaskStatus("incomplete");
   fetchTodos();
  } catch (error) {
   console.error("Error adding task:", error);
  }
 };

 const editTaskSubmit = async (id) => {
  try {
   // Map status to isComplete
   const isComplete = editTaskStatus === "completed";

   await axios.put(
    `https://localhost:7128/api/todo/${id}`,
    { task: editTask, isComplete },
    {
     headers: {
      "Content-Type": "application/json",
      Accept: "application/json",
     },
    },
   );
   setEditTaskId(null);
   setEditTask("");
   setEditTaskStatus("");
   fetchTodos();
  } catch (error) {
   console.error("Error editing task:", error);
  }
 };

 const deleteTask = async (id) => {
  try {
   await axios.delete(`https://localhost:7128/api/todo/${id}`, {
    headers: {
     "Content-Type": "application/json",
     Accept: "application/json",
    },
   });
   fetchTodos();
  } catch (error) {
   console.error("Error deleting task:", error);
  }
 };

 const markComplete = async (id, isComplete) => {
  try {
   await axios.put(
    `https://localhost:7128/api/todo/${id}`,
    { isComplete: !isComplete },
    {
     headers: {
      "Content-Type": "application/json",
      Accept: "application/json",
     },
    },
   );
   fetchTodos();
  } catch (error) {
   console.error("Error updating completion status:", error);
  }
 };

 // Filtering todos based on selected status
 const filteredTodos =
  filter === "all"
   ? todos
   : filter === "completed"
   ? todos.filter((todo) => todo.isComplete)
   : todos.filter((todo) => !todo.isComplete);

 return (
  <Container>
   <Typography variant="h4" gutterBottom>
    To-Do List
   </Typography>
   <Grid container spacing={2} alignItems="center">
    <Grid item xs={12} sm={6}>
     <TextField
      fullWidth
      label="Add New Task"
      value={newTask}
      onChange={(e) => setNewTask(e.target.value)}
     />
    </Grid>
    <Grid item xs={12} sm={3}>
     <FormControl fullWidth>
      <InputLabel>Status</InputLabel>
      <Select
       value={newTaskStatus}
       label="Status"
       onChange={(e) => setNewTaskStatus(e.target.value)}
      >
       <MenuItem value="incomplete">Incomplete</MenuItem>
       <MenuItem value="completed">Completed</MenuItem>
      </Select>
     </FormControl>
    </Grid>
    <Grid item xs={12} sm={3}>
     <Button
      fullWidth
      startIcon={<Add />}
      variant="contained"
      color="success"
      onClick={addTask}
     >
      Add Task
     </Button>
    </Grid>
   </Grid>

   <FormControl sx={{ marginTop: 2, width: "100%", maxWidth: 300 }}>
    <InputLabel>Filter</InputLabel>
    <Select
     value={filter}
     label="Filter"
     onChange={(e) => setFilter(e.target.value)}
    >
     <MenuItem value="all">Show All Tasks</MenuItem>
     <MenuItem value="completed">Show Completed Tasks</MenuItem>
     <MenuItem value="incomplete">Show Incomplete Tasks</MenuItem>
    </Select>
   </FormControl>

   <Grid container spacing={2} sx={{ marginTop: 2 }}>
    {filteredTodos.map((todo) => (
     <Grid item xs={12} sm={6} md={4} key={todo.id}>
      <Card
       sx={{
        backgroundColor: todo.isComplete ? "#e0f7fa" : "#fff",
        border: todo.isComplete ? "1px solid green" : "none",
       }}
      >
       <CardContent>
        {editTaskId === todo.id ? (
         <>
          <TextField
           fullWidth
           value={editTask}
           onChange={(e) => setEditTask(e.target.value)}
           label="Edit Task"
          />
          <FormControl fullWidth sx={{ marginTop: 2 }}>
           <InputLabel>Status</InputLabel>
           <Select
            value={editTaskStatus}
            label="Status"
            onChange={(e) => setEditTaskStatus(e.target.value)}
           >
            <MenuItem value="incomplete">Incomplete</MenuItem>
            <MenuItem value="completed">Completed</MenuItem>
           </Select>
          </FormControl>
         </>
        ) : (
         <>
          <Typography
           variant="h6"
           style={{
            textDecoration: todo.isComplete ? "line-through" : "none",
           }}
          >
           {todo.task}
          </Typography>
          {todo.isComplete && (
           <Typography variant="caption" color="textSecondary">
            Completed
           </Typography>
          )}
         </>
        )}
       </CardContent>

       <Grid
        container
        justifyContent="space-around"
        alignItems="center"
        sx={{ paddingBottom: 1 }}
       >
        {editTaskId === todo.id ? (
         <IconButton color="success" onClick={() => editTaskSubmit(todo.id)}>
          <Save />
         </IconButton>
        ) : (
         <>
          {!todo.isComplete && (
           <>
            <IconButton
             color="primary"
             onClick={() => {
              setEditTaskId(todo.id);
              setEditTask(todo.task);
              setEditTaskStatus(todo.status); // This will be 'incomplete'
             }}
            >
             <Edit sx={{ color: "skyblue" }} />
            </IconButton>
            <IconButton color="error" onClick={() => deleteTask(todo.id)}>
             <Delete />
            </IconButton>
            <IconButton
             color="success"
             onClick={() => markComplete(todo.id, todo.isComplete)}
            >
             <CheckCircle />
            </IconButton>
           </>
          )}
         </>
        )}
       </Grid>
      </Card>
     </Grid>
    ))}
   </Grid>
  </Container>
 );
};

export default TodoList;
