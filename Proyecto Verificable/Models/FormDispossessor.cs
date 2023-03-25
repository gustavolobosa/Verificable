using System;
using System.Collections.Generic;

namespace Proyecto_Verificable.Models;

public partial class FormDispossessor
{
    public int FormDispossessorId { get; set; }

    public int? FormId { get; set; }

    public string? DispossessorRunRut { get; set; }

    public decimal? DispossessorEntitlement { get; set; }

    public decimal? DispossessorPercentNotCredited { get; set; }

    public virtual Form? Form { get; set; }
}
