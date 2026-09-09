/*
 * MODEL: A plain C# class that represents the data structure of a Student.
 * Models carry data between the Controller and the View.
 *
 * DATA ANNOTATIONS (System.ComponentModel.DataAnnotations):
 *   Attributes placed on model properties that define validation rules.
 *   ASP.NET MVC checks these automatically before the action body runs.
 *   ModelState.IsValid is false if any rule is violated.
 *
 *   [Required]       - Field must not be null or empty.
 *   [StringLength]   - Text length must be within the specified min/max.
 *   [Range]          - Numeric value must fall between the two bounds.
 *   ErrorMessage     - Custom text shown in the view when validation fails.
 */

using System.ComponentModel.DataAnnotations;

namespace RenderingHTML.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be 2-50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; }

        [Range(16, 60, ErrorMessage = "Age must be between 16 and 60")]
        public int Age { get; set; }
    }
}
