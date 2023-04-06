using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrtalaMatik.Models.Entities;

public partial class Lessons
{
    internal List<Lessons> lessons;

    public int Id { get; set; }

    [Required(ErrorMessage = "Boş bırakılamaz")]
    [StringLength(100)]
    public string LessonName { get; set; }

    [Required(ErrorMessage = "Boş bırakılamaz")]
    public int Note { get; set; }

    [Required(ErrorMessage = "Boş bırakılamaz")]

    public int Credit { get; set; }
}
