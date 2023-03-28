using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models.Entities;

public partial class Todo
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool? IsComplated { get; set; }
}
