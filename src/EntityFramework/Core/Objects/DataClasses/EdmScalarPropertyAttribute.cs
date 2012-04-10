namespace System.Data.Entity.Core.Objects.DataClasses
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Attribute for scalar properties in an IEntity.    
    /// Implied default AttributeUsage properties Inherited=True, AllowMultiple=False,
    /// The metadata system expects this and will only look at the first of each of these attributes, even if there are more.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class EdmScalarPropertyAttribute : EdmPropertyAttribute
    {
        // Private variables corresponding to their properties.
        private bool _isNullable         = true;
        private bool _entityKeyProperty;

        /// <summary>
        /// Attribute for scalar properties. 
        /// EdmScalarPropertyAttribute(EntityKeyProperty=[true|false], IsNullable=[true|false])
        /// IsNullable and EntityKeyProperty cannot both be true.
        /// </summary>
        public EdmScalarPropertyAttribute()
        {
        }

        /// <summary>
        /// The property is allowed to have a value of NULL.
        /// </summary>
        public bool   IsNullable
        {
            get { return _isNullable; }
            set { _isNullable = value;}
        }

        /// <summary>
        /// The property is a key.
        /// </summary>
        public bool   EntityKeyProperty
        {
            get { return _entityKeyProperty; }
            set { _entityKeyProperty = value; }
        }

    }
}
