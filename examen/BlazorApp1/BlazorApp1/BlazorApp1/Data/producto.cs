using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [SupplyParameterFromForm]
    [Required(ErrorMessage = "El número de inventario no debe estar vacío")]
    [Range(1, int.MaxValue, ErrorMessage = "El número de inventario debe ser positivo")]
    public int Id { get; set; }

    [Required(ErrorMessage = "El Nombre no debe estar vacío")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 200 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Elige el tipo de producto")]
    public string Department { get; set; }

    public Product()
    {
        Id = 0;
        Name = "";
        Department = "";
    }

    public Product(int id, string name, string department)
    {
        Id = id;
        Name = name;
        Department = department;
    }

    public bool Equals(Product other)
    {
        if (other == null)
            return false;

        return Id == other.Id && Name == other.Name && Department == other.Department;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return Equals(obj as Product);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() ^ Name.GetHashCode() ^ Department.GetHashCode();
    }
}
