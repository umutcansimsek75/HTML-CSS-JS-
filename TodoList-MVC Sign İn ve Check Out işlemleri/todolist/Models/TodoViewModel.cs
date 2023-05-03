
using TodoList.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models;

public class TodoViewModel
{
    [Required(ErrorMessage="Lütfen boş geçmeyiniz!")]

    public string? Title { get; set; }
    public IEnumerable<Todo>? Todos { get; set;}


    [Required(ErrorMessage="Lütfen boş geçmeyiniz!")]
    public string? Username { get; set; }

     [Required(ErrorMessage="Lütfen boş geçmeyiniz!")]
    public string? Password { get; set; }


    public IEnumerable<Todo>? Users { get; set;}



}
