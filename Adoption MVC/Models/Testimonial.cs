using System;
using System.Collections.Generic;

namespace Adoption_MVC.Models;

public partial class Testimonial
{
    public string? Owner { get; set; }

    public string PetName { get; set; } = null!;

    public string? Breed { get; set; }

    public string? Description { get; set; }

    public int Id { get; set; }

    public DateTime? DateTimeColumn { get; set; }
}
