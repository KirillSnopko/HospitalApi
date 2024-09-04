using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum Gender
{
    [Display(Name = "Not Set")]
    NotSet = 1,

    [Display(Name = "Male")]
    Male = 2,

    [Display(Name = "Female")]
    Female = 3
}
