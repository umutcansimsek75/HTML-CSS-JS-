//console.log("Hello JQuery")
$(function(){
    //console.log("Hello JQuery")
    var todoList=[
        {id:1, title:"Yemek Ye", isComplated:false},
        {id:2, title:"Erken Uyan", isComplated:true},
       
    ];

    createListView();

    
 
     function clickBtnClose() {
           $(".btn-close").click(function () {
        var btn=$(this);
        //console.log(obj);
        var id=btn.parent().attr("id");
         deleteTodo(id);
         btn.parent().remove();
         console.log();
        
    })
    function deleteTodo(id) {
        var newTodoList=[];
        todoList.map((element)=>{
            if (element.id!=id){
                newTodoList.push(element);
            }
        });
        todoList=newTodoList;
        
    }
        
     }




     function clickLi() {
        $("li").click(function () {
     var btn=$(this);
     var id=btn.attr("id");
      updateTodo(id);
      
      console.log();
     createListView();
 })
 function updateTodo(id) {
     var newTodoList=[];
     todoList.map((element)=>{
         if (element.id==id){
            
           element.isComplated= !element.isComplated;
         }
         newTodoList.push(element);
     });
     todoList=newTodoList;
     
 }
     
  }
    $("#btnAdd").click(function(){
        //console.log("btnAdd tıklandı!");

        var txtTitle=$("#txtTitle");
        var title=txtTitle.val();
        //console.log("title");

        if (title!="") {

            var id=1;

            if (todoList.length>0) {
                id=todoList[todoList.length-1].id+1;
            }
            var data={
                id:id,
                title:title,
                isComplated:false
            }

            todoList.push(data);
            txtTitle.val("");
            txtTitle.focus();
            createListView();
        } else {
            alert("Lütfen başlık giriniz!");
            txtTitle.focus();
        }

       
    });

    function createListView() {
        $("#list").empty();
        var ul=document.getElementById("list");
       

        for (let index = 0; index < todoList.length; index++) {
            const element = todoList[index];

            var li=document.createElement("li");


            if (element.isComplated) {
                li.className="list-group-item list-group-item-danger text-decoration-line-through m-1";
            }else{
            li.className="list-group-item list-group-item-success m-1";
                
            }
            
            var attr=document.createAttribute("id");

            attr.value=element.id;

            li.setAttributeNode(attr);

            var title=document.createTextNode(element.title);
            li.appendChild(title);

            var btnClose=document.createElement("button");
            btnClose.className="btn-close";
            li.appendChild(btnClose);
            ul.appendChild(li);
           
        }
         clickLi();
        clickBtnClose();
       
    }
})