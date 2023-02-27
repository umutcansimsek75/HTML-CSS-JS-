$(function() {
    // console.log("Hello world")
    var todolist = [
        { id: 1, title: "Erken kalk", isComplated: false },
        { id: 2, title: "Erken uyu", isComplated: true },
        { id: 3, title: "Çok çalış", isComplated: false },
    ];
    createListView();

    function createListView() {
        var ul = document.getElementById("list");
        $(ul).empty();
        // ul.empty();
        for (let index = 0; index < todolist.length; index++) {
            const element = todolist[index];

            var li = document.createElement("li");
            if (element.isComplated) {
                li.className = "list-group-item list-group-item-danger m-1 text-decoration-line-through";
            } else {
                li.className = "list-group-item list-group-item-success m-1";
            }
            var attr = document.createAttribute("id");
            attr.value = element.id;
            li.setAttributeNode(attr);
            var title = document.createTextNode(element.title);
            li.appendChild(title);
            var btnClose = document.createElement("button");
            btnClose.className = "btn-close float-end";
            li.appendChild(btnClose);
            ul.appendChild(li);
        }
        clickLi();
        clickBtnClose();
    }

    function clickLi() {
        $("li").click(function() {
            var btn = $(this);
            var id = btn.attr("id");
            updateTodo(id);
            createListView();
        })
    }

    function updateTodo(id) {
        var newTodoList = [];
        todolist.map((element => {
            if (element.id == id) {
                element.isComplated = !element.isComplated;
            }
            newTodoList.push(element);

        }));
        todolist = newTodoList;
        console.log(todolist);

    }

    function clickBtnClose() {
        $(".btn-close").click(function() {
            var btn = $(this);
            var id = btn.parent().attr("id");
            deleteTodo(id);

        })
    }

    function deleteTodo(id) {
        var newTodoList = [];
        todolist.map((element => {
            if (element.id != id) {
                newTodoList.push(element);
            }
        }));
        todolist = newTodoList;
        createListView();
    }

    $("#btnAdd").click(function() {
        var txtTitle = $("#txtTitle");

        var title = $("#txtTitle").val();
        lastId = 1;
        if (todolist.length > 0) {
            lastId = (todolist.length) + 1; //lastId = todolist[todolist.length - 1].id + 1;
        }
        if (title != "") {
            var data = {
                id: lastId,
                title: title,
                isComplated: false,
            }
            todolist.push(data)
            console.log(todolist);
            createListView();
            title = ("");
        } else {
            alert("Lütfen başlık girin.");
            txtTitle.focus();
        }
    })

})