import React, { useState } from 'react';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

function TodoAdd(props: any) {
    const [inputText, setInputText] = useState("");
    const [startDate, setStartDate] = useState(new Date());

    function addTodo() {
        setInputText("");
        props.addTodo(inputText, startDate)
    }

    return (
        <div className="flex justify-center mb-4">
            <input type="text" value={inputText} placeholder="Add new todo item" className="border-gray-300 border rounded-l px-4 py-2" onChange={(e) => setInputText(e.target.value)} />
            <DatePicker className="border-gray-300 border px-4 py-2" selected={startDate} onChange={(date) => date && setStartDate(date)} />
            <button className="bg-blue-500 text-white px-4 py-2 rounded-r" onClick={() => addTodo()}>Add</button>
        </div>
    );
}

export default TodoAdd;
