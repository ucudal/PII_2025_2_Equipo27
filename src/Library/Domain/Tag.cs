using System;

namespace Library
{
    public class Tag
    {
        private string tagName;
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

        public Tag(string tagname)
        {
            this.TagName = tagname;
        }
    }
}