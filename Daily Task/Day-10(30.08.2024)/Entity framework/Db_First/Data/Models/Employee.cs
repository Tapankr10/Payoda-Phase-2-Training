﻿using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Position { get; set; }

    public DateOnly? HireDate { get; set; }

    public virtual ICollection<Recipient> Recipients { get; set; } = new List<Recipient>();
}
