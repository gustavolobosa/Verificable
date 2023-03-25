using System;
using System.Collections.Generic;

namespace Proyecto_Verificable.Models;

public partial class Form
{
    public int FormId { get; set; }

    public string? Cne { get; set; }

    public string? Commune { get; set; }

    public string? Block { get; set; }

    public string? Property { get; set; }

    public int? Pages { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? RegistrationNumber { get; set; }

    public virtual ICollection<FormAcquirer> FormAcquirers { get; } = new List<FormAcquirer>();

    public virtual ICollection<FormDispossessor> FormDispossessors { get; } = new List<FormDispossessor>();
}
