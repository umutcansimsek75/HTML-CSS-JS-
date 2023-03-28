
using TodoList.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models;

public class TodoViewModel
{
    [Required(ErrorMessage="Lütfen boş geçmeyiniz!")]

    public string? Title { get; set; }
    public IEnumerable<Todo>? Todos { get; set;}


}
