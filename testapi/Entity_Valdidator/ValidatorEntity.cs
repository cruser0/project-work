using System.Collections.Generic;

namespace Entity_Validator
{
    public class ValidatorEntity
    {
        public Dictionary<string,bool> Tests { get; set; }
        public bool Valid { get; set; }
    }
}
