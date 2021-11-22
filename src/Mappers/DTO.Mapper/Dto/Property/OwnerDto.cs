
using Weelo.Dto.Common;

namespace Weelo.Dto.Property
{
    public class OwnerDto
    {
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
        public FileDto File { get; set; }
    }
}
