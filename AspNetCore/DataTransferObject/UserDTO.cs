using System.Runtime.Serialization;

namespace AspNetCore.DataTransferObject
{
    [DataContract]
    public class UserDTO
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string FirstName { get; set; }
        [DataMember] public string LastName { get; set; }
    }
}
