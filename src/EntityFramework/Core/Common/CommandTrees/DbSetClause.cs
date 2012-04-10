using System;
using System.Collections.Generic;

using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Common.CommandTrees.Internal;
using System.Data.Entity.Core.Common.Utils;
using System.Diagnostics;

namespace System.Data.Entity.Core.Common.CommandTrees
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Specifies a clause in a modification operation setting the value of a property.
    /// </summary>
    public sealed class DbSetClause : DbModificationClause
    {
        private DbExpression _prop;
        private DbExpression _val;

        internal DbSetClause(DbExpression targetProperty, DbExpression sourceValue)
            : base()
        {
            EntityUtil.CheckArgumentNull(targetProperty, "targetProperty");
            EntityUtil.CheckArgumentNull(sourceValue, "sourceValue");
            _prop = targetProperty;
            _val = sourceValue;
        }

        /// <summary>
        /// Gets an <see cref="DbExpression"/> that specifies the property that should be updated.
        /// </summary>
        /// <remarks>
        /// Constrained to be a <see cref="DbPropertyExpression"/>.
        /// </remarks>
        public DbExpression Property
        {
            get
            {
                return _prop;
            }
        }
        
        /// <summary>
        /// Gets an <see cref="DbExpression"/> that specifies the new value with which to update the property.
        /// </summary>
        /// <remarks>
        /// Constrained to be a <see cref="DbConstantExpression"/> or <see cref="DbNullExpression"/>
        /// </remarks>
        public DbExpression Value
        { 
            get
            {
                return _val;
            }
        }
                
        internal override void DumpStructure(ExpressionDumper dumper)
        {
            dumper.Begin("DbSetClause");
            if (null != this.Property)
            {
                dumper.Dump(this.Property, "Property");
            }
            if (null != this.Value)
            {
                dumper.Dump(this.Value, "Value");
            }
            dumper.End("DbSetClause");
        }

        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "DbSetClause"), SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Data.Entity.Core.Common.Utils.TreeNode.#ctor(System.String,System.Data.Entity.Core.Common.Utils.TreeNode[])")]
        internal override TreeNode Print(DbExpressionVisitor<TreeNode> visitor)
        {
            TreeNode node = new TreeNode("DbSetClause");
            if (null != this.Property)
            {
                node.Children.Add(new TreeNode("Property", this.Property.Accept(visitor)));
            }
            if (null != this.Value)
            {
                node.Children.Add(new TreeNode("Value", this.Value.Accept(visitor)));
            }
            return node;
        }
    }
}