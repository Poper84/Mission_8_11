using System;
using System.Collections.Generic;

namespace Mission_8_11.Models;

// This is the model build by scaffold command
public partial class Stat
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public DateTime? DueDate { get; set; }

    public string Quadrant { get; set; } = null!;

    public int? CategoryId { get; set; }

    public bool? Completed { get; set; }

    public virtual Category? Category { get; set; }
}
