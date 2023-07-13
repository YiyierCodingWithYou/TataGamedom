const submitForm = document.querySelector('.add');
const addButton = document.querySelector('.add-todo');
const todoList = document.querySelector('.todos');
const dayTitle = document.querySelector('#dayName');

const lang = navigator.language;

let date = new Date();

let dayName = date.toLocaleString(lang, {
    weekday: 'long',
});

dayTitle.innerHTML = dayName;

let todos = []; // 存储待办事项的数组

const generateTemplate = (todo) => {
    const html = `<li>
                  <input type="checkbox">
                  <label>
                    <span class="check"></span>
                    ${todo}
                  </label>
                  <i class="fas fa-paw delete"></i>
                </li>`;
    todoList.innerHTML += html;
};

window.addEventListener('DOMContentLoaded', () => {
    todos = JSON.parse(localStorage.getItem('todos')) || [];
    todos.forEach((todo) => {
        generateTemplate(todo);
    });
});

function addTodo(e) {
    e.preventDefault();
    const todo = submitForm.add.value.trim();
    if (todo.length) {
        todos.push(todo);
        generateTemplate(todo);
        localStorage.setItem('todos', JSON.stringify(todos));
        submitForm.reset();
    }
}

submitForm.addEventListener('submit', addTodo);
addButton.addEventListener('click', addTodo);

function deleteTodo() {
    if (event.target.classList.contains('delete')) {
        const todoItem = event.target.parentElement;
        const todo = todoItem.querySelector('label').innerText;
        todos = todos.filter((item) => item !== todo);
        localStorage.setItem('todos', JSON.stringify(todos));
        todoItem.remove();
    }
}

todoList.addEventListener('click', deleteTodo);

const clearButton = document.querySelector('.clear-button');

function clearTodos() {
    todoList.innerHTML = '';
    localStorage.removeItem('todos');
    todos = [];
}

//clearButton.addEventListener('click', clearTodos);

$('#tataImg').on('click', function () {
    console.log('Hi!');
    $('.todoList').toggleClass('hidetodo');
});
