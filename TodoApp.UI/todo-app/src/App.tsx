import React, { useEffect } from 'react';
import './App.css';
import TodoList from './components/TodoList';

function App() {
    useEffect(() => {
        document.title = "Todo App"
    }, []);

    return (
        <div className="flex w-full justify-center">
            <TodoList />
        </div>
    );
}

export default App;
