using System;
using System.Collections.Generic;

namespace Proyecto_Verificable.Models;

public partial class FormAcquirer
{
    public int FormAcquirerId { get; set; }

    public int? FormId { get; set; }

    public string? AcquirerRunRut { get; set; }

    public decimal? AcquirerEntitlement { get; set; }

    public decimal? AcquirerPercentNotCredited { get; set; }

    public virtual Form? Form { get; set; }
}
