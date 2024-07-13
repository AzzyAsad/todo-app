import React from 'react';
import Moment from 'moment';
import "react-toastify/dist/ReactToastify.css";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash, faCheckCircle } from '@fortawesome/free-solid-svg-icons'

function TodoItem(props: any) {
    function updateTodo(id: number) {
        props.updateTodo(id)
    }

    function deleteTodo(id: number) {
        props.deleteTodo(id)
    }

    return (
        <div>
            {
                props.todos.length > 0 ?
                    props.todos.map((todo, index) => (
                        <li key={todo.id} className={`flex items-center justify-between border-b py-2 px-2 rounded my-2 ${props.status === "InProgress" && (new Date(todo.completeBy).toISOString().split('T')[0] < new Date().toISOString().split('T')[0]) ? "bg-red-200" : ""}`}>
                            <span className="break-all w-60">{todo.description}</span>
                            <span>{Moment(todo.completeBy).format('DD-MMM-YYYY')}</span>
                            {
                                props.status === "InProgress" ?
                                    <div>
                                        <button className="text-green-500 mr-3" onClick={() => updateTodo(todo.id)}><span><FontAwesomeIcon icon={faCheckCircle} size="lg" /></span></button>
                                        <button className="text-red-500" onClick={() => deleteTodo(todo.id)}><span><FontAwesomeIcon icon={faTrash} size="lg" /></span></button>
                                    </div> : ""
                            }
                        </li>
                    )) : <label>No todos to display.</label>
            }
        </div>
    );
}

export default TodoItem;
