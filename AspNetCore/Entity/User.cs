using System;


namespace AspNetCore.Entity
{
    [Serializable]
    public class User : BaseResponseType
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
