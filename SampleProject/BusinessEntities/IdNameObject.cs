using System;

namespace BusinessEntities
{
    public class IdNameObject : IdObject
    {
        private string _name;

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public IdNameObject(Guid id, string name) : base()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            Name = name;
        }
    }
}