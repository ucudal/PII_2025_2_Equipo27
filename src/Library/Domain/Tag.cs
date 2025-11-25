using System;

namespace Library
{
    public class Tag
    {
        private string tagName;
        public int Id { get; set; }
        public string TagName
        {
            get
            {
                return this.tagName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("La etiqueta debe tener un nombre", nameof(value));
                }

                tagName = value;
            }
        }

        public Tag(int id,string tagname)
        {
            string name = tagname.ToLower().Trim();
            this.Id = id;
            this.TagName = name;
        }
    }
}