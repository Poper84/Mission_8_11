using System;
using System.Collections.Generic;

namespace Mission_8_11.Models;

// Another model made by scaffold
public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Stat> Stats { get; set; } = new List<Stat>();
}
