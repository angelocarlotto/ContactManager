using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ContactList.Data;

public class Contact
{
    public int ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime DateAdded { get; set; }
    [ValidateNever]
    public Category Category { get; set; }
    public int CategoryId { get; set; }

}
