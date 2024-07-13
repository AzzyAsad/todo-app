import React, { useState } from 'react';
import axios from 'axios';
import { ToastContainer } from 'react-toastify';
import "react-toastify/dist/ReactToastify.css";
import TodoAdd from './TodoAdd';
import TodoItem from './TodoItem';
import { TodoItemModel } from '../models/TodoItemModel';
import ToastService from '../services/ToastService';


export default function TodoList(props: any) {
    const [todos, setTodos] = useState<TodoItemModel[]>([]);
    const baseURL = "https://localhost:7027";

    function getAllTodos() {
        axios.get(`${baseURL}/TodoItems`).then((response) => {
            if (response.status === 200) {
                setTodos(response.data);
            } else {
                ToastService.showErrorToast("An error occurred while fetching todos. Please try again later.");
            }
        }).catch((error) => {
            ToastService.showErrorToast(error.message);
        });
    }

    React.useEffect(() => {
        getAllTodos();
    }, []);

    function addTodo(inputText: string, startDate: Date) {
        if (inputText.trim().length < 11) {
            ToastService.showErrorToast('The tasks must be longer than 10 characters.');
        } else {
            axios.post(`${baseURL}/TodoItem`, {
                "description": inputText,
                "completeBy": startDate
            }).then((response) => {
                if (response.status === 200) {
                    ToastService.showSuccessToast('Todo item added successfully.');
                    getAllTodos();
                } else {
                    ToastService.showErrorToast("An error occurred while saving todo. Please try again later.");
                }
            }).catch((error) => {
                ToastService.showErrorToast(error.response.data);
            });
        }
    }

    function deleteTodo(id: number) {
        axios.delete(`${baseURL}/TodoItem/${id}`).then((response) => {
            if (response.status === 204) {
                ToastService.showSuccessToast('Todo item deleted successfully.');
                getAllTodos();
            } else {
                ToastService.showErrorToast("An error occurred while deleting todo. Please try again later.");
            }
        }).catch((error) => {
            ToastService.showErrorToast(error.response.data);
        });
    };

    function updateTodo(id: number) {
        axios.put(`${baseURL}/TodoItem/${id}`, {
            "completedOn": new Date()
        }).then((response) => {
            if (response.status === 200) {
                ToastService.showSuccessToast('Todo item updated successfully.');
                getAllTodos();
            } else {
                ToastService.showErrorToast("An error occurred while updating todo. Please try again later.");
            }
        }).catch((error) => {
            ToastService.showErrorToast(error.response.data);
        });
    };

    return (
        <div className="">
            <ToastContainer />

            <h2 className="flex text-2xl justify-center font-bold mb-4 mt-10">Todo App using React & .NET APIs</h2>

            <TodoAdd addTodo={addTodo}></TodoAdd>

            <div className="mt-12 w-full">
                <h2 className="flex text-l justify-center font-bold mb-4">Todo items that are in progress</h2>
                <ul>
                    <li className="flex items-center justify-between border-b py-2 text-xl">
                        <span className="w-60">Description</span>
                        <span>Complete By</span>
                        <span>Actions</span>
                    </li>
                    <TodoItem todos={todos.filter(x => x.status === "In Progress")} updateTodo={updateTodo} deleteTodo={deleteTodo} status={"InProgress"}></TodoItem>
                </ul>
            </div>

            <div className="mt-12">
                <h2 className="flex text-l justify-center font-bold mb-4">Todo items that are completed</h2>
                <ul>
                    <li className="flex items-center justify-between border-b py-2 text-xl">
                        <span className="w-60">Description</span>
                        <span>Complete On</span>
                    </li>
                    <TodoItem todos={todos.filter(x => x.status === "Completed")} status={"Completed"}></TodoItem>
                </ul>
            </div>
        </div>
    );
}