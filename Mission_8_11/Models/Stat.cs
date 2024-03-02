using System;
using System.Collections.Generic;

namespace Mission_8_11.Models;

// This is the model build by scaffold command
// Changes were made to make it use data annotations but for some reason it keeps reverting back
// to this even if I save it. Strange... But it works so we will take it!
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
